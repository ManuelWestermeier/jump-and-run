using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class JumpAndRunController : MonoBehaviour
{
	public float speed;
	public float ospeed = 1;
	private float collisionTime;
	public Rigidbody2D rb;
	public float jump;
	public bool isGrounded = false;
	public bool isInCave = true;
	public Animator anim;
	public Vector3 rotation;
	public buttonController b;
	public GameObject Fallschirm;
	public ParticleSystem _jumpParticles;

	private void Start() {
		transform.eulerAngles = rotation;
		float richtung = 0;
		float hochrunter = 0;
		StartCoroutine(Grounder());
		PlayerPrefs.SetFloat("Lives", 3);
	}

	void FixedUpdate()
	{
		speed = speed * 0.8f;
		float richtung = b.Horizontal;
		float hochrunter = b.Vertical;
		//float richtung = Input.GetAxis("Horizontal");
		//float hochrunter = Input.GetAxis("Vertical");

		if (isInCave) {
			if (richtung != 0) {
				anim.SetBool("isRunning", true);
			}
			else {
				anim.SetBool("isRunning", false);
			}

			if (hochrunter > 0 && isGrounded) {
				anim.SetBool("isJumping", true);
			}
			else {
				anim.SetBool("isJumping", false);
			}

			if (hochrunter < 0) {
				speed = 12;
				isGrounded = true;
				//rb.AddForce(Vector2.up * -0.1f* jump);
				GetComponent < Rigidbody2D > ().gravityScale = 0.2f;
			}
			else {
				speed = 8;
				GetComponent < Rigidbody2D > ().gravityScale = 1;
			}

			if (hochrunter < 0) {
				Fallschirm.SetActive(true);
			}
			else {
				Fallschirm.SetActive(false);
			}

			if (hochrunter > 0 && isGrounded) {
				rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
				isGrounded = false;
				_jumpParticles.Play();
			}

			if (b.Slide == 1 && ospeed < 3) {
				ospeed += Time.deltaTime;
				GetComponent < Rigidbody2D > ().gravityScale = 10;
			}

			if (b.Slide == 0 && hochrunter == 0) {
				ospeed = 1;
				GetComponent < Rigidbody2D > ().gravityScale = 1f;
			}

			if (richtung > 0) {
				transform.eulerAngles = rotation + new Vector3(0, 180, 0);
				transform.Translate(Vector2.right * speed * ospeed * richtung * Time.deltaTime);
			}

			if (richtung < 0) {
				transform.eulerAngles = rotation;
				transform.Translate(Vector2.right * ospeed * -speed * richtung * Time.deltaTime);
			}
		}




		if (!isInCave) {

			if (richtung != 0) {
				anim.SetBool("isRunning", true);
			}
			else {
				anim.SetBool("isRunning", false);
			}

			if (hochrunter > 0 && isGrounded) {
				anim.SetBool("isJumping", true);
			}
			else {
				anim.SetBool("isJumping", false);
			}

			if (hochrunter < 0) {
				speed = 12;
				//isGrounded = true;
				//rb.AddForce(Vector2.up * -0.1f* jump);
				GetComponent < Rigidbody2D > ().gravityScale = 0.2f;
			}
			else {
				speed = 8;
				GetComponent < Rigidbody2D > ().gravityScale = 1;
			}

			if (hochrunter < 0) {
				Fallschirm.SetActive(true);
			}
			else {
				Fallschirm.SetActive(false);
			}

			if (hochrunter > 0 && isGrounded) {
				rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
				isGrounded = false;
				_jumpParticles.Play();
			}

			if (b.Slide == 1 && ospeed < 3) {
				ospeed += Time.deltaTime;
				GetComponent < Rigidbody2D > ().gravityScale = 10;
			}

			if (b.Slide == 0 && hochrunter == 0) {
				ospeed = 1;
				GetComponent < Rigidbody2D > ().gravityScale = 1f;
			}

			if (richtung > 0) {
				transform.eulerAngles = rotation + new Vector3(0, 180, 0);
				transform.Translate(Vector2.right * speed * ospeed * richtung * Time.deltaTime);
			}

			if (richtung < 0) {
				transform.eulerAngles = rotation;
				transform.Translate(Vector2.right * ospeed * -speed * richtung * Time.deltaTime);
			}
		}

	}
	
	private void OnCollisionEnter2D(Collision2D collision) {
		collisionTime = 0;
		if (collision.gameObject.tag == "Ground") {
			isGrounded = true;
			anim.SetBool("isJumping", false);
		}

		if (collision.gameObject.tag == "Gegner") {
			float Lives = PlayerPrefs.GetFloat("Lives");
			Lives -= 1;
			PlayerPrefs.SetFloat("Lives", Lives);
		}
		
		if (collision.gameObject.tag == "FirstKillGegner") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
		}
	}
	
	private void OnCollisionStay2D(Collision2D collision) {
		if (isInCave) {
			if (collision.gameObject.tag == "Ground" && collisionTime < 1.5f) {
				isGrounded = true;
				collisionTime += Time.deltaTime;
			}
		}
		if (!isInCave) {
			if (collision.gameObject.tag == "Ground" && collisionTime < 0.1f && !isGrounded) {
				isGrounded = true;
				collisionTime += Time.deltaTime;
			}
		}
	}
	/*
	private void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.tag == "Ground")
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
	}
	*/
	
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ground") {
			isGrounded = true;
		}

		if (other.tag == "Coin") {
			float coins = PlayerPrefs.GetFloat("Coins");
			coins += 1 * PlayerPrefs.GetFloat("CoinMultiplicator");
			PlayerPrefs.SetFloat("Coins", coins);
			isGrounded = true;
		}
	}
	public void canJump()
	{
		isGrounded = true;
	}
	
	IEnumerator Grounder()
	{
		yield return new WaitForSeconds(8);
		isGrounded = true;
		StartCoroutine(Grounder1());
	}
	IEnumerator Grounder1()
	{
		yield return new WaitForSeconds(8);
		isGrounded = true;
		StartCoroutine(Grounder());
	}
}
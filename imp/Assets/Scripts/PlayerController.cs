using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Rigidbody2D rb;
	public float jump;
	public bool isGrounded = false;
	public Animator anim;
	public Vector3 rotation;
	public buttonController b;
	
	private void Start() {
		transform.eulerAngles = rotation;
		float richtung = b.Horizontal;
		float hochrunter = b.Vertical;
	}
	
	void FixedUpdate()
	{
		float richtung = b.Horizontal;
		float hochrunter = b.Vertical;
		//float richtung = Input.GetAxis("Horizontal");
		//float hochrunter = Input.GetAxis("Vertical");
		
		if (richtung > 0)
		{
			transform.eulerAngles = rotation + new Vector3(0,180,0);
			transform.Translate(Vector2.right * 0 * speed * richtung * Time.deltaTime);
		}
		
		if (richtung < 0)
		{
			transform.eulerAngles = rotation;
			transform.Translate(Vector2.right * 0 *-speed * richtung * Time.deltaTime);
		}

		
		if (richtung != 0)
		{
			anim.SetBool("isRunning", true);
		}
		else
		{
			anim.SetBool("isRunning", false);
		}
		
		if (hochrunter > 0 && isGrounded)
		{
			rb.AddForce(Vector2.up * 0, ForceMode2D.Impulse);
			anim.SetBool("isJumping", true);
			isGrounded = false;
		}
		else
		{
			anim.SetBool("isJumping", false);
		}
	}
	
	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Ground")
		{
			isGrounded = true;
			anim.SetBool("isJumping", false);
			//FindObjectOfType<AudioManager>().Play("Coin");
		}
		
		if (collision.gameObject.tag == "Gegner")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Gegner")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
		}
	}
	public void canJump() 
	{
		isGrounded = true;
	}
}
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gegner : MonoBehaviour
{
	public float speed = 3f;
	public float TimeToChang;
	private Vector3 rotation;
	
	void Start()
	{
		rotation = transform.eulerAngles;
		StartCoroutine(changer());
	}

	void FixedUpdate()
	{
		transform.Translate(Vector2.left * speed * Time.deltaTime);
	}
	IEnumerator changer()
	{
		yield return new WaitForSeconds(TimeToChang);
		transform.eulerAngles = rotation + new Vector3(0,180,0);
		StartCoroutine(changers());
	}
	
	IEnumerator changers()
	{
		yield return new WaitForSeconds(TimeToChang);
		transform.eulerAngles = rotation;
		StartCoroutine(changer());
	}
	
	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy(gameObject);
		}
	}
}

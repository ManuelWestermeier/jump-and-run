using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
	public GameObject go;
	private void OnCollisionEnter2D(Collision2D other) {
		Destroy(go);
	}
}

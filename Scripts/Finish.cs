using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
	public string level;
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player")
		{
			PlayerPrefs.SetFloat(level, 1);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
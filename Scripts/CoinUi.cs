using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinUi : MonoBehaviour
{
	public Text CoinText;
	public float Lives = 3;
	public Text LiveText;
	void Update()
	{
		CoinText.text = "Coins: " + PlayerPrefs.GetFloat("Coins");
		Lives = PlayerPrefs.GetFloat("Lives");
		LiveText.text = "" + Lives;
		PlayerPrefs.GetFloat("Lives");
		if (Lives < 1)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
		}
	}
}
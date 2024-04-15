using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenueScript : MonoBehaviour
{
	public GameObject[] Buttons;
	public SceneMannager SM;
	void Start()
	{
		Buttons[0].SetActive(true);
		SM.Page1();
		if (PlayerPrefs.GetFloat("Level7_CanPlay") == 1)
		{
			Buttons[1].SetActive(true);
			SM.Page2();
		}
		if (PlayerPrefs.GetFloat("Level13_CanPlay") == 1)
		{
			Buttons[2].SetActive(true);
			SM.Page3();
		}
		if (PlayerPrefs.GetFloat("Level19_CanPlay") == 1)
		{
			Buttons[3].SetActive(true);
			SM.Page4();
		}
		if (PlayerPrefs.GetFloat("Level25_CanPlay") == 1)
		{
			Buttons[4].SetActive(true);
			SM.Page5();
		}
		if (PlayerPrefs.GetFloat("Level31_CanPlay") == 1)
		{
			Buttons[5].SetActive(true);
			SM.Page6();
		}
		if (PlayerPrefs.GetFloat("Level37_CanPlay") == 1)
		{
			Buttons[6].SetActive(true);
			SM.Page7();
		}
	}
}

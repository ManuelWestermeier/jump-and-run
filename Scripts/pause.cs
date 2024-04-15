using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
	public GameObject PausenMenü;
	
	public void zurpause() 
	{
		PausenMenü.SetActive(true);
		Time.timeScale = 0;
	}
	
	public void weiter() 
	{
		PausenMenü.SetActive(false);
		Time.timeScale = 1;
	}
	
	public void restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
		Time.timeScale = 1;
	}
	
	public void hauptmenue()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
		Time.timeScale = 1;
	}
}

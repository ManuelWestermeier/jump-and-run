using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMannager : MonoBehaviour
{
	public GameObject[] Page;
	public GameObject ShopPanel;
	
	private void Start() {
		if (PlayerPrefs.GetFloat("CoinMultiplicator") > 1)
		{
			PlayerPrefs.SetFloat("CoinMultiplicator" ,1);
		}
		PlayerPrefs.SetFloat("CoinMultiplicator" ,1);
		/*
		{
			Page1();
		}
		if (PlayerPrefs.GetFloat("PagePosition") == 2)
		{
			Page2();
		}
		if (PlayerPrefs.GetFloat("PagePosition") == 3)
		{
			Page3();
		}
		if (PlayerPrefs.GetFloat("PagePosition") == 4)
		{
			Page4();
		}
		if (PlayerPrefs.GetFloat("PagePosition") == 5)
		{
			Page5();
		}
		if (PlayerPrefs.GetFloat("PagePosition") == 6)
		{
			Page6();
		}
		if (PlayerPrefs.GetFloat("PagePosition") == 7)
		{
			Page7();
		}
		*/
	}
	
	public void ToShop() 
	{
		ShopPanel.SetActive(true);
	}
	
	public void BuyMultiplicator() 
	{
		if (PlayerPrefs.GetFloat("Coins") > 499)
		{
			float coins = PlayerPrefs.GetFloat("Coins");
			PlayerPrefs.SetFloat("CoinMultiplicator", 2);
			float newcoins = coins - 500;
			PlayerPrefs.SetFloat("Coins", newcoins);
		}
	}

	public void ExitShop() 
	{
		ShopPanel.SetActive(false);
	}
	
	public void Page1() 
	{
		Page[0].SetActive(true);
		Page[1].SetActive(false);
		Page[2].SetActive(false);
		Page[3].SetActive(false);
		Page[4].SetActive(false);
		Page[5].SetActive(false);
		Page[6].SetActive(false);
		PlayerPrefs.SetFloat("PagePosition",1);
	}

	public void Page2() 
	{
		Page[0].SetActive(false);
		Page[1].SetActive(true);
		Page[2].SetActive(false);
		Page[3].SetActive(false);
		Page[4].SetActive(false);
		Page[5].SetActive(false);
		Page[6].SetActive(false);
		PlayerPrefs.SetFloat("PagePosition",2);
	}

	public void Page3() 
	{
		Page[0].SetActive(false);
		Page[1].SetActive(false);
		Page[2].SetActive(true);
		Page[3].SetActive(false);
		Page[4].SetActive(false);
		Page[5].SetActive(false);
		Page[6].SetActive(false);
		PlayerPrefs.SetFloat("PagePosition",3);
	}
	
	public void Page4() 
	{
		Page[0].SetActive(false);
		Page[1].SetActive(false);
		Page[2].SetActive(false);
		Page[3].SetActive(true);
		Page[4].SetActive(false);
		Page[5].SetActive(false);
		Page[6].SetActive(false);
		PlayerPrefs.SetFloat("PagePosition",4);
	}
	
	public void Page5() 
	{
		Page[0].SetActive(false);
		Page[1].SetActive(false);
		Page[2].SetActive(false);
		Page[3].SetActive(false);
		Page[4].SetActive(true);
		Page[5].SetActive(false);
		Page[6].SetActive(false);
		PlayerPrefs.SetFloat("PagePosition",5);
	}

	public void Page6() 
	{
		Page[0].SetActive(false);
		Page[1].SetActive(false);
		Page[2].SetActive(false);
		Page[3].SetActive(false);
		Page[4].SetActive(false);
		Page[5].SetActive(true);
		Page[6].SetActive(false);
		PlayerPrefs.SetFloat("PagePosition",6);
	}

	public void Page7() 
	{
		Page[0].SetActive(false);
		Page[1].SetActive(false);
		Page[2].SetActive(false);
		Page[3].SetActive(false);
		Page[4].SetActive(false);
		Page[5].SetActive(false);
		Page[6].SetActive(true);
		PlayerPrefs.SetFloat("PagePosition",7);
	}
	
	public void ToMenue()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
	}

	public void LevelUp()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LevelDown()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}	
	public void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	//Levels
}

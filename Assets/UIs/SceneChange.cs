using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
	public AudioSource menu;
	public AudioSource click;
	public AudioSource click1;
	public AudioSource click2;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("LevelPassed",0);
		menu.Play ();
	}

	// Update is called once per frame

	public void play()
	{
		click.Play ();
		if (CustomPlayerPrefs.LevelPotence() > 1) {
			SceneManager.LoadScene (CustomPlayerPrefs.LevelPotence() + 1);
		} else {
			SceneManager.LoadScene (5);
		}
		//done
	}
	public void Store()
	{
		click1.Play();
		SceneManager.LoadScene (1);
	}

	public void Settings()
	{
		click1.Play();
		SceneManager.LoadScene (7);
	}

	public void Level()
	{
		click2.Play();
		SceneManager.LoadScene (2);
	}

	public void Quit()
	{
		
		Application.Quit ();
	}
	public void returntoHome()
	{
		SceneManager.LoadScene (0);
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadsceneController : MonoBehaviour {

	public Text moneyText;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = ((int)PlayerPrefs.GetFloat ("HighScore")).ToString();

	}

	public void Play()
	{
		PlayerPrefs.SetFloat ("HighScore", ((int)PlayerPrefs.GetFloat ("HighScore")) - 2);
		//	click.Play ();
		SceneManager.LoadScene ("ProblemFOUND");
	}

	public void QuitToMenu()
	{
		//	click.Play ();
		SceneManager.LoadScene ("MainMenu");
	}
}

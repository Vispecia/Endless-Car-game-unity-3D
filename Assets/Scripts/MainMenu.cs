using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour {

	//public Text highScoreText,sshighScoreText;

	public GameObject canvas,cancelButton,yesButton,nextUpdateImage,nextUpdateChallengeImage;

	public Text moneyText;
	public Text chestTimerText;


	//public AudioSource click;
	// Use this for initialization
	void Start () 
	{
		canvas.SetActive (false);
		cancelButton.SetActive (false);
		yesButton.SetActive (false);

		moneyText.text =((int)PlayerPrefs.GetFloat ("HighScore")).ToString();


			}
	
	void Update()
	{
		moneyText.text =((int)PlayerPrefs.GetFloat ("HighScore")).ToString();
	}


	public void Play()
	{
	//	click.Play ();

		PlayerPrefs.SetFloat ("HighScore", ((int)PlayerPrefs.GetFloat ("HighScore")) - 2);

		SceneManager.LoadScene ("ProblemFOUND");
	}

	public void Quit()
	{
		canvas.SetActive (true);
		cancelButton.SetActive (true);
		yesButton.SetActive (true);
		chestTimerText.enabled = false;

		//	click.Play ();
		//Application.Quit();

	}

	public void Cancell(Button btn)
	{
		if (btn.name.Equals ("cancel")) {
			SceneManager.LoadScene ("MainMenu");
		}
	}

	public void Yess(Button btn)
	{
		if (btn.name.Equals ("yes")) {
			Application.Quit ();
		}
	}

	public void CloseNextUpdateImage()
	{
		nextUpdateImage.SetActive (false);
	}

	public void OnVehicleButton()
	{
		nextUpdateImage.SetActive (true);
	}

	public void CloseNextUpdateChallengeImage()
	{
		nextUpdateChallengeImage.SetActive (false);
	}


	public void OnChallangesButton()
	{
		nextUpdateChallengeImage.SetActive (true);
	}


}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Chest : MonoBehaviour {

	public float msToWait = 5000.0f;

	private Text chestTimer;
	private Button chestButton;
	private ulong lastChestOpen;

	public GameObject g1, g2, g3, g4;

	// Use this for initialization
	void Start () {

		chestButton = GetComponent<Button> ();
		lastChestOpen = ulong.Parse (PlayerPrefs.GetString ("LastChestOpen"));
		chestTimer = GetComponentInChildren<Text> ();

		if (!IsChestReady ()) {

			g1.SetActive (false);
			g2.SetActive (false);
			g3.SetActive (false);
			g4.SetActive (false);
			chestButton.interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (!chestButton.IsInteractable ()) {

			if (IsChestReady ()) {
				g1.SetActive (true);
				g2.SetActive (true);
				g3.SetActive (true);
				g4.SetActive (true);
				chestButton.interactable = true;
				return;
			}
			if (!IsChestReady ()) {

				g1.SetActive (false);
				g2.SetActive (false);
				g3.SetActive (false);
				g4.SetActive (false);
				chestButton.interactable = false;
			}

			//set Timer
			ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
			ulong m = diff / TimeSpan.TicksPerMillisecond;
			float secondsLeft = (float)(msToWait - m) / 1000.0f;

			string r = "";
			//hours
			r+=((int)secondsLeft/3600).ToString() + "h ";
			secondsLeft -= ((int)secondsLeft / 3600) * 3600;
			//minutes
			r+= ((int)secondsLeft/60).ToString("00") + "m ";
			//seconds
			r+= (secondsLeft % 60).ToString("00") + "s";
			chestTimer.text = r;



		}

	}

	private bool IsChestReady()
	{
		ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
		ulong m = diff / TimeSpan.TicksPerMillisecond;

		float secondsLeft = (float)(msToWait - m) / 1000.0f;

		if (secondsLeft < 0) {
			chestTimer.text = "COLLECT!";
			return true;
		}
		else
			return false;
		
	}

	public void Chestclick()
	{
		PlayerPrefs.SetFloat ("HighScore", ((int)PlayerPrefs.GetFloat ("HighScore")) + 10);
		lastChestOpen = (ulong)DateTime.Now.Ticks; 
		PlayerPrefs.SetString ("LastChestOpen", lastChestOpen.ToString ());
		chestButton.interactable = false;

	}

}

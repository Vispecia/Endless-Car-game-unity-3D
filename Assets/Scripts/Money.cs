using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour {

	public Text moneyText;
	public int amount = 0;
	private int cashvalue = 1;



	// Use this for initialization
	void Start () {
		amount = 0;
	}

	// Update is called once per frame
	void Update () {
		moneyText.text = amount.ToString();

		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Money") {
			amount += cashvalue;
			moneyText.text = amount.ToString();
			other.gameObject.SetActive (false);
		}

	}
}

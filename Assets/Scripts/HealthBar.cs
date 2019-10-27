using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {



	public Image currentHealth;
	public Image currentEnergy;
	//public Text ratioText;

	public float hitpoint = 150;
	public float energy = 150;

	private float maxhitpoint = 150;
	private float maxEnergy = 150;

	public bool dead;

	//private PlayerMovement pm;

	private GameObject gbar;
	// Use this for initialization
	void Start () {
		//	pm = GetComponent<PlayerMovement> ();
	
		dead = false;
		UpdateHealthBar ();
		UpdateEnergyBar ();
		gbar = GameObject.FindGameObjectWithTag("HealthBar");
	}
	
	// Update is called once per frame
	void Update()
	{
		
		TakeDamage (2f * Time.deltaTime);
		//UpdateEnergyBar ();

		///*if (hitpoint <= 0 || energy<=0/*|| pm.dead*/ ) {
			//hitpoint = 0;
		//	dead=true;
		//	SceneManager.LoadScene ("DeadScene");
			//		pm.playerDead = true;
		//	currentHealth.enabled = false;
			//		ratioText.enabled = false;
		//	gbar.SetActive (false);
		//	return;
			//Debug.Log ("gfcgcnnnc");
		//}


	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Gas") {
			//Debug.Log ("Increase speed");
			//IncreaseSpeed (20.0f);
			//eatBasketSound.Play();
			//GetComponent<HealthBar> ().hitpoint = 150f;
			hitpoint = 150f;
			other.gameObject.SetActive (false);
		}

		if (other.tag == "Spikes") {
			//Debug.Log ("Increase speed");
			//IncreaseSpeed (20.0f);
			//eatBasketSound.Play();
			//GetComponent<HealthBar> ().hitpoint = 150f;
			TakeEnergy (3f);
		}
		/*if (other.tag == "Damage") {
			//deathmenu.ToggleEndMenu (GetComponent<Timer>().timer);
			//dead = true;
			//deadSound.Play ();

			//hitpoint = 15f;
			TakeEnergy(15f);
		
		}

		if (other.tag == "Spikes") {
		
			//hitpoint = 35f;
			TakeEnergy(35f);
		}*/

	}

	private void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.CompareTag("Damage"))
		{
			TakeEnergy (7f);
		}
		if(col.gameObject.CompareTag("Spikes"))
		{
			TakeEnergy (35f);
		}


	}



	 void UpdateHealthBar () {
		
		float ratio = hitpoint / maxhitpoint;
		currentHealth.rectTransform.localScale = new Vector3 (ratio,1,1);
	//	ratioText.text = (ratio*100).ToString("0") + "%";
	}


	void TakeDamage(float damage)
	{
		hitpoint -= damage;

		if (hitpoint <= 0) {

			//	if ((int)PlayerPrefs.GetFloat ("HighScore") < (int)GetComponent<Money>().amount) {
			PlayerPrefs.SetFloat ("HighScore", GetComponent<Money>().amount + PlayerPrefs.GetFloat ("HighScore"));
			SceneManager.LoadScene ("DeadScene");
				
		//	}
		}

		UpdateHealthBar ();
	}

	public void HealDamage(float heal)
	{
		//Debug.Log ("Inside heal");
		hitpoint += heal;
		//Debug.Log (hitpoint);
		if (hitpoint > maxhitpoint)
			hitpoint = maxhitpoint;

		UpdateHealthBar ();
	}


	void TakeEnergy(float damage)
	{
		energy -= damage;
		if(energy>=0)
		UpdateEnergyBar ();

		if (energy <= 0) {
			
		//	if ((int)PlayerPrefs.GetFloat ("HighScore") < (int)GetComponent<Money>().amount) {
				PlayerPrefs.SetFloat ("HighScore", GetComponent<Money>().amount + PlayerPrefs.GetFloat ("HighScore"));
			   SceneManager.LoadScene ("DeadScene");
				
			//}
		}
		
	}

	public void UpdateEnergyBar ()
	{
		float ratio = energy / maxEnergy;
		currentEnergy.rectTransform.localScale = new Vector3 (ratio,1,1);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlatform1 : MonoBehaviour 
{

	public GameObject[] prefabs;


	public Transform playerTransform;
	private float spawnz = 0.0f;
	private float tileLength = 350.0f;
	private float safeZone =10;

	private int amnTilesOnScreen = 5;

	private List<GameObject> activeTiles;

	private int lastPrefabIndex =0;

	// Use this for initialization
	private void Start () {
		activeTiles = new List<GameObject> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		for (int i = 0; i < amnTilesOnScreen; i++) {

			if(i<2)
			    SpawnTile (0);
			else
				SpawnTile ();

		}
	}
	
	// Update is called once per frame
	private void Update () {
		//print (spawnz);
		//print (playerTransform.position.z);
		if (playerTransform.position.z  > (spawnz -  tileLength)) {
		
			SpawnTile ();
			DeleteTile ();
		}

	}
	private void SpawnTile(int prefabIndex = -1)
	{
		GameObject go;
		if(prefabIndex == -1)
					go = Instantiate (prefabs [RandomPrefabIndex()]) as GameObject;
		else
			go = Instantiate (prefabs[prefabIndex]) as GameObject;
		go.transform.SetParent (transform);
		//go.transform.position = new Vector3(11.43f,0.0f,10.0f) * spawnz;
		go.transform.position = Vector3.forward * spawnz;
		spawnz += tileLength;
		activeTiles.Add (go);
	}

	private void DeleteTile()
	{
		Destroy (activeTiles[0]);
		activeTiles.RemoveAt (0);
	}
	private int RandomPrefabIndex()
	{
		if (prefabs.Length <= 1)
			return 0;
		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex) {
			randomIndex = Random.Range (0,prefabs.Length);
		}

		lastPrefabIndex = randomIndex;
		return randomIndex;
	}


}

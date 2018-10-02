using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	private float lastSpawnTime = 0.0f;
	private float nextSpawnTime = 0.0f;
	public GameObject toSpawn;

	// Use this for initialization
	void Start () {
		nextSpawnTime = Random.Range(2.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.realtimeSinceStartup >= lastSpawnTime + nextSpawnTime){
			lastSpawnTime = Time.realtimeSinceStartup;
			Instantiate(toSpawn,new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
		}
	}
}

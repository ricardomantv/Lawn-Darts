using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_Spawn_Tutorial : MonoBehaviour {


    public GameObject enemy;
    public Transform[] spawnPoints;
    public float spawnTime = 10f; // * 0.float depending on level

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Spawn() {
		int spawnPointIndex = Random.Range(0, spawnPoints.Length);
		Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}

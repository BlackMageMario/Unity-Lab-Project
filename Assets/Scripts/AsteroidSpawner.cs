using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
	public ObjectPool asteroidPool;
	private bool canAttemptSpawn;
	// Use this for initialization
	void Start () {
		canAttemptSpawn = true;
		Random.InitState((int)Time.time);
	}
	
	// Update is called once per frame
	void Update () {
		if (canAttemptSpawn)
		{
			//Debug.Log("Got here");
			bool canSpawn = Random.Range(1, 100) > 1 ? true : false;
			if(canSpawn)
			{
				//Debug.Log("Got here as well");
				asteroidPool.spawnObject();
				StartCoroutine(delaySpawn());
			}
			
		}
	}

	IEnumerator delaySpawn()
	{
		canAttemptSpawn = false;
		yield return new WaitForSeconds(0.2f);
		canAttemptSpawn = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {
	public float forceAmount;
	[Range(-400, -1)]public float minXPos, minZPos;
	[Range(1, 400)]public float maxXpos, maxZPos;
	private Camera mainCamera;
	
	private float initialAngle;
	private Vector3 parentPosition;
	void Start () {
		mainCamera = Camera.main;
		parentPosition = transform.parent.position;
		GameObject marsObject = GameObject.Find("mars1");
		initialAngle = Vector3.Angle(marsObject.transform.position, this.transform.position);
		transform.position = randPosition(); 
		transform.eulerAngles = new Vector3(0, 0, initialAngle);
		GetComponent<Rigidbody>().AddTorque(Vector3.up, ForceMode.Acceleration);
		GetComponent<Rigidbody>().AddForce(-Vector3.right * forceAmount);
	}
	void OnEnable()
	{
		transform.position = randPosition();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 screenPoint = mainCamera.WorldToViewportPoint(this.transform.position);//get the screenPoint
		if(screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.z < 0)
		{
			StartCoroutine(despawn());
		}
		else
		{
			//this will stop it if it gets back into line of sight.
			StopAllCoroutines();
		}
	}

	private Vector3 randPosition()
	{
		Vector3 randPosition = new Vector3(Random.Range(minXPos, maxXpos), 0, Random.Range(minZPos, maxXpos));
		return (parentPosition + randPosition);
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log("Trigger entered: " + col);
		this.transform.GetComponent<PooledObject>().pool.ReturnObject(this.gameObject);
	}

	IEnumerator despawn()
	{
		Debug.Log("Despawning....");
		yield return new WaitForSeconds(.5f);
		Debug.Log("Successful");
		this.transform.GetComponent<PooledObject>().pool.ReturnObject(this.gameObject);
	}
}

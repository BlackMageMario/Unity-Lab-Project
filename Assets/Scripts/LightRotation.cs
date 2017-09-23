using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour {

    public GameObject marsObject;
    public float rotationSpeed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(marsObject.transform.position, new Vector3(0, this.transform.position.y, 0), Time.deltaTime * rotationSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public GameObject marsObject;
	// Use this for initialization
	void Start () {
        marsObject.GetComponent<Rigidbody>().AddTorque(0, 20f, 0, ForceMode.Acceleration);
    }
}

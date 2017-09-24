using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mars : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody>().AddTorque(0, 20f, 0, ForceMode.Acceleration);
	}
}

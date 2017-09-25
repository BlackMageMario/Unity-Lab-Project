using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {
    public GameObject marsObject;
    public int rotationSpeed;
	public int rotateAroundSpeed;
	public bool rotateSpinRight;
	public bool rotateAroundMarsRight;
	private int rotateAroundDirection;
    // Use this for initialization
    void Start()
    {
		int rotationDirection = rotateSpinRight ? 1 : -1;
		rotateAroundDirection = rotateAroundMarsRight ? 1 : -1;
        this.GetComponent<Rigidbody>().AddTorque(rotationDirection * rotationSpeed, 0, 0, ForceMode.Acceleration);
    }
	// Update is called once per frame
	void Update () {
        transform.RotateAround(marsObject.transform.position, new Vector3(0, 1, 0), Time.deltaTime * rotateAroundDirection * rotateAroundSpeed);
	}
}

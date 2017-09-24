using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public GameObject marsObject;
	public float maxZoom;
    public float minZoom;
    public float speedOfZoom;
    public float speedOfRotation;
	public float scrollSpeed;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, 0, 100);
        transform.LookAt(marsObject.transform);
    }
	
	// Update is called once per frame
	void Update () {
        float zMovement = 0.0f;
        float xMovement = 0.0f;
        float yMovement = 0.0f;
        float distanceBetweenCameraAndMars = Vector3.Distance(this.transform.position, marsObject.transform.position);
        if (Input.anyKey)
        {
			float mouseScrollMovement = Input.GetAxis("Mouse ScrollWheel");
			if (Input.GetKey(KeyCode.UpArrow))
            {
                //close in zoom
               zMovement = speedOfZoom * Time.deltaTime;
               if (distanceBetweenCameraAndMars > minZoom )
               {
                   transform.position = Vector3.MoveTowards(transform.position, marsObject.transform.position, zMovement);
               }
               else
               {
                    transform.position = (this.transform.position - marsObject.transform.position).normalized * minZoom + marsObject.transform.position;
					//normalise the difference between the two positions, then multiply them by our bound (in this case the minZoom) and add it to the marsObject position
               }
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                zMovement = -speedOfZoom * Time.deltaTime;
                if (distanceBetweenCameraAndMars < maxZoom)
                {
                    transform.position = Vector3.MoveTowards(transform.position, marsObject.transform.position, zMovement);
                }
                else
                {
                    
                }
            }
			if(mouseScrollMovement > 0)
			{

				zMovement = speedOfZoom * scrollSpeed * mouseScrollMovement * Time.deltaTime;
				if (distanceBetweenCameraAndMars > minZoom)
				{
					transform.position = Vector3.MoveTowards(transform.position, marsObject.transform.position, zMovement);
				}
				else
				{
					transform.position = (this.transform.position - marsObject.transform.position).normalized * minZoom + marsObject.transform.position;
				}
			}
			if(mouseScrollMovement < 0)
			{
				zMovement = speedOfZoom * scrollSpeed * mouseScrollMovement * Time.deltaTime;
				if (distanceBetweenCameraAndMars < maxZoom)
				{
					transform.position = Vector3.MoveTowards(transform.position, marsObject.transform.position, zMovement);
				}
				else
				{
					transform.position = (this.transform.position - marsObject.transform.position).normalized * maxZoom + marsObject.transform.position;
				}
			}
            if (Input.GetKey(KeyCode.W))
            {
                yMovement = speedOfRotation * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                yMovement = -speedOfRotation * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                xMovement = -speedOfRotation * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                xMovement = speedOfRotation * Time.deltaTime;
            }
            transform.RotateAround(marsObject.transform.position, this.transform.up, xMovement);
            transform.RotateAround(marsObject.transform.position, this.transform.right, yMovement);
            Debug.Log(distanceBetweenCameraAndMars);
        }
	}
}

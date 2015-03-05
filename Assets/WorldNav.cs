﻿using UnityEngine;
using System.Collections;

public class WorldNav : MonoBehaviour {
 
	//Checks whether the button has been clicked.
	private bool flag = false;
	//Destination point
	private Vector3 endPoint;
	//Speed of the player; can be modified!
	public float duration = 50.0f;
	//Vertical position of the gameobject
	private float yAxis;
	
	void Start(){
		//save the y axis
		yAxis = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
		//check if the screen is right-clicked   
		if(Input.GetMouseButtonDown(1))
		{
			//declare a variable of RaycastHit struct
			RaycastHit hit;
			//Create a Ray on the clicked position
			Ray ray;

			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			//Check if the ray hits any collider
			if(Physics.Raycast(ray,out hit)) {
				//set a flag to indicate to move the gameobject
				flag = true;
				//save the clicked position
				endPoint = hit.point;
				//as we do not want to change the y axis value based on click position, reset it to original y axis value
				endPoint.y = yAxis;
				Debug.Log(endPoint);
			}
			
		}
		//check if the flag for movement is true and the current gameobject position is not same as the clicked position
		if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)){
			//move the gameobject to the desired position
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1/(duration*(Vector3.Distance(gameObject.transform.position, endPoint))));
			//Later change: make sure the object is not running through into terrain that's in the way.
		}
		//set the movement indicator flag to false if the endPoint and current gameobject position are equal
		else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) {
			flag = false;
			Debug.Log("I am here");
		}
		
	}
}
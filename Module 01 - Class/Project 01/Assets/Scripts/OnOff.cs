﻿using UnityEngine;
using System.Collections;

public class OnOff : MonoBehaviour {

	//Create the object whose material will be modified
	public GameObject myObject;

	//Create the boolean variable (true/false)
	//Through this boolean variable we can use a single button to give two different commands (in our case the On / Off)
	//Initialize the value to true.
	private bool On_Off = true;

	void Start (){
		}
	
	//This function allows you to perform two different tasks depending on the current Boolean variable.
	//This function is activated after clicking the object on which it was attached this script.
	void OnMouseDown(){

		//If the boolean variable is true (it is always true at the beginning), the object myObject (SpotLight) is activated 
		//and returns false to the boolean variable.
		//Note the myObject should be initially disabled.
		if (On_Off == true)
		
		{
		myObject.SetActive (true);

			On_Off = false;
			return;
	} 

		//If the boolean variable is false (for example after the first click), the object myObject (SpotLight) is deactivated 
		//and returns true to the boolean variable.
		if (On_Off == false)
			
		{
			myObject.SetActive (false);

			On_Off = true;
			return;
		} 
		return;
	} 

}

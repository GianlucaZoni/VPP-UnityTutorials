using UnityEngine;
using System.Collections;

public class Change_Color : MonoBehaviour
{
	//Create the object whose material will be modified
	public GameObject myObject;
	

	void start ()
	{
	}

	void Update ()
	{
		//Pressing the keyboard button "M", the color of myobject change to magenta.

		//change for example the letter M to change the button to be pressed on the keyboard and the word
		//magenta for example to modify the color associated with the letter

		if(Input.GetKeyDown(KeyCode.M))
		{
			myObject.GetComponent<Renderer>().material.color = Color.magenta;
		}
		if(Input.GetKeyDown(KeyCode.G))
		{
			myObject.GetComponent<Renderer>().material.color = Color.grey;
		}
		if(Input.GetKeyDown(KeyCode.B))
		{
			myObject.GetComponent<Renderer>().material.color = Color.blue;
		}
		if(Input.GetKeyDown(KeyCode.Y))
		{
			myObject.GetComponent<Renderer>().material.color = Color.yellow;
		}
	}
}
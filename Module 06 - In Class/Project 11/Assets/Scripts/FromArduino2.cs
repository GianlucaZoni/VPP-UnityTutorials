using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Linq;

public class FromArduino2 : MonoBehaviour {

    SerialPort stream;
    int buttonState = 0;
    public string portName ="COM3";
    public GameObject cube;
    private int amountToMove = 2;

    // Use this for initialization
    void Start () {
        stream = new SerialPort(portName, 9600);
        stream.DtrEnable = false;   //Prevent the Arduino from rebooting once we connect to it. 
                                    //A 10 uF cap across RST and GND will prevent this. Remove cap when programming.
        stream.ReadTimeout = 1;     //Shortest possible read time out.
        stream.WriteTimeout = 1;    //Shortest possible write time out.
        if (!stream.IsOpen)
            stream.Open();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && stream.IsOpen)
            stream.Close();

        string value = CheckForRecievedData();
        Move(value);
	}

    public string CheckForRecievedData()
    {
        try //Sometimes malformed serial commands come through. We can ignore these with a try/catch.
        {
            string inData = stream.ReadLine();
            int inSize = inData.Count();
            if (inSize > 0)
            {
                Debug.Log("ARDUINO->|| " + inData + " ||MSG SIZE:" + inSize.ToString());
            }
            //Got the data. Flush the in-buffer to speed reads up.
            inSize = 0;
            stream.BaseStream.Flush();
            stream.DiscardInBuffer();
            return inData;
        }
        catch { return string.Empty; }
    }

    private void Move(string direction)
    {
        // Move the cube
        if (direction == "a")
        {
            cube.transform.Translate(Vector3.left * amountToMove, Space.World);
        }
        else if (direction == "b")
        {
            cube.transform.Translate(Vector3.right * amountToMove, Space.World);
        }
    }

}

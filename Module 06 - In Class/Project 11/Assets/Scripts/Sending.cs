using UnityEngine;
using System.IO.Ports;
using System.Linq;

public class Sending : MonoBehaviour {
    public string portName = "COM3";
	public static SerialPort sp;
	float timePassed = 0.0f;
	// Use this for initialization
	void Start () {
        sp = new SerialPort("\\\\.\\" + portName, 9600);
        OpenConnection();
	}
	
    public void OpenConnection() 
    {
       if (sp != null) 
       {
         if (sp.IsOpen) 
         {
          sp.Close();
          print("Closing port, because it was already open!");
         }
         else 
         {
          sp.Open();            // opens the connection
          sp.ReadTimeout = 16;  // sets the timeout value before reporting error
          print("Port Opened!");
         }
       }
       else 
       {
         if (sp.IsOpen)
         {
          print("Port is already open");
         }
         else 
         {
          print("Port == null");
         }
       }
    }

    void OnApplicationQuit() 
    {
       sp.Close();
       Debug.Log("Close");
    }

    public void SendYellow(){
        Debug.Log("Y");
        sp.Write("y");        
    }

    public void SendGreen(){
        Debug.Log("G");
        sp.Write("g");
    }

    public void SendRed(){
        Debug.Log("R");
        sp.Write("r");        
    }
    public void TurnOff()
    {
        Debug.Log("Q");
        sp.Write("q");
    }
}

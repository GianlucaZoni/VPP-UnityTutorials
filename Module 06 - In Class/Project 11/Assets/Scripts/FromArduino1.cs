//C#
using UnityEngine;
using System.IO.Ports;
using System.Linq;

public class FromArduino1 : MonoBehaviour
{
    SerialPort sp;
    string inText;
    public string port = "COM5";

    void Start()
    {
        sp = new SerialPort(port, 9600);
        sp.ReadTimeout = 1;     //Shortest possible read time out.
        sp.WriteTimeout = 1;    //Shortest possible write time out.
        sp.Open();
    }

    void Update()
    {
        inText = CheckForRecievedData();
        MenageData();

        // Close the serial port and the application when the user presses Escape
        if (Input.GetKeyDown(KeyCode.Escape) && sp.IsOpen)
        {
            sp.Close();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
        }

    }

    public string CheckForRecievedData()
    {
        try //Sometimes malformed serial commands come through. We can ignore these with a try/catch.
        {
            string inData = sp.ReadLine();
            int inSize = inData.Count();
            if (inSize > 0)
            {
                Debug.Log("ARDUINO->|| " + inData + " ||MSG SIZE:" + inSize.ToString());
            }
            //Got the data. Flush the in-buffer to speed reads up.
            inSize = 0;
            sp.BaseStream.Flush();
            sp.DiscardInBuffer();
            return inData;
        }
        catch { return string.Empty; }  // Mange exeptions
    }

    private void OnApplicationQuit()
    {
        if (sp.IsOpen)
            sp.Close();
    }

    // -- Add here your functions --
    public GameObject lamp;

    private void MenageData()
    {
        string buttonState = inText;
        // Switch the light in Unity3D scene
        if (buttonState == "0")
            lamp.SetActive(false);
        else if (buttonState == "1")
            lamp.SetActive(true);

    }

    private void OnGUI()
    {
        string newString = "Received value: " + inText;
        GUI.Label(new Rect(10, 10, 600, 100), newString);
    }
}

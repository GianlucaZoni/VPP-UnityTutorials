using UnityEngine;
using UnityEngine.Events;

public class CallSending : MonoBehaviour {

    public UnityEvent send;

	// Use this for initialization
	void Start () {
		
	}
	
    void OnMouseDown()
    {
        send.Invoke();
    }
}

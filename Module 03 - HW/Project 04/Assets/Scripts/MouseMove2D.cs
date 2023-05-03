using UnityEngine;
using System. Collections;
using System.Collections.Generic;

public class MouseMove2D: MonoBehaviour
{

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    void Start()
    {
        
    }


void Update()
    {
        if(Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
       
    }

}

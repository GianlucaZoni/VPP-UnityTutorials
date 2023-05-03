using UnityEngine;
using System. Collections;
using System.Collections.Generic;

public class Changecolorcollision2D: MonoBehaviour
{

    private int counter = 0;
    public List<Color> colors; //list of colors, can be changed in the inspector
    SpriteRenderer renderReference;

    void Start()
    {
        renderReference = GetComponent<SpriteRenderer>();
        renderReference.color = colors[counter];
    }


void OnCollisionEnter2D(Collision2D coll)
    {
        if(counter < colors.Count - 1)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        renderReference.color = colors[counter];

    }

}

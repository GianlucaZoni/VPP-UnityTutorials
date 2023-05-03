using UnityEngine;
using System. Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class changescene: MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "button")
        {
            SceneManager.LoadScene("Scene2");
        }
    }


}

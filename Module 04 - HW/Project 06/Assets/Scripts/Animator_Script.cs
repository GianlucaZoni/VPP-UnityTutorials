using UnityEngine;
using System.Collections;

public class Animator_Script : MonoBehaviour
{

   public Animator animator;
   public object my_object;


    private void Update()
    {

    }


void OnMouseDown()
    {
            animator.SetTrigger("click");
    }

     
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollision : MonoBehaviour
{


    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "x_Cube")
        {
            Debug.Log("Collision with y_Cube happening!");
        }
        
    }

}

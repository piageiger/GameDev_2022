using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    /*  Doku:
    *   Lässt Object kontinuierlich rotieren um eine von außen festgelegte Achse
    */
   public float speed;
   public string axis;
   
    // Update is called once per frame
    void Update()
    {
        switch(axis) 
        {
            case "y" : 
                transform.Rotate(Vector3.up *speed * Time.deltaTime);
                break;
            case "z" :
                transform.Rotate(Vector3.forward *speed * Time.deltaTime);
                break;
            case "x" :
                transform.Rotate(Vector3.right *speed * Time.deltaTime);
                break;
        }  
    }
}

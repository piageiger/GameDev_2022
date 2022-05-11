using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPlatform : MonoBehaviour
{    
    //Doku:
    //Script schrumpft die Plattform, worauf das Skript liegt solange, bis es nicht mehr existiert
    //Dabei gibt "shrinkVector" die Werte an, wie schnell geschrumpft werden soll
    
    public Vector3 shrinkVector = new Vector3(1f, 0f, 1f);
    private bool shrink = false;
    private Vector3 zeroSize = new Vector3(0, 1, 0);
    
    void Update()
    {
        if (shrink)
        {
            //Solange localScale.X und localScale.Y der Plattform größer ist als Ursprung, dann verringere das Scaling der Platform
            if ((transform.localScale.x > zeroSize.x) && (transform.localScale.z > zeroSize.z))
            {
                transform.localScale -= shrinkVector;
            }   
            //Wenn localScale der Plattform kleiner ist als Ursprung, disable die Plattform         
            else
            {
                gameObject.SetActive(false);
            }
        } 
    }

    void OnCollisionEnter(Collision collision)
    {
        //Wenn Player die Plattform berührt, dann beginne zu schrumpfen
        if(collision.gameObject.tag == "Player")
        {
            shrink = true;
        }
    
    }
}

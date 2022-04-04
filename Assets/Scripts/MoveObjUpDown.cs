using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjUpDown : MonoBehaviour
{
    private Vector3 originalHeight;
    private float actualXPos; 
    //private float maxHeight;
    private float lowerBound;
    private float upperBound;
    private bool upwards;

    public float upperLowerBound;  
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        originalHeight = transform.position;
        lowerBound = originalHeight.y - upperLowerBound;
        upperBound = originalHeight.y + upperLowerBound;
        //Zu Beginn aufwärtsbewegung
        upwards = true;
    }

    // Update is called once per frame
    void Update()
    {
        actualXPos = transform.position.y;

        if (actualXPos >= upperBound) 
        {
            //wenn Obergrenze erreicht wurde, dann nach unten steuern
            upwards = false;
            move();
        } 
        else if (actualXPos <= lowerBound)
        {
            //wenn Untergrenze erreicht wurde, dann nach oben steuern
            upwards = true;          
            move();
        }
        else 
        {

            move();
        }
        
    }

    void move()
    {
        if (upwards)
        {
            //Wenn True dann bewegung richtung oben
            moveUp();
        }
        else
        {
            moveDown();
        }
    }

    void moveUp()
    {
        transform.Translate(Vector3.up *speed* Time.deltaTime, Space.World);
    }

    void moveDown()
    {
        transform.Translate(Vector3.down *speed* Time.deltaTime, Space.World);
    }

}

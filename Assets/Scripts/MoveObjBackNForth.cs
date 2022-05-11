using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjBackNForth : MonoBehaviour
{
    /*  Doku:
    *   Object moves constantly back & forth, depending on the given axis
    *   Speed up by setting a lower number for "time"
    *   Moves until the turning point (targetPosition or origin) is reached, so "bound" sets the distance
    *   By default moves first up then down / right then left / towards then backwarts
    *   Change flip this order by using a negative number for "bound"
    */

    private Vector3 origin;
    private Vector3 actualPos; 
    private Vector3 targetPosition;
    private bool isMoving = true;
    private bool isBoundAdded = true;
    private float duration = 0;

    public string axis;
    public float bound;  
    public float time; 

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        targetPosition = transform.position;

        switch(axis)
        {
            case "y" : 
                targetPosition.y = origin.y + bound;
                break;
            case "z" :
                targetPosition.z = origin.z + bound;
                break;
            case "x" :
                targetPosition.x = origin.x + bound;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        MoveObject();
        if (isMoving && isBoundAdded)
        {
            MovingObject(origin, targetPosition);
        }
        else if (isMoving && !isBoundAdded)
        {
            MovingObject(targetPosition, origin);
        }
    }

    public void MoveObject()
    {
        isMoving = true;
    }
    private void MovingObject(Vector3 start, Vector3 finish)
    {
        duration += Time.deltaTime / time;
        if (duration < 1)
        {
            transform.position = Vector3.Lerp(start, finish, duration);
        }
        else
        {
            isMoving = false;
            isBoundAdded = !isBoundAdded;
            duration = 0;
        }
    }
}
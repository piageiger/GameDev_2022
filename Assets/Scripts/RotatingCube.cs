using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCube : MonoBehaviour
{
    public float rotateInTime = 5f;
    public int moveSpeed = 3;

    [SerializeField]
    private Vector3 target1 = new Vector3(30, 0, 0);
    public float rotateDegrees1 = 180f;

    [SerializeField]
    private Vector3 target2 = new Vector3(0, 30, 0);
    public float rotateDegrees2 =90f;

    [SerializeField]
    private Vector3 target3 = new Vector3(0, 0, 30);
    public float rotateDegrees3 = 180f;

    [SerializeField]
    private Vector3 target4 = new Vector3(0, -30, 0);
    public float rotateDegrees4 = 90f;

    private int target = 1;
    private bool rotate = true;
    private bool started = false; 
    private Vector3 actualPos;
    private Vector3 originalPos;   

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;         
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            started = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
        {        
            if(target == 1)
            {
                actualPos = transform.position;
                transform.position = Vector3.MoveTowards(transform.position, originalPos + target1, Time.deltaTime * moveSpeed);
                if(rotate)
                {
                    StartCoroutine(RotateMe(Vector3.forward * rotateDegrees1, rotateInTime));  
                    rotate = false;     
                }
                
                if(actualPos.x >= (originalPos.x + target1.x))
                {
                    target = 2;
                    originalPos = actualPos;   
                    rotate = true;          
                }
            }
            if (target == 2)
            {
                actualPos = transform.position;
                transform.position = Vector3.MoveTowards(transform.position, originalPos + target2, Time.deltaTime * moveSpeed);
                if(rotate)
                {
                    StartCoroutine(RotateMe(Vector3.left * rotateDegrees2, rotateInTime));  
                    rotate = false;     
                }

                if (actualPos.y >= (originalPos.y + target2.y))
                {
                    target = 3;
                    originalPos = actualPos;
                    rotate = true;
                    rotateInTime *= 3;
                }
            }
            if (target == 3)
            {
                actualPos = transform.position;
                transform.position = Vector3.MoveTowards(transform.position, originalPos + target3, Time.deltaTime * moveSpeed);
                if(rotate)
                {
                    StartCoroutine(RotateMe(Vector3.right * rotateDegrees3, rotateInTime));  
                    rotate = false;     
                }
                if (actualPos.z <= (originalPos.z + target3.z))
                {
                    target = 4;
                    originalPos = actualPos;
                    rotate = true;
                    rotateInTime /= 3;
                }
            }
            if (target == 4)
            {
                actualPos = transform.position;
                transform.position = Vector3.MoveTowards(transform.position, originalPos + target4, Time.deltaTime * moveSpeed);
                if(rotate)
                {
                    StartCoroutine(RotateMe(Vector3.left * rotateDegrees4, rotateInTime));  
                    rotate = false;     
                }

                if (actualPos.y <= (originalPos.y + target4.y))
                {
                    target = 5;
                    originalPos = actualPos;
                                        
                }
            }
        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime) 
    {
           var fromAngle = transform.rotation;
           var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
           for(var t = 0f; t < 1; t += Time.deltaTime/inTime) 
           {
                transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
                yield return null;
           }
    }
}

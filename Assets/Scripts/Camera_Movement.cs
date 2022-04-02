using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{      
    public Transform player;      
       
    void Update () 
    {         
        transform.position = player.transform.position + new Vector3(0, 1, -5);     
    } 

    // Start is called before the first frame update
    void Start()
    {
        
    }

}

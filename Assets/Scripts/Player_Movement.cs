using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;

    private Rigidbody rigid;

    public float jumpAmount;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }

    //maybe change to: FixedUpdate()
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0.0f, vertical);
        //rotates player
        rigid.AddForce(move*speed);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
           
        }
    }
}

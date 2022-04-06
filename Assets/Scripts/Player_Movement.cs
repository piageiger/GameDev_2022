using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    
    public bool isGrounded;
    private Rigidbody rigid;

    public float jumpForce;
    
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
        rigid.AddForce(move*speed);
    	
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    public void OnCollisionEnter(Collision collision){
        Debug.Log("Collision Enter");
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    public void OnCollisionExit(Collision collision){
        Debug.Log("Collision Exit");
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
    

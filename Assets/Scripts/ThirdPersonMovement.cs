using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonMovement : MonoBehaviour
{ 
    public Transform cam;
    public float speed = 6f;
    public float jump= 3f;    
    public float gravity = -9.81f;
    public float maxSpeed = 30f;

    private Vector3 velocity;
    public static bool isGrounded;
    private Rigidbody rigid;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {               
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveLR = Input.GetAxisRaw("Horizontal")   ;
        float moveFB = Input.GetAxisRaw("Vertical");
        Vector3 position = new Vector3(moveLR, 0f, moveFB).normalized;

        //Move
        if (position.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(position.x, position.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            if(rigid.velocity.magnitude > maxSpeed)
            {
                rigid.velocity = rigid.velocity.normalized * maxSpeed;
            }
            else
            {
                rigid.AddForce(direction * speed);
            }
        }

        //Jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2.0f * gravity);
            rigid.AddForce(new Vector3(0, velocity.y, 0), ForceMode.Impulse);
        }

        velocity.y += gravity * Time.deltaTime;
        rigid.AddForce(velocity * Time.deltaTime);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        //Wenn DeathZone erreicht wurde, dann reset
        if(collision.gameObject.CompareTag("DeathZone"))
        {
            Respawn();
        }    
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;   
        }
    }

    void Respawn()
    {
        SceneManager.LoadScene("Game");
    }
}
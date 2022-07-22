using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ThirdPersonMovement : MonoBehaviour
{ 
    public Transform cam;
    public float speed = 6f;
    public float jump= 3f;    
    public float gravity = -9.81f;
    public float maxSpeed = 30f;

    private Vector3 velocity;
    private Rigidbody rigid;

    public static bool isGrounded;
    public static bool checkpointsActive = true;
    public static int checkPointNr = 0;

    private Vector3 checkPoint0 = new Vector3(0f, 2f, 0f);

    [SerializeField]
    private Vector3 checkPoint1 = new Vector3(-397.84f, 2f, 330.08f);
    [SerializeField]
    private Vector3 checkPoint2 = new Vector3(-488.06f, 33.7f, -145.29f);
    [SerializeField]
    private AudioClip deathAudio;
    [SerializeField]
    private AudioClip collisionAudio;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        initCheckPoints();        
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        //Wenn DeathZone erreicht wurde, dann reset
        else if(collision.gameObject.CompareTag("DeathZone"))
        {
            Respawn();
        }
        else 
        {
            AudioSource.PlayClipAtPoint(collisionAudio, transform.position);
        }  
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;   
        }
    }

    private void Respawn()
    {
        AudioSource.PlayClipAtPoint(deathAudio, transform.position);
        SceneManager.LoadScene("Game");
        GameManager.died = true;
        ScoreManager.addFalldown += 100;
        PlayerPrefs.SetFloat("ellapsedTime", ScoreManager.ellapsedTime);
    }

    private void initCheckPoints()
    {
        checkPointNr = PlayerPrefs.GetInt("checkPointNr", 0);

        if(checkpointsActive)
        {
            if(checkPointNr == 1)
            {
                Debug.Log("setze zu Checpoint 1");
                transform.position = checkPoint1;
            }
            else if(checkPointNr == 2)
            {
                transform.position = checkPoint2;
            }
            else
            {
                Debug.Log("setze zu Checpoint 0");
                transform.position = checkPoint0;
            }
        }
        else
        {
            transform.position = checkPoint0;
        }
    }
}
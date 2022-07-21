using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove_Platform : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private BoxCollider boxCol; 
    public float time;
    private Color meshCol; 

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshCol = meshRenderer.material.color;
    }

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            BlinkRed0();
        }
    }

    void BlinkGreen0()
    {
        meshRenderer.material.color = meshCol;        
        Invoke("BlinkRed1", time);
    }

    void BlinkGreen1()
    {
        meshRenderer.material.color = meshCol;        
        Invoke("BlinkRed2", time);
    }

    void BlinkGreen2()
    {
        meshRenderer.material.color = meshCol;        
        Invoke("Despawn", time);
    }

    void BlinkRed0()
    {
        meshRenderer.material.color = Color.red;      
        Invoke("BlinkGreen0", time);
    }

    void BlinkRed1()
    {
        meshRenderer.material.color = Color.red;      
        Invoke("BlinkGreen1", time);
    }

    void BlinkRed2()
    {
        meshRenderer.material.color = Color.red;      
        Invoke("BlinkGreen2", time);
    }

    void Despawn()
    {
        gameObject.SetActive(false);
    }

}
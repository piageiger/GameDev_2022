using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove_Platform : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float time;

    IEnumerator waiter()
    {   
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = Color.red;

        
        yield return new WaitForSecondsRealtime(time);
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("The player has collided with the wall!");
            StartCoroutine(waiter());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnGegner : MonoBehaviour
{
    public Transform Spawnpoint1;
    public Transform Spawnpoint2;
    public Transform Spawnpoint3;

    public GameObject Spawnee;
    public bool stopSpawning = true;
    public float spawnTime;
    public float spawnDelay;
    int i = 0;
    
    void OnTriggerEnter(Collider collision)
        {
        if(collision.gameObject.CompareTag("Player"))
        {
        Debug.Log("Entered");
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        }
        }
    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
        CancelInvoke();
        Debug.Log("exit");
        }
    }
/*
    void OnTriggerEnter()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }
      
    void OnTriggerExit()
    {
        CancelInvoke();
        Debug.Log("exit");
    }
    */
    public void SpawnObject()
    {
        if(i==0)
        {
            Instantiate(Spawnee, Spawnpoint1.position, Spawnpoint1.rotation);
            Instantiate(Spawnee, Spawnpoint3.position, Spawnpoint3.rotation);
            i++;
        }
        else{
            Instantiate(Spawnee, Spawnpoint2.position, Spawnpoint2.rotation);
            i--;
        }
    }
    /*Instantiate(Prefab, Spawnpoint1.position, Spawnpoint1.rotation);
    Instantiate(Prefab, Spawnpoint3.position, Spawnpoint3.rotation);
    Instantiate(Prefab, Spawnpoint2.position, Spawnpoint2.rotation);*/

}
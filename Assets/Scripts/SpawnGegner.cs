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
    int j = 0;

    void OnTriggerEnter()
    {
        if(i==0)
        {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        i++;
        }
        else{
            stopSpawning = false; 
            i=0;
        }
    }   
    /*void OnTriggerExited()
    {
        CancelInvoke("SpawnObject)");
    }
    */
    public void SpawnObject()
    {
        if(j==0)
        {
            Instantiate(Spawnee, Spawnpoint1.position, Spawnpoint1.rotation);
            Instantiate(Spawnee, Spawnpoint3.position, Spawnpoint3.rotation);
            j++;
        }
        else{
            Instantiate(Spawnee, Spawnpoint2.position, Spawnpoint2.rotation);
            j--;
        }
        if(stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
    /*Instantiate(Prefab, Spawnpoint1.position, Spawnpoint1.rotation);
    Instantiate(Prefab, Spawnpoint3.position, Spawnpoint3.rotation);
    Instantiate(Prefab, Spawnpoint2.position, Spawnpoint2.rotation);*/

}

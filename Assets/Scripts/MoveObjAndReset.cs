using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjAndReset : MonoBehaviour
{
    
    public float timeToWait = 1;
    public float speed = 15;
    [SerializeField] 
    private Vector3 target = new Vector3(30, 0, 0);

    private Vector3 originalPosition;
    private Vector3 destinationPos;    
    private bool move;
    private MeshRenderer rend;
    private BoxCollider boxCol;
    
    void Start()
    {
        //Setze original und Ziel- Position
        originalPosition = transform.position;
        destinationPos = originalPosition + target;
        move = true;
        //get Meshrenderer des gameObjects, um Visibility an und auszuschalten
        rend = GetComponent<MeshRenderer>();
        boxCol = GetComponent<BoxCollider>();
    }

    void Update()
    {        
        Vector3 actualPos = transform.position;
        //wenn Zielposition erreicht wurde und move erlaubt
        if((actualPos == destinationPos) && (move))
        {     
            move = false;
            rend.enabled = false;
            boxCol.enabled = false;
            //führt "Restart" aus nach X Sekunden                
            Invoke("Restart", timeToWait);                                                           
        }
        //Wenn keine Zielposition erreicht wurde, bewege richtung Ziel
        else if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinationPos, Time.deltaTime * speed);
        }           
    }

    void Restart()
    {   
        //setze Position und visibility zurück
        transform.position = originalPosition;
        rend.enabled = true;
        boxCol.enabled = true;
        //Rufe Warte nach X Sekunden auf
        Invoke("Warte", timeToWait);
        
    }

    void Warte()
    {
        //erlaube wieder das Bewegen
        move = true;
        
    }

}
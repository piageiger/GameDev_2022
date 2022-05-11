using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOnJump : MonoBehaviour
{
    //Doku:
    //Dieses Skript aktiviert / deaktiviert das gameObject, auf dem das Skript liegt
    //Dazu den Layer des gameObjects zu "FlipPlatformA" bzw. "FlipPlatformB" setzen
    //Beim drücken der Sprungtaste: Platformen des Layers A verschwinden, während Platformen von Layer B erscheinen und umgekehrt

    private bool en_disabled;
    private MeshRenderer rend;
    private BoxCollider boxCol; 
    private string layerName;

    // Start is called before the first frame update
    void Start()
    {
        //hole Meshrenderer und BoxCollider des gameObjects
        rend = GetComponent<MeshRenderer>();
        boxCol = GetComponent<BoxCollider>();
        ChangeVisibility();        
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = ThirdPersonMovement.isGrounded;
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            if(en_disabled)
            {
                en_disabled = false;
            }
            else
            {
                en_disabled = true;
            }
            //Rufe ChangeVisibility nach 0.1 Sekunden auf
            Invoke("ChangeVisibility", 0.1f);
        }
    }

    void ChangeVisibility()
    {        
        //nehme den Layer des gameObjects und vergleiche, ob es FlipPlatformA oder B heißt
        layerName = LayerMask.LayerToName(gameObject.layer);

        if(layerName == "FlipPlatformA") 
        {
            //enable / disable die Plattform A entgegengesetzt zu B
            rend.enabled = en_disabled;
            boxCol.enabled = en_disabled;
        } 
        if(layerName == "FlipPlatformB")
        {
            //enable / disable die Plattform B entgegengesetzt zu A
            rend.enabled = ! en_disabled;
            boxCol.enabled = ! en_disabled;
        }
    }
}

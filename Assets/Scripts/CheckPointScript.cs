using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    private string layerName; 
    // Start is called before the first frame update
    void Start()
    {
        layerName = LayerMask.LayerToName(gameObject.layer);
        if(ThirdPersonMovement.checkpointsActive == false)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(layerName == "CheckPoint1") 
        {
            Debug.Log("CheckPoint 1 erreicht!");
            ThirdPersonMovement.checkPointNr = 1;
            PlayerPrefs.SetInt("checkPointNr", ThirdPersonMovement.checkPointNr);
        } 
        if(layerName == "CheckPoint2") 
        {
            Debug.Log("CheckPoint 2 erreicht!");
            ThirdPersonMovement.checkPointNr = 2;    
            PlayerPrefs.SetInt("checkPointNr", ThirdPersonMovement.checkPointNr);
        }      
        gameObject.SetActive(false);
    }
}

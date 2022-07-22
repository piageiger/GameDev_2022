using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCheckpointsOnOff : MonoBehaviour
{
    private bool toggle = false; // global variable default is off
    
    public void changeCheckpointsOn() 
    {
        toggle = !toggle;
        if(toggle)
        {
            GameObject.Find("ButtonOnOff").GetComponentInChildren<Text>().text = "On";
        }
        else
        {
            GameObject.Find("ButtonOnOff").GetComponentInChildren<Text>().text = "Off";
        }
        ThirdPersonMovement.checkpointsActive = toggle;
        
    }
}

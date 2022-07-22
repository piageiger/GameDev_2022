using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetCheckpointsOnOff : MonoBehaviour
{
    private bool toggle;// global variable default is off
    private int boolVal;
    public TextMeshProUGUI buttonText;

    void Start()
    {
        
        toggle = PlayerPrefs.GetInt("checkPointOnOff") == 1;
        //foo = PlayerPrefs.GetInt("foo")==1;
        if (toggle == true)
        {
            buttonText.text = "On";
        }
        else
        {
            buttonText.text = "Off";
        }
    }
    
    public void changeCheckpointsOn() 
    {
        toggle = !toggle;
        if(toggle)
        {
            buttonText.text = "On";
            boolVal = 1;
        }
        else
        {
            buttonText.text = "Off";
            boolVal = 0;
        }
        ThirdPersonMovement.checkpointsActive = toggle;
        PlayerPrefs.SetInt("checkPointOnOff", boolVal);
        
    }
}

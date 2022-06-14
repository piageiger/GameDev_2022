using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//When reaching the goal, this script is triggered
public class GoalTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerEntered;
    public UnityEvent OnTriggerExited;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.zielErreicht = true;
    }

    private void OnTriggerExit(Collider other)
    {
    }
}

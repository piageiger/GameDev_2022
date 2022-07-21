using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//When reaching the goal, this script is triggered
public class GoalTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip goalAudio;

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(goalAudio, transform.position);
        GameManager.zielErreicht = true;
    }
}

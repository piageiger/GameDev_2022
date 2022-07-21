using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip coin;
    [SerializeField]
    private AudioClip death;
    [SerializeField]
    private AudioClip impact;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        {
            Debug.Log("AudioSouce is NULL!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("DeathZone") && audioSource != null)
        {
            audioSource.clip = death;
            audioSource.Play(); 
        }
        else if (collision.gameObject.CompareTag("ImpactSound") && audioSource != null)
        {
            audioSource.clip = impact;
            audioSource.Play(); 
        }
    } 
}

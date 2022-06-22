using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private AudioClip coin;
    [SerializeField] private AudioClip death;
    [SerializeField] private AudioClip impact;

    void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.gameObject.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coin); 
        }
        
    }

    void OnCollisionEnter(Collision obstacle)
    {
        if (obstacle.gameObject.CompareTag("DeathZone"))
        {
            audioSource.PlayOneShot(death); 
        }
        if (obstacle.gameObject.CompareTag("Gegner"))
        {
            audioSource.PlayOneShot(impact); 
        }
    }
    
}

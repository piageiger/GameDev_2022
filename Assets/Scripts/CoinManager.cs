using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    //static Variable, damit diese in "ScoreManager" genutzt werden kann
    public static int coinsTotal;

    public int coinsCounter = 4;
    public float rotationSpeed = 2f;

    [SerializeField]
    private AudioClip coinAudio;

    // Start is called before the first frame update
    void Start()
    {
        coinsTotal = 0;
    }

    void Update()
    {
        //rotiere die Münze
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(coinAudio, transform.position);
        coinsTotal += coinsCounter;
        gameObject.SetActive(false);
    }
    
}

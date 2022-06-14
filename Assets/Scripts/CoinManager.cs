using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    //static Variable, damit diese in "ScoreManager" genutzt werden kann
    public static int coinsTotal;

    public int coinsCounter = 4;
    public float rotationSpeed = 2f;

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
    
    public void OnTriggerEnter(Collider other)
    {
        coinsTotal += coinsCounter;
        gameObject.SetActive(false);
    }
}

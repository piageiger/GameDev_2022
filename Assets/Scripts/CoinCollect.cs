using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    //static Variable, damit diese in "ScoreManager" genutzt werden kann
    public static int countCoin;

    public float rotationSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        countCoin = 0;
    }

    void Update()
    {
        //rotiere die Münze
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
    
    public void OnTriggerEnter(Collider other)
    {
        countCoin += 1;
        gameObject.SetActive(false);
    }


}

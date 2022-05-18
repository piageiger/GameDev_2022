using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_Platform : MonoBehaviour
{
    public float time;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waiter()
    {    
        while (true)
        {
            yield return new WaitForSecondsRealtime(time);
            transform.Rotate(Vector3.right, 90f);

        }       
        
    }
}

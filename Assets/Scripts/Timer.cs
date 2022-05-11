using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counterText;
    public float seconds, minutes;

    void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
    }

    // Update is called once per frame
    void Update()
    {
        minutes = (int)(Time.time/60f);
        seconds  = (int)(Time.time%60f);
        counterText.text = minutes.ToString("00") + ":"+ seconds.ToString("00");
    }
}

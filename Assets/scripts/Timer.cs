using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timertext;
    private float startTime;


    void Start()
    {
        
        startTime = Time.time;

    }

    void Update()
    {

        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = ((int)t % 60).ToString("D2");
        string millisec = ((int)(t * 100f) % 100).ToString("D2");

        //to be displayed when game is running
        timertext.text = minutes + " : " + seconds + " : " + millisec;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    public bool isOn = false;
    public GameObject lightsource;

    // Update is called once per frame
    private void Start()
    {
        lightsource.SetActive(false);//make sure light is off until player turns it on
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))//input for turing on light
        {
            if(isOn == false)//checks if the light is on or not
            {
                lightsource.SetActive(true);//turn light on
                isOn = true;
            }
            else if (isOn == true)
            {
                lightsource.SetActive(false);//turns light off
                isOn = false;
            }
        }
        
    }
}

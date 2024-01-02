using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    public GameManger GameManger;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        //check to see if the object on the pressure plate is not the player or enemy just the box to be place
        if (collision.gameObject.tag == "pickupable")
        {
            Debug.Log("active");
            GameManger.PressureCounter += 1;
            rend.material.color = Color.red;//color change to show the plate is working
        }
    }

    //if box is taken of the plate
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "pickupable")
        {
            Debug.Log("Unactive");
            GameManger.PressureCounter -= 1;
            rend.material.color = Color.white;

        }
    }

}

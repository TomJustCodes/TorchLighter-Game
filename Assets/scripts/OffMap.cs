using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffMap : MonoBehaviour
{
    public PlayerHealth playerHealth;

    //kills the player for when they fall off the map
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerHealth.Damaged(playerHealth.PlayerMaxhealth);
        }
    }

}

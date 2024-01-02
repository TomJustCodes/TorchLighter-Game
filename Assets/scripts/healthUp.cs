using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthUp : MonoBehaviour
{
    public PlayerHealth playerHealth;

    //when player collids the heal function of the player health is called
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(playerHealth.PlayerCurrentHealth < 100)
            {
                playerHealth.Heal();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);//make sure the heal box can only be used once
        }
    }

}

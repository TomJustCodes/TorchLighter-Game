using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float PlayerCurrentHealth;
    public float PlayerMaxhealth = 100f;
    public PlayerHealthBar playerHealthBar;
    // when the game begins health is set to max
    void Start()
    {
        PlayerCurrentHealth = PlayerMaxhealth;

        playerHealthBar.SetHealth(PlayerMaxhealth);
    }

    public void Damaged(float damage)//reducing health when player is damged 
    {
        PlayerCurrentHealth -= damage;
        playerHealthBar.SetPlayerHealth(PlayerCurrentHealth);

        if (PlayerCurrentHealth <= 0f)//a check if player health is below 0
        {
            Die();
        }
    }

    public void Heal()
    {
        while (PlayerCurrentHealth < PlayerMaxhealth)//repeat until player is back at max health
        {
            PlayerCurrentHealth += 1;
            playerHealthBar.SetPlayerHealth(PlayerCurrentHealth);
        }
    }

    void Die()
    {
        //calls the game Over Script
        FindObjectOfType<GameManger>().GameOVER();
    }
}

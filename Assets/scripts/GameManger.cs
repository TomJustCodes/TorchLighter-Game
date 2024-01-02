using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public Transform lastpoint;
    public bool win;
    public GameOverScreen GameOverScreen;
    public EnemyHealth bossHealth;
    public WInScreen wInScreen;
    //doors
    public GameObject warehousedoor;
    public GameObject GymSidedoor;
    public GameObject GrappleDoor;
    public GameObject KeyDoor1;
    public GameObject KeyDoor2;
    public GameObject KeyDoor3;
    public GameObject bossDoor;
    public GameObject KeyDoor5;

    //checks
    public int KillCount = 0;
    public int KeyButtonCounter = 0;
    public int PressureCounter = 0;

    public void GameOVER()
    {
        GameOverScreen.Setup(lastpoint);

        Debug.Log("GameOVER");
    }
    private void Update()
    {

        if(PressureCounter == 2)
        {
            GymSidedoor.SetActive(false);
        }
        if(PressureCounter == 4)
        {
            warehousedoor.SetActive(false);
        }
        if (PressureCounter == 6)
        {
            KeyDoor5.SetActive(false);
        }
        if (KeyButtonCounter == 1)
        {
            KeyDoor1.SetActive(false);
            GrappleDoor.SetActive(true);
        }
        if (KeyButtonCounter == 2)
        {
            KeyDoor2.SetActive(false);
        }
        if (KeyButtonCounter == 3)
        {
            KeyDoor3.SetActive(false);
        }
        if (KeyButtonCounter == 5)
        {
            bossDoor.SetActive(false);
            KeyDoor5.SetActive(true);
        }

        if(bossHealth.currentHealth == 0)
        {
            win = true;
            wInScreen.Setup();
           
        }


    }

}

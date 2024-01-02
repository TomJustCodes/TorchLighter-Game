using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{ 
    public Transform lastCheckpoint;
    public Transform player;
    GameObject varGameObject;
    PlayerHealth playerHealth;

    public void Setup(Transform lastPoint)
    {
        Time.timeScale = 0f;//stops the game time
        gameObject.SetActive(true);//shows the ui on scrren
        GameObject varGameObject = GameObject.Find("Canvas");//makes sure the games cant be paused to stop overlap
        varGameObject.GetComponent<PauseMenu>().enabled = false;
        Cursor.lockState = CursorLockMode.None;//unhides the cursor
        lastCheckpoint = lastPoint;
    }

    public void restartFromCheckPoint()
    {
        //turn back on what was turns off 
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        player.transform.position = lastCheckpoint.transform.position;
        playerHealth.PlayerCurrentHealth = playerHealth.PlayerMaxhealth;
        //teloports player back to previous checkpoint
        gameObject.SetActive(false);//rehides death screen
        varGameObject.GetComponent<PauseMenu>().enabled = true;
    }

    public void Restartlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //reloads the active scence
    }

    public void Quit()
    {

        SceneManager.LoadScene("StartScreen");
      
    }
}

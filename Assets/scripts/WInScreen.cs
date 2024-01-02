using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WInScreen : MonoBehaviour
{
    public Text time;
    public Timer timer;

    public void Setup()//stops the GamePlay and activates visuals 
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        GameObject varGameObject = GameObject.Find("Canvas");//makes sure the games cant be paused to stop overlap
        varGameObject.GetComponent<PauseMenu>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        time.text = timer.timertext.text;
    }

    public void Restartlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartScreen");
    }
}

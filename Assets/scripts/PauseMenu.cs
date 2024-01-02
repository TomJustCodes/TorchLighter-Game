using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseMenuUI;
    public GameObject OptionsMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//input escape key
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
               
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);//deactives the pause menu graphics
        OptionsMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;//set time back to normal
        GamePaused = false;
    }

    private void Pause()
    {
        PauseMenuUI.SetActive(true);//activate graphics
        Cursor.lockState = CursorLockMode.None;//unlocks cursor
        Time.timeScale = 0f;//stops the game time
        GamePaused = true;
    }

    public void LoadMenu()
    {
        //returning to start scene
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }
}

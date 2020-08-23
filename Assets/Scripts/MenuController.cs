using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject instructionBG;
    public GameObject mainButtons;


    public void PlayGame ()
    {
        SceneManager.LoadScene("Level_01");
        Time.timeScale = 1f;
    }

    public void ShowInstructions ()
    {
        instructionBG.SetActive(true);
        mainButtons.SetActive(false);
    }

    public void HideInstructions ()
    {
        instructionBG.SetActive(false);
        mainButtons.SetActive(true);
    }

    public void Retry ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void ExitGame ()
    {
        Application.Quit();
    }

    public void NextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void ReturnToMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

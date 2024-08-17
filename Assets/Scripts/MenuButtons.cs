using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LevelsScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BacktoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

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
    public void TutorialModeScene()
    {
        SceneManager.LoadScene("TutorialMode");
    }
    public void EasyModeScene()
    {
        SceneManager.LoadScene("EasyMode");
    }
    public void NormalModeScene()
    {
        SceneManager.LoadScene("NormalMode");
    }
    public void HardModeScene()
    {
        SceneManager.LoadScene("HardMode");
    }
}

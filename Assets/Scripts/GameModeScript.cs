using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeScript : MonoBehaviour
{
    public GameObject gameWelcomeScreen;
    public GameObject gameScreen;
    public GameObject emailScreen;

    public void ProceedToGame()
    {
        gameWelcomeScreen.SetActive(false);
        gameScreen.SetActive(true);
    }
    public void BacktoLevelsScene()
    {
        SceneManager.LoadScene("LevelsScene");
    }
    public void MaximizeScreen()
    {
        gameScreen.SetActive(false);
        emailScreen.SetActive(true);
    }
    public void MinimizeScreen()
    {
        emailScreen.SetActive(false);
        gameScreen.SetActive(true);
    }
}

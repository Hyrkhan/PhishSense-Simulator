using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeScript : MonoBehaviour
{
    public GameObject gameWelcomeScreen;
    public GameObject gameScreen;
    public void ProceedToGame()
    {
        SceneManager.LoadScene("LevelsScene");
    }
    public void BacktoLevelsScene()
    {
        SceneManager.LoadScene("LevelsScene");
    }
}

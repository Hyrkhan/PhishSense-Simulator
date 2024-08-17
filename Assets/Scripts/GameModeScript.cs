using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void ProceedToGame()
    {
        SceneManager.LoadScene("LevelsScene");
    }
    public void BacktoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

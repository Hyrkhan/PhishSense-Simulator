using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModeScript : MonoBehaviour
{
    public GameObject gameWelcomeScreen;
    public GameObject gameScreen;
    public GameObject detectionScreen;

    public GameObject detectionGameScreen;
    public GameObject detectionScanScreen;
    public GameObject detectionVMScreen;



    public void ProceedToGame()
    {
        gameWelcomeScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void BacktoLevelsScene()
    {
        SceneManager.LoadScene("LevelsScene");
    }

    public void goToDetection()
    {
        gameScreen.SetActive(false);
        detectionScreen.SetActive(true);
    }

    public void backToGame()
    {
        detectionScreen.SetActive(false);
        gameScreen.SetActive(true);
    }
    public void goScan()
    {
        detectionGameScreen.SetActive(false);
        detectionScanScreen.SetActive(true);
    }
    public void goVM()
    {
        detectionGameScreen.SetActive(false);
        detectionVMScreen.SetActive(true);
    }
    public void cancelDetect()
    {
        detectionScanScreen.SetActive(false);
        detectionVMScreen.SetActive(false);
        detectionGameScreen.SetActive(true);
    }

}

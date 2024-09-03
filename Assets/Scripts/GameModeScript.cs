using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModeScript : MonoBehaviour
{
    public GameObject gameWelcomeScreen;
    public GameObject gameScreen;
    public GameObject emailScreen; // Panel for fullscreen image
    public Image normalEmailImage; // Image container for normal view
    public Image fullscreenEmailImage; // Image container for fullscreen view
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

    public void MaximizeScreen()
    {
        // Set the image for the fullscreen view
        fullscreenEmailImage.sprite = normalEmailImage.sprite;
        gameScreen.SetActive(false);
        emailScreen.SetActive(true);
        
    }

    public void MinimizeScreen()
    {
        emailScreen.SetActive(false);
        gameScreen.SetActive(true);
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

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


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static EmailFetcher;

public class GameModeScript : MonoBehaviour
{
    public GameObject gameWelcomeScreen;
    public GameObject gameScreen;
    public GameObject detectionScreen;

    public GameObject detectionGameScreen;
    public GameObject detectionScanScreen;
    public GameObject detectionVMScreen;

    public emailNavScript emailNavScript;  // Reference to the emailNavScript
    public EmailFetcher emailFetcher;  // Reference to the EmailFetcher



    private void Start()
    {
        // Subscribe to the OnEmailsFetched event
        emailFetcher.OnEmailsFetched += OnEmailsFetched;
    }

    public void ProceedToGame()
    {
        // Check if emails are loaded before proceeding
        if (emailFetcher.GetEmails().Count > 0)
        {
            gameWelcomeScreen.SetActive(false);
            gameScreen.SetActive(true);

            // Pass the fetched emails to emailNavScript and display the first one
            emailNavScript.SetEmails(emailFetcher.GetEmails());
            emailNavScript.DisplayEmail(0);
        }
        else
        {
            Debug.LogError("Emails are not loaded yet. Please wait.");
        }
    }
    // When emails are fetched
    private void OnEmailsFetched()
    {
        Debug.Log("Emails fetched, ready to display.");
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

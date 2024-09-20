using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class otherButtons : MonoBehaviour
{
    public GameObject gameScreen;         // The normal game screen panel
    public GameObject emailScreen;        // The fullscreen email screen panel

    // TextMeshPro UI elements for normal and fullscreen views
    public TMP_Text normalSenderEmailText;
    public TMP_Text normalEmailBodyText;
    public TMP_Text normalEmailLinkText;

    public TMP_Text fullscreenSenderEmailText;
    public TMP_Text fullscreenEmailBodyText;
    public TMP_Text fullscreenEmailLinkText;

    // Method to maximize the email screen
    public void MaximizeScreen()
    {
        // Copy the email content from normal view to fullscreen view
        fullscreenSenderEmailText.text = normalSenderEmailText.text;
        fullscreenEmailBodyText.text = normalEmailBodyText.text;
        fullscreenEmailLinkText.text = normalEmailLinkText.text;

        // Switch to fullscreen email view
        gameScreen.SetActive(false);
        emailScreen.SetActive(true);
    }

    // Method to minimize the email screen and go back to the game screen
    public void MinimizeScreen()
    {
        emailScreen.SetActive(false);
        gameScreen.SetActive(true);
    }
}

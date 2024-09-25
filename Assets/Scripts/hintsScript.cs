using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hintsScript : MonoBehaviour
{
    public GameObject hintDisplay;  // Container for displaying hints
    public TMP_Text hintText;       // UI Text component to display the hint
    public bool isPressed = false;  // Flag to track if the hint is displayed
    private string theHint = "";    // Current hint text

    private void Start()
    {
        hintDisplay.SetActive(false);  // Make sure the hint display is initially hidden
    }

    // Call this method to update the hint content
    public void SetHint(string hint)
    {
        Debug.Log("Hint Set: " + hint);  // Log for debugging
        theHint = hint;                  // Set the hint text
    }

    // This method toggles the hint display on or off
    public void displayHint()
    {
        if (isPressed)
        {
            hintDisplay.SetActive(false);  // Hide the hint display
        }
        else
        {
            hintDisplay.SetActive(true);   // Show the hint display
            hintText.text = theHint;       // Update the displayed hint text
        }

        isPressed = !isPressed;  // Toggle the pressed state
    }
}

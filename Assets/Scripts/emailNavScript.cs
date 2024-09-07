using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class emailNavScript : MonoBehaviour
{
    [System.Serializable]
    public class Email
    {
        public Sprite emailImage;  // The image representing the email
    }

    public List<Email> emails;  // List of all emails
    public Image emailDisplay;  // UI element to display the email image
    private int currentIndex = 0;
    public hintsScript hintSystem;

    private void Start()
    {
        DisplayEmail(currentIndex);  // Display the first email at the start
    }

    public void NextEmail()
    {
        if (currentIndex < emails.Count - 1)
        {
            currentIndex++;
            DisplayEmail(currentIndex);
        }
    }

    public void PreviousEmail()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            DisplayEmail(currentIndex);
        }
    }

    private void DisplayEmail(int index)
    {
        emailDisplay.sprite = emails[index].emailImage;
        hintSystem.hintIndex = index;
    }


}

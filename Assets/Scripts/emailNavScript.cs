using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class emailNavScript : MonoBehaviour
{
    public TMP_Text senderEmailDisplay;  // TextMeshPro for sender email
    public TMP_Text emailBodyDisplay;    // TextMeshPro for email body
    public TMP_Text emailLinkDisplay;    // TextMeshPro for email link

    private List<EmailFetcher.Email> emails;
    private int currentIndex = 0;  // Track which email is currently displayed

    public hintsScript hintSystem;

    // Set the emails from the fetched data
    public void SetEmails(List<EmailFetcher.Email> fetchedEmails)
    {
        emails = fetchedEmails;
    }

    // Display the email data in the UI
    public void DisplayEmail(int index)
    {
        if (emails == null || index < 0 || index >= emails.Count)
        {
            Debug.LogError("Invalid email index or emails not loaded.");
            return;
        }

        EmailFetcher.Email email = emails[index];

        Debug.Log($"Displaying Email: {email.senderEmail} | Body: {email.emailTextBody} | Link: {email.emailLink}");

        senderEmailDisplay.text = email.senderEmail;
        emailBodyDisplay.text = email.emailTextBody;
        emailLinkDisplay.text = email.emailLink;

        // Update hint system with the new hint
        hintSystem.SetHint(email.hint);  // Set the hint for the current email

        Debug.Log("UI updated: Sender, Body, Link, Hint");
    }

    // Navigation for next and previous buttons
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class emailNavScript : MonoBehaviour
{
    [System.Serializable]
    public class Email
    {
        public string senderEmail;    // Sender's email address
        public string emailTextBody;  // The text of the email
        public string emailLink;      // The link inside the email
    }

    // List to store the hardcoded emails
    private List<Email> emails = new List<Email>();

    // TextMeshPro UI elements for displaying email content
    public TMP_Text senderEmailDisplay;  // TextMeshPro for sender email
    public TMP_Text emailBodyDisplay;    // TextMeshPro for email body
    public TMP_Text emailLinkDisplay;    // TextMeshPro for email link

    private int currentIndex = 0;  // Track which email is currently displayed

    public hintsScript hintSystem;

    private void Start()
    {
        // Populate the emails list with hardcoded data
        HardcodeEmails();

        // Display the first email at the start
        if (emails.Count > 0)
        {
            DisplayEmail(currentIndex);
        }
    }

    // Hardcode some sample emails for the demo
    private void HardcodeEmails()
    {
        emails.Add(new Email
        {
            senderEmail = "example1@phishing.com",
            emailTextBody = "Dear user, click this link to claim your prize: http://phishinglink.com.",
            emailLink = "http://phishinglink.com"
        });

        emails.Add(new Email
        {
            senderEmail = "example2@scam.com",
            emailTextBody = "Your account has been compromised! Log in immediately at http://scamlink.com to secure it.",
            emailLink = "http://scamlink.com"
        });

        emails.Add(new Email
        {
            senderEmail = "support@fakebank.com",
            emailTextBody = "We detected unusual activity on your bank account. Visit http://fakebank.com to review your recent transactions.",
            emailLink = "http://fakebank.com"
        });
    }

    // Navigate to the next email
    public void NextEmail()
    {
        if (currentIndex < emails.Count - 1)
        {
            currentIndex++;
            DisplayEmail(currentIndex);
        }
    }

    // Navigate to the previous email
    public void PreviousEmail()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            DisplayEmail(currentIndex);
        }
    }

    // Display the email data in the UI
    private void DisplayEmail(int index)
    {
        Email email = emails[index];
        senderEmailDisplay.text = email.senderEmail;
        emailBodyDisplay.text = email.emailTextBody;
        emailLinkDisplay.text = email.emailLink;  // Set the email link text

        hintSystem.hintIndex = index;
    }
}
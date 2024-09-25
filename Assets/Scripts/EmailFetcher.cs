using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;  // Firestore package

public class EmailFetcher : MonoBehaviour
{
    [System.Serializable]
    public class Email
    {
        public string senderEmail;    // Sender's email address
        public string emailTextBody;  // The text of the email
        public string emailLink;      // The link inside the email
        public string hint;
    }

    public List<Email> emails = new List<Email>();  // List to store fetched emails
    private FirebaseFirestore db;

    // Event to notify when emails are fetched
    public delegate void EmailsFetched();
    public event EmailsFetched OnEmailsFetched;

    private void Start()
    {
        db = FirebaseFirestore.DefaultInstance;  // Initialize Firestore
        FetchEmailsFromFirestore();  // Start fetching emails
    }

    // Fetch emails from Firestore
    private void FetchEmailsFromFirestore()
    {
        db.Collection("emails").GetSnapshotAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                QuerySnapshot snapshot = task.Result;

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    Dictionary<string, object> emailData = document.ToDictionary();

                    Email email = new Email
                    {
                        senderEmail = emailData["senderEmail"].ToString(),
                        emailTextBody = emailData["emailTextBody"].ToString(),
                        emailLink = emailData["emailLink"].ToString(),
                        hint = emailData["hint"].ToString()
                    };

                    emails.Add(email);  // Add each email to the list
                }

                Debug.Log($"Fetched {emails.Count} emails from Firestore");

                // Trigger event to notify that emails have been fetched
                if (OnEmailsFetched != null)
                {
                    OnEmailsFetched.Invoke();
                }
            }
            else
            {
                Debug.LogError("Failed to fetch emails from Firestore");
            }
        });
    }

    // Provide access to the fetched emails
    public List<Email> GetEmails()
    {
        return emails;
    }
}

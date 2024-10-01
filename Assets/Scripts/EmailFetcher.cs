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

        // URL Scanner fields
        public string securityVerdict;
        public string securityHeaders;
        public string securityViolations;

        // SSL Certificates Info
        public string certSubject;
        public string certIssueDate;
        public string certExpiryDate;
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

                    // Handle urlScanner fields, which are nested
                    if (emailData.ContainsKey("urlScanner"))
                    {
                        Dictionary<string, object> urlScanner = emailData["urlScanner"] as Dictionary<string, object>;

                        email.securityVerdict = urlScanner["securityVerdict"].ToString();
                        email.securityHeaders = urlScanner["securityHeaders"].ToString();
                        email.securityViolations = urlScanner["securityViolations"].ToString();

                        if (urlScanner.ContainsKey("certificates"))
                        {
                            Dictionary<string, object> certificates = urlScanner["certificates"] as Dictionary<string, object>;

                            email.certSubject = certificates["subject"].ToString();
                            email.certIssueDate = certificates["issueDate"].ToString();
                            email.certExpiryDate = certificates["expiryDate"].ToString();
                        }
                    }

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

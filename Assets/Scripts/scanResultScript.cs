using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class scanResultScript : MonoBehaviour
{
    public TMP_Text linkBeingScanned;
    public TMP_Text resultLink;
    public TMP_Text resultHeaders;
    public TMP_Text resultVerdict;
    public TMP_Text resultViolations;
    public TMP_Text certSubject;
    public TMP_Text certIssue;
    public TMP_Text certExpiry;

    private string placeHolder_resultVerdict = "";
    private string placeHolder_resultHeaders = "";
    private string placeHolder_resultViolations = "";
    private string placeHolder_certSubject = "";
    private string placeHolder_certIssue = "";
    private string placeHolder_certExpiry = "";



    public void SetURLParameters(string verdict, string headers, string violations, string subject, string issue, string expiry)
    {
        Debug.Log("Being called");
        placeHolder_resultVerdict = verdict;
        placeHolder_resultHeaders = headers;
        placeHolder_resultViolations = violations;
        placeHolder_certSubject = subject;
        placeHolder_certIssue = issue;
        placeHolder_certExpiry = expiry;
        Debug.Log("Being Done");
    }

    public void DisplayResult()
    {
        resultLink.text = linkBeingScanned.text;
        resultVerdict.text = placeHolder_resultVerdict;
        resultHeaders.text = placeHolder_resultHeaders;
        resultViolations.text = placeHolder_resultViolations;
        certSubject.text = placeHolder_certSubject;
        certIssue.text = placeHolder_certIssue;
        certExpiry.text = placeHolder_certExpiry;
    }
}

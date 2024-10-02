using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class scanResultScript : MonoBehaviour
{
    public TMP_Text linkBeingScanned;
    public TMP_Text resultLink;
    public TMP_Text resultVerdict;

    // url scanner fields
    public TMP_Text domainAge;
    public TMP_Text redirectsFound;
    // ssl certificates info
    public TMP_Text certSubject;
    public TMP_Text certIssue;
    public TMP_Text certExpiry;
    // security headers info
    public TMP_Text contentSecurityPolicy;
    public TMP_Text strictTransportSecurity;
    public TMP_Text xFrameOptions;

    private string placeHolder_domainAge = "";
    private int placeHolder_redirectsFound = 0;

    private string placeHolder_certSubject = "";
    private string placeHolder_certIssue = "";
    private string placeHolder_certExpiry = "";

    private string state_contentSecurityPolicy = "";
    private string state_strictTransportSecurity = "";
    private string state_xFrameOptions = "";

    public void SetURLParameters(string domainage, int redirects ,string subject, string issue, string expiry, string csp_state, string sts_state, string xfo_state)
    {
        Debug.Log("Being called");
        placeHolder_domainAge = domainage;
        placeHolder_redirectsFound = redirects;
        placeHolder_certSubject = subject;
        placeHolder_certIssue = issue;
        placeHolder_certExpiry = expiry;
        state_contentSecurityPolicy = csp_state;
        state_strictTransportSecurity = sts_state;
        state_xFrameOptions= xfo_state;
        Debug.Log("Being Done");
    }

    public void DisplayResult()
    {
        resultLink.text = linkBeingScanned.text;
        domainAge.text = placeHolder_domainAge;
        redirectsFound.text = System.Convert.ToString(placeHolder_redirectsFound);

        certSubject.text = placeHolder_certSubject;
        certIssue.text = placeHolder_certIssue;
        certExpiry.text = placeHolder_certExpiry;

        contentSecurityPolicy.text = state_contentSecurityPolicy;
        strictTransportSecurity.text = state_strictTransportSecurity;
        xFrameOptions.text = state_xFrameOptions;
    }
}

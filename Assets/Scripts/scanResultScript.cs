using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Globalization;
using System;

public class scanResultScript : MonoBehaviour
{
    public TMP_Text linkBeingScanned;
    public TMP_Text resultLink;
    public TMP_Text resultVerdict;
    public TMP_Text resultViolations;

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

    private DateTime todayDate = DateTime.Today;
    private string grammarError = "";
    private string suspiciousSender = "";
    private string certificateResult = "";

    public void SetURLParameters(string domainage, int redirects ,string subject, 
        string issue, string expiry, string csp_state, string sts_state, string xfo_state, string grammar, string sender)
    {
        placeHolder_domainAge = domainage;
        placeHolder_redirectsFound = redirects;
        placeHolder_certSubject = subject;
        placeHolder_certIssue = issue;
        placeHolder_certExpiry = expiry;
        state_contentSecurityPolicy = csp_state;
        state_strictTransportSecurity = sts_state;
        state_xFrameOptions= xfo_state;
        grammarError = grammar;
        suspiciousSender = sender;
        Debug.Log("URL Params Set");
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
        resultVerdict.text = CalculateSecurityRisk();
        resultViolations.text = System.Convert.ToString(CalculateSecurityViolations());
    }

    public string CalculateSecurityRisk()
    {
        int risklevel = (CalculateSecurityViolations() + CalculateOtherRisk());
        if (risklevel == 0)
        {
            return "Very Low";
        }
        else if (risklevel < 4)
        {
            return "Low";
        }
        else if (risklevel >= 4 && risklevel <= 6)
        {
            return "Medium";
        }
        else
        {

            return "High";
        }
    }

    public int CalculateSecurityViolations()
    {
        int violations = 0;
        if (state_contentSecurityPolicy == "Not Set")
        {
            violations++;
        }
        if (state_strictTransportSecurity == "Not Set")
        {
            violations++;
        }
        if (state_xFrameOptions == "Not Set")
        {
            violations++;
        }
        return violations;
    }

    public int CalculateOtherRisk()
    {
        int riskLevel = 0;
        DateTime certExpiryDate = ParseDate(placeHolder_certExpiry, "yyyy-MM-dd");
        DateTime certIssueDate = ParseDate(placeHolder_certIssue, "yyyy-MM-dd");
        DateTime domainAgeDate = ParseDate(placeHolder_domainAge, "yyyy-MM-dd");

        string certResult = CheckCertificate(certIssueDate, certExpiryDate, todayDate);
        string domainResult = CheckDomainAge(domainAgeDate, todayDate);
        
        if (certResult == "Expired")
        {
            riskLevel += 2;
        }
        if (domainResult == "Too young")
        {
            riskLevel++;
        }
        if (placeHolder_redirectsFound > 3)
        {
            riskLevel++;
        }
        if (CheckSuspiciousSender() == "Yes")
        {
            riskLevel += 2;
        }
        if(CheckGrammar() == "Yes")
        {
            riskLevel++;
        }
        return riskLevel;
    }

    static DateTime ParseDate(string dateString, string format)
    {
        return DateTime.ParseExact(dateString.Trim(), format, CultureInfo.InvariantCulture);
    }
  

    public string CheckCertificate(DateTime issueDate, DateTime expiryDate, DateTime today)
    {
        if (expiryDate < today)
        {
            certificateResult = "Expired";
        }
        else
        {
            certificateResult = "Valid";
        }
        return certificateResult;
    }
    public string CheckDomainAge(DateTime domainAge, DateTime today)
    {
        TimeSpan ageDifference = today - domainAge;
        if (ageDifference.Days < 365)
        {
            return "Too young";
        }
        else
        {
            return "Acceptable";
        }
    }
    public string CheckGrammar()
    {
        return grammarError;
    }
    public string CheckSuspiciousSender()
    {
        return suspiciousSender;
    }
    public string CallCertificateResult()
    {
        return certificateResult;
    }
}

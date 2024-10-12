using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using TMPro;

public class EvaluationScript : MonoBehaviour
{
    public List<Button> yesButtons;  // List of Yes buttons
    public List<Button> noButtons;   // List of No buttons

    public Button lowButton;         // Low risk button
    public Button midButton;         // Medium risk button
    public Button highButton;        // High risk button

    // Initial colors
    private Color defaultColor = Color.white;
    private Color yesColor = Color.green;
    private Color noColor = Color.red;
    private Color lowColor = Color.green;
    private Color midColor = Color.yellow;
    private Color highColor = Color.red;

    // To track the state of each Yes/No button pair
    private bool[] isYesSelected;
    private bool[] isNoSelected;

    // To track the state of the risk level buttons
    private bool isLowSelected = false;
    private bool isMidSelected = false;
    private bool isHighSelected = false;

    private List<List<string>> emailEvaluations = new List<List<string>>();
    private List<Color[]> yesButtonColors = new List<Color[]>();
    private List<Color[]> noButtonColors = new List<Color[]>();
    private List<Color[]> riskButtonColors = new List<Color[]>();
    private int currentEmailIndex;

    public TMP_InputField violationsText;
    public scanResultScript scanResultScript;
    public GameObject safeLogo;
    public GameObject warningLogo;

    private List<bool?> emailMarks = new List<bool?>();
    public int emailCount;

   
    void Start()
    {
        
        ResetButtons();

    }
    public void InitializeEmailEvaluationList(int count)
    {
        isYesSelected = new bool[3];
        isNoSelected = new bool[3];
        // For simplicity, assuming you have 5 questions per email and 3 emails
        emailCount = count;
        int numOfEvaluation = 5;

        for (int i = 0; i < count; i++)
        {
            List<string> emailEvaluate = new List<string>(new string[numOfEvaluation]); // initialize with empty strings
            emailEvaluations.Add(emailEvaluate);
            emailMarks.Add(null);

            yesButtonColors.Add(new Color[yesButtons.Count]);
            noButtonColors.Add(new Color[noButtons.Count]);
            riskButtonColors.Add(new Color[] { defaultColor, defaultColor, defaultColor });

            // Set all to default color initially
            for (int j = 0; j < yesButtons.Count; j++)
            {
                yesButtonColors[i][j] = defaultColor;
                noButtonColors[i][j] = defaultColor;
            }
        }
    }

    // Call this function when loading a new email
    public void SetCurrentEmailIndex(int emailIndex)
    {
        currentEmailIndex = emailIndex;
        ResetButtons();
        for (int i = 0; i < yesButtons.Count; i++)
        {
            yesButtons[i].GetComponent<Image>().color = yesButtonColors[emailIndex][i];
            noButtons[i].GetComponent<Image>().color = noButtonColors[emailIndex][i];
        }

        lowButton.GetComponent<Image>().color = riskButtonColors[emailIndex][0];
        midButton.GetComponent<Image>().color = riskButtonColors[emailIndex][1];
        highButton.GetComponent<Image>().color = riskButtonColors[emailIndex][2];
        violationsText.text = emailEvaluations[currentEmailIndex][4];
    }

    private void ResetButtons()
    {
        // If no evaluation saved for this email, set buttons to default colors
        if (emailEvaluations[currentEmailIndex].TrueForAll(e => e == null || e == "null"))
        {
            for (int i = 0; i < yesButtons.Count; i++)
            {
                yesButtons[i].GetComponent<Image>().color = defaultColor;
                noButtons[i].GetComponent<Image>().color = defaultColor;
            }
            lowButton.GetComponent<Image>().color = defaultColor;
            midButton.GetComponent<Image>().color = defaultColor;
            highButton.GetComponent<Image>().color = defaultColor;
        }
    }

    public void TurnOffButtons()
    {
        for (int i = 0; i < yesButtons.Count; i++)
        {
            yesButtons[i].GetComponent<Image>().color = defaultColor;
            noButtons[i].GetComponent<Image>().color = defaultColor;
        }

        lowButton.GetComponent<Image>().color = defaultColor;
        midButton.GetComponent<Image>().color = defaultColor;
        highButton.GetComponent<Image>().color = defaultColor;

        // Ensure button states are reset as well
        isYesSelected = new bool[yesButtons.Count];
        isNoSelected = new bool[noButtons.Count];
        isLowSelected = false;
        isMidSelected = false;
        isHighSelected = false;
        violationsText.text = "";
    }

    public void ToggleYesButton(int index)
    {
        if (!isYesSelected[index])  // If not selected, turn Yes green and reset No
        {
            yesButtons[index].GetComponent<Image>().color = yesColor;
            noButtons[index].GetComponent<Image>().color = defaultColor;  // Reset No button
            isYesSelected[index] = true;
            isNoSelected[index] = false;
            emailEvaluations[currentEmailIndex][index] = "Yes";

            yesButtonColors[currentEmailIndex][index] = yesColor;
            noButtonColors[currentEmailIndex][index] = defaultColor;
        }
        else  // If already selected, reset color
        {
            yesButtons[index].GetComponent<Image>().color = defaultColor;
            isYesSelected[index] = false;
            emailEvaluations[currentEmailIndex][index] = "null";

            yesButtonColors[currentEmailIndex][index] = defaultColor;
        }
        //Debug.Log($"Button Yes: {index} is pressed");
    }

    // Toggle No button for a specific question index
    public void ToggleNoButton(int index)
    {
        if (!isNoSelected[index])  // If not selected, turn No red and reset Yes
        {
            noButtons[index].GetComponent<Image>().color = noColor;
            yesButtons[index].GetComponent<Image>().color = defaultColor;  // Reset Yes button
            isNoSelected[index] = true;
            isYesSelected[index] = false;
            emailEvaluations[currentEmailIndex][index] = "No";

            noButtonColors[currentEmailIndex][index] = noColor;
            yesButtonColors[currentEmailIndex][index] = defaultColor;
        }
        else  // If already selected, reset color
        {
            noButtons[index].GetComponent<Image>().color = defaultColor;
            isNoSelected[index] = false;
            emailEvaluations[currentEmailIndex][index] = "null";

            noButtonColors[currentEmailIndex][index] = defaultColor;
        }
        //Debug.Log($"Button No: {index} is pressed");
    }

    // Toggle Low button
    public void ToggleLowButton()
    {
        if (!isLowSelected)  // If not selected, turn Low green and reset others
        {
            lowButton.GetComponent<Image>().color = lowColor;
            midButton.GetComponent<Image>().color = defaultColor;
            highButton.GetComponent<Image>().color = defaultColor;
            isLowSelected = true;
            isMidSelected = false;
            isHighSelected = false;
            emailEvaluations[currentEmailIndex][3] = "Low";

            riskButtonColors[currentEmailIndex][0] = lowColor;
            riskButtonColors[currentEmailIndex][1] = defaultColor;
            riskButtonColors[currentEmailIndex][2] = defaultColor;
        }
        else  // If already selected, reset color
        {
            lowButton.GetComponent<Image>().color = defaultColor;
            isLowSelected = false;
            emailEvaluations[currentEmailIndex][3] = "null";
            Debug.Log("nullingLow");
            riskButtonColors[currentEmailIndex][0] = defaultColor;
        }
        //Debug.Log($"Low Button is pressed");
    }

    // Toggle Mid button
    public void ToggleMidButton()
    {
        if (!isMidSelected)  // If not selected, turn Mid yellow and reset others
        {
            midButton.GetComponent<Image>().color = midColor;
            lowButton.GetComponent<Image>().color = defaultColor;
            highButton.GetComponent<Image>().color = defaultColor;
            isMidSelected = true;
            isLowSelected = false;
            isHighSelected = false;
            emailEvaluations[currentEmailIndex][3] = "Medium";

            riskButtonColors[currentEmailIndex][0] = defaultColor;
            riskButtonColors[currentEmailIndex][1] = midColor;
            riskButtonColors[currentEmailIndex][2] = defaultColor;
        }
        else  // If already selected, reset color
        {
            midButton.GetComponent<Image>().color = defaultColor;
            isMidSelected = false;
            emailEvaluations[currentEmailIndex][3] = "null";
            Debug.Log("nullingMid");
            riskButtonColors[currentEmailIndex][1] = defaultColor;
        }
        //Debug.Log($"Mid Button is pressed");
    }

    // Toggle High button
    public void ToggleHighButton()
    {
        if (!isHighSelected)  // If not selected, turn High red and reset others
        {
            highButton.GetComponent<Image>().color = highColor;
            lowButton.GetComponent<Image>().color = defaultColor;
            midButton.GetComponent<Image>().color = defaultColor;
            isHighSelected = true;
            isLowSelected = false;
            isMidSelected = false;
            emailEvaluations[currentEmailIndex][3] = "High";

            riskButtonColors[currentEmailIndex][0] = defaultColor;
            riskButtonColors[currentEmailIndex][1] = defaultColor;
            riskButtonColors[currentEmailIndex][2] = highColor;
        }
        else  // If already selected, reset color
        {
            highButton.GetComponent<Image>().color = defaultColor;
            isHighSelected = false;
            emailEvaluations[currentEmailIndex][3] = "null";
            Debug.Log("nullingHigh");
            riskButtonColors[currentEmailIndex][2] = defaultColor;
        }
        //Debug.Log($"High Button is pressed");
    }

    public void MarkAsSafe()
    {
        AnswerChecker();
        Debug.Log("Marked as Safe");
        emailMarks[currentEmailIndex] = false;
        ToggleEmailMark(false);
    }

    public void MarkAsPhishing()
    {
        AnswerChecker();
        Debug.Log("Marked as Phishing");
        emailMarks[currentEmailIndex] = true;
        ToggleEmailMark(true);
    }

    private void AnswerChecker()
    {
        List<string> evaluations = emailEvaluations[currentEmailIndex];
        string grammarError = scanResultScript.CheckGrammar();
        string suspiciousSender = scanResultScript.CheckSuspiciousSender();
        string risk = scanResultScript.CalculateSecurityRisk();
        int violations = scanResultScript.CalculateSecurityViolations();
        int violationsInputed = 0;
        try
        {
            violationsInputed = System.Convert.ToInt32(violationsText.text);
            emailEvaluations[currentEmailIndex][4] = violationsText.text;
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
        string certResult = scanResultScript.CallCertificateResult();

        if (evaluations[0] == grammarError)
        {
            Debug.Log($"Number 1 is correct because {evaluations[0]} = {grammarError}");
        }
        else
        {
            Debug.Log("Number 1 is incorrect");
        }

        if (evaluations[1] == suspiciousSender)
        {
            Debug.Log($"Number 2 is correct because {evaluations[1]} = {suspiciousSender}");
        }
        else
        {
            Debug.Log("Number 2 is incorrect");
        }

        if (evaluations[3] == risk)
        {
            Debug.Log($"Number 3 is correct because {risk} = {evaluations[3]}");
        }
        else
        {
            Debug.Log($"Number 3 is incorrect becauese {risk} not {evaluations[3]}");
        }

        if (violationsInputed == violations)
        {
            Debug.Log($"Number 4 is correct because {violationsInputed} = {violations}");
        }
        else
        {
            Debug.Log($"Number 4 is incorrect becauese {violationsInputed} not {violations}");
        }

        if (evaluations[2] == "Yes" && certResult == "Expired")
        {
            Debug.Log($"Number 5 is correct because certificate is indeed expired");
        }
        else if (evaluations[2] == "No" && certResult == "Valid")
        {
            Debug.Log($"Number 5 is correct because certificate is indeed not expired");
        }
        else
        {
            Debug.Log($"Number 5 is incorrect");
        }
    }

    public void ToggleEmailMark(bool isPhishing)
    {
        if (isPhishing)
        {
            // Show warning logo, hide safe logo
            safeLogo.SetActive(false);
            warningLogo.SetActive(true);
        }
        else
        {
            // Show safe logo, hide warning logo
            warningLogo.SetActive(false);
            safeLogo.SetActive(true);
        }
    }

    public void DisplayEmailMark()
    {
        bool? mark = emailMarks[currentEmailIndex];

        if (mark.HasValue)
        {
            // If the email is marked, show the appropriate logo
            ToggleEmailMark(mark.Value);
        }
        else
        {
            // No mark saved, hide both logos
            warningLogo.SetActive(false);
            safeLogo.SetActive(false);
        }
    }

    public class EmailData
    {
        public bool? Mark { get; set; }
        public List<string> Evaluation { get; set; }

        public EmailData(bool? mark, List<string> evaluation)
        {
            Mark = mark;
            Evaluation = evaluation;
        }
    }
    public EmailData GetEmailData(int currentEmailIndex)
    {
        bool? emailMark = emailMarks[currentEmailIndex];
        List<string> emailEvaluation = emailEvaluations[currentEmailIndex];

        return new EmailData(emailMark, emailEvaluation);
    }

    public List<string> GetEmailEvaluations(int currentEmailIndex)
    {
        // Ensure the index is within bounds
        if (currentEmailIndex < 0 || currentEmailIndex >= emailEvaluations.Count)
        {
            return new List<string>(); // Return an empty list if the index is out of bounds
        }

        List<string> emailEvaluation = emailEvaluations[currentEmailIndex];
        return emailEvaluation;
    }

    public class EmailButtonState
    {
        public string Evaluation { get; set; }  // "Yes", "No", or "null"
        public Color ButtonColor { get; set; }  // Color of the button

        public EmailButtonState(string evaluation, Color buttonColor)
        {
            Evaluation = evaluation;
            ButtonColor = buttonColor;
        }
    }

}

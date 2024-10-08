using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

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
    private int currentEmailIndex;


    void Start()
    {
        InitializeEmailEvaluationList();

        // Initialize Yes/No buttons state tracking
        int numberOfQuestions = yesButtons.Count;
        isYesSelected = new bool[numberOfQuestions];
        isNoSelected = new bool[numberOfQuestions];

        ResetButtons();
    }
    private void InitializeEmailEvaluationList()
    {
        // For simplicity, assuming you have 5 questions per email and 3 emails
        int numOfEmails = 2;
        int numOfEvaluation = 4;

        for (int i = 0; i < numOfEmails; i++)
        {
            List<string> emailEvaluate = new List<string>(new string[numOfEvaluation]); // initialize with empty strings
            emailEvaluations.Add(emailEvaluate);
        }
    }

    // Call this function when loading a new email
    public void SetCurrentEmailIndex(int emailIndex)
    {
        currentEmailIndex = emailIndex;
        // Reset buttons to the default state
        ResetButtons();
    }

    // Resets the colors of buttons when switching emails
    private void ResetButtons()
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

    // Toggle Yes button for a specific question index
    public void ToggleYesButton(int index)
    {
        if (!isYesSelected[index])  // If not selected, turn Yes green and reset No
        {
            yesButtons[index].GetComponent<Image>().color = yesColor;
            noButtons[index].GetComponent<Image>().color = defaultColor;  // Reset No button
            isYesSelected[index] = true;
            isNoSelected[index] = false;
            emailEvaluations[currentEmailIndex][index] = "Yes";
        }
        else  // If already selected, reset color
        {
            yesButtons[index].GetComponent<Image>().color = defaultColor;
            isYesSelected[index] = false;
            emailEvaluations[currentEmailIndex][index] = "null";
        }
        Debug.Log($"Button Yes: {index} is pressed");
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
        }
        else  // If already selected, reset color
        {
            noButtons[index].GetComponent<Image>().color = defaultColor;
            isNoSelected[index] = false;
            emailEvaluations[currentEmailIndex][index] = "null";
        }
        Debug.Log($"Button No: {index} is pressed");
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
        }
        else  // If already selected, reset color
        {
            lowButton.GetComponent<Image>().color = defaultColor;
            isLowSelected = false;
            emailEvaluations[currentEmailIndex][3] = "null";
        }
        Debug.Log($"Low Button is pressed");
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
            emailEvaluations[currentEmailIndex][3] = "Mid";
        }
        else  // If already selected, reset color
        {
            midButton.GetComponent<Image>().color = defaultColor;
            isMidSelected = false;
            emailEvaluations[currentEmailIndex][3] = "null";
        }
        Debug.Log($"Mid Button is pressed");
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
        }
        else  // If already selected, reset color
        {
            highButton.GetComponent<Image>().color = defaultColor;
            isHighSelected = false;
            emailEvaluations[currentEmailIndex][3] = "null";
        }
        Debug.Log($"High Button is pressed");
    }

    public void DisplayEvaluations()
    {
        // Get the evaluations for the selected email
        List<string> evaluations = emailEvaluations[currentEmailIndex];

        // Log each evaluation
        Debug.Log($"Evaluations for email {currentEmailIndex}:");
        for (int i = 0; i < evaluations.Count; i++)
        {
            Debug.Log($"Question {i + 1}: {evaluations[i]}");
        }
    }

}

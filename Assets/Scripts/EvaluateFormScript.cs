using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static EvaluationScript;

public class EvaluateFormScript : MonoBehaviour
{
    public GameObject evaluationDisplay;     
    public bool isPressed = false;
    public int currentEmailIndex;
    public EvaluationScript evaluationScript;

    private void Start()
    {
        evaluationDisplay.SetActive(false); 
    }

    public void displayEvaluationForm()
    {
        if (isPressed)
        {
            evaluationDisplay.SetActive(false); 
        }
        else
        {
            evaluationDisplay.SetActive(true);   
        }

        isPressed = !isPressed;  
    }
    public void DisplayAnswer()
    {
        // Get the data for the current email
        EmailData emailData = evaluationScript.GetEmailData(currentEmailIndex);

        Debug.Log("Evaluation for this email:");

        // Display the mark
        if (emailData.Mark.HasValue)
        {
            if (emailData.Mark.Value)
            {
                Debug.Log("Marked as Phishing");
            }
            else
            {
                Debug.Log("Marked as Safe");
            }
        }
        else
        {
            Debug.Log("Email is unmarked");
        }
        
        foreach (var evaluation in emailData.Evaluation)
        {
            Debug.Log(evaluation);
        }
    }
}

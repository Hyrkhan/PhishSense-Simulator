using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvaluateFormScript : MonoBehaviour
{
    public GameObject evaluationDisplay;     
    public bool isPressed = false;  

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
}

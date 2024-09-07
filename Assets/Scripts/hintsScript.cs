using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hintsScript : MonoBehaviour
{
    [System.Serializable]
    public class Hints
    {
        public GameObject hintsContainer;
    }

    public List<Hints> hints;
    public GameObject hintDisplay;
    public int hintIndex = 0;
    public bool isPressed;

    /* im having problem, this function wont work, it has to be displayed when the hints button is pressed and then it will
        call a function and display the hintsDisplay container with the corresponding hint based on the index
     */

    private void Start()
    {
        isPressed = true;
    }
    public void displayHint()
    {
        if (isPressed)
        {
            hints[hintIndex].hintsContainer.SetActive(true);
            hintDisplay.SetActive(true);
            isPressed = false;
        }
        else
        {
            hints[hintIndex].hintsContainer.SetActive(false);
            hintDisplay.SetActive(false);
            isPressed = true;
        }
    }

}

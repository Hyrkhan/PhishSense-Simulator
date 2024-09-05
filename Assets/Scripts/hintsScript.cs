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

    /* im having problem, this function wont work, it has to be displayed when the hints button is pressed and then it will
        call a function and display the hintsDisplay container with the corresponding hint based on the index
     */
    public void displayHint(int index)
    {
        foreach (var hint in hints)
        {
            hint.hintsContainer.SetActive(false);
            hintDisplay.SetActive(false);
        }

        if (index > 0)
        {
            hints[index-1].hintsContainer.SetActive(true);
            hintDisplay.SetActive(true);
        }

    }
}

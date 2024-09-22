using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualScript : MonoBehaviour
{
    public GameObject MainMenuScreen;
    public GameObject ManualScreen;

    // List of all the pages/screens in your manual
    public List<GameObject> manualPages;

    // Current page index
    private int currentIndex = 0;

    private void Start()
    {
        // Initially display the first page
        if (manualPages.Count > 0)
        {
            DisplayPage(currentIndex);
        }
    }

    // Function to open the manual
    public void OpenManual()
    {
        MainMenuScreen.SetActive(false);
        ManualScreen.SetActive(true);
        DisplayPage(currentIndex); // Ensure the correct page is shown
    }

    // Function to exit the manual
    public void ExitManual()
    {
        ManualScreen.SetActive(false);
        MainMenuScreen.SetActive(true);
    }

    // Navigate to the next page
    public void NextPage()
    {
        if (currentIndex < manualPages.Count - 1)
        {
            currentIndex++;
            DisplayPage(currentIndex);
        }
    }

    // Navigate to the previous page
    public void PrevPage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            DisplayPage(currentIndex);
        }
    }

    // Display the page at the specified index and hide the rest
    private void DisplayPage(int index)
    {
        // Loop through all pages and set active state
        for (int i = 0; i < manualPages.Count; i++)
        {
            if (i == index)
            {
                manualPages[i].SetActive(true);  // Show the current page
            }
            else
            {
                manualPages[i].SetActive(false); // Hide all other pages
            }
        }
    }
}

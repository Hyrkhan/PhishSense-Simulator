using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class detectionScript : MonoBehaviour
{
    public TMP_Text urlLink;
    public TMP_Text clipboard;
    public TMP_InputField searchBox;
    public TMP_InputField VMsearchBox;
    private string copyLink = "";

    void Update()
    {
        clipboard.text = copyLink;
    }

    public void CopyLink()
    {
        copyLink = urlLink.text;
        Debug.Log($"Link has been copied: {copyLink}");
    }
    public void PasteLink1()
    {
        searchBox.text = copyLink;
    }
    public void PasteLink2()
    {
        VMsearchBox.text = copyLink;
    }
}

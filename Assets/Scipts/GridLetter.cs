using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridLetter : MonoBehaviour
{
    public TextMeshProUGUI lettertext;
    private WordSearchManager wordSearchManager;
    bool isClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        wordSearchManager = FindObjectOfType<WordSearchManager>();
    }

    public void OnLetterClick()
    {
        string selectedLetter = lettertext.text;
        wordSearchManager.AddLetterToSelection(selectedLetter);

        lettertext.color = Color.red;
        
    }
    public void ResetColor()
    {
        lettertext.color = Color.white;
    }
}

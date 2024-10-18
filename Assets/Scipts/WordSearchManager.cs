using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordSearchManager : MonoBehaviour
{
    public GameObject gridLetterPrefab;
    public Transform wordGrid;
    public TextMeshProUGUI wordListText;

    private string[,] grid;
    private Trie wordTrie;
    private List<string> wordsToFind = new List<string> { "UNITY", "GAME", "TRIE", "CODE", "SEARCH" };
    private List<string> selectedLetters = new List<string>();

    private int gridSize = 10; //example size

    void Start()
    {
        wordTrie = new Trie();
        foreach (string word in wordsToFind)
        {
            wordTrie.Insert(word);
        }
        PopulateGrid();
        DisplayWords();
    }
    private void PopulateGrid()
    {
        grid = new string[gridSize, gridSize];

        //for simplicity, randomly place letters into the grid
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                grid[i, j] = ((char)Random.Range(65, 91)).ToString(); // random letter a-z
                CreateGridLetter(i, j, grid[i, j]);
            }

        }
        //you would also add logic here to place actual words into the grid
        //for now its randomly generated
    }
    void CreateGridLetter(int row, int col, string letter)
    {
        GameObject gridLetter = Instantiate(gridLetterPrefab, wordGrid);
        gridLetter.GetComponent<TextMeshProUGUI>().text = letter;
    }
    private void DisplayWords()
    {
        wordListText.text = "Find the following word:\n";
        foreach (string word in wordsToFind)
        {
            wordListText.text += word + "\n";
        }
    }
    public void AddLetterToSelection(string letter)
    {
        selectedLetters.Add(letter);
        Debug.Log("Selected word: " + GetCurrentSelectedWord());
    }
    public string GetCurrentSelectedWord()
    {
        return string.Join("", selectedLetters);
    }
    public void CheckSelectedWord()
    {
        string currentWord = GetCurrentSelectedWord();
        if (wordTrie.Search(currentWord))
        {
            Debug.Log("Word found: " + currentWord);
            //optionally, update the UI to show words been found
            foreach (string word in wordsToFind)
            {
                if (word == currentWord)
                {
                    wordsToFind.Remove(word);
                    DisplayWords();

                    if (wordsToFind.Count == 0)
                    {
                        Debug.Log("well done");
                    }
                }
            }
            
        }
        else
        {
            Debug.Log("Word not found: " + currentWord);
            // reset the selection but allow player to try again     
        }
        // reselt the selection and color
        ClearSelectedLetters();
    }
    public void ClearSelectedLetters()
    {
        selectedLetters.Clear();
        ResetGridColors();
    }
    public void ResetGridColors()
    {
        foreach (GridLetter letter in wordGrid.GetComponentsInChildren<GridLetter>())
        {
            letter.ResetColor();
        }
    }

  
}

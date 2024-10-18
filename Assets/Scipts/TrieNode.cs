using System.Collections.Generic;
using UnityEngine;

public class TrieNode : MonoBehaviour
{
    public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    public bool isEndOfWord = false;
}

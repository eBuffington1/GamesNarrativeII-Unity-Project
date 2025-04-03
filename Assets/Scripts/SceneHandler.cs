using UnityEngine;
using System.Collections.Generic;

public class SceneHandler : MonoBehaviour
{
    public struct WordSlot
    {
        public GameObject WordBox;
        public string Word;

        public WordSlot (GameObject wordBox)
        {
            WordBox = wordBox;
            Word = null;
        }
    }

    List<WordSlot> _wordBoxList = new List<WordSlot>();
    WordSlot _createWordBox;

    public void AddWordBoxToList (GameObject wordBox)
    {
        _createWordBox = new WordSlot(wordBox);
        _wordBoxList.Add(_createWordBox);
    }

}

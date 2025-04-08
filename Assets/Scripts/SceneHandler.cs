using UnityEngine;
using System.Collections.Generic;

public class WordSlot
{
    public GameObject WordBox;
    public Select Word = Select.Blank;
}

public class SceneHandler : MonoBehaviour
{
    //public struct WordSlot
    //{
    //    public GameObject WordBox;
    //    public Select Word;

    //    public WordSlot (GameObject wordBox)
    //    {
    //        WordBox = wordBox;
    //        Word = Select.Blank;
    //    }
    //}

    public List<WordSlot> _wordBoxList = new List<WordSlot>();

    GameController gameController;
    PlayerInteraction playerInteraction;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        playerInteraction = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerInteraction>();

        if (playerInteraction)
        {
            playerInteraction.onInteractObject.AddListener(OnInteraction);
        }
    }

    private void OnEnable()
    {
        // Subscribe to player interaction event
        if (playerInteraction)
        {
            playerInteraction.onInteractObject.AddListener(OnInteraction);
        }
    }

    private void OnDisable()
    {
        // Unsubscribe to player interaction event
        if (playerInteraction)
        {
            playerInteraction.onInteractObject.RemoveListener(OnInteraction);
        }
    }

    public void AddWordBoxToList (GameObject wordBox)
    {
        _wordBoxList.Add(new WordSlot { WordBox = wordBox });
    }

    public void RemoveWordBoxFromList (GameObject wordBox)
    {
        for (int i = 0; i < _wordBoxList.Count; i++)
        {
            if (_wordBoxList[i].WordBox == wordBox)
            {
                _wordBoxList.RemoveAt(i);
            }
        }
    }

    void OnInteraction (GameObject gameObject)
    {

        // INTERACTION FOR WORDBOX
        if(gameObject.tag == "WordBox")
        {
            WordBoxInteraction(gameObject);
        }
    }

    void WordBoxInteraction (GameObject gameObject)
    {
        WordBox wordBox = gameObject.GetComponent<WordBox>();

        // Find wordbox in list
        for (int i = 0; i < _wordBoxList.Count; i++)
        {
            if (_wordBoxList[i].WordBox == gameObject)
            {
                // If wordbox already has curWord, remove it
                if(wordBox.heldWord == gameController.curSelection)
                {
                    RemoveWord(gameObject, i);
                }
                // Otherwise add curWord
                else
                {
                    AddWord(gameObject, i);
                }

                break;
            }
        }
    }

    void RemoveWord(GameObject gameObject, int listPos)
    {
        WordBox wordBox = gameObject.GetComponent<WordBox>();

        // Update word box visual
        wordBox.RemoveWord();

        // Update wordbox list
        _wordBoxList[listPos].Word = Select.Blank;
    }

    void AddWord(GameObject gameObject, int listPos)
    {
        WordBox wordBox = gameObject.GetComponent<WordBox>();

        // Remove other word boxes that contains word
        for (int i = 0; i < _wordBoxList.Count; i++)
        {
            // Skip current word
            if (i == listPos)
            {
                continue;
            }

            // Remove duplicate word, break since there should be only one other word
            if (_wordBoxList[i].Word == gameController.curSelection)
            {
                RemoveWord(_wordBoxList[i].WordBox, i);
                break;
            }
        }

        // Update word box visual
        wordBox.ReceiveWord(gameController.curSelection);

        // Update word box list
        _wordBoxList[listPos].Word = gameController.curSelection;
    }

}


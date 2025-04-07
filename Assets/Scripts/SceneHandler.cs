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
                    wordBox.RemoveWord();

                    _wordBoxList[i].Word = Select.Blank;
                }
                // Otherwise add curWord
                else
                {
                    wordBox.RemoveWord();
                    wordBox.ReceiveWord(gameController.curSelection);

                    _wordBoxList[i].Word = gameController.curSelection;
                }

                break;
            }
        }
    }
}


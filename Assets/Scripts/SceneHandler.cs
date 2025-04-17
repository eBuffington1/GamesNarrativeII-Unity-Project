using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public class WordSlot
{
    public GameObject WordBox;
    public Select Word = Select.Blank;
}

public class SceneHandler : MonoBehaviour
{

    public List<WordSlot> _wordBoxList = new List<WordSlot>();

    // Send event of updated words, true = added, false = removed
    //public UnityEvent<GameObject, bool> onUpdateWordBox;
    public event Action<GameObject> onUpdateWordBox;

    GameController gameController;
    PlayerInteraction playerInteraction;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        //if(onUpdateWordBox == null)
        //{
        //    onUpdateWordBox = new UnityEvent<GameObject, bool>();
        //}
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

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


    public void WordBoxInteraction (GameObject gameObject)
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

    void InteractableInteraction (GameObject gameObject)
    {

    }

    void RemoveWord(GameObject gameObject, int listPos)
    {
        WordBox wordBox = gameObject.GetComponent<WordBox>();

        // Update word box visual
        wordBox.RemoveWord();

        // Update wordbox list
        _wordBoxList[listPos].Word = Select.Blank;

        // Invoke signal to level controllers
        //onUpdateWordBox.Invoke(gameObject, false);
        onUpdateWordBox?.Invoke(gameObject);
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

        // Invoke signal to level controllers
        //onUpdateWordBox.Invoke(gameObject, true);
        onUpdateWordBox?.Invoke(gameObject);
    }

    public Select GetValueOfWordBox (GameObject wordBox)
    {
        // Find box, return it's position
        for (int i = 0; i < _wordBoxList.Count; i++)
        {
            if(wordBox == _wordBoxList[i].WordBox)
            {
                return _wordBoxList[i].Word;
            }
        }

        // Return blank if error otherwise
        Debug.Log("Could not find " + wordBox.name + " in list");
        return Select.Blank;
    }
}


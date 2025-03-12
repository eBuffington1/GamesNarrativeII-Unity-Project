using Unity.VisualScripting;
using UnityEngine;

public class WordBox : MonoBehaviour
{
    private string _linkedWord;

    [SerializeField]
    string _section;

    [SerializeField]
    GameObject _dialogueBox;

    [SerializeField]
    GameObject _sceneHandlerObject;
    SceneHandler _sceneHandler;

    [SerializeField]
    string _identifier;


    private void Awake()
    {
        _sceneHandlerObject = GameObject.Find("Scene Handler");
        _sceneHandler = _sceneHandlerObject.GetComponent<SceneHandler>();
    }

    void LinkedWord(string word)
    {
        
        _linkedWord = word;

        // NEW DIALOGUE CODE
        if (_dialogueBox != null)
        {
            _dialogueBox.SendMessage("GotWord", word);
        }

        _sceneHandler.ReceiveWord(gameObject, word, _section);
    }

    void Removed()
    {
        _linkedWord = null;

        // Direct Dialogue box
        if (_dialogueBox != null)
        {
            _dialogueBox.SendMessage("GotWord", "");
        }

        _sceneHandler.RemoveWord(gameObject, _section);

    }


    private void OnValidate()
    {
        this.name = "Box_" + _identifier;
    }
}

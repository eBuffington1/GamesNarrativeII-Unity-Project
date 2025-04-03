using TMPro;
using UnityEngine;

public class CharDialogueBox : MonoBehaviour
{
    private TextMeshPro _text;
    private SpriteRenderer _spriteRenderer;

    //[SerializeField]
    //private bool _isActive = false;

    [SerializeField]
    private string[] _keyWord = { "Scared" };

    [SerializeField]
    private string[] _dialogue;

    [SerializeField]
    private string _defaultDialogue;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshPro>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        
        
        if(_defaultDialogue != "")
        {
            UpdateText(_defaultDialogue);
        }
        else
        {
            UpdateText("");
        }

            ResizeBackdrop();
        
    }

    //void GotWord(string word)
    //{
    //    if (word == "")
    //    {
    //        if (_defaultDialogue != "")
    //        {
    //            UpdateText(_defaultDialogue);
    //        }
    //        else
    //        {
    //            EndText();
    //        }
    //    }
    //    else
    //    {
    //        for (int i = 0; i < _keyWord.Length; i++)
    //        {
    //            if (_keyWord[i] == word)
    //            {
    //                UpdateText(_dialogue[i]);
    //                break;
    //            }
    //        }
    //    }
    //}

    void UpdateText(string String)
    {
        //_isActive = true;
        _text.text = String;
        ResizeBackdrop();
    }

    void EndText()
    {
        //_isActive = false;
        _text.text = "";
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x, 0);
    }

    void ResizeBackdrop()
    {
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x, _text.preferredHeight);
    }

}

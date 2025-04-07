using TMPro;
using UnityEngine;

public class WordBox : MonoBehaviour
{
    private GameObject _sceneHandlerObject;
    private SceneHandler _sceneHandler;

    [SerializeField] GameObject _textBackdrop;
    [SerializeField] GameObject _textObject;
    TextMeshPro _textTMP;

    public Select heldWord = Select.Blank;

    private void Awake()
    {
        _sceneHandlerObject = GameObject.Find("Scene_Handler");
        _sceneHandler = _sceneHandlerObject.GetComponent<SceneHandler>();

        _textTMP = _textObject.GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        _sceneHandler.AddWordBoxToList(this.gameObject);

        _textTMP.text = "test";
    }

    private void OnEnable()
    {
        _sceneHandler.AddWordBoxToList(this.gameObject);
    }

    private void OnDisable()
    {
        
    }

    public void ReceiveWord(Select word)
    {
        Debug.Log("Received " + word);

        heldWord = word;

        // UPDATE VISUALS
        _textBackdrop.SetActive(true);
        _textObject.SetActive(true);

        switch (word)
        {
            case Select.Joy:
                _textTMP.text = "Joy";
                break;
            case Select.Fear:
                _textTMP.text = "Fear";
                break;
            default:
                Debug.Log("Invalid word received at " + this.name);
                break;
        }
    }

    public void RemoveWord()
    {
        Debug.Log("Word Removed");

        heldWord = Select.Blank;

        // UPDATE VISUALS
        _textBackdrop.SetActive(false);
        _textObject.SetActive(false);
    }
}

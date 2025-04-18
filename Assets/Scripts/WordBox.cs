using TMPro;
using UnityEngine;

public class WordBox : MonoBehaviour
{
    private GameObject _sceneHandlerObject;
    private SceneHandler _sceneHandler;
    private GameObject _playerInteractionObject;
    private PlayerInteraction _playerInteraction;

    [SerializeField] GameObject _textBackdrop;
    [SerializeField] GameObject _textObject;
    TextMeshPro _textTMP;
    SpriteRenderer _textBackdropRender;

    public Select heldWord = Select.Blank;

    [Header("Word Colors")]
    [SerializeField] Color joyColor;
    [SerializeField] Color fearColor;

    private void Awake()
    {
        _textTMP = _textObject.GetComponent<TextMeshPro>();
        _textBackdropRender = _textBackdrop.GetComponent<SpriteRenderer>();

        _sceneHandlerObject = GameObject.Find("Scene_Handler");
        _sceneHandler = _sceneHandlerObject.GetComponent<SceneHandler>();

        _playerInteractionObject = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject;
        if (_playerInteractionObject)
        {
            _playerInteraction = _playerInteractionObject.GetComponent<PlayerInteraction>();
        }
    }

    private void Start()
    {
        _textTMP.text = "test";
    }

    

    private void OnEnable()
    {
        _sceneHandler.AddWordBoxToList(this.gameObject);

        // Subscribe to player interaction
        _playerInteraction.onInteractObject += PlayerInteracted;
    }

    private void OnDisable()
    {
        _sceneHandler.RemoveWordBoxFromList(this.gameObject);

        // Unsubscribe to player interaction
        _playerInteraction.onInteractObject -= PlayerInteracted;
    }

    private void OnDestroy()
    {
        // Unsubscribe to player interaction
        _playerInteraction.onInteractObject -= PlayerInteracted;
    }

    private void PlayerInteracted(GameObject gameObject)
    {
        if (gameObject == this.gameObject)
        {
            _sceneHandler.WordBoxInteraction(this.gameObject);
        }
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
                _textBackdropRender.color = joyColor;
                break;
            case Select.Fear:
                _textTMP.text = "Fear";
                _textBackdropRender.color = fearColor;
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

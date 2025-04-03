using UnityEngine;

public class WordBox : MonoBehaviour
{
    private GameObject _sceneHandlerObject;
    private SceneHandler _sceneHandler;

    private void Awake()
    {
        _sceneHandlerObject = GameObject.Find("Scene_Handler");
        _sceneHandler = _sceneHandlerObject.GetComponent<SceneHandler>();
    }

    private void Start()
    {
        _sceneHandler.AddWordBoxToList(this.gameObject);
    }
}

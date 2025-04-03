using UnityEngine;

public class TopHUD : MonoBehaviour
{
    private GameObject selector;
    private RectTransform selectorRect;
    
    [SerializeField] private GameObject joyWord;
    [SerializeField] private GameObject fearWord;

    void Start()
    {
        selector = GameObject.Find("Selector");
        selectorRect = selector.GetComponent<RectTransform>();

        MoveSelectedWord(Select.Joy);
    }

    void MoveSelectedWord(Select word)
    {
        switch (word)
        {
            case Select.Joy:
                selector.transform.SetParent(joyWord.transform);
                selectorRect.anchoredPosition = new Vector2(0, -100);
                break;
            case Select.Fear:
                selector.transform.SetParent(fearWord.transform);
                selectorRect.anchoredPosition = new Vector2(0, -100);
                break;
            default:
                Debug.Log("Move Selected Word broke");
                break;
        }
    }



}

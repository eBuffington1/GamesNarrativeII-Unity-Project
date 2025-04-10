using UnityEngine;

public class TopHUD : MonoBehaviour
{
    [SerializeField] private GameObject selector;
    private RectTransform selectorRect;

    [SerializeField] private GameObject joyPar;
    [SerializeField] private GameObject joyWord;
    [SerializeField] private GameObject fearPar;
    [SerializeField] private GameObject fearWord;

    
    

    void Awake()
    {
        selectorRect = selector.GetComponent<RectTransform>();

    }

    public void AddWord(Select word)
    {
        switch (word)
        {
            case Select.Joy:
                joyPar.SetActive(true);
                break;
            case Select.Fear:
                fearPar.SetActive(true);
                break;
            default:
                Debug.Log("Add word failed for Top HUD");
                break;
        }
    }

    public void MoveSelectedWord(Select word)
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

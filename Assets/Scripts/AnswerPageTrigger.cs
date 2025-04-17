using UnityEngine;

public class AnswerPageTrigger : MonoBehaviour
{
    Interactable _interactable;
    [SerializeField] GameObject _answerPage;
    bool _pageActive = false;

    private void Start()
    {
        _interactable = GetComponent<Interactable>();
        _interactable.Interacted += TogglePage;
    }

    void TogglePage()
    {
        Debug.Log("Answer Page Triggered");
        if(_pageActive == false)
        {
            _pageActive = true;
            _answerPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(380, -6);
        }
        else if (_pageActive == true)
        {
            ClosePage();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ClosePage();
        }
    }

    void ClosePage()
    {
        if(_pageActive == true)
        {
            _pageActive = false;
            _answerPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(-149, -6);
        }
    }
}

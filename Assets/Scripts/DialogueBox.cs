using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    RectTransform m_RectTransform;
    private TextMeshProUGUI _TMP;
    private string _text;

    bool _active = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();

        _TMP = GetComponentInChildren<TextMeshProUGUI>();
        _text = _TMP.text;

        //EndText();
    }



    void DiaClick()
    {

        EndText();

    }

     public void UpdateText(string _text)
    {
        if(_active == false)
        {
            m_RectTransform.anchoredPosition = new Vector2(0, 0);
            gameObject.SetActive(true);
            _active = true;
        }
        
        _TMP.text += _text;
    }

    public void SetText(string _text)
    {
        if (_active == false)
        {
            m_RectTransform.anchoredPosition = new Vector2(0, 0);
            gameObject.SetActive(true);
            _active = true;
        }

        _TMP.text = _text;
    }

    public void EndText()
    {
        _TMP.text = "";

        if(_active == true)
        {
            m_RectTransform.anchoredPosition = new Vector2(0, -250);
            _active = false;
        }
    }

}

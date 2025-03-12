using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _TextBox;

    [SerializeField]
    private GameObject[] _keyPoints;

    [SerializeField]
    private GameObject[] _wordBoxes;


    private GameObject _linkedWord;
    private Camera myMainCamera;
    private LayerMask _mask;

    void Start()
    {
        myMainCamera = Camera.main;

        _mask = LayerMask.GetMask("CanClick");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayCast();
        }
    }

    void RayCast()
    {
        Ray ray = myMainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, _mask);

        if(hit.collider != null && hit.collider.gameObject.tag == "CanClick")
        {
            ClickedObject(hit.collider.gameObject, hit.point);
            
        }
        else
        {
            MiscClick();
        }
    }

    void ClickedObject(GameObject clicked, Vector2 point)
    {
        // Send message to Clicked function
        clicked.SendMessage("Clicked", point);
    }

    void MiscClick()
    {
        if (_linkedWord != null)
        {
            _linkedWord.SendMessage("Deselect");
            Debug.Log("testA");

        }
        else if (_TextBox != null)
        {
            _TextBox.SendMessage("DiaClick");
        }
    }
}

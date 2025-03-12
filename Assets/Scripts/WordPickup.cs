using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class WordPickup : MonoBehaviour
{
    [SerializeField]
    private string _word;
    
    [SerializeField]
    private Color _baseColor, _highlightColor;

    [SerializeField]
    private bool _linkOnStart = false;

    private bool _isHeld = false;
    private bool _slotted = false;

    [SerializeField]
    private GameObject _overlappedBox;

    private SpriteRenderer _sprite;
    private Camera myMainCamera;
    private Vector3 _mouseOffset;
    private Plane dragPlane;


    private void Start()
    {
        myMainCamera = Camera.main;
        _sprite = GetComponentInChildren<SpriteRenderer>();

        if(_linkOnStart == true)
        {
            Deselect();
        }
    }

    



    private void FixedUpdate()
    {
        if (_isHeld)
        {
            Dragged();
        }
    }

    void Clicked(Vector2 mousePos)
    {
        if (_isHeld == false)
        {
            // If currently slotted, remove it
            if(_slotted == true)
            {
                _overlappedBox.SendMessage("Removed");
                _slotted = false;
            }

            // Setup offset
            _mouseOffset = new Vector3(mousePos.x, mousePos.y, transform.position.z) - transform.position;
            _isHeld = true;

            dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            _mouseOffset = transform.position - camRay.GetPoint(planeDist);

        }
        else if(_isHeld == true)
        {
            Deselect();
        }

    }

    void Deselect()
    {
        if(_isHeld == true)
        {
            _isHeld = false;
        }

        if (_overlappedBox != null)
        {
            // Place word in box
            transform.position = new Vector2(_overlappedBox.transform.position.x, _overlappedBox.transform.position.y);
            _slotted = true;

            // Communicate word to 
            _overlappedBox.SendMessage("LinkedWord", _word);
        }
    }

    void Dragged()
    {
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + _mouseOffset;
    }

    void ForcedOff()
    {
        _slotted = false;
        transform.position -= new Vector3(0.85f, -0.85f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "WordBox")
        {
            _sprite.color = _highlightColor;
            _overlappedBox = collision.gameObject;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "WordBox")
        {
            _sprite.color = _baseColor;
            _overlappedBox = null;

        }

        
    }

    private void OnValidate()
    {
        // Update text in editor
        TextMeshPro TMP = GetComponentInChildren<TextMeshPro>();
        if(TMP == null)
        {

            return;
        }
        TMP.text = _word;

        this.name = "Word_" + _word;

        //_sprite.color = _baseColor;
        GetComponentInChildren<SpriteRenderer>().color = _baseColor;
    }




}

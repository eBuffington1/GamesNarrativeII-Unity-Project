using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    BoxCollider2D _collider;

    public List<GameObject> _interactables = new List<GameObject>();
    //public UnityEvent<GameObject> onInteractObject;

    public event Action<GameObject> onInteractObject;

    private void Start()
    {
        //if (onInteractObject == null)
        //{
        //    onInteractObject = new UnityEvent<GameObject>();
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "WordBox" || collision.tag == "Interact")
        {
            _interactables.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(_interactables.Contains(collision.gameObject) && collision.tag == "WordBox" || collision.tag == "Interact")
        {
            _interactables.Remove(collision.gameObject);
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        
        GameObject _closest = null;
        float _dist = 0;

        // If no interactables nearby, or button wasn't fully performed, end function
        if (!context.performed || _interactables.Count <= 0)
        {
            return;
        }

        // Find closest interactable
        for (int i = 0; i < _interactables.Count; i++)
        {
            // If no object is closest yet, assign it
            if (_closest == null)
            {
                _closest = _interactables[i];
                _dist = Vector2.Distance(_interactables[i].transform.position, this.transform.position);
                continue;
            }

            // If object is closer to player, assign as new closest
            if (Vector2.Distance(_interactables[i].transform.position, this.transform.position) < _dist)
            {
                _closest = _interactables[i];
                _dist = Vector2.Distance(_interactables[i].transform.position, this.transform.position);
            }
        }

        // Invoke event
        onInteractObject?.Invoke(_closest);
    }
}

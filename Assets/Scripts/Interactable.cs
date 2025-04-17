using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    PlayerInteraction _playerInteraction;
    public event Action Interacted;

    private void OnEnable()
    {
        if (!_playerInteraction)
        {
            _playerInteraction = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.GetComponent<PlayerInteraction>();
        }

        // Subscribe to player interaction
        _playerInteraction.onInteractObject += ObjectInteracted;
    }

    private void OnDisable()
    {
        // Unsubscribe to player interaction
        _playerInteraction.onInteractObject -= ObjectInteracted;
    }


    void ObjectInteracted(GameObject gameObject)
    {
        if (gameObject == this.gameObject)
        {
            Interacted?.Invoke();
            Debug.Log(this.gameObject.name + " interacted with");
        }
    }
}

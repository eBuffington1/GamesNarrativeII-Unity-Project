using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _triggeredObject;

    [SerializeField]
    private bool _singleUse = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && _triggeredObject != null)
        {
            _triggeredObject.SendMessage("Triggered");
        }
        
        if(_singleUse == true)
        {
            Destroy(gameObject);
        }
    }
}

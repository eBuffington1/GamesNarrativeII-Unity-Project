using UnityEngine;

public class ClickTrigger : MonoBehaviour
{
    [SerializeField]
    private bool _singleUse = false;

    [SerializeField]
    private GameObject _targetObject;

    private void Clicked()
    {
        _targetObject.SendMessage("Triggered");

        if(_singleUse == true)
        {
            Destroy(gameObject);
        }
    }
}

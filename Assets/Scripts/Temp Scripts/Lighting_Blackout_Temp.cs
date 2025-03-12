using TMPro;
using UnityEngine;

public class Lighting_Blackout_Temp : MonoBehaviour
{
    private TextMeshPro _textMeshPro;
    
    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        _textMeshPro.enabled = false;
    }

    void Triggered()
    {
        _textMeshPro.enabled = true;
    }
}

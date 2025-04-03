using System.Collections;
using UnityEngine;

public class SceneHandler_OLD : MonoBehaviour
{
    [Header("Scene Masters")]
        [SerializeField]
        GameObject _aliceMasterObject;
        AliceHouse _aliceMaster;
    
    [Header("Alice House")]

        [SerializeField]
        GameObject[] _wordBoxesAlice;
    
        [SerializeField]
        string[] _wordAlice;

    [Header("Other")]
        [SerializeField]
        GameObject _blackoutBox;

    private void Awake()
    {
        _aliceMaster = _aliceMasterObject.GetComponent<AliceHouse>();
    }

    private void OnValidate()
    {
        _wordAlice = new string[_wordBoxesAlice.Length];
    }

    public void ReceiveWord(GameObject wordObject, string word, string section)
    {
        if (section == "Alice")
        {
            for (int i = 0; i < _wordBoxesAlice.Length; i++)
            {
                if (wordObject == _wordBoxesAlice[i])
                {
                    _wordAlice[i] = word;
                    _aliceMaster.WordUpdate(wordObject, word);
                    break;
                }
            }

            return;
        }


        // Display error if not found
        Debug.Log("SceneHandler ReceiveWord not found");

    }

    public void RemoveWord(GameObject wordObject, string section)
    {
        if(section == "Alice")
        {
            for (int i = 0; i < _wordBoxesAlice.Length; i++)
            {
                if(wordObject == _wordBoxesAlice[i])
                {
                    _wordAlice[i] = null;
                    _aliceMaster.WordUpdate(wordObject, "remove");
                    break;
                }
            }
        }
    }

    public IEnumerator Blackout(float time)
    {
        Debug.Log("blackout test");
        _blackoutBox.SetActive(true);
        yield return new WaitForSeconds(time);
        _blackoutBox.SetActive(false);
    }
}

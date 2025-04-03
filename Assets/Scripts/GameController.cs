using UnityEngine;
using UnityEngine.InputSystem;

public enum Select { Joy, Fear };

public class GameController : MonoBehaviour
{
    [Header("Word Selection")]
    public Select curSelection;
    [SerializeField] public int maxSelection = 0;

    [Header("UI")]
    [SerializeField] private GameObject topHUD;

    private InputSystem_Actions inputSys;

    private void Start()
    {
        inputSys = new InputSystem_Actions();
    }

    private void OnPrevious()
    {
        // If on leftmost...
        if (curSelection == 0)
        {
            curSelection = (Select)maxSelection;
        }
        else
        {
            curSelection--;
        }
        topHUD.SendMessage("MoveSelectedWord", curSelection);
        Debug.Log("previous to " + curSelection);
    }

    private void OnNext()
    {
        // If on rightmost, reset to start
        if (curSelection == (Select)maxSelection)
        {
            curSelection = 0;
        }
        else
        {
            curSelection++;
        }
        topHUD.SendMessage("MoveSelectedWord", curSelection);
        Debug.Log("next to " + curSelection);
    }

}

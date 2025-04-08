using UnityEngine;
using UnityEngine.InputSystem;

public enum Select {Blank = -1, Joy, Fear };

public class GameController : MonoBehaviour
{
    PlayerInteraction playerInteraction;

    [Header("Word Selection")]
    public Select curSelection = (Select)0;
    [SerializeField] public int maxSelection = 0;

    [Header("UI")]
    [SerializeField] private GameObject topHUD;


    public void OnPrevious(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

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
        //Debug.Log("previous to " + curSelection);
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

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
        //Debug.Log("next to " + curSelection);
    }

}

using UnityEngine;
using UnityEngine.InputSystem;

public enum Select {Blank = -1, Joy, Fear };

public class GameController : MonoBehaviour
{
    PlayerInteraction playerInteraction;

    [Header("Word Selection")]
    [HideInInspector] public Select curSelection = (Select)0;
    [SerializeField] public int maxSelection = 0;

    [Header("UI")]
    [SerializeField] private GameObject topHUDObject;
    private TopHUD topHUD;

    private void Start()
    {

        if (topHUDObject)
        {
            topHUD = topHUDObject.GetComponent<TopHUD>();
        }

        // If starting with no words, don't assign current word
        if (maxSelection == -1)
        {
            curSelection = Select.Blank;
        }
        else
        {
            curSelection = (Select)0;
            topHUD.MoveSelectedWord(curSelection);
        }
    }

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
        topHUD.MoveSelectedWord(curSelection);
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
        topHUD.MoveSelectedWord(curSelection);
        //Debug.Log("next to " + curSelection);
    }

}

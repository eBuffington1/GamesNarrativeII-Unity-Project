using TMPro;
using UnityEngine;

public class UIDebug : MonoBehaviour
{
    TextMeshProUGUI text;

    [SerializeField] GameObject gameConObj;
    GameController gameController;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        if (gameConObj)
        {
            gameController = gameConObj.GetComponent<GameController>();
        }
    }

    private void Update()
    {
        text.text = "CurSelection: " + (int)gameController.curSelection;
    }
}

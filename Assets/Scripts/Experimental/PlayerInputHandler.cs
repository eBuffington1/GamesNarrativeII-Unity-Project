using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset controls;

    [Header("Action Map Name Reference")]
    [SerializeField] private string actionMapName = "Player";

    [Header("Action Name Reference")]
    [SerializeField] private string move = "Move";
    [SerializeField] private string next = "Next";
    [SerializeField] private string previous = "Previous";
    [SerializeField] private string interact = "Interact";

    private InputAction MoveAction;
    private InputAction PreviousAction;
    private InputAction NextAction;
    private InputAction InteractAction;

    public Vector2 MoveInput { get; private set; }

    public bool PreviousTriggered { get; private set; }

    public bool NextTriggered { get; private set; }

    public bool InteractTriggered { get; private set; }

    public static PlayerInputHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        MoveAction = controls.FindActionMap(actionMapName).FindAction(move);
        PreviousAction = controls.FindActionMap(actionMapName).FindAction(previous);
        NextAction = controls.FindActionMap(actionMapName).FindAction(next);
        InteractAction = controls.FindActionMap(actionMapName).FindAction(interact);

        RegisterInputActions();
    }

    private void RegisterInputActions()
    {
        MoveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        MoveAction.canceled += context => MoveInput = Vector2.zero;

        PreviousAction.performed += context => PreviousTriggered = true;
        PreviousAction.canceled += context => PreviousTriggered = false;

        NextAction.performed += context => NextTriggered = true;
        NextAction.canceled += context => NextTriggered = false;

        InteractAction.performed += context => InteractTriggered = true;
        InteractAction.canceled += context => InteractTriggered = false;

    }

    private void OnEnable()
    {
        MoveAction.Enable();
        PreviousAction.Enable();
        NextAction.Enable();
        InteractAction.Enable();
    }

    private void OnDisable()
    {
        MoveAction.Disable();
        PreviousAction.Disable();
        NextAction.Disable();
        InteractAction.Disable();
    }
}

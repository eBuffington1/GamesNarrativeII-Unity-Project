using UnityEngine;

public class ch_2_level : MonoBehaviour
{
    private SceneHandler sceneHandler;

    [Header("Driveway")]
    [SerializeField] GameObject drivewayBoxAlice;
    [SerializeField] GameObject drivewayBoxDerek;
    [SerializeField] GameObject drivewayDialogueAlice;
    [SerializeField] GameObject drivewayDialogueDerek;

    [Header("Entryway")]
    [SerializeField] GameObject entrywayBoxAlice;
    [SerializeField] GameObject entrywayBoxDerek;
    [SerializeField] GameObject entrywayDialogueAlice;
    [SerializeField] GameObject entrywayDialogueDerek;

    [Header("Dining Room")]
    [SerializeField] GameObject diningBoxAlice;
    [SerializeField] GameObject diningDialogueAlice;

    [Header("Kitchen")]
    [SerializeField] GameObject kitchingBoxAlice;
    [SerializeField] GameObject kitchenDialogueAlice;

    [Header("Living Room")]
    [SerializeField] GameObject livingBoxAlice;
    [SerializeField] GameObject livingDialogueAlice;

    private void Start()
    {
        sceneHandler = gameObject.GetComponent<SceneHandler>();
        sceneHandler.onUpdateWordBox.AddListener(SceneUpdated);
    }

    private CharDialogueBox GetCharDialogue(GameObject dialogueObject)
    {
        return dialogueObject.GetComponent<CharDialogueBox>();
    }

    private void SceneUpdated(GameObject gameObject, bool action)
    {
        // ADD WORDS
        if (action)
        {
            // DRIVEWAY
            if (gameObject == drivewayBoxAlice)
            {
                
            }
            else if (gameObject == drivewayBoxDerek)
            {

            }
            // ENTRYWAY
            else if (gameObject == entrywayBoxAlice)
            {

            }
            else if (gameObject == entrywayBoxDerek)
            {

            }
            // DINING ROOM
            else if (gameObject == diningBoxAlice)
            {

            }
        }
        // REMOVE WORDS
        if (!action)
        {

        }
    }

    void DrivewayAliceAdd()
    {

    }

    void DrivewayAliceRemove()
    {

    }

    void DrivewayDerekAdd()
    {

    }







}

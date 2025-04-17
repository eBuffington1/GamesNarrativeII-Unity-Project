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
        sceneHandler.onUpdateWordBox += SceneUpdated;
    }

    private void SetCharDialogue(GameObject dialogueObject, string dialogue)
    {
        dialogueObject.GetComponent<CharDialogueBox>().UpdateText(dialogue);
    }

    private void ClearCharDialogue(GameObject dialogueObject)
    {
        dialogueObject.GetComponent<CharDialogueBox>().EndText();
    }

    private Select GetBoxValue(GameObject gameObject)
    {
        return sceneHandler.GetValueOfWordBox(gameObject);
    }

    private void SceneUpdated(GameObject gameObject)
    {

        // DRIVEWAY
        if (gameObject == drivewayBoxAlice || gameObject == drivewayBoxDerek)
        {
            Driveway();
        }
        // ENTRYWAY
        else if (gameObject == entrywayBoxAlice || gameObject == entrywayBoxDerek)
        {
            Entryway();
        }
        // DINING ROOM
        else if (gameObject == diningBoxAlice)
        {
            DiningRoom();
        }
        // KITCHEN
        else if (gameObject == kitchingBoxAlice)
        {
            Kitchen();
        }
        // LIVING ROOM
        else if (gameObject == livingBoxAlice)
        {
            LivingRoom();
        }
    }

    void Driveway()
    {
        // If Alice empty, clear dialogue
        if(GetBoxValue(drivewayBoxAlice) == Select.Blank)
        {
            ClearCharDialogue(drivewayDialogueAlice);
        }

        // If Derek empty, clear dialogue
        if(GetBoxValue(drivewayBoxDerek) == Select.Blank)
        {
            ClearCharDialogue(drivewayDialogueDerek);
        }

        // Alice Joy
        if(GetBoxValue(drivewayBoxAlice) == Select.Joy)
        {
            SetCharDialogue(drivewayDialogueAlice, "Come one! Look at this, a royal invitation to tour this beautiful house! We are free to do whatever we please in here!");
        }

        // Alice Fear
        if (GetBoxValue(drivewayBoxAlice) == Select.Fear)
        {
            SetCharDialogue(drivewayDialogueAlice, "Just got to be quick... Get in, grab some goodies, get out. Old man will probably take forever to catch up.");
        }

        // Derek Joy
        if(GetBoxValue(drivewayBoxDerek) == Select.Joy)
        {
            SetCharDialogue(drivewayDialogueDerek,
                "One, two, three, four hundred dollar bills. That guy has to learn not to keep so much money in his wallet. Three hundred dollars should be enough for us to split, I won't take it all");
        }

        // Derek Fear
        if (GetBoxValue(drivewayBoxDerek) == Select.Fear)
        {
            SetCharDialogue(drivewayDialogueDerek, "Alice, I really don't think we should do this. We already stole his money, isn't this taking it too far?");
        }
    }

    void Entryway()
    {
        if(GetBoxValue(entrywayBoxAlice) == Select.Blank)
        {
            ClearCharDialogue(entrywayDialogueAlice);
        }

        if(GetBoxValue(entrywayBoxDerek) == Select.Blank)
        {
            ClearCharDialogue(entrywayDialogueDerek);
        }

        // Alice Joy
        if(GetBoxValue(entrywayBoxAlice) == Select.Joy)
        {
            SetCharDialogue(entrywayDialogueAlice, "Oh, come on! It'll be fun! How about this, lets split up and scout out what complementary goods are available!");
        }

        // Alice Fear
        if(GetBoxValue(entrywayBoxAlice) == Select.Fear)
        {
            SetCharDialogue(entrywayDialogueAlice, "(thinking) Please just shup up and loot this house, you're wasting too much time.");
        }

        // Derek Joy
        if (GetBoxValue(entrywayBoxDerek) == Select.Joy)
        {
            SetCharDialogue(entrywayDialogueDerek, "Such a beautiful house. This guy has good taste.");
        }

        // Derek Fear
        if (GetBoxValue(entrywayBoxDerek) == Select.Fear)
        {
            SetCharDialogue(entrywayDialogueDerek, "I feel like this is too far. Come on Alice, we got enough from his wallet, why not leave his house be?");
        }
    }

    void DiningRoom()
    {
        if (GetBoxValue(diningBoxAlice) == Select.Blank)
        {
            ClearCharDialogue(diningDialogueAlice);
        }

        // Alice Joy
        if (GetBoxValue(diningBoxAlice) == Select.Joy)
        {
            SetCharDialogue(diningDialogueAlice, "Well well well ain't this some fine cuttlery. I'll be taking that thank you very much.");
        }

        // Alice Fear
        if (GetBoxValue(diningBoxAlice) == Select.Fear)
        {
            SetCharDialogue(diningDialogueAlice, "WHO'S THERE?! I'M NOT- oh. Just a cat. Just a cat, there's nothing to be scared of in house.");
        }
    }

    void Kitchen()
    {
        if (GetBoxValue(kitchingBoxAlice) == Select.Blank)
        {
            ClearCharDialogue(kitchenDialogueAlice);
        }

        // Alice Joy
        if (GetBoxValue(kitchingBoxAlice) == Select.Joy)
        {
            SetCharDialogue(kitchenDialogueAlice, "Wow for such a fine house you've got to fill up your refrigerator man. Ooh but I will taking this though, yum!");
        }

        // Alice Fear
        if (GetBoxValue(kitchingBoxAlice) == Select.Fear)
        {
            SetCharDialogue(kitchenDialogueAlice, "Wait wait what is this... 'Byers, recognized for military service.' Damn, we just robbed a veteran.");
        }
    }

    void LivingRoom()
    {
        if (GetBoxValue(livingBoxAlice) == Select.Blank)
        {
            ClearCharDialogue(livingDialogueAlice);
        }

        // Alice Joy
        if (GetBoxValue(livingBoxAlice) == Select.Joy)
        {
            SetCharDialogue(livingDialogueAlice, "Aha! Here's the stash. Jackpot, now to find Derek and get out of here!");
        }

        // Alice Fear
        if (GetBoxValue(livingBoxAlice) == Select.Fear)
        {
            SetCharDialogue(livingDialogueAlice, "Was that a gunshot?! Derek, was that you?!");
        }
    }

}

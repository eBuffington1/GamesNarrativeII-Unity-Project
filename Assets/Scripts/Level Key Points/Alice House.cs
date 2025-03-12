using UnityEngine;

public class AliceHouse : MonoBehaviour
{
    private string _wordTrack;
    private bool _darkShift = false;

    private GameObject _sceneHandlerObject;
    private SceneHandler _sceneHandler;

    [SerializeField]
    private GameObject _goldHouseTiles;

    [SerializeField]
    private GameObject _darkHouseTiles;

    // Driveway
    [Header("House Driveway")]

    [SerializeField]
    private GameObject _drivewayStatics;

    [SerializeField]
    private GameObject _drivewayWordBox;

    [SerializeField]
    private GameObject _door;

    [SerializeField]
    private GameObject _drivewayAliceDialogue;

    [SerializeField]
    private GameObject _drivewayDerekDialogue;

    // Entryway
    [Header("Entryway")]

    [SerializeField]
    private GameObject _EntrywayStaticsJoy;

    [SerializeField]
    private GameObject _EntrywayStaticsFear;

    [SerializeField]
    private GameObject _EntrywayWordBox;

    [SerializeField]
    private GameObject _EntrywayAliceDialogue;

    [SerializeField]
    private GameObject _EntrywayDerekDialogue;

    [SerializeField]
    private GameObject _EntrywayDoor;

    // Dining Room
    [Header("Dining Room")]

    [SerializeField]
    private GameObject _DiningRoomStaticsJoy;

    [SerializeField]
    private GameObject _DiningRoomStaticsFear;

    [SerializeField]
    private GameObject _DiningRoomWordBox;

    [SerializeField]
    private GameObject _DiningRoomAliceDialogue;

    // Kitchen
    [Header("Kitchen")]
    [SerializeField]
    private GameObject _KitchenStaticsJoy;

    [SerializeField]
    private GameObject _KitchenStaticsFear;

    [SerializeField]
    private GameObject _KitchenWordBox;

    [SerializeField]
    private GameObject _KitchenAliceDialogue;

    // Living Room
    [Header("House Living Room")]
    [SerializeField]
    private GameObject _livingRoomStaticsJoy;

    [SerializeField]
    private GameObject _livingRoomStaticsFear;

    [SerializeField]
    private GameObject _livingRoomWordBox;

    [SerializeField]
    private GameObject _livingRoomAliceDialogue;

    [SerializeField]
    private GameObject _livingRoomDoor;

    // Hallway
    [Header("Hallway")]
    [SerializeField]
    private GameObject _hallwayWordBox;

    [SerializeField]
    private GameObject _hallwayStaticsJoy;

    [SerializeField]
    private GameObject _hallwayStaticsFear;

    // Bedroom
    [Header("Bedroom")]
    [SerializeField]
    private GameObject _bedroomWordBox;

    [SerializeField]
    private GameObject _bedroomStaticsFear;

    [SerializeField]
    private GameObject _bedroomStaticsJoy;


    private void Awake()
    {
        _sceneHandlerObject = GameObject.Find("Scene Handler");
        _sceneHandler = _sceneHandlerObject.GetComponent<SceneHandler>();
    }

    public void WordUpdate(GameObject wordObject, string word)
    {
        Debug.Log(wordObject + "   " + word);
        
        // Driveway Section
        if(wordObject == _drivewayWordBox)
        {
            if(word == "Joy")
            {
                DrivewayJoy();
            }
            else if(word == "remove")
            {
                DrivewayRemove();
            }
        }

        // Entryway
        if(wordObject == _EntrywayWordBox)
        {
            if (word == "Joy")
            {
                EntrywayJoy();
            }
            else if (word == "Fear")
            {
                EntrywayFear();
            }
            else if (word == "remove")
            {
                EntrywayRemove();
            }
        }
        // Dining Room
        if(wordObject == _DiningRoomWordBox)
        {
            if(word == "Joy")
            {
                DiningRoomJoy();
            }
            else if(word == "Fear"){
                DiningRoomFear();
            }
            else if(word == "remove")
            {
                DiningRoomRemove();
            }
        }
        // Kitchen
        if (wordObject == _KitchenWordBox)
        {
            if (word == "Joy")
            {
                KitchenJoy();
            }
            else if (word == "Fear")
            {
                KitchenFear();
            }
            else if (word == "remove")
            {
                KitchenRemove();
            }
        }

        // Living Room
        else if (wordObject == _livingRoomWordBox)
        {
            if (word == "Joy")
            {
                LivingRoomJoy();
            }
            else if (word == "Fear")
            {
                LivingRoomFear();
            }
            else if (word == "remove")
            {
                LivingRoomRemove();
            }
        }

    }

    // DRIVEWAY
    void DrivewayJoy()
    {
        // Remove door to house
        if (_door != null)
        {
            Destroy(_door);
        }

        // Toggle character visibility
        _drivewayStatics.SetActive(true);

        // Alice Dialogue
        _drivewayAliceDialogue.SendMessage("UpdateText", "Woooaaahhh look at this place! Come one, we've GOT TO take a peek inside!");

    }

    void DrivewayFear()
    {
        _drivewayStatics.SetActive(true);
        _drivewayDerekDialogue.SendMessage("UpdateText", "Alice, I really don't think we should do this. I think we've caused enough trouble already.");
    }

    void DrivewayRemove()
    {
        _drivewayAliceDialogue.SendMessage("EndText");
        _drivewayDerekDialogue.SendMessage("EndText");

        _drivewayStatics.SetActive(false);

    }

    // ENTRYWAY
    void EntrywayJoy()
    {
        _EntrywayStaticsJoy.SetActive(true);
        _EntrywayAliceDialogue.SendMessage("UpdateText", "Come on, it will be fun. The front door was essentially left open to everyone, why wouldn't we be welcome in?");
        _EntrywayDerekDialogue.SendMessage("UpdateText", "I feel nervous about this. I don't feel like we'd be welcome.");
    }

    void EntrywayFear()
    {
        //if(_EntrywayDoor != null)
        //{
        //    Destroy(_EntrywayDoor);
        //}
        //if(_livingRoomDoor != null)
        //{

        //}

        _EntrywayStaticsFear.SetActive(true);
        _EntrywayAliceDialogue.SendMessage("UpdateText", "Wha' wait where are you going. Split up? Fine, just hurry up. I'll go this way.");
    }

    void EntrywayRemove()
    {
        _EntrywayAliceDialogue.SendMessage("EndText");
        _EntrywayDerekDialogue.SendMessage("EndText");
        
        _EntrywayStaticsJoy.SetActive(false);
        _EntrywayStaticsFear.SetActive(false);
    }

    // DINING ROOM
    void DiningRoomJoy()
    {
        _DiningRoomStaticsJoy.SetActive(true);

        _DiningRoomAliceDialogue.SendMessage("UpdateText", "Now calm down and let's split up. If people weren't allowed to take a look around, they'd put up more signs or something!");
    }

    void DiningRoomFear()
    {
        _DiningRoomStaticsFear.SetActive(true);
    }

    void DiningRoomRemove()
    {
        _DiningRoomAliceDialogue.SendMessage("EndText");
        
        _DiningRoomStaticsJoy.SetActive(false);
        _DiningRoomStaticsFear.SetActive(false);
    }

    // KITCHEN
    void KitchenJoy()
    {
        _KitchenStaticsJoy.SetActive(true);

        _KitchenAliceDialogue.SendMessage("UpdateText", "Well, the owner of this place must be quite nice to have a kitchen like this.");
    }

    void KitchenFear()
    {
        _KitchenStaticsFear.SetActive(true);

        _KitchenAliceDialogue.SendMessage("UpdateText", "Hey! Stop it old man, why are you using a gun?! Just leave... me... alone!");
    }

    void KitchenRemove()
    {
        _KitchenAliceDialogue.SendMessage("EndText");
        
        _KitchenStaticsJoy.SetActive(false);
        _KitchenStaticsFear.SetActive(false);
    }

    // LIVING ROOM
    void LivingRoomJoy()
    {
        _livingRoomAliceDialogue.SendMessage("UpdateText", "Oooh look at all this stuff! I wonder what other treasures this house holds...");
        _livingRoomStaticsJoy.SetActive(true);
    }

    void LivingRoomFear()
    {
        if (_darkShift == false)
        {
            _darkShift = true;
            StartCoroutine(_sceneHandler.Blackout(1f));
            _goldHouseTiles.SetActive(false);
            _darkHouseTiles.SetActive(true);
        }

        _livingRoomStaticsFear.SetActive(true);
        _livingRoomAliceDialogue.SendMessage("UpdateText", "Was that a gunshot?! Derek was that you?");
    }

    void LivingRoomRemove()
    {
        _livingRoomAliceDialogue.SendMessage("EndText");
        _livingRoomStaticsJoy.SetActive(false);
        _livingRoomStaticsFear.SetActive(false);
    }
}

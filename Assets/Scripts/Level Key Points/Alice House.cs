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
    private GameObject _EntrywayWordBox2;

    [SerializeField]
    private GameObject _EntrywayAliceDialogue;

    [SerializeField]
    private GameObject _EntrywayDerekDialogue;

    [SerializeField]
    private GameObject _EntrywayDoorWest;

    [SerializeField]
    private GameObject _EntrywayDoorNorth;

    [SerializeField]
    private GameObject _TEMPFearWord;

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

    [SerializeField]
    private GameObject _DiningRoomDoorNorth;

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

    [SerializeField]
    private GameObject _KitchenDoorEast;

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

    [SerializeField]
    private GameObject _bedroomDialogue;


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
            else if(word == "Fear")
            {
                DrivewayFear();
            }
            else if (word == "remove")
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

        if(wordObject == _EntrywayWordBox2)
        {
            if(word == "Fear")
            {
                Entryway2Fear();
            }
            else if(word == "remove")
            {
                EntrywayRemove2();
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

        // Bedroom
        else if (wordObject == _bedroomWordBox)
        {
            if (word == "Joy")
            {
                BedroomJoy();
            }
            else if (word == "Fear")
            {
                BedroomFear();
            }
            else if (word == "remove")
            {
                BedroomRemove();
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

        _EntrywayWordBox.SetActive(true);

        // Alice Dialogue
        _drivewayAliceDialogue.SendMessage("UpdateText", "Come one! Look at this, a royal invitation to tour this beautiful house! We are free to do whatever we please in here!");

    }

    void DrivewayFear()
    {
        _drivewayStatics.SetActive(true);
        _drivewayDerekDialogue.SendMessage("UpdateText", "Alice, I really don't think we should do this. We already stole his money, isn't this taking it too far?");
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
        if (_EntrywayDoorWest)
        {
            _EntrywayDoorWest.SetActive(false);
        }
        
        _EntrywayStaticsJoy.SetActive(true);
        _EntrywayAliceDialogue.SendMessage("UpdateText", "Oh, come on! It'll be fun! How about this, lets split up and scout out what complementary goods are available!");
        //_EntrywayDerekDialogue.SendMessage("UpdateText", "I feel nervous about this. I don't feel like we'd be welcome.");

        _EntrywayWordBox2.SetActive(true);
        _DiningRoomWordBox.SetActive(true);
    }

    void EntrywayFear()
    {

        _EntrywayStaticsFear.SetActive(true);
        _EntrywayAliceDialogue.SendMessage("UpdateText", "Who else is here?! I'm not scared of you, whoever you are!");
    }

    void Entryway2Fear()
    {
        if (_EntrywayDoorNorth)
        {
            _EntrywayDoorNorth.SetActive(false);
        }
        if (_livingRoomDoor)
        {
            _livingRoomDoor.SetActive(false);
        }

        _EntrywayDerekDialogue.SendMessage("UpdateText", "H-hey! What if he comes back?! Well... fine. Just be quick though, I'll look over here.");

        _bedroomWordBox.SetActive(true);
    }

    void EntrywayRemove()
    {
        _EntrywayAliceDialogue.SendMessage("EndText");
        _EntrywayDerekDialogue.SendMessage("EndText");
        
        _EntrywayStaticsJoy.SetActive(false);
        _EntrywayStaticsFear.SetActive(false);

        //_TEMPFearWord.SendMessage("ForcedOff");
        _EntrywayWordBox2.SetActive(false);
    }

    void EntrywayRemove2()
    {
        _EntrywayDerekDialogue.SendMessage("EndText");
    }

    // DINING ROOM
    void DiningRoomJoy()
    {

        if (_DiningRoomDoorNorth)
        {
            _DiningRoomDoorNorth.SetActive(false);
        }

        _DiningRoomStaticsJoy.SetActive(true);
        _KitchenWordBox.SetActive(true);

        _DiningRoomAliceDialogue.SendMessage("UpdateText", "Honestly dining table seems kinda dull. Obviously cheaped out here.");
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
        if (_KitchenDoorEast)
        {
            _KitchenDoorEast.SetActive(false);
        }
        
        _KitchenStaticsJoy.SetActive(true);

        _livingRoomWordBox.SetActive(true);

        _KitchenAliceDialogue.SendMessage("UpdateText", "Ooh got any snacks hiding in here? Don't mind if I indulge myself a moment.");
    }

    void KitchenFear()
    {
        _KitchenStaticsFear.SetActive(true);

        _KitchenAliceDialogue.SendMessage("UpdateText", "Hey who are you?! If you didn't want us in here old man maybe you should've-");
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
        _livingRoomAliceDialogue.SendMessage("UpdateText", "Oooh look at all this stuff! Old man has quite a few badges hanging up here. Don't mind if I... wait what was that?");
        _livingRoomStaticsJoy.SetActive(true);

        _TEMPFearWord.SetActive(true);
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

    // BEDROOM
    void BedroomJoy()
    {
        _bedroomStaticsJoy.SetActive(true);

        _bedroomDialogue.SendMessage("UpdateText", "Okay, I just need to get this job and I can turn my life around. I've been through worse, I can do this.");
    }

    void BedroomFear()
    {
        _bedroomStaticsFear.SetActive(true);

        _bedroomDialogue.SendMessage("UpdateText", "So many health bills... he isn't nearly as rich as she said he was. This is too much, I'm not robbing from this man. Please Alice, don't start another argument over this...");
    }

    void BedroomRemove()
    {
        _bedroomStaticsJoy.SetActive(false);
        _bedroomStaticsFear.SetActive(false);

        _bedroomDialogue.SendMessage("EndText");
    }
}

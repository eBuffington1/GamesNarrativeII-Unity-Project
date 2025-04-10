using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ch_2_preScene : MonoBehaviour
{
    // 0 is empty, 1 is top, 2 is mid, 3 is bot, 4 is continue
    int sceneStep = 0;
    bool inAnim = false;
    PlayableDirector timeline;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    private void Update()
    {
        // temp code for left click
        if (Input.GetMouseButtonDown(0))
        {
            if (sceneStep < 3 && inAnim == false)
            {
                timeline.Play();
                inAnim = true;
            }

            if (inAnim == false && sceneStep >= 3)
            {
                SceneManager.LoadScene("ch_2_level");
            }
        }
    }

    public void ClickTrigger(InputAction.CallbackContext context)
    {
        // If button wasn't fully performed, end function
        if (!context.performed)
        {
            return;
        }

        Debug.Log("Clicked");


    }

    public void timelineSig()
    {
        Debug.Log("Signal detected");
        timeline.Pause();
        sceneStep++;
        inAnim = false;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene("ch_2_preScene_cs");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

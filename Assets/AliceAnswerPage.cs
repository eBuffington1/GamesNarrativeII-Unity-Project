using TMPro;
using UnityEngine;

public class AliceAnswerPage : MonoBehaviour
{
    // Index value of each dropdown for correct answer
    const int answerName = 2;
    const int answerCauseOfDeath = 1;
    const int answerLocationOfDeath = 2;
    const int answerReasonPresent = 5;

    [SerializeField] TMP_Dropdown nameDropdown;
    [SerializeField] TMP_Dropdown causeOfDeathDropdown;
    [SerializeField] TMP_Dropdown locationDeathDropdown;
    [SerializeField] TMP_Dropdown reasonDeathDropdown;

    [SerializeField] TextMeshProUGUI validationText;

    public void ValidateAnswers()
    {
        Debug.Log("Validating answer...");
        if (nameDropdown.value == answerName && 
            causeOfDeathDropdown.value == answerCauseOfDeath &&
            locationDeathDropdown.value == answerLocationOfDeath &&
            reasonDeathDropdown.value == answerReasonPresent
            )
        {
            DisplayCorrectAnswer();
        }
        else
        {
            DisplayWrongAnswer();
        }
    }

    void DisplayWrongAnswer()
    {
        Debug.Log("Wrong answer");
        validationText.text = "Incorrect";
    }

    void DisplayCorrectAnswer()
    {
        Debug.Log("Right answer");
        validationText.text = "Correct";
    }
}

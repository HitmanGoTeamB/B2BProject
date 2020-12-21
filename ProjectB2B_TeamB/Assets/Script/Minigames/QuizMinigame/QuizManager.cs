using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [SerializeField]
    private Question[] QuestionsArray;

    private Question currentQuestion;
    private int currentQuestionNumber = 0;

    [SerializeField]
    private Text QuestionTextUI;
    [SerializeField]
    private Text RightAnswerNumberUI;
    private int RightAnswerNumber = 0;
    [SerializeField]
    private GameObject TrueButton;
    [SerializeField]
    private GameObject FalseButton;
    private bool inputEnabled = false;
    [SerializeField]
    private Text DescriptionTextUI;

    // Start is called before the first frame update
    void Start()
    {
        AskQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputEnabled == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentQuestionNumber++;
                ActivateButtonDeactivateDescription(TrueButton, FalseButton);
                AskQuestion();
            }
        }
    }

    void AskQuestion()
    {
        if (currentQuestionNumber >= QuestionsArray.Length)
        {
            GiveMinigameResult(RightAnswerNumber);
            return;
        }

        if (QuestionsArray[currentQuestionNumber] != null)
            currentQuestion = QuestionsArray[currentQuestionNumber];

        QuestionTextUI.text = QuestionsArray[currentQuestionNumber].QuestionText;     
    }

    void AskFirstQuestion()
    {
        if (currentQuestionNumber >= QuestionsArray.Length)
        {
            GiveMinigameResult(RightAnswerNumber);
        }

        if (QuestionsArray[currentQuestionNumber] != null)
            currentQuestion = QuestionsArray[currentQuestionNumber];

        QuestionTextUI.text = QuestionsArray[currentQuestionNumber].QuestionText;
    }

    void GiveMinigameResult(int RightQuestionAnswered)
    {
        if(RightQuestionAnswered == 3)
        {
            SceneManager.LoadScene("10_VictoryScreenUI");
        }
        else
        {
            SceneManager.LoadScene("09_DefeatScreenUI");
        }
    }

    public void CheckTrueButtonAnswer()
    {
        if(currentQuestion.Answer == true)
        {
            RightAnswerNumber++;
            RightAnswerNumberUI.text = RightAnswerNumber.ToString();

            DeactivateButtonsActivateDescription(TrueButton, FalseButton);
        }
        else
        {
            DeactivateButtonsActivateDescription(TrueButton, FalseButton);
        }
    }

    public void CheckFalseButtonAnswer()
    {
        if (currentQuestion.Answer == false)
        {
            RightAnswerNumber++;
            RightAnswerNumberUI.text = RightAnswerNumber.ToString();
            DeactivateButtonsActivateDescription(TrueButton, FalseButton);
        }
        else
        {
            DeactivateButtonsActivateDescription(TrueButton, FalseButton);
        }
    }

    void DeactivateButtonsActivateDescription(GameObject trueButton, GameObject falseButton)
    {
        DescriptionTextUI.text = QuestionsArray[currentQuestionNumber].Description;
        trueButton.SetActive(false);
        falseButton.SetActive(false);
        inputEnabled = true;        
    }

    void ActivateButtonDeactivateDescription(GameObject trueButton, GameObject falseButton)
    {
        DescriptionTextUI.text = "";
        trueButton.SetActive(true);
        falseButton.SetActive(true);
        inputEnabled = false;
    }
}

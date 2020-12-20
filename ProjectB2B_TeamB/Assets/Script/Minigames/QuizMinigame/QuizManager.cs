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
    private GameObject MinigameWinScreen;
    [SerializeField]
    private GameObject MinigameLoseScreen;
    [SerializeField]
    private GameObject minigameQuestionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        AskQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
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

        currentQuestionNumber++;      
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
            MinigameWinScreen.SetActive(true);
            minigameQuestionCanvas.SetActive(false);
        }
        else
        {
            MinigameLoseScreen.SetActive(true);
            minigameQuestionCanvas.SetActive(false);
        }
    }

    public void CheckTrueButtonAnswer()
    {
        if(currentQuestion.Answer == true)
        {
            RightAnswerNumber++;
            RightAnswerNumberUI.text = RightAnswerNumber.ToString();
            AskQuestion();
        }
        else
        {
            AskQuestion();
        }
    }

    public void CheckFalseButtonAnswer()
    {
        if (currentQuestion.Answer == false)
        {
            RightAnswerNumber++;
            RightAnswerNumberUI.text = RightAnswerNumber.ToString();
            AskQuestion();
        }
        else
        {
            AskQuestion();
        }
    }

    public void RestartMinigame()
    {
        SceneManager.LoadScene(3); //scena minigame
    }

    //momentaneamente qui
    public void BackToGame()
    {
        SceneManager.LoadScene(1); //scena game
    }
}

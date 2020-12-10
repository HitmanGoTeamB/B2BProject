using UnityEngine;

public class QuestionAssign : MonoBehaviour
{
    [SerializeField] private QuizCollection quizCollection;
    private QuizContents currentQuestion;
    [HideInInspector] public int correctAnswers;
    [HideInInspector] public bool endStatus;


    private void Start()
    {
        correctAnswers = 0;
        endStatus = false;
    }

    void CheckCorrectAnswer(bool answerReceived)
    {
        if (answerReceived == currentQuestion.rightAnswer)
        {
            correctAnswers++;
        }
        if (quizCollection.currentQuestionIndex < quizCollection.quizDatabase[quizCollection.currentPaintingIndex].quizQuestions.Length - 1)
        {
            quizCollection.currentQuestionIndex++;
        }
        else endStatus = true;
    }

    private void Update()
    {
        currentQuestion = quizCollection.quizDatabase[quizCollection.currentPaintingIndex].quizQuestions[quizCollection.currentQuestionIndex];
    }

    public void AnswerYes()
    {
        CheckCorrectAnswer(true);
    }

    public void AnswerNo()
    {
        CheckCorrectAnswer(false);
    }
}

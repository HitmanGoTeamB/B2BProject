using UnityEngine;
using UnityEngine.UI;

public class CurrentQuestionText : MonoBehaviour
{
    [SerializeField] private QuizCollection quizCollection;
    [SerializeField] private QuestionAssign questionAssign;
    [SerializeField] private GameObject[] buttons;
    private Text thisText;

    private void Awake()
    {
        thisText = this.gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        if (questionAssign.endStatus == false) QuestionTextShow();
        else EndGameStatusShow();
    }

    void QuestionTextShow()
    {
        thisText.text = quizCollection.quizDatabase[quizCollection.currentPaintingIndex].quizQuestions[quizCollection.currentQuestionIndex].question;
    }

    void EndGameStatusShow()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(true);
        if (questionAssign.correctAnswers == quizCollection.quizDatabase[quizCollection.currentPaintingIndex].quizQuestions.Length)
        {
            thisText.text = "You got all the answers!";
        }
        else
        {
            thisText.text = "You got " + questionAssign.correctAnswers + "/" + quizCollection.quizDatabase[quizCollection.currentPaintingIndex].quizQuestions.Length + " correct answers";
        }
    }
}

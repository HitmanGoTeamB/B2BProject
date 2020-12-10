using UnityEngine;

public class QuizCollection : MonoBehaviour
{
    public QuizDatabase[] quizDatabase;
    public int currentPaintingIndex;
    public int currentQuestionIndex;

    private void Start()
    {
        currentPaintingIndex = 0;
        currentQuestionIndex = 0;
    }
}

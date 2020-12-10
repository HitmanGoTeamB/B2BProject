[System.Serializable]
public class QuizContents
{
    public string question;
    public bool rightAnswer;
}
[System.Serializable]
public class QuizDatabase
{
    public string paintingName;
    public QuizContents[] quizQuestions;
}

using UnityEngine;
using UnityEngine.UI;

public class DifferencesGame : MonoBehaviour
{
    [HideInInspector] public int score;
    [HideInInspector] public float currentTimerSecond;
    [SerializeField] private float maxTimer;
    [SerializeField] private GameObject endGameButton;
    [SerializeField] private Text endGameButtonText;
    [SerializeField] private string victoryMessage;
    [SerializeField] private string defeatMessage;
    private bool defeatTimerOff;

    private void Start()
    {
        score = 0;
        currentTimerSecond = maxTimer;
        defeatTimerOff = false;
    }

    public void CheckForVictory()
    {
        if (score == transform.childCount)
        {
            defeatTimerOff = true;
            EndGame(victoryMessage);
        }
    }

    private void Update()
    {
        if (defeatTimerOff == false)
        {
            TimerToDefeat();
        }
    }

    private void TimerToDefeat()
    {
        if (currentTimerSecond > 0) currentTimerSecond -= Time.deltaTime;
        else EndGame(defeatMessage);
    }

    void EndGame(string message)
    {
        endGameButton.SetActive(true);
        endGameButtonText.text = message;
    }
}

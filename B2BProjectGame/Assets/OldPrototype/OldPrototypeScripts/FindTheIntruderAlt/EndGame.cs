using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject endGameButton;
    [SerializeField] private Text endGameButtonText;
    [SerializeField] private string victoryText;
    [SerializeField] private string defeatText;

    private void Start()
    {
        Timer.loseTheGame += LostTheGame;
        ValidateTheIntruder.winTheGame += WonTheGame;
    }

    void LostTheGame()
    {
        endGameButtonText.text = defeatText;
        endGameButton.SetActive(true);
    }

    void WonTheGame()
    {
        endGameButtonText.text = victoryText;
        endGameButton.SetActive(true);
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

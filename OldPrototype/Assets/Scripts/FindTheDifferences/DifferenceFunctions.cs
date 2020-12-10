using UnityEngine;

public class DifferenceFunctions : MonoBehaviour
{
    [SerializeField] private DifferencesGame differencesGame;
    [SerializeField] private GameObject leftSideButton;
    [SerializeField] private GameObject rightSideButton;
    [SerializeField] private GameObject leftSideImage;
    [SerializeField] private GameObject rightSideImage;


    public void DifferenceFound()
    {
        differencesGame.score++;
        leftSideButton.SetActive(false);
        rightSideButton.SetActive(false);
        leftSideImage.SetActive(true);
        rightSideImage.SetActive(true);
        differencesGame.CheckForVictory();
    }
}

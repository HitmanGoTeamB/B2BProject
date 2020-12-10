using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private DifferencesGame differencesGame;
    private Text thisText;


    private void Awake()
    {
        thisText = this.gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        thisText.text = ((int)differencesGame.currentTimerSecond).ToString();
    }
}

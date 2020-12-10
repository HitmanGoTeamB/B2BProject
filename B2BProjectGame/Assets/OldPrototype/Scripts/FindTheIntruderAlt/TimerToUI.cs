using UnityEngine;
using UnityEngine.UI;

public class TimerToUI : MonoBehaviour
{
    private Timer timer;
    private Text thisText;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        thisText = this.gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        thisText.text = ((int)timer.currentTimerStatus).ToString();
    }
}

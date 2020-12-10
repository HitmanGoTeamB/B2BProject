using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float maxTimer;
    [SerializeField] private float timeLostOnError;
    [SerializeField] private float timeGainedOnIntruderFound;
    [HideInInspector] public float currentTimerStatus;
    public static Action loseTheGame;
    private bool timerOff;

    private void Start()
    {
        timerOff = false;
        PossibleIntruder.innocentFound += LoseSeconds;
        PossibleIntruder.intruderFound += GainSeconds;
        ValidateTheIntruder.winTheGame += TimerStop;
        currentTimerStatus = maxTimer;
    }

    private void Update()
    {
        if (timerOff == false) TimerGo();
    }

    void TimerGo()
    {
        if (currentTimerStatus > 0) currentTimerStatus -= Time.deltaTime;
        else loseTheGame();
    }

    void LoseSeconds()
    {
        currentTimerStatus -= timeLostOnError;
    }

    void GainSeconds()
    {
        currentTimerStatus += timeGainedOnIntruderFound;
    }

    void TimerStop()
    {
        timerOff = true;
    }
}

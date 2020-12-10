using System;
using UnityEngine;

public class ValidateTheIntruder : MonoBehaviour
{
    public static Action intruderSet;
    public static Action winTheGame;
    public void ValidateIntruder()
    {
        intruderSet();
    }

    public void WinTheGame()
    {
        winTheGame();
    }
}

using System;
using UnityEngine;

public class PossibleIntruder : MonoBehaviour
{
    [SerializeField] private string parentName;
    public bool isIntruder;
    public static Action intruderFound;
    public static Action innocentFound;

    private void OnEnable()
    {
        if (this.transform.parent.gameObject.name == parentName) ValidateTheIntruder.intruderSet += SetIntruder;
        isIntruder = false;
    }

    public void CheckIfIsIntruder()
    {
        if (isIntruder == true) intruderFound();
        else innocentFound();
    }

    void SetIntruder()
    {
        isIntruder = true;
    }
}

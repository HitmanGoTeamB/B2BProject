using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntruiderManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask intruidersLayer;
    [SerializeField]
    private int intruiderNumberInScene;
    private int intruidersMissing;
    private float Timer;
    [SerializeField]
    private float MaxTimer;
    private bool InputEnabled = true;

    //debug
    public GameObject WINUI;
    public GameObject LOSEUI;

    // Start is called before the first frame update
    void Start()
    {
        intruidersMissing = intruiderNumberInScene;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();

        if (Input.GetMouseButtonDown(0) && InputEnabled == true)
        {
            CheckForIntruider();
        }
    }

    void CheckForIntruider()
    {
        GameObject intruiderHitted = ShootRaycast();

        intruiderHitted.GetComponent<SpriteRenderer>().enabled = true;

        intruidersMissing -= 1;

        if(intruidersMissing <= 0)
        {
            //activeWinUI
            WINUI.SetActive(true);
            InputEnabled = false;
        }
    }

    GameObject ShootRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit raycasthit, Mathf.Infinity, intruidersLayer))
        {
            return raycasthit.collider.gameObject;
        }

        return null;
    }

    void UpdateTimer()
    {
        Timer += Time.deltaTime;

        Debug.Log(Timer);

        if(Timer >= MaxTimer)
        {
            //activeLoseUI
            LOSEUI.SetActive(true);
            InputEnabled = false;
        }
    }
}

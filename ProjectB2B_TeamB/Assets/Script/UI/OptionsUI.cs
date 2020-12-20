using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsUI : MonoBehaviour
{
    [SerializeField]
    private GameObject SoundON;
    [SerializeField]
    private GameObject SoundOFF;

    // Start is called before the first frame update
    void Start()
    {
        ActiveRightSoundUI(SoundON, SoundOFF);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActiveRightSoundUI(GameObject soundON, GameObject soundOFF)
    {
        if(PlayerPrefs.GetString("SoundEnabled") == "True")
        {
            soundON.SetActive(true);
            soundOFF.SetActive(false);
        }
        else if(PlayerPrefs.GetString("SoundEnabled") == "False")
        {
            soundOFF.SetActive(true);
            soundON.SetActive(false);
        }
        
    }
}

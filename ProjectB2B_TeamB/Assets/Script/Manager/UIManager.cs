using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string NextScene)
    {
        SceneManager.LoadScene(NextScene);
    }

    public void ActiveUI(GameObject UItoActive)
    {
        UItoActive.SetActive(true);
    }

    public void DeactiveUI(GameObject UItoDeactive)
    {
        UItoDeactive.SetActive(false);
    }

    public void OpenWebPage(string Link)
    {
        Application.OpenURL(Link);
    }

    public void SavesoundData(string name)
    {
        PlayerPrefs.SetString("SoundEnabled", name);
    }
}

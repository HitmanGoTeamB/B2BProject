using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArtworkLoader : MonoBehaviour
{
    public GameObject Artwork0;
    public GameObject Artwork1;
    public GameObject Artwork2;
    public CameraMovementObserveMode cameraMovementObserveMode;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("ArtworkID") == 0)
        {
            Artwork0.SetActive(true);
            cameraMovementObserveMode.zoomMax = 1.3f;
            cameraMovementObserveMode.zoomMin = 0.45f;
            Camera.main.orthographicSize = 1.3f;
        }
        else if(PlayerPrefs.GetInt("ArtworkID") == 1)
        {
            Artwork1.SetActive(true);
            cameraMovementObserveMode.zoomMax = 2.75f;
            cameraMovementObserveMode.zoomMin = 0.9f;
            Camera.main.orthographicSize = 2.75f;
        }
        else if(PlayerPrefs.GetInt("ArtworkID") == 2)
        {
            Artwork2.SetActive(true);
            cameraMovementObserveMode.zoomMax = 1.8f;
            cameraMovementObserveMode.zoomMin = 0.85f;
            Camera.main.orthographicSize = 1.8f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activeminigame()
    {
        if (PlayerPrefs.GetInt("ArtworkID") == 0)
        {
            SceneManager.LoadScene("06_MinigameMemoryUI");
        }
        else if(PlayerPrefs.GetInt("ArtworkID") == 1)
        {
            SceneManager.LoadScene("08_MinigameIntruderUI");
        }
        else if (PlayerPrefs.GetInt("ArtworkID") == 2)
        {
            SceneManager.LoadScene("07_MinigameQuizUI");
        }
    }
}

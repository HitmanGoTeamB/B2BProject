using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovementObserveMode : MonoBehaviour
{
    private Vector3 startInput;
    [SerializeField]
    private float viewSensitivity;
    public float zoomMax;
    public float zoomMin;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (Input.GetMouseButtonDown(0))
        {
            startInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = startInput - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction * viewSensitivity * Time.deltaTime;
            //Mathf.Clamp(Camera.main.transform.position.x, , );
            //Mathf.Clamp(Camera.main.transform.position.y, , );
        }

        ZoomCamera(Input.GetAxis("Mouse ScrollWheel"));
    }

    void ZoomCamera(float input)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - input, zoomMin, zoomMax);
    }

    //modificare da qui

    public void StartMinigame()
    {
        SceneManager.LoadScene(3);
    }

    public void BackToGame()
    {
        SceneManager.LoadScene(1);
    }
}

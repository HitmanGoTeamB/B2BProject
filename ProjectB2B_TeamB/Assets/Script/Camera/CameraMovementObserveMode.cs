using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovementObserveMode : MonoBehaviour
{
    private Vector3 startInput;
    [SerializeField]
    private float viewSensitivity;
    [SerializeField]
    private float zoomSensitivity;
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
        if (Input.GetMouseButtonDown(0))
        {
            startInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPosition = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPosition = touchOne.position - touchOne.deltaPosition;

            float previousDistance = (touchZeroPrevPosition - touchOnePrevPosition).magnitude;
            float currentDistance = (touchZero.position - touchOne.position).magnitude;

            float DistanceDifference = currentDistance - previousDistance;

            ZoomCamera(DistanceDifference * zoomSensitivity);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = startInput - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction * viewSensitivity * Time.deltaTime;
        }
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

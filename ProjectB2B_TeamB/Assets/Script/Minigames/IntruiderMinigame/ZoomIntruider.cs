using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomIntruider : MonoBehaviour
{
    [SerializeField]
    private float zoomSensitivity;
    [SerializeField]
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
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
    }

    void ZoomCamera(float input)
    {
        //Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - input, zoomMin, zoomMax);

        //this.transform.localScale = new Vector3(this.transform.localScale.x - input, this.transform.localScale.y - input,  ;

        rectTransform.localScale = new Vector3(rectTransform.localScale.x - input, rectTransform.localScale.x - input, rectTransform.localScale.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float playerMoveSpeed;
    private Vector3 finalPosition;
    [SerializeField]
    private LayerMask layermaskFloor;
    [SerializeField]
    private LayerMask layermaskArtwork;
    [SerializeField]
    private float viewSensitivity;
    private float xAxisRotation;
    private float yAxisRotation;
    private ArtworkCollider artworkCollider;
    

    private void OnValidate()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        artworkCollider = FindObjectOfType<ArtworkCollider>();
        finalPosition = this.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        #region ViewControls
        float mouseX = Input.GetAxis("Mouse X") * viewSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * viewSensitivity * Time.deltaTime;

        xAxisRotation -= mouseY;
        xAxisRotation = Mathf.Clamp(xAxisRotation, -90f, 90f);
        yAxisRotation = mouseX;

        transform.Rotate(Vector3.up * yAxisRotation);
        mainCamera.transform.localRotation = Quaternion.Euler(xAxisRotation, 0f, 0f);
        #endregion

        if (Input.GetMouseButtonDown(0))
        {
            CheckforArtwork();
            finalPosition = SetFinalPosition();
            Debug.Log("Point PostClamp " + finalPosition);
        }
            

        if (this.transform.position != finalPosition)
            transform.position = Vector3.MoveTowards(this.transform.position, finalPosition, playerMoveSpeed * Time.deltaTime);
    }

    Vector3 SetFinalPosition()
    {
        //create a ray in the maincamera on mouse position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        //shoot a raycast
        if (Physics.Raycast(ray, out RaycastHit raycasthit, Mathf.Infinity, layermaskFloor))
        {
            //return final position
            return new Vector3(Mathf.Clamp(raycasthit.point.x, -9.5f, 9.5f), this.transform.position.y, Mathf.Clamp(raycasthit.point.z, -9.5f, 9.5f));
        }

        //return this position
        return this.transform.position;
    }

    void CheckforArtwork()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycasthit, Mathf.Infinity, layermaskArtwork))
        {
            if(artworkCollider.IsArtworkInteractable == true)
            {
                artworkCollider.ActiveObserveMode();
            }
        }
    }


}

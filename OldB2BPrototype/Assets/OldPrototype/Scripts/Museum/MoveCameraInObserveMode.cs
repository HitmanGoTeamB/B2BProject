using UnityEngine;

public class MoveCameraInObserveMode : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private ObserveMode observeMode;
    [SerializeField] private GameObject thisPaintingCamera;
    [SerializeField] private float cameraMovementSpeed;
    [SerializeField] private float cameraRotationSpeed;
    [SerializeField] private float cameraZoomSpeed;
    [SerializeField] private float cameraLimit;
    [SerializeField] private float cameraZoomLimit;
    [SerializeField] private float cameraRotationLimit;
    private float startingZPos;

    private void Start()
    {
        startingZPos = thisPaintingCamera.transform.localPosition.z;
    }

    private void FixedUpdate()
    {
        if (observeMode.observeModeOnOff == true) CameraOperations();
    }

    void CameraOperations()
    {
        CameraMovement();
        CameraRotation();
        CameraZoom();
    }


    private void CameraMovement()
    {
        Vector3 thisCameraPos = thisPaintingCamera.transform.localPosition;
        if (playerInput.ForwardInput == true && thisCameraPos.y < cameraLimit) thisPaintingCamera.transform.position += new Vector3(0f, cameraMovementSpeed * Time.fixedDeltaTime, 0f);
        if (playerInput.BackInput == true && thisCameraPos.y > -cameraLimit) thisPaintingCamera.transform.position += new Vector3(0f, -cameraMovementSpeed * Time.fixedDeltaTime, 0f);
        if (playerInput.RightInput == true && thisCameraPos.x < cameraLimit) thisPaintingCamera.transform.position += new Vector3(cameraMovementSpeed * Time.fixedDeltaTime, 0f, 0f);
        if (playerInput.LeftInput == true && thisCameraPos.x > -cameraLimit) thisPaintingCamera.transform.position += new Vector3(-cameraMovementSpeed * Time.fixedDeltaTime, 0f, 0f);
    }

    private void CameraRotation()
    {
        Quaternion thisCameraRotation = thisPaintingCamera.transform.localRotation;
        if (playerInput.LeftArrow == true && thisCameraRotation.y > -cameraRotationLimit) thisPaintingCamera.transform.rotation = Quaternion.Slerp(thisPaintingCamera.transform.rotation, new Quaternion(thisPaintingCamera.transform.rotation.x, thisPaintingCamera.transform.rotation.y - cameraRotationSpeed, thisPaintingCamera.transform.rotation.z, thisPaintingCamera.transform.rotation.w), Time.fixedDeltaTime);
        if (playerInput.RightArrow == true && thisCameraRotation.y < cameraRotationLimit) thisPaintingCamera.transform.rotation = Quaternion.Slerp(thisPaintingCamera.transform.rotation, new Quaternion(thisPaintingCamera.transform.rotation.x, thisPaintingCamera.transform.rotation.y + cameraRotationSpeed, thisPaintingCamera.transform.rotation.z, thisPaintingCamera.transform.rotation.w), Time.fixedDeltaTime);
        if (playerInput.UpArrow == true && thisCameraRotation.x > -cameraRotationLimit) thisPaintingCamera.transform.rotation = Quaternion.Slerp(thisPaintingCamera.transform.rotation, new Quaternion(thisPaintingCamera.transform.rotation.x - cameraRotationSpeed, thisPaintingCamera.transform.rotation.y, thisPaintingCamera.transform.rotation.z, thisPaintingCamera.transform.rotation.w), Time.fixedDeltaTime);
        if (playerInput.DownArrow == true && thisCameraRotation.x < cameraRotationLimit) thisPaintingCamera.transform.rotation = Quaternion.Slerp(thisPaintingCamera.transform.rotation, new Quaternion(thisPaintingCamera.transform.rotation.x + cameraRotationSpeed, thisPaintingCamera.transform.rotation.y, thisPaintingCamera.transform.rotation.z, thisPaintingCamera.transform.rotation.w), Time.fixedDeltaTime);
    }
    private void CameraZoom()
    {
        float thisCameraPosZ = thisPaintingCamera.transform.localPosition.z;
        if (playerInput.PlusInput == true && thisCameraPosZ < startingZPos + cameraZoomLimit) thisPaintingCamera.transform.position += new Vector3(0f, 0f, cameraZoomSpeed * Time.fixedDeltaTime);
        if (playerInput.MinusInput == true && thisCameraPosZ > startingZPos - cameraZoomLimit) thisPaintingCamera.transform.position += new Vector3(0f, 0f, -cameraZoomSpeed * Time.fixedDeltaTime);
    }
}

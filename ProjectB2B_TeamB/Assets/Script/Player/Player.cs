using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float playerMoveSpeed;
    private Vector3 finalPosition;

    private void OnValidate()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        finalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
            finalPosition = SetFinalPosition();

        if (this.transform.position != finalPosition)
            transform.position = Vector3.MoveTowards(this.transform.position, finalPosition, playerMoveSpeed * Time.deltaTime);
    }

    Vector3 SetFinalPosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        int layermask = 8;

        if (Physics.Raycast(ray, out RaycastHit raycasthit))
        {
            return new Vector3(raycasthit.point.x, this.transform.position.y, raycasthit.point.z);
        }

        return this.transform.position;
    }
}

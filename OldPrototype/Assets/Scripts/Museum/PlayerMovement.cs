using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float movementSpeed;

    private void FixedUpdate()
    {
        if (playerInput.ForwardInput == true) transform.Translate(Vector3.forward * movementSpeed * Time.fixedDeltaTime);
        if (playerInput.BackInput == true) transform.Translate(Vector3.back * movementSpeed * Time.fixedDeltaTime);
        if (playerInput.RightInput == true) transform.Translate(Vector3.right * movementSpeed * Time.fixedDeltaTime);
        if (playerInput.LeftInput == true) transform.Translate(Vector3.left * movementSpeed * Time.fixedDeltaTime);
    }
}

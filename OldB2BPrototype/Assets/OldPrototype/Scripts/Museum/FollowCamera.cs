using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;

    private void Update()
    {
        this.transform.rotation = mainCamera.transform.rotation;
    }
}

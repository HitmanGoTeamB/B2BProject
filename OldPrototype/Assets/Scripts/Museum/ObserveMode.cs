using UnityEngine;

public class ObserveMode : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject[] gameObjectsOfThis;
    [SerializeField] private GameObject border;
    [SerializeField] private GameObject camera;
    [HideInInspector] public bool observeModeOnOff;
    private GameObject[] allGameObjects;
    private Vector3 cameraStartingPos;
    private Quaternion cameraStartingRotation;
    private void Awake()
    {
        ActivateInteraction.startObserveMode += ObserveModeActivate;
        allGameObjects = FindObjectsOfType<GameObject>();
        observeModeOnOff = false;
    }

    private void Start()
    {
        cameraStartingPos = camera.transform.localPosition;
        cameraStartingRotation = camera.transform.localRotation;
    }

    void ObserveModeActivate()
    {
        GameObjectActivateDeactivateOperation(false, allGameObjects);
        GameObjectActivateDeactivateOperation(true, gameObjectsOfThis);
        GameObjectActivateDeactivateOperation(false, border);
        observeModeOnOff = true;
    }

    void ObserveModeDeactivate()
    {
        GameObjectActivateDeactivateOperation(true, allGameObjects);
        GameObjectActivateDeactivateOperation(true, border);
        GameObjectActivateDeactivateOperation(false, camera);
        camera.transform.localPosition = cameraStartingPos;
        camera.transform.localRotation = cameraStartingRotation;
        observeModeOnOff = false;
    }

    private void Update()
    {
        if (playerInput.ExitInput == true && observeModeOnOff == true)
        {
            ObserveModeDeactivate();
        }
    }

    void GameObjectActivateDeactivateOperation(bool onOff, GameObject[] arrayToOperate)
    {
        for (int i = 0; i < arrayToOperate.Length; i++)
        {
            arrayToOperate[i].SetActive(onOff);
        }
    }
    void GameObjectActivateDeactivateOperation(bool onOff, GameObject gameObjectToOperate)
    {
        gameObjectToOperate.SetActive(onOff);
    }
}

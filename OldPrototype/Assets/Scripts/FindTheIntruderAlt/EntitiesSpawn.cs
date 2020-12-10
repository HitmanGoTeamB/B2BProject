
using UnityEngine;

public class EntitiesSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] possibleIntruders;
    [SerializeField] private GameObject intruderContainer;
    [SerializeField] private GameObject innocentContainer;
    [SerializeField] private int[] roundsInnocentNumber;
    [SerializeField] private float verticalLimitStart;
    [SerializeField] private float verticalLimitEnd;
    [SerializeField] private float horizontalLimitStart;
    [SerializeField] private float horizontalLimitEnd;
    private int intruderIndex;
    [HideInInspector] public int roundNumber;
    [HideInInspector] public int roundLimit;
    ValidateTheIntruder validateTheIntruder;

    private void Awake()
    {
        validateTheIntruder = FindObjectOfType<ValidateTheIntruder>();
    }

    private void Start()
    {
        PossibleIntruder.intruderFound += UpdateRound;
        RoundInitialization();
        RoundGeneration();
    }

    void RoundGeneration()
    {
        SelectIntruder();
        SpawnButtons();
        ValidateIntruder();
    }

    private void UpdateRound()
    {
        roundNumber++;
        DestroyPreviousRound();
        if (roundNumber < roundLimit) RoundGeneration();
        else validateTheIntruder.WinTheGame();
    }

    void RoundInitialization()
    {
        roundNumber = 0;
        roundLimit = roundsInnocentNumber.Length;
    }

    void SelectIntruder()
    {
        intruderIndex = UnityEngine.Random.Range(0, possibleIntruders.Length);
    }

    void SpawnButtons()
    {
        for (int possibleIntrudersIndex = 0; possibleIntrudersIndex < possibleIntruders.Length; possibleIntrudersIndex++)
        {
            if (possibleIntrudersIndex == intruderIndex) SpawnSingle(possibleIntrudersIndex, true);
            else SpawnTheInnocents(possibleIntrudersIndex);
        }
    }

    private void SpawnSingle(int i, bool isIntruder)
    {
        if (isIntruder == true) Instantiate(possibleIntruders[i], RandomizePosition(), Quaternion.identity, intruderContainer.transform);
        else Instantiate(possibleIntruders[i], RandomizePosition(), Quaternion.identity, innocentContainer.transform);
    }

    void SpawnTheInnocents(int i)
    {
        for (int spawnNumber = 0; spawnNumber < roundsInnocentNumber[roundNumber]; spawnNumber++)
        {
            SpawnSingle(i, false);
        }
    }

    Vector3 RandomizePosition()
    {
        float randomHorizontal = Random.Range(horizontalLimitStart, horizontalLimitEnd);
        float randomVertical = Random.Range(verticalLimitStart, verticalLimitEnd);
        return new Vector3(randomHorizontal, randomVertical, 0f);
    }

    void ValidateIntruder()
    {
        validateTheIntruder.ValidateIntruder();
    }

    void DestroyPreviousRound()
    {
        DestroyAllOfContainer(intruderContainer);
        DestroyAllOfContainer(innocentContainer);
    }

    void DestroyAllOfContainer(GameObject container)
    {
        int count = 0;
        Transform[] containedChildren = container.GetComponentsInChildren<Transform>();
        foreach (Transform child in containedChildren)
        {
            if (count == 0) count++;
            else Destroy(child.gameObject);
        }
    }
}

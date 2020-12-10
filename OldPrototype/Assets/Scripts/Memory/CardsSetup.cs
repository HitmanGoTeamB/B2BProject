using UnityEngine;
using UnityEngine.UI;

public class CardsSetup : MonoBehaviour
{
    [SerializeField] private Image[] cardImages;
    public Image[] cardSpaces;
    [SerializeField] private GameObject[] covers;
    public GameObject endButtonPanel;
    public Text endButtonText;

    private void Start()
    {
        Shuffle();
        AddCardsInDeck();
    }

    private void Shuffle()
    {
        Image tempGoImg;
        GameObject tempGoObj;
        for (int i = 0; i < cardSpaces.Length; i++)
        {
            int rnd = Random.Range(0, cardSpaces.Length);
            tempGoImg = cardSpaces[rnd];
            cardSpaces[rnd] = cardSpaces[i];
            cardSpaces[i] = tempGoImg;
            tempGoObj = covers[rnd];
            covers[rnd] = covers[i];
            covers[i] = tempGoObj;
        }
    }

    private void AddCardsInDeck()
    {
        for (int i = 0; i < cardSpaces.Length; i += 2)
        {
            cardSpaces[i].color = cardImages[i / 2].color;
            cardSpaces[i + 1].color = cardImages[i / 2].color;
        }
    }

    public void ActivateAllCovers()
    {
        for (int i = 0; i < covers.Length; i++)
        {
            if (covers[i] != null) covers[i].SetActive(true);
        }
    }
}

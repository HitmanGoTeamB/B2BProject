using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MemoryManager : MonoBehaviour
{
    [SerializeField]
    private Card[] CardInscene;
    [SerializeField]
    private int ActiveCardNumber;
    [SerializeField]
    private List<Card> CardFlipped = new List<Card>();
    [SerializeField]
    private LayerMask CardLayer;
    private bool InputEnabled = true;
    [SerializeField]
    private int MaxErrorsPossible;
    private int CurrentErrorNumber;
    [SerializeField]
    private Text CurrentErrorText;
    [SerializeField]
    private Text MaxErrorText;


    // Start is called before the first frame update
    void Start()
    {
        CardInSceneCheck(CardInscene);

        ActiveCardNumber = CardInscene.Length;

        MaxErrorText.text = MaxErrorsPossible.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && InputEnabled == true)
        {
            Card CardHittedFromClick = RaycastAndCheckForCard();
            
            if(CardHittedFromClick != null)
            {
                //StartCoroutine(FlipCardAndWait(CardHittedFromClick, 1f));
                CardHittedFromClick.gameObject.transform.Rotate(Vector3.up, 180f);
                AddCardToFlippedCards(CardHittedFromClick, CardFlipped);
            }

            //CoupleControl(CardFlipped);


            StartCoroutine(CoupleControlCoroutine(CardFlipped, 1.6f));
        }
    }

    void CardInSceneCheck(Card[] cardInScene)
    {
        foreach(Card card in cardInScene)
        {
            if(card == null)
            {
                Debug.LogWarning("Some Cards Miss Reference In the Memory Manager Array");
            }
        }
    }

    Card RaycastAndCheckForCard()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycasthit, Mathf.Infinity, CardLayer))
        {
            Card CardHitted = raycasthit.collider.GetComponent<Card>();
            if (CardHitted != null)
                return CardHitted;
        }

        return null;
    }

    void AddCardToFlippedCards(Card cardHitted, List<Card> FlippedCards)
    {
        if (FlippedCards.Count < 2)
            FlippedCards.Add(cardHitted);
    }

    void RemoveFromFlippedCards(List<Card> FlippedCards)
    {
        FlippedCards.Clear();
    }

    void WinOrLoseCheck()
    {
        if(ActiveCardNumber == 0)
        {
            SceneManager.LoadScene("10_VictoryScreenUI");
        }
        else if(CurrentErrorNumber >= MaxErrorsPossible)
        {
            SceneManager.LoadScene("09_DefeatScreenUI");
        }
    }



    void CoupleControl(List<Card> FlippedCards)
    {
        if (FlippedCards.Count == 2)
        {
            if(FlippedCards[0].ID == FlippedCards[1].ID)
            {
                //deactivate objects
                FlippedCards[0].gameObject.SetActive(false);
                FlippedCards[1].gameObject.SetActive(false);
                ActiveCardNumber -= 2;

                RemoveFromFlippedCards(FlippedCards);

                WinOrLoseCheck();
            }
            else
            {

                CurrentErrorNumber++;
                CurrentErrorText.text = CurrentErrorNumber.ToString();

                foreach(Card card in FlippedCards)
                {
                    card.gameObject.transform.Rotate(Vector3.up, 180f);
                }

                RemoveFromFlippedCards(FlippedCards);

                WinOrLoseCheck();
            }
        }
    }

    IEnumerator FlipCardAndWait(Card cardtoflip, float timeToWait)
    {
        InputEnabled = false;
        cardtoflip.gameObject.transform.Rotate(Vector3.up, 180f);
        yield return new WaitForSeconds(timeToWait);
        InputEnabled = true;

    }

    IEnumerator CoupleControlCoroutine(List<Card> flippedcards, float timeToWait)
    {
        if(flippedcards.Count == 2)
            InputEnabled = false;

        yield return new WaitForSeconds(timeToWait);

        if (flippedcards.Count == 2)
            InputEnabled = true;
        
        CoupleControl(CardFlipped);
    }
}

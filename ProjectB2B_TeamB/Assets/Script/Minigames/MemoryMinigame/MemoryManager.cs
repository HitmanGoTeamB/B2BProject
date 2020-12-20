using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        CardInSceneCheck(CardInscene);

        ActiveCardNumber = CardInscene.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Card CardHittedFromClick = RaycastAndCheckForCard();

            //animazione flip carta

            if(CardHittedFromClick != null)
                AddCardToFlippedCards(CardHittedFromClick, CardFlipped);

            CoupleControl(CardFlipped);
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
            //activeWinUI
        }
        else if(CurrentErrorNumber >= MaxErrorsPossible)
        {
            //activeLoseUI
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
                //animation

                //updateErrorsUI

                RemoveFromFlippedCards(FlippedCards);

                WinOrLoseCheck();
            }
        }
    }
}

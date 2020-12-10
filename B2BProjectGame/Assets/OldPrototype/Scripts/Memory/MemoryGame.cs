using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MemoryGame : MonoBehaviour
{
    [SerializeField] private CardsSetup cardsSetup;
    [SerializeField] private GameObject firstCard;
    [SerializeField] private GameObject firstCardCover;
    [SerializeField] private GameObject secondCard;
    [SerializeField] private GameObject secondCardCover;
    private Image firstCardImage;
    private Image secondCardImage;
    private int currentDrawStatus;
    private int score;
    private int error;
    [SerializeField] private int errorLimit;
    [SerializeField] private string victoryText;
    [SerializeField] private string defeatText;
    [SerializeField] private float maxTimer;
    private float currentTimerStatus;
    private bool timerOnFlag;

    private void Start()
    {
        currentTimerStatus = maxTimer;
        currentDrawStatus = 0;
        score = 0;
        error = 0;
        timerOnFlag = false;
    }

    private void Update()
    {
        if (timerOnFlag == true) WaitTimer();
    }

    public void ClickToRevealCard()
    {
        if (timerOnFlag == false)
        {
            GameObject objectClicked = EventSystem.current.currentSelectedGameObject;
            EventSystem.current.currentSelectedGameObject.SetActive(false);
            CardCover thisObjectCardCover = objectClicked.GetComponent<CardCover>();
            DrawCheck(thisObjectCardCover);
        }
    }

    void DrawCheck(CardCover thisObjectCardCover)
    {
        if (currentDrawStatus == 0)
        {
            FirstDrawStatus(thisObjectCardCover);
        }
        else
        {
            SecondDrawStatus(thisObjectCardCover);
        }
    }

    void FirstDrawStatus(CardCover thisObjectCardCover)
    {
        firstCard = thisObjectCardCover.linkedImage.gameObject;
        firstCardCover = thisObjectCardCover.gameObject;
        currentDrawStatus++;
    }

    void SecondDrawStatus(CardCover thisObjectCardCover)
    {
        secondCard = thisObjectCardCover.linkedImage.gameObject;
        secondCardCover = thisObjectCardCover.gameObject;
        firstCardImage = firstCard.GetComponent<Image>();
        secondCardImage = secondCard.GetComponent<Image>();
        timerOnFlag = true;
    }

    void SameCards()
    {
        score++;
        ScoreCheck();
        Destroy(firstCard.gameObject);
        Destroy(firstCardCover.gameObject);
        Destroy(secondCard.gameObject);
        Destroy(secondCardCover.gameObject);
    }

    void NotSameCards()
    {
        error++;
        ErrorsCheck();
        cardsSetup.ActivateAllCovers();
    }

    void ScoreCheck()
    {
        if (score == cardsSetup.cardSpaces.Length / 2)
        {
            cardsSetup.endButtonPanel.SetActive(true);
            cardsSetup.endButtonText.text = victoryText;
        }
    }

    void ErrorsCheck()
    {
        if (error == errorLimit)
        {
            cardsSetup.endButtonPanel.SetActive(true);
            cardsSetup.endButtonText.text = defeatText;
        }
    }

    void WaitTimer()
    {
        if (currentTimerStatus > 0) currentTimerStatus -= Time.deltaTime;
        else
        {
            currentTimerStatus = maxTimer;
            timerOnFlag = false;
            CardStatusCheck();
        }
    }

    void CardStatusCheck()
    {
        if (firstCardImage.color == secondCardImage.color)
        {
            SameCards();
        }
        else
        {
            NotSameCards();
        }
        StatusCheckEndOperations();
    }

    void StatusCheckEndOperations()
    {
        firstCard = null;
        firstCardCover = null;
        secondCard = null;
        secondCardCover = null;
        currentDrawStatus = 0;
    }
}

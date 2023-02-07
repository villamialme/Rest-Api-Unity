using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    public TMP_InputField number;
    [SerializeField]
    public RestApi apiRest;
    [SerializeField] Image[] drawCards;

    private void OnEnable()
    {
        apiRest.onDataDeckFilled += DrawCardsUI;
    }
    private void OnDisable()
    {
        apiRest.onDataDeckFilled -= DrawCardsUI;
    }
    public void DrawCards(){
        
        if(number != null){
            apiRest.SendRequest(int.Parse(number.text));
        }

    }
    private void DrawCardsUI(DataDeck data)
    {
        for (int i = 0; i < data.dataDeck.Count; i++)
        {
            for (int j = 0; j < deck.deck.Length; j++)
            {
                if (data.dataDeck[i].index == deck.deck[j].index)
                {
                    drawCards[i].sprite = deck.deck[j].card;
                }
            }
        }

    }
}

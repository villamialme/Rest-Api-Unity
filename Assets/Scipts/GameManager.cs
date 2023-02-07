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
    

    public void DrawCards(){
        if(number != null){
            apiRest.SendRequest(number.text);
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class RestApi : MonoBehaviour
{
    public string uri;
    private const string limit = "?limit=";
    [SerializeField]
    [Range(1,5)]
    private int limiter;
    public UnityAction<DataDeck> onDataDeckFilled;

    public int Limiter 
    { 
        get => limiter;
        set
        {
            if(value < 1)
            {
                limiter = 1;
                return;
            }
            if (value > 10)
            {
                limiter = 10;
                return;
            }
            limiter = value;
            return;
        } 
    }

    public void SendRequest(int lit)
    {
        Limiter = lit;
        string url = uri+limit+Limiter;
        Debug.LogAssertion(url);
        StartCoroutine(RequestGet(url));

    }
    
    private IEnumerator RequestGet(string uri)
    {
          
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
            ProcessData(www.downloadHandler.text);
            //Debug.Log(results);
        }

    }
    private void ProcessData(string data)
    {
        DataDeck jsondata = JsonUtility.FromJson<DataDeck>("{\"dataDeck\":" + data + "}");
        Debug.Log(jsondata.dataDeck);
        onDataDeckFilled?.Invoke(jsondata);
        
    }
}


[Serializable]
public class DeckIndex
{
    public int id;
    public int index;
}
[Serializable]
public class DataDeck
{
    public List<DeckIndex> dataDeck;
}



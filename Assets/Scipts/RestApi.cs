using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestApi : MonoBehaviour
{
    public string uri;
    private const string limit = "?limit=";
    [SerializeField]
    [Range(1,5)]
    private int limiter;

    private void Start()
    {
        SendRequest();

    }



    public void SendRequest(int lit)
    {
        limiter = lit;
        string url = uri+limit+limiter;
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
        Debug.Log(jsondata.dataDeck[0].id);
        
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



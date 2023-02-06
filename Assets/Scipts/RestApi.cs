using System.Collections;
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



    public void SendRequest()
    {
        string url = uri+limit+limiter;
        Debug.LogAssertion(url);
        StartCoroutine(RequestGet(url));
        StartCoroutine(Test());
        
    }

    IEnumerator Test()
    {
        Debug.LogError("first");
        yield return new WaitForSeconds(4);
        Debug.LogError("second");
    }

    private IEnumerator RequestGet(string uri)
    {
        Debug.Log("sTART CORRUTINE");   
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
        }

    }
}

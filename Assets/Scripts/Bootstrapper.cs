using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Bootstrapper : MonoBehaviour
{

    [SerializeField] private string apiURL;
    private AllPieces allPieces;

    private void Start()
    {
        CallAPI();
    }

    public void CallAPI()
    {
        StartCoroutine(GetRequest(apiURL, LoadJsonDataCallback));
    }

    private IEnumerator GetRequest(string url, Action<string> callback)
    {
        string response;

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.error != null)
        {
            callback(request.error);
        }
        else
        {
            callback(request.downloadHandler.text);
        }
    }

    private void LoadJsonDataCallback(string result)
    {
        if (result != null)
        {
            result = "{\"list\": " + result + "}";
            allPieces = JsonUtility.FromJson<AllPieces>(result);
        }
        else
        {
            Debug.LogError("Could not load API");
        }
    }
}
    
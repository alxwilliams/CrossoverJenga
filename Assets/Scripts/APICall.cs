using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APICall : MonoBehaviour
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

    /// <summary>
    ///  attempts to get API data
    /// </summary>
    private IEnumerator GetRequest(string url, Action<string> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.error != null)
            callback(request.error);
        else
            callback(request.downloadHandler.text);
    }

    /// <summary>
    /// load data into the stack manager. If no data is present, Create error
    /// </summary>
    private void LoadJsonDataCallback(string result)
    {
        if (result != null)
        {
            result = "{\"list\": " + result + "}";
            allPieces = JsonUtility.FromJson<AllPieces>(result);
            StackManager.I.SetAllPieces(allPieces);
        }
        else
        {
            Debug.LogError("Could not load API");
        }
    }
}
    

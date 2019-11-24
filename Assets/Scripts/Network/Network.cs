using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Network : MonoBehaviour
{
    private static readonly string host = "http://api.myjson.com/bins/1amu7o";

    public static Network instance;

    public PlayersInfo playersInfo;

    private void Awake()
    {
        instance = this;
    }

    public Coroutine GetPlayers()
    {
        return StartCoroutine(LoadTextFromServer(host, ParseDataPlayers));
    }

    private void ParseDataPlayers(string data)
    {
        playersInfo = JsonUtility.FromJson<PlayersInfo>(data);
    }

    private IEnumerator LoadTextFromServer(string url, Action<string> response)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (!request.isHttpError && !request.isNetworkError)
        {
            response(request.downloadHandler.text);
        }
        else
        {
            Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);
            response(null);
        }

        request.Dispose();
    }
}

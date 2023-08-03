using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using UnityEngine;

public class WordleAPI : SingletonMonoBehaviour<WordleAPI>
{
    private void Start()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://wordle-answers-solutions.p.rapidapi.com/answers"),
            Headers =
            {
                { "X-RapidAPI-Key", "16e39059f6msh10762af6773a633p1683f4jsn0e270bbfc31f" },
                { "X-RapidAPI-Host", "wordle-answers-solutions.p.rapidapi.com" }
            }
        };

        Read(request);
    }

    private static async void Read(HttpRequestMessage request)
    {
        using var response = new HttpClient().SendAsync(request);

        var jsonContent = await response.Result.Content.ReadAsStringAsync();

        var content = JsonUtility.FromJson<Content>(jsonContent);

        var answerList = new List<string>(content.data.Select(x => x.answer));

        GameManager.Instance.answers = answerList;
        GameManager.Instance.GetRandomAnswer();
    }
}

[Serializable]
public class ContentClass
{
    public string day;
    public string num;
    public string answer;
}

[Serializable]
public class Content
{
    public ContentClass[] data;
}
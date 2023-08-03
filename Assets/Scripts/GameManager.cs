using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public AssetsHolder assetsHolder;
    [SerializeField] private Board board;

    [HideInInspector] public string answer;
    [HideInInspector] public List<string> answers;

    public IEnumerator NewGame()
    {
        yield return new WaitForSeconds(2f);
        GetRandomAnswer();
        board.ResetBoard();
    }

    public void GetRandomAnswer()
    {
        answer = answers[Random.Range(0, answers.Count)].ToLower();
        Debug.Log(answer);
    }
}
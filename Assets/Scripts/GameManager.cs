using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        answer = answers.GetRandomItem().ToLower();
        Debug.Log(answer);
    }
}
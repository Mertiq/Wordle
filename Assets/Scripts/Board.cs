using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Row> rows;

    private int activeRowIndex;
    private bool isEnd;
    private bool canEnterInput = true;

    private int ActiveRowIndex
    {
        get => activeRowIndex;
        set
        {
            if (value >= rows.Count)
                isEnd = true;
            else
                activeRowIndex = value;
        }
    }

    private void Update()
    {
        if (!canEnterInput) return;

        if (Input.GetKeyDown(KeyCode.Backspace))
            rows[ActiveRowIndex].DeleteLetter();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!rows[ActiveRowIndex].isFull) return;

            if (!rows[ActiveRowIndex].CheckAnswer(GameManager.Instance.answer))
            {
                ActiveRowIndex++;
                if (isEnd)
                    StartCoroutine(GameManager.Instance.NewGame());
            }
            else
            {
                canEnterInput = false;
                StartCoroutine(GameManager.Instance.NewGame());
            }
        }

        if (Input.anyKeyDown)
        {
            var input = Input.inputString;

            if (Extensions.IsLetter(input))
            {
                rows[ActiveRowIndex].WriteLetter(char.Parse(input));
            }
        }
    }

    public void ResetBoard()
    {
        foreach (var row in rows)
            row.ResetRow();

        ActiveRowIndex = 0;
        canEnterInput = true;
    }
}
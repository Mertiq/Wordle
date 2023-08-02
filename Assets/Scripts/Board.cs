using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Row> rows;
    
    private int activeRowIndex;
    private bool isEnd;
    
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
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            rows[activeRowIndex].DeleteLetter();
        }
        
        if (Input.anyKeyDown)
        {
            var input = Input.inputString;

            if (Extensions.IsLetter(input))
            {
                rows[activeRowIndex].WriteLetter(char.Parse(input));
            }
        }
    }
}

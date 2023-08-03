using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Row : MonoBehaviour
{
    public List<Tile> tiles;
    public bool isFull;

    private int activeTileIndex;

    private int ActiveTileIndex
    {
        get => activeTileIndex;
        set
        {
            if (value >= tiles.Count)
                isFull = true;
            else
                activeTileIndex = value;
        }
    }

    public void WriteLetter(char letter)
    {
        if (isFull) return;

        tiles[ActiveTileIndex++].Letter = char.Parse(letter.ToString().ToLower());
    }

    private string ReadWord()
    {
        if (!isFull) return string.Empty;

        var stringBuilder = new StringBuilder(string.Empty);

        foreach (var tile in tiles)
            stringBuilder.Append(tile.Letter);

        return stringBuilder.ToString().ToLower();
    }

    public void DeleteLetter()
    {
        if (isFull)
            tiles[ActiveTileIndex--].Letter = '\0';
        else
            tiles[--ActiveTileIndex].Letter = '\0';
    }

    public bool CheckAnswer(string answer)
    {
        if (ReadWord().Equals(answer))
        {
            foreach (var tile in tiles)
                tile.State = TileState.Correct;
            return true;
        }

        var index = 0;
        foreach (var tile in tiles)
        {
            var letter = tile.Letter;

            if (letter.Equals(answer[index++]))
                tile.State = TileState.Correct;
            else
                tile.State = answer.Contains(letter) ? TileState.MisPlaced : TileState.Wrong;
        }

        return false;
    }

    public void ResetRow()
    {
        foreach (var tile in tiles)
            tile.ResetTile();

        ActiveTileIndex = 0;
        isFull = false;
    }
}
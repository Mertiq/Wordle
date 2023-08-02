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

        tiles[ActiveTileIndex++].Letter = letter;
    }

    public string ReadWord()
    {
        if (!isFull) return string.Empty;
        
        var stringBuilder = new StringBuilder(string.Empty);

        foreach (var tile in tiles)
            stringBuilder.Append(tile.Letter);

        return stringBuilder.ToString();
    }

    public void DeleteLetter()
    {
        tiles[--ActiveTileIndex].Letter = '\0';
    }
}
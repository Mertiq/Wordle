using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image image;

    [HideInInspector] public TileState state;

    public bool isFilled => !letter.Equals('\0');

    private char letter = '\0';

    public char Letter
    {
        get => letter;
        set
        {
            letter = value;
            text.text = letter.ToString().ToUpper();
        }
    }

    public TileState State
    {
        get => state;
        set
        {
            state = value;
            image.sprite = GameManager.Instance.assetsHolder.tileStateSpritePair
                .FirstOrDefault(x => x.key.Equals(value))?.value;
        }
    }

    public void ResetTile()
    {
        Letter = '\0';
        State = TileState.None;   
    }
}

public enum TileState
{
    None,
    Correct,
    MisPlaced,
    Wrong
}
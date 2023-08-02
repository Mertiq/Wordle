using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image image;

    public bool isFilled => !letter.Equals('\0');

    private char letter = '\0';

    public char Letter
    {
        get => letter;
        set
        {
            if (isFilled) return;
            
            letter = value;
            text.text = letter.ToString().ToUpper();
        }
    }
}
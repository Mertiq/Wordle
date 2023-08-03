using System.Collections;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image image;
    [SerializeField] private float rotationDuration;


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

    public IEnumerator CheckTileLetter(string answer, int index)
    {
        yield return new WaitForSeconds(index * .25f);

        RotationAnimation();
        if (letter.Equals(answer[index]))
            State = TileState.Correct;
        else
            State = answer.Contains(letter) ? TileState.MisPlaced : TileState.Wrong;
    }
    
    public void ResetTile()
    {
        Letter = '\0';
        State = TileState.None;
    }
    
    private void RotationAnimation()
    {
        transform.DOLocalRotate(new Vector3(-90, 0, 0), rotationDuration).OnComplete(() =>
        {
            transform.DOLocalRotate(Vector3.zero, rotationDuration);
        });
    }

}

public enum TileState
{
    None,
    Correct,
    MisPlaced,
    Wrong
}
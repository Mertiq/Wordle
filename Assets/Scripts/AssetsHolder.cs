using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AssetsHolder", menuName = "AssetsHolder", order = 0)]
public class AssetsHolder : ScriptableObject
{
    public List<CustomKeyValuePair<TileState, Sprite>> tileStateSpritePair;
}
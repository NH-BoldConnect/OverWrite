using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card : MonoBehaviour
{
    public string CardID;
    public int Point;
    public int Priority;
    public Sprite Image;
    public Card(string _CardID, int _Point, int _Priority)
    {
        CardID = _CardID;
        Point = _Point;
        Priority = _Priority;
        Image = Resources.Load<Sprite>("Card/" + _CardID);
    }
}

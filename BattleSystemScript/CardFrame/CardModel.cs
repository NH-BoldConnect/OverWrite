using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardModel
{
    
    public string CardID;
    public int Point;
    public int Priority;
    public Sprite Image;

    public CardModel(string _CardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/" + _CardID);

        CardID = _CardID;
        Point = cardEntity.Point;
        Priority = cardEntity.Priority;
        Image = Resources.Load<Sprite>("Card/" + _CardID);
    }
}

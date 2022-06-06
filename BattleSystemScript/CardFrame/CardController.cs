using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public CardView view;
    public CardModel model;

    private void Awake()
    {
        view = GetComponent<CardView>();
    }

    public void Init(string cardID)
    {
        model = new CardModel(cardID);
        view.Show(model);
    }
}

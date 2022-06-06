using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomSystem : MonoBehaviour
{
    [SerializeField] Image CardImage;
    [SerializeField] GameObject ZoomImage;

    public void ZoomReceptor(Sprite _cardImage)
    {
        ZoomImage.SetActive (true);
        CardImage.sprite = _cardImage;
    }
}

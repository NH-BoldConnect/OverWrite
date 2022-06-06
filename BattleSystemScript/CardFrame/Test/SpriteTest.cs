using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteTest : MonoBehaviour
{
    [SerializeField] Image Pict;
    void Start()
    {
        Pict.sprite = Resources.Load<Sprite>("Card/1-1");
    }
    public void ClickGeneCard()
    {
        
    }
}

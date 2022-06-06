using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Net.Logging;
using SoftGear.Strix.Unity.Runtime.Event;
using System;

public class Priority3Effect : StrixBehaviour
{
    public int PlusMinus;
    public int Multiply;
    public int EffectPoint;
    GameObject SystemManager;

    [SerializeField] GameObject Priority0Field;
    [SerializeField] GameObject Priority1Field;
    [SerializeField] GameObject Priority2Field;

    [SerializeField] GameObject Priority4Field;
    [SerializeField] GameObject Priority5Field;
    [SerializeField] GameObject Priority6Field;
    [SerializeField] GameObject Priority7Field;
    [SerializeField] GameObject Priority8Field;
    [SerializeField] GameObject Priority9Field;
    [SerializeField] GameObject Priority10Field;

    [SerializeField] Text MyField3Point;
    [SerializeField] Text EnemyField3Point;

    [SerializeField] GameObject MyMarker3;
    [SerializeField] GameObject EnemyMarker3;

    string CardID = "";
    public int isMyCard = 0; //0=中立、1=自分、-1=敵
    public bool EffectActive = true;
    bool DidClear;

    void Update()
    {
        CopyEffectUpdate();
        if (EffectActive == true)
        {
            Priority3Boot();
            DidClear = false;
        }
        if (EffectActive == false & DidClear == false)
        {
            EffectClear();
            CardID34DidCheck = true;
            DidClear = true;
        }

        OverWriteAllow();
        
    }
    
    void Start()
    {
        SystemManager = GameObject.Find("SystemManager");
    }

    public void SetCardData(string _CardID, int _isMyCard)
    {
        CardID = _CardID;
        isMyCard = _isMyCard;
        CardID34DidCheck = false;
        EffectClear();
        CardIDTemp = _CardID;
    }

    public bool OverWriteBan;

    public void OverWriteAllow()
    {
        if (OverWriteBan == true)
        {
            foreach (Transform ChildCard in this.transform)
            {
                ChildCard.gameObject.GetComponent<CardOverWriteEvent>().OverWriteJudge = false;
            }
        }
        if (OverWriteBan == false)
        {
            foreach (Transform ChildCard in this.transform)
            {
                ChildCard.gameObject.GetComponent<CardOverWriteEvent>().OverWriteJudge = true;
            }
        }
    
    }

    public void Priority3Boot()
    {
        
        switch (CardID)
        {
            case "3-1":
                CardID31();
                break;

            case "3-2":
                CardID32();
                break;

            case "3-3":
                CardID33();
                break;

            case "3-4":
                CardID34();
                break;

            default:
                break;
        }
    }

    public int ID3Total;

    public void CardID31()
    {
        int Effect31 = 1;
        ID3Total = Effect31 * PlusMinus * Multiply;
        if (MyMarker3.activeSelf == true)
        {
            MyField3Point.text = ID3Total.ToString() + "P";
        }
        if (EnemyMarker3.activeSelf == true)
        {
            EnemyField3Point.text = ID3Total.ToString() + "P";
        }
    }

    int Effect32;

    public void CardID32()
    {
        CardId32Effect();
        ID3Total = Effect32 * PlusMinus * Multiply;
        if (MyMarker3.activeSelf == true)
        {
            MyField3Point.text = ID3Total.ToString() + "P";
        }
        if (EnemyMarker3.activeSelf == true)
        {
            EnemyField3Point.text = ID3Total.ToString() + "P";
        }
    }

    public void CardID33()
    {
        if (MyMarker3.activeSelf == true)
        {
            CardId33Effect();
        }
    }

    bool CardID34DidCheck;

    public void CardID34()
    {
        if (MyMarker3.activeSelf == true)
        {
            if (CardID34DidCheck == false)
            {
                CardId34Effect();
                CardID34DidCheck = true;
            }
        }
    }

    public void CardId32Effect()
    {
        int Priority10Card = Priority10Field.GetComponent<Priority10Effect>().isMyCard;
        if (Priority10Card != 0)
        {
            Effect32 = 5;
        }
        if (Priority10Card == 0)
        {
            EffectClear();
        }
    }
    
    [SerializeField] Text HandPointAddMemo;

    public void CardId33Effect()
    {
        HandPointAddMemo.text = "2";
    }
    

    public void CardId34Effect()
    {
        SystemManager.GetComponent<EraserAndDelete>().UnReverseBoot();
        Debug.Log("CardId34Effectが起動しました");
    }

    public void EffectClear()
    {
        SystemManager.GetComponent<EraserAndDelete>().UnReverseCancel();
        HandPointAddMemo.text = "";
        MyField3Point.text = "";
        EnemyField3Point.text = "";
        ID3Total = 0;
    }

    bool isCheckToggle;
    Text MyPointTextTemp;
    Text EnemyPointTextTemp;
    GameObject MyMarkerTemp;
    GameObject EnemyMarkerTemp;
    string CardIDTemp = "";
    
    GameObject MyPoint9;
    GameObject EnemyPoint9;
    GameObject MyMarker9;
    GameObject EnemyMarker9;
    public string CopycardID = "";

    void Awake()
    {
        MyPointTextTemp = MyField3Point;
        EnemyPointTextTemp = EnemyField3Point;

        MyMarkerTemp = MyMarker3;
        EnemyMarkerTemp = EnemyMarker3;

        MyPoint9 = GameObject.Find("MyPoint9");
        EnemyPoint9 = GameObject.Find("EnemyPoint9");

        GameObject PlayerMarker = GameObject.Find("PlayerMarker");
        Transform MyMarker9BoxTrans = PlayerMarker.transform.Find("9");

        Transform MyMarker9Trans = MyMarker9BoxTrans.Find("My9");
        MyMarker9 = MyMarker9Trans.gameObject;

        Transform EnemyMarker9Trans = MyMarker9BoxTrans.Find("Enemy9");
        EnemyMarker9 = EnemyMarker9Trans.gameObject;
    }

    public void PointAndMarkerTo9Set()
    {
        MyField3Point = MyPoint9.GetComponent<Text>();
        EnemyField3Point = EnemyPoint9.GetComponent<Text>();
        MyMarker3 = MyMarker9;
        EnemyMarker3 = EnemyMarker9;
        CardID = CopycardID;
    }

    public void PointAndMarkerTo9Clear()
    {
        MyField3Point = MyPointTextTemp;
        EnemyField3Point = EnemyPointTextTemp;
        MyMarker3 = MyMarkerTemp;
        EnemyMarker3 = EnemyMarkerTemp;
        CardID = CardIDTemp;
    }
    public void To9SetToggle()
    {
        if (isCheckToggle == false)
        {
            PointAndMarkerTo9Set();
            isCheckToggle = true;
            Debug.Log("To9Set");
        }
        else if (isCheckToggle == true)
        {
            PointAndMarkerTo9Clear();
            isCheckToggle = false;
            Debug.Log("To9Clear");
        }
    }

    public void CopyEffectUpdate()
    {
        if (isMyCard != 3 & CopycardID.Equals("") == false)
        {
            if (MyMarker3.activeSelf == true | EnemyMarker3.activeSelf == true)
            {
                To9SetToggle();
            }
        }
        if (isMyCard == 3 & CopycardID.Equals("") == false)
        {
            PointAndMarkerTo9Set();
            Priority3Boot();
            PointAndMarkerTo9Clear();
        }
    }
}

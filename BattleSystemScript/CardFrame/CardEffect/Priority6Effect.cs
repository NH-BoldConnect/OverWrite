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

public class Priority6Effect : StrixBehaviour
{
    public int PlusMinus;
    public int Multiply;
    public int EffectPoint;

    [SerializeField] GameObject Priority0Field;
    [SerializeField] GameObject Priority1Field;
    [SerializeField] GameObject Priority2Field;
    [SerializeField] GameObject Priority3Field;
    [SerializeField] GameObject Priority4Field;
    [SerializeField] GameObject Priority5Field;

    [SerializeField] GameObject Priority7Field;
    [SerializeField] GameObject Priority8Field;
    [SerializeField] GameObject Priority9Field;
    [SerializeField] GameObject Priority10Field;

    [SerializeField] Text MyField6Point;
    [SerializeField] Text EnemyField6Point;

    [SerializeField] GameObject MyMarker6;
    [SerializeField] GameObject EnemyMarker6;

    [SerializeField] Transform GraveContent;
    
    Text MyHandCountText;
    Text EnemyHandCountText;

    string CardID = "";
    public int isMyCard = 0; //0=中立、1=自分、-1=敵
    public bool EffectActive = true;
    bool DidClear;

    void Update()
    {
        CopyEffectUpdate();
        if (EffectActive == true)
        {
            Priority6Boot();
            DidClear = false;
        }
        if (EffectActive == false & DidClear == false)
        {
            EffectClear();
            DidClear = true;
        }

        OverWriteAllow();
        
    }

    void Start()
    {
        GameObject MyHandCountObject = GameObject.Find ("MyCount");
        MyHandCountText = MyHandCountObject.GetComponent<Text>();

        GameObject EnemyHandCountObject = GameObject.Find ("EnemyCount");
        EnemyHandCountText = EnemyHandCountObject.GetComponent<Text>();
    }

    public void SetCardData(string _CardID, int _isMyCard)
    {
        CardID = _CardID;
        isMyCard = _isMyCard;
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

    public void Priority6Boot()
    {
        
        switch (CardID)
        {
            case "6-1":
                CardID61();
                break;

            case "6-2":
                CardID62();
                break;

            case "6-3":
                CardID63();
                break;

            case "6-4":
                CardID64();
                break;

            default:
                break;
        }
    }

    public int ID6Total;

    int Id61Effect;

    public void CardID61()
    {
        CardID61Effect();
        ID6Total = Id61Effect * PlusMinus * Multiply;
        if (MyMarker6.activeSelf == true)
        {
            MyField6Point.text = ID6Total.ToString() + "P";
            if (ID6Total == 0)
            {
                MyField6Point.text = "";
            }
        }
        if (EnemyMarker6.activeSelf == true)
        {
            EnemyField6Point.text = ID6Total.ToString() + "P";
            if (ID6Total == 0)
            {
                EnemyField6Point.text = "";
            }
        }
    }

    int Id62Effect;

    public void CardID62()
    {
        CardID62Effect();
        ID6Total = Id62Effect * PlusMinus * Multiply;
        if (MyMarker6.activeSelf == true)
        {
            MyField6Point.text = ID6Total.ToString() + "P";
            if (ID6Total == 0)
            {
                MyField6Point.text = "";
            }
        }
        if (EnemyMarker6.activeSelf == true)
        {
            EnemyField6Point.text = ID6Total.ToString() + "P";
            if (ID6Total == 0)
            {
                EnemyField6Point.text = "";
            }
        }
    }

    int Id63Effect;

    public void CardID63()
    {
        CardID63Effect();
        ID6Total = Id63Effect * PlusMinus * Multiply;
        if (MyMarker6.activeSelf == true)
        {
            MyField6Point.text = ID6Total.ToString() + "P";
            if (ID6Total == 0)
            {
                MyField6Point.text = "";
            }
        }
        if (EnemyMarker6.activeSelf == true)
        {
            EnemyField6Point.text = ID6Total.ToString() + "P";
            if (ID6Total == 0)
            {
                EnemyField6Point.text = "";
            }
        }
    }

    int Id64Effect;

    public void CardID64()
    {
        CardID64Effect();
        ID6Total = Id64Effect * PlusMinus * Multiply;
        if (MyMarker6.activeSelf == true)
        {
            MyField6Point.text = ID6Total.ToString() + "P";
        }
        if (EnemyMarker6.activeSelf == true)
        {
            EnemyField6Point.text = ID6Total.ToString() + "P";
        }
    }

    public void CardID61Effect()
    {
        string MyHandCountString = MyHandCountText.text.ToString();
        int MyHandCountNumber = int.Parse(MyHandCountString);

        string EnemyHandCountString = EnemyHandCountText.text.ToString();
        int EnemyHandCountNumber = int.Parse(EnemyHandCountString);
        if (MyMarker6.activeSelf == true)
        {
            if (MyHandCountNumber > EnemyHandCountNumber)
            {
                Id61Effect = 4;
            }
            if (MyHandCountNumber <= EnemyHandCountNumber)
            {
                Id61Effect = 0;
            }
        }
        if (EnemyMarker6.activeSelf == true)
        {
            if (MyHandCountNumber < EnemyHandCountNumber)
            {
                Id61Effect = 4;
            }
            if (MyHandCountNumber >= EnemyHandCountNumber)
            {
                Id61Effect = 0;
            }
        }
    }

    public void CardID62Effect()
    {
        string MyHandCountString = MyHandCountText.text.ToString();
        int MyHandCountNumber = int.Parse(MyHandCountString);

        string EnemyHandCountString = EnemyHandCountText.text.ToString();
        int EnemyHandCountNumber = int.Parse(EnemyHandCountString);
        
        if (MyHandCountNumber == EnemyHandCountNumber)
        {
            Id62Effect = 6;
        }
        if (MyHandCountNumber != EnemyHandCountNumber)
        {
            Id62Effect = 0;
        }
    }

    public void CardID63Effect()
    {
        string MyHandCountString = MyHandCountText.text.ToString();
        int MyHandCountNumber = int.Parse(MyHandCountString);

        string EnemyHandCountString = EnemyHandCountText.text.ToString();
        int EnemyHandCountNumber = int.Parse(EnemyHandCountString);
        
        if (MyMarker6.activeSelf == true)
        {
            if (MyHandCountNumber < EnemyHandCountNumber)
            {
                Id63Effect = 8;
            }
            if (MyHandCountNumber >= EnemyHandCountNumber)
            {
                Id63Effect = 0;
            }
        }
        if (EnemyMarker6.activeSelf == true)
        {
            if (MyHandCountNumber > EnemyHandCountNumber)
            {
                Id63Effect = 8;
            }
            if (MyHandCountNumber <= EnemyHandCountNumber)
            {
                Id63Effect = 0;
            }
        }
    }

    public void CardID64Effect()
    {
        int Temp64Point = 0;
        foreach (Transform Card in GraveContent)
        {
            string Priority6CardName = Card.gameObject.GetComponent<CardView>()._CardID;
            if (Priority6CardName.Equals("6-1"))
            {
                Temp64Point += 4;
            }
            if (Priority6CardName.Equals("6-2"))
            {
                Temp64Point += 6;
            }
            if (Priority6CardName.Equals("6-3"))
            {
                Temp64Point += 8;
            }
            if (Priority6CardName.Equals("6-4"))
            {
                Temp64Point += 2;
            }
        }
        if (Temp64Point == 0)
        {
            Temp64Point = 2;
        }
        Id64Effect = Temp64Point;
    }

    public void EffectClear()
    {
        MyField6Point.text = "";
        EnemyField6Point.text = "";
        ID6Total = 0;
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
        MyPointTextTemp = MyField6Point;
        EnemyPointTextTemp = EnemyField6Point;

        MyMarkerTemp = MyMarker6;
        EnemyMarkerTemp = EnemyMarker6;

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
        MyField6Point = MyPoint9.GetComponent<Text>();
        EnemyField6Point = EnemyPoint9.GetComponent<Text>();
        MyMarker6 = MyMarker9;
        EnemyMarker6 = EnemyMarker9;
        CardID = CopycardID;
    }

    public void PointAndMarkerTo9Clear()
    {
        MyField6Point = MyPointTextTemp;
        EnemyField6Point = EnemyPointTextTemp;
        MyMarker6 = MyMarkerTemp;
        EnemyMarker6 = EnemyMarkerTemp;
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
        if (isMyCard != 6 & CopycardID.Equals("") == false)
        {
            if (MyMarker6.activeSelf == true | EnemyMarker6.activeSelf == true)
            {
                To9SetToggle();
            }
        }
        if (isMyCard == 6 & CopycardID.Equals("") == false)
        {
            PointAndMarkerTo9Set();
            Priority6Boot();
            PointAndMarkerTo9Clear();
        }
    }
}

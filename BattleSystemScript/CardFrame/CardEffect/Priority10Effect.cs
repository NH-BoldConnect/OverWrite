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

public class Priority10Effect : StrixBehaviour
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
    [SerializeField] GameObject Priority6Field;
    [SerializeField] GameObject Priority7Field;
    [SerializeField] GameObject Priority8Field;
    [SerializeField] GameObject Priority9Field;

    [SerializeField] Text MyField10Point;
    [SerializeField] Text EnemyField10Point;

    [SerializeField] GameObject MyMarker10;
    [SerializeField] GameObject EnemyMarker10;

    [SerializeField] Transform HandField;
    
    [SerializeField] Text MyHandCount;
    [SerializeField] Text EnemyHandCount;

    GameObject SystemManager;

    string CardID = "";
    public int isMyCard = 0; //0=中立、1=自分、-1=敵
    public bool EffectActive = true;
    bool DidClear;

    void Update()
    {
        CopyEffectUpdate();

        if (EffectActive == true)
        {
            Priority10Boot();
            DidClear = false;
        }
        if (EffectActive == false & DidClear == false)
        {
            EffectClear();
            DidClear = true;
        }
        
    }

    public void SetCardData(string _CardID, int _isMyCard)
    {
        CardID = _CardID;
        isMyCard = _isMyCard;
        EffectClear();
        CardIDTemp = _CardID;
        Set93WithDelete();
    }

    void Start()
    {
        SystemManager = GameObject.Find("SystemManager");
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


    public void Priority10Boot()
    {
        switch (CardID)
        {
            case "9-3":
                CardID101();
                break;
        }
    }

    public int ID10Total;

    public void CardID101()
    {
        Card10Effect();
        ID10Total = Effect101 * PlusMinus * Multiply;
        if (MyMarker10.activeSelf == true)
        {
            MyField10Point.text = ID10Total.ToString() + "P";
        }
        if (EnemyMarker10.activeSelf == true)
        {
            EnemyField10Point.text = ID10Total.ToString() + "P";
        }
    }

    int Effect101;

    public void Card10Effect()
    {
        if (MyMarker10.activeSelf == true)
        {
            string MyHandCountString = MyHandCount.text.ToString();
            Effect101 = int.Parse(MyHandCountString);
        }
        if (EnemyMarker10.activeSelf == true)
        {
            string EnemyHandCountString = EnemyHandCount.text.ToString();
            Effect101 = int.Parse(EnemyHandCountString);
        }
    }

    public void Set93WithDelete()
    {
        if (CardID.Equals("9-3"))
        {
            foreach (Transform OldCard in Priority9Field.transform)
            {
                Destroy(OldCard.gameObject);
            }
            SystemManager.GetComponent<MarkerController>().MarkerClear(9);
        }
    }

    public void EffectClear()
    {
        MyField10Point.text = "";
        EnemyField10Point.text = "";
        ID10Total = 0;
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
        MyPointTextTemp = MyField10Point;
        EnemyPointTextTemp = EnemyField10Point;

        MyMarkerTemp = MyMarker10;
        EnemyMarkerTemp = EnemyMarker10;

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
        MyField10Point = MyPoint9.GetComponent<Text>();
        EnemyField10Point = EnemyPoint9.GetComponent<Text>();
        MyMarker10 = MyMarker9;
        EnemyMarker10 = EnemyMarker9;
        CardID = CopycardID;
    }

    public void PointAndMarkerTo9Clear()
    {
        MyField10Point = MyPointTextTemp;
        EnemyField10Point = EnemyPointTextTemp;
        MyMarker10 = MyMarkerTemp;
        EnemyMarker10 = EnemyMarkerTemp;
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
        if (isMyCard != 10 & CopycardID.Equals("") == false)
        {
            if (MyMarker10.activeSelf == true | EnemyMarker10.activeSelf == true)
            {
                To9SetToggle();
            }
        }
        if (isMyCard == 10 & CopycardID.Equals("") == false)
        {
            PointAndMarkerTo9Set();
            Priority10Boot();
            PointAndMarkerTo9Clear();
        }
    }
}
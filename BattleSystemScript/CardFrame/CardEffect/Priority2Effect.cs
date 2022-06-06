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

public class Priority2Effect : StrixBehaviour
{
    public int PlusMinus;
    public int Multiply;
    public int EffectPoint;

    [SerializeField] GameObject Priority0Field;
    [SerializeField] GameObject Priority1Field;

    [SerializeField] GameObject Priority3Field;
    [SerializeField] GameObject Priority4Field;
    [SerializeField] GameObject Priority5Field;
    [SerializeField] GameObject Priority6Field;
    [SerializeField] GameObject Priority7Field;
    [SerializeField] GameObject Priority8Field;
    [SerializeField] GameObject Priority9Field;
    [SerializeField] GameObject Priority10Field;

    [SerializeField] Text MyField2Point;
    [SerializeField] Text EnemyField2Point;

    [SerializeField] GameObject MyMarker2;
    [SerializeField] GameObject EnemyMarker2;

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
            Priority2Boot();
            DidClear = false;
        }
        if (EffectActive == false & DidClear == false)
        {
            EffectClear();
            CardID22DidCheck = true;
            CardID24DidCheck = true;
            DidClear = true;
        }

        OverWriteAllow();
        
    }

    public void SetCardData(string _CardID, int _isMyCard)
    {
        CardID = _CardID;
        isMyCard = _isMyCard;
        EffectClear();
        CardID22DidCheck = false;
        CardID24DidCheck = false;
        CardIDTemp = _CardID;
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

    public void Priority2Boot()
    {
        
        switch (CardID)
        {
            case "2-1":
                CardID21();
                break;

            case "2-2":
                CardID22();
                break;

            case "2-3":
                CardID23();
                break;

            case "2-4":
                CardID24();
                break;

            default:
                break;
        }
    }

    public int ID2Total;
    int Effect21;

    public void CardID21()
    {
        CardID21Effect();
        ID2Total = Effect21 * PlusMinus * Multiply;
        if (MyMarker2.activeSelf == true)
        {
            MyField2Point.text = ID2Total.ToString() + "P";
        }
        if (EnemyMarker2.activeSelf == true)
        {
            EnemyField2Point.text = ID2Total.ToString() + "P";
        }
    }

    bool CardID22DidCheck = false;

    public void CardID22()
    {
        if (MyMarker2.activeSelf == true)
        {
            if (CardID22DidCheck == false)
            {
                SystemManager.GetComponent<EraserAndDelete>().ToGraveBoot(2);
                CardID22DidCheck = true;
            }
        }
    }

    int Effect23One;
    int Effect23Two;

    public void CardID23()
    {
        CardID23Effect1();
        CardID23Effect2();
        if (Effect23One != 0 | Effect23Two != 0)
        {
            ID2Total = Effect23One + Effect23Two;
            ID2Total = ID2Total * PlusMinus * Multiply;
            if (MyMarker2.activeSelf == true)
            {
                MyField2Point.text = ID2Total.ToString() + "P";
            }
            if (EnemyMarker2.activeSelf == true)
            {
                EnemyField2Point.text = ID2Total.ToString() + "P";
            }
        }
        if (Effect23One == 0 & Effect23Two == 0)
        {
            ID2Total = 0;
            MyField2Point.text = "";
            EnemyField2Point.text = "";
        }
    }

    bool CardID24DidCheck = false;

    public void CardID24()
    {
        if (MyMarker2.activeSelf == true)
        {
            if (CardID24DidCheck == false)
            {
                CardId24Effect();
                CardID24DidCheck = true;
            }
        }
    }

    public void CardID21Effect()
    {
        int Priority0Card = Priority0Field.GetComponent<Priority0Effect>().isMyCard;
        int Priority1Card = Priority1Field.GetComponent<Priority1Effect>().isMyCard;
        if (MyMarker2.activeSelf == true)
        {
            if (Priority0Card != 1 && Priority1Card != 1)
            {
                Effect21 = -20;
            }
            if (Priority0Card == 1 || Priority1Card == 1)
            {
                Effect21 = 5;
            }
        }
        if (EnemyMarker2.activeSelf == true)
        {
            if (Priority0Card != -1 && Priority1Card != -1)
            {
                Effect21 = -20;
            }
            if (Priority0Card == -1 || Priority1Card == -1)
            {
                Effect21 = 5;
            }
        }
        

    }

    public void CardID23Effect1()
    {
        int Priority3Card = Priority3Field.GetComponent<Priority3Effect>().isMyCard;
        int Priority5Card = Priority5Field.GetComponent<Priority5Effect>().isMyCard;
        int Priority7Card = Priority7Field.GetComponent<Priority7Effect>().isMyCard;
        if (MyMarker2.activeSelf == true)
        {
            if (Priority3Card != 1 | Priority5Card != 1 | Priority7Card != 1)
            {
                Effect23One = 0;
            }
            if (Priority3Card == 1 & Priority5Card == 1 & Priority7Card == 1)
            {
                Effect23One = 20;
            }
        }
        if (EnemyMarker2.activeSelf == true)
        {
            if (Priority3Card != -1 | Priority5Card != -1 | Priority7Card != -1)
            {
                Effect23One = 0;
            }
            if (Priority3Card == -1 & Priority5Card == -1 & Priority7Card == -1)
            {
                Effect23One = 20;
            }
        }
    }

    public void CardID23Effect2()
    {
        int Priority1Card = Priority1Field.GetComponent<Priority1Effect>().isMyCard;
        int Priority4Card = Priority4Field.GetComponent<Priority4Effect>().isMyCard;
        int Priority9Card = Priority9Field.GetComponent<Priority9Effect>().isMyCard;
        if (MyMarker2.activeSelf == true)
        {
            if (Priority1Card != 1 & Priority4Card != 1 & Priority9Card != 1)
            {
                Effect23Two = 0;
            }
            if (Priority1Card == 1 | Priority4Card == 1 | Priority9Card == 1)
            {
                Effect23Two = -3;
            }
        }
        if (EnemyMarker2.activeSelf == true)
        {
            if (Priority1Card != -1 & Priority4Card != -1 & Priority9Card != -1)
            {
                Effect23Two = 0;
            }
            if (Priority1Card == -1 | Priority4Card == -1 | Priority9Card == -1)
            {
                Effect23Two = -3;
            }
        }
    }

    public void CardId24Effect()
    {
        for (int i = 0; i < 2; i++)
        {
            SystemManager.GetComponent<BattleSystem>().ClickAddCard();
        }
    }

    public void EffectClear()
    {
        MyField2Point.text = "";
        EnemyField2Point.text = "";
        ID2Total = 0;
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
        MyPointTextTemp = MyField2Point;
        EnemyPointTextTemp = EnemyField2Point;

        MyMarkerTemp = MyMarker2;
        EnemyMarkerTemp = EnemyMarker2;

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
        MyField2Point = MyPoint9.GetComponent<Text>();
        EnemyField2Point = EnemyPoint9.GetComponent<Text>();
        MyMarker2 = MyMarker9;
        EnemyMarker2 = EnemyMarker9;
        CardID = CopycardID;
    }

    public void PointAndMarkerTo9Clear()
    {
        MyField2Point = MyPointTextTemp;
        EnemyField2Point = EnemyPointTextTemp;
        MyMarker2 = MyMarkerTemp;
        EnemyMarker2 = EnemyMarkerTemp;
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
        if (isMyCard != 2 & CopycardID.Equals("") == false)
        {
            if (MyMarker2.activeSelf == true | EnemyMarker2.activeSelf == true)
            {
                To9SetToggle();
            }
        }
        if (isMyCard == 2 & CopycardID.Equals("") == false)
        {
            PointAndMarkerTo9Set();
            Priority2Boot();
            PointAndMarkerTo9Clear();
        }
    }
}



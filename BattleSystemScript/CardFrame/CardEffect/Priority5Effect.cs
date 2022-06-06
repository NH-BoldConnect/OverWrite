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

public class Priority5Effect : StrixBehaviour
{
    public int PlusMinus;
    public int Multiply;
    public int EffectPoint;

    [SerializeField] GameObject Priority0Field;
    [SerializeField] GameObject Priority1Field;
    [SerializeField] GameObject Priority2Field;
    [SerializeField] GameObject Priority3Field;
    [SerializeField] GameObject Priority4Field;

    [SerializeField] GameObject Priority6Field;
    [SerializeField] GameObject Priority7Field;
    [SerializeField] GameObject Priority8Field;
    [SerializeField] GameObject Priority9Field;
    [SerializeField] GameObject Priority10Field;

    [SerializeField] Text MyField5Point;
    [SerializeField] Text EnemyField5Point;

    [SerializeField] GameObject MyMarker5;
    [SerializeField] GameObject EnemyMarker5;
    
    GameObject SystemManager;
    GameObject TurnManager;

    [SerializeField] Transform GraveContent;

    string CardID = "";
    public int isMyCard = 0; //0=中立、1=自分、-1=敵
    public bool EffectActive = true;
    bool DidClear;

    void Update()
    {
        CopyEffectUpdate();
        if (EffectActive == true)
        {
            Priority5Boot();
            DidClear = false;
        }
        if (EffectActive == false & DidClear == false)
        {
            EffectClear();
            CardID52DidCheck = true;
            CardID53DidCheck = true;
            CardID54DidCheck = true;
            DidClear = true;
        }

        OverWriteAllow();
    }

    void Start()
    {
        SystemManager = GameObject.Find("SystemManager");
        TurnManager = GameObject.Find("TurnMamager");
    }

    public void SetCardData(string _CardID, int _isMyCard)
    {
        CardID = _CardID;
        isMyCard = _isMyCard;
        EffectClear();
        SetCardID51(_CardID);
        Can51EffectJudge(_CardID);
        CardID51Effect();
        CardID52DidCheck = false;
        CardID53DidCheck = false;
        CardID54DidCheck = false;
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

    public void Priority5Boot()
    {
        
        switch (CardID)
        {
            case "5-1":
                CardID51();
                break;

            case "5-2":
                CardID52();
                break;

            case "5-3":
                CardID53();
                break;

            case "5-4":
                CardID54();
                break;

            default:
                break;
        }
    }

    public int ID5Total;
    bool InCard51;

    public void CardID51()
    {
        ID5Total = 4 * PlusMinus * Multiply;
        if (MyMarker5.activeSelf == true)
        {
            MyField5Point.text = ID5Total.ToString() + "P";
        }
        if (EnemyMarker5.activeSelf == true)
        {
            EnemyField5Point.text = ID5Total.ToString() + "P";
        }
    }

    bool CardID52DidCheck;

    public void CardID52()
    {
        if (MyMarker5.activeSelf == true)
        {
            if (CardID52DidCheck == false)
            {
                Card52Effect();
                CardID52DidCheck = true;
            }
        }
    }

    bool CardID53DidCheck;

    public void CardID53()
    {
        if (MyMarker5.activeSelf == true)
        {
            TurnManager.GetComponent<TurnController>().EndPhaseEffect = true;
            bool EndPhaseAlert = TurnManager.GetComponent<TurnController>().EndPhaseAlert;
            if (CardID53DidCheck == false & EndPhaseAlert == true)
            {
                Card53Effect();
                if (GraveContent.childCount == 0)
                {
                    SystemManager.GetComponent<EraserAndDelete>().GraveToHandCancel();
                }
                CardID53DidCheck = true;
            }
        }
        
    }

    bool CardID54DidCheck;

    public void CardID54()
    {
        ID5Total = -4 * PlusMinus * Multiply;
        if (MyMarker5.activeSelf == true)
        {
            MyField5Point.text = ID5Total.ToString() + "P";
            if (CardID54DidCheck == false)
            {
                Card54Effect();
                CardID54DidCheck = true;
            }
        }
        if (EnemyMarker5.activeSelf == true)
        {
            EnemyField5Point.text = ID5Total.ToString() + "P";
        }
    }

    public void CardID51Effect()
    {
        if (InCard51 == true & InCardOther51 == true)
        {
            SystemManager.GetComponent<EraserAndDelete>().ToGraveHandOnlyBoot(false);
            InCard51 = false;
        }
    }

    bool InCardOther51;
    string TempCardID = "";

    public void Can51EffectJudge(string _CardID)
    {
        switch (_CardID)
        {
            case "5-1":
                InCardOther51 = false;
                break;

            default:
                InCardOther51 = true;
                break;
        }
        if (TempCardID.Equals(_CardID))
        {
            InCardOther51 = true;
        }
        TempCardID = _CardID;
    }

    public void SetCardID51(string _CardID)
    {
        switch (_CardID)
        {
            case "5-1":
                InCard51 = true;
                break;
            default:
                break;
        }
    }

    public void Card52Effect()
    {
        int[] AllSearch = new int[10];
        AllSearch[0] = Priority0Field.GetComponent<Priority0Effect>().isMyCard;
        AllSearch[1] = Priority1Field.GetComponent<Priority1Effect>().isMyCard;
        AllSearch[2] = Priority2Field.GetComponent<Priority2Effect>().isMyCard;
        AllSearch[3] = Priority3Field.GetComponent<Priority3Effect>().isMyCard;
        AllSearch[4] = Priority4Field.GetComponent<Priority4Effect>().isMyCard;
        AllSearch[5] = Priority6Field.GetComponent<Priority6Effect>().isMyCard;
        AllSearch[6] = Priority7Field.GetComponent<Priority7Effect>().isMyCard;
        AllSearch[7] = Priority8Field.GetComponent<Priority8Effect>().isMyCard;
        AllSearch[8] = Priority9Field.GetComponent<Priority9Effect>().isMyCard;
        AllSearch[9] = Priority10Field.GetComponent<Priority10Effect>().isMyCard;

        int MyCardCount = 0;
        foreach (int Card in AllSearch)
        {
            if (Card == 1)
            {
                MyCardCount++ ;
            }
        }
        if (MyCardCount > 0)
        {
            SystemManager.GetComponent<EraserAndDelete>().ToGraveFieldOnlyBoot(5);
        }
        if (MyCardCount == 0)
        {
            SystemManager.GetComponent<EraserAndDelete>().ToGraveHandOnlyBoot(false);
        }
    }

    public void Card53Effect()
    {
        SystemManager.GetComponent<EraserAndDelete>().GraveToHandBoot();
    }

    public void Card54Effect()
    {
        SystemManager.GetComponent<EraserAndDelete>().ReverseBoot(5);
    }

    public void EffectClear()
    {
        MyField5Point.text = "";
        EnemyField5Point.text = "";
        ID5Total = 0;
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
        MyPointTextTemp = MyField5Point;
        EnemyPointTextTemp = EnemyField5Point;

        MyMarkerTemp = MyMarker5;
        EnemyMarkerTemp = EnemyMarker5;

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
        MyField5Point = MyPoint9.GetComponent<Text>();
        EnemyField5Point = EnemyPoint9.GetComponent<Text>();
        MyMarker5 = MyMarker9;
        EnemyMarker5 = EnemyMarker9;
        CardID = CopycardID;
    }

    public void PointAndMarkerTo9Clear()
    {
        MyField5Point = MyPointTextTemp;
        EnemyField5Point = EnemyPointTextTemp;
        MyMarker5 = MyMarkerTemp;
        EnemyMarker5 = EnemyMarkerTemp;
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
        if (isMyCard != 5 & CopycardID.Equals("") == false)
        {
            if (MyMarker5.activeSelf == true | EnemyMarker5.activeSelf == true)
            {
                To9SetToggle();
            }
        }
        if (isMyCard == 5 & CopycardID.Equals("") == false)
        {
            PointAndMarkerTo9Set();
            Priority5Boot();
            PointAndMarkerTo9Clear();
        }
    }
}

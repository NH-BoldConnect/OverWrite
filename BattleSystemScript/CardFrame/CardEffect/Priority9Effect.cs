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

public class Priority9Effect : StrixBehaviour
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

    [SerializeField] GameObject Priority10Field;

    [SerializeField] Text MyField9Point;
    [SerializeField] Text EnemyField9Point;

    [SerializeField] GameObject MyMarker9;
    [SerializeField] GameObject EnemyMarker9;

    [SerializeField] Transform GraveContent;
    [SerializeField] Transform HandField;
    
    GameObject SystemManager;

    string CardID = "";
    public int isMyCard = 0; //0=中立、1=自分、-1=敵
    public bool EffectActive = true;
    bool DidClear;

    void Update()
    {
        if (EffectActive == true)
        {
            Priority9Boot();
            DidClear = false;
        }
        if (EffectActive == false & DidClear == false)
        {
            EffectClear();
            CardID91DidCheck = false;
            DidClear = true;
        }

        OverWriteAllow();
        
    }

    public void SetCardData(string _CardID, int _isMyCard)
    {
        CardID = _CardID;
        isMyCard = _isMyCard;
        EffectClear();
        if (MyMarker9.activeSelf == true)
        {
            SetCardID94(_CardID);
            Can94EffectJudge(_CardID);
            CardId94EffectDraw();
        }
        CardID91DidCheck = false;
        CardID93DidCheck = false;
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

    public void Priority9Boot()
    {
        
        switch (CardID)
        {
            case "9-1":
                CardID91();
                break;

            case "9-2":
                CardID92();
                break;

            case "9-3":
                CardID93();
                break;

            case "9-4":
                CardID94();
                break;

            default:
                break;
        }
    }

    public int ID9Total;

    bool CardID91DidCheck;

    public void CardID91()
    {
    
        if (CardID91DidCheck == false)
        {
            CardID91EffectCopy();
            CardID91DidCheck = true;
        }
    
    }

    public void CardID92()
    {
        int Priority3 = Priority3Field.GetComponent<Priority3Effect>().isMyCard;
        if (MyMarker9.activeSelf == true)
        {
            if (Priority3 == 1)
            {
                Effect92HandMultiply(5);
                Priority3Field.GetComponent<Priority3Effect>().Multiply = 5;
            }
        }
        if (EnemyMarker9.activeSelf == true)
        {
            if (Priority3 == -1)
            {
                Priority3Field.GetComponent<Priority3Effect>().Multiply = 5;
            }
        }
    }

    bool CardID93DidCheck;

    public void CardID93()
    {
        if (MyMarker9.activeSelf == true)
        {
            if (CardID93DidCheck == false)
            {
                Card93EffectRemote();
                CardID93DidCheck = true;
            }
        }
    }

    bool InCard94;

    public void CardID94()
    {
        ID9Total = 12 * Multiply * PlusMinus;
        if (MyMarker9.activeSelf == true)
        {
            MyField9Point.text = ID9Total.ToString() + "P";
        }
        if (EnemyMarker9.activeSelf == true)
        {
            EnemyField9Point.text = ID9Total.ToString() + "P";
        }
    }

    public void CardID91EffectCopy()
    {
        string GraveCardID = "";
        int GraveCardPriority = 0;
        foreach (Transform GraveCard in GraveContent)
        {
            GraveCardID = GraveCard.gameObject.GetComponent<CardView>()._CardID;
            GraveCardPriority = GraveCard.gameObject.GetComponent<CardView>()._Priority;
        }
        Effect91Input(GraveCardPriority, GraveCardID);

    }

    int PriorityTemp = 0;

    public void Effect91Input(int _Priority, string _CardID)
    {
        PriorityTemp = _Priority;
        switch (_Priority)
        {
            case 0:
                Priority0Field.GetComponent<Priority0Effect>().CopycardID = _CardID;
                break;
            case 1:
                Priority1Field.GetComponent<Priority1Effect>().CopycardID = _CardID;
                break;
            case 2:
                Priority2Field.GetComponent<Priority2Effect>().CopycardID = _CardID;
                break;
            case 3:
                Priority3Field.GetComponent<Priority3Effect>().CopycardID = _CardID;
                break;
            case 4:
                Priority4Field.GetComponent<Priority4Effect>().CopycardID = _CardID;
                break;
            case 5:
                Priority5Field.GetComponent<Priority5Effect>().CopycardID = _CardID;
                break;
            case 6:
                Priority6Field.GetComponent<Priority6Effect>().CopycardID = _CardID;
                break;
            case 7:
                Priority7Field.GetComponent<Priority7Effect>().CopycardID = _CardID;
                break;
            case 8:
                Priority8Field.GetComponent<Priority8Effect>().CopycardID = _CardID;
                break;
            case 9:
                CardID = _CardID;
                break;
            case 10:
                Priority10Field.GetComponent<Priority10Effect>().CopycardID = _CardID;
                break;
        }
    }

    public void Effect92HandMultiply(int Multiply)
    {
        foreach (Transform Card in HandField)
        {
            int CardPriority = Card.gameObject.GetComponent<CardView>()._Priority;
            if (CardPriority == 3)
            {
                Card.gameObject.GetComponent<CardView>()._Multiply = Multiply;
            }
        }
    }

    public void Card93EffectRemote()
    {
        SystemManager.GetComponent<EraserAndDelete>().ToGraveHandOnlyBoot(true);
        SystemManager.GetComponent<EraserAndDelete>().Effect93ToGraveBoot = true;
    }

    public void Card93To10FieldEffect()
    {
        Priority10Field.GetComponent<DropPlace>().FreeCreateCard("9-3",10);
        Priority10Field.GetComponent<DropPlace>().FieldUpdate("9-3", 10);
        SystemManager.GetComponent<MarkerController>().MarkerSwitch(10, true);
        SystemManager.GetComponent<MarkerController>().MarkerClear(9);
    }

    public void CardId94EffectDraw()
    {
        if (InCard94 == true & InCardOther94 == true)
        {
            for (int i = 0; i < 2; i++)
            {
                SystemManager.GetComponent<BattleSystem>().ClickAddCard();
            }
        }
        
    }

    bool InCardOther94;
    string TempCardID = "";

    public void Can94EffectJudge(string _CardID)
    {
        switch (_CardID)
        {
            case "9-4":
                InCardOther94 = false;
                break;

            default:
                InCardOther94 = true;
                break;
        }
        if (TempCardID.Equals(_CardID))
        {
            InCardOther94 = true;
        }
        TempCardID = _CardID;
    }

    public void SetCardID94(string _CardID)
    {
        switch (_CardID)
        {
            case "9-4":
                InCard94 = true;
                break;
            default:
                break;
        }
    }

    public void EffectClear()
    {
        Effect92HandMultiply(1);
        Priority3Field.GetComponent<Priority3Effect>().Multiply = 1;
        Effect91Input(PriorityTemp, "");
        MyField9Point.text = "";
        EnemyField9Point.text = "";
        ID9Total = 0;
    }

    bool isCheckToggle;
    Text MyPointTextTemp;
    Text EnemyPointTextTemp;
    GameObject MyMarkerTemp;
    GameObject EnemyMarkerTemp;
    string CardIDTemp = "";
    
    GameObject MyPoint9;
    GameObject EnemyPoint9;
    GameObject MyMarker9Obj;
    GameObject EnemyMarker9Obj;
    public string CopycardID = "";

    void Awake()
    {
        MyPointTextTemp = MyField9Point;
        EnemyPointTextTemp = EnemyField9Point;

        MyMarkerTemp = MyMarker9;
        EnemyMarkerTemp = EnemyMarker9;

        MyPoint9 = MyField9Point.gameObject;
        EnemyPoint9 = EnemyField9Point.gameObject;

        MyMarker9Obj = MyMarker9.gameObject;

        EnemyMarker9Obj = MyMarker9.gameObject;
        CardIDTemp = CardID;
    }

    public void PointAndMarkerTo9Set()
    {
        MyField9Point = MyPoint9.GetComponent<Text>();
        EnemyField9Point = EnemyPoint9.GetComponent<Text>();
        MyMarker9 = MyMarker9Obj;
        EnemyMarker9 = EnemyMarker9Obj;
        CardID = CopycardID;
    }

    public void PointAndMarkerTo9Clear()
    {
        MyField9Point = MyPointTextTemp;
        EnemyField9Point = EnemyPointTextTemp;
        MyMarker9 = MyMarkerTemp;
        EnemyMarker9 = EnemyMarkerTemp;
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

    public bool Can9Boot = false;

    public void CopyEffectUpdate()
    {
        if (isMyCard != 0 & Can9Boot == true)
        {
            To9SetToggle();
        }
        if (isMyCard == 0 & Can9Boot == true)
        {
            PointAndMarkerTo9Set();
            Priority9Boot();
            PointAndMarkerTo9Clear();
        }
    }
}

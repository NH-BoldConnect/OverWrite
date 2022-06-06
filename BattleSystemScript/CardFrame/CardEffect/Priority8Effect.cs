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

public class Priority8Effect : StrixBehaviour
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

    [SerializeField] GameObject Priority9Field;
    [SerializeField] GameObject Priority10Field;

    [SerializeField] Text MyField8Point;
    [SerializeField] Text EnemyField8Point;

    [SerializeField] GameObject MyMarker8;
    [SerializeField] GameObject EnemyMarker8;

    string CardID = "";
    public int isMyCard = 0; //0=中立、1=自分、-1=敵
    public bool EffectActive = true;
    bool DidClear;
    
    GameObject TurnMamager;

    void Update()
    {
        CopyEffectUpdate();
        if (EffectActive == true)
        {
            Priority8Boot();
            DidClear = false;
        }
        if (EffectActive == false & DidClear == false)
        {
            EffectClear();
            DidClear = true;
        }

        OverWriteAllow();
        
    }

    public void SetCardData(string _CardID, int _isMyCard)
    {
        CardID = _CardID;
        isMyCard = _isMyCard;
        EffectClear();
        CardIDTemp = _CardID;
    }

    void Start()
    {
        TurnMamager = GameObject.Find("TurnMamager");
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

    public void Priority8Boot()
    {
        
        switch (CardID)
        {
            case "8-1":
                CardID81();
                break;

            case "8-2":
                CardID82();
                break;

            case "8-3":
                CardID83();
                break;

            case "8-4":
                CardID84();
                break;

            default:
                break;
        }
    }

    public int ID8Total;

    public void CardID81()
    {
        if (MyMarker8.activeSelf == true)
        {
            TurnMamager.GetComponent<TurnController>().LimitEdit(3);
        }
        
    }

    int Effect1Point;
    int Effect2Point;

    public void CardID82()
    {
        CardID82OneEffect();
        CardID82TwoEffect();
        if (Effect1Point + Effect2Point != 0)
        {
            ID8Total = Effect1Point + Effect2Point;
            ID8Total = ID8Total * PlusMinus * Multiply;
            if (MyMarker8.activeSelf == true)
            {
                MyField8Point.text = ID8Total.ToString() + "P";
            }
            if (EnemyMarker8.activeSelf == true)
            {
                EnemyField8Point.text = ID8Total.ToString() + "P";
            }
        }
        if (Effect1Point + Effect2Point == 0)
        {
            MyField8Point.text = "";
            EnemyField8Point.text = "";
        }
    }

    public void CardID83()
    {
        if (EnemyMarker8.activeSelf == true)
        {
            TurnMamager.GetComponent<TurnController>().LimitEdit(1);
        }
    }

    public void CardID84()
    {
        ID8Total = 8 * Multiply * PlusMinus;
        if (MyMarker8.activeSelf == true)
        {
            MyField8Point.text = ID8Total.ToString() + "P";
        }
        if (EnemyMarker8.activeSelf == true)
        {
            EnemyField8Point.text = ID8Total.ToString() + "P";
            CardID84Effect();
        }
    }

    public void CardID82OneEffect()
    {
        int[] OneEffect = new int[3];
        OneEffect[0] = Priority3Field.GetComponent<Priority3Effect>().isMyCard;
        OneEffect[1] = Priority6Field.GetComponent<Priority6Effect>().isMyCard;
        OneEffect[2] = Priority7Field.GetComponent<Priority7Effect>().isMyCard;

        int OneEffectCount = 0;
        foreach (int Field in OneEffect)
        {
            if (Field == 1)
            {
                OneEffectCount++ ;
            }
        }
        if (OneEffectCount > 0)
        {
            Effect1Point = 15;
        }
        if (OneEffectCount == 0)
        {
            Effect1Point = 0;
        }
    }

    public void CardID82TwoEffect()
    {
        int Field1 = Priority1Field.GetComponent<Priority1Effect>().isMyCard;
        if (Field1 != 0)
        {
            Effect2Point = -5;
        }
        if (Field1 == 0)
        {
            Effect2Point = 0;
        }
    }

    int[] AllSearch = new int[11];

    public void CardID84Effect()
    {
        MyCardScan();
        AllSetIntercept(true);
    }

    public void MyCardScan()
    {
        AllSearch[0] = Priority0Field.GetComponent<Priority0Effect>().isMyCard;
        AllSearch[1] = Priority1Field.GetComponent<Priority1Effect>().isMyCard;
        AllSearch[2] = Priority2Field.GetComponent<Priority2Effect>().isMyCard;
        AllSearch[3] = Priority3Field.GetComponent<Priority3Effect>().isMyCard;
        AllSearch[4] = Priority4Field.GetComponent<Priority4Effect>().isMyCard;
        AllSearch[5] = Priority5Field.GetComponent<Priority5Effect>().isMyCard;
        AllSearch[6] = Priority6Field.GetComponent<Priority6Effect>().isMyCard;
        AllSearch[7] = Priority7Field.GetComponent<Priority7Effect>().isMyCard;
        AllSearch[8] = isMyCard;
        AllSearch[9] = Priority9Field.GetComponent<Priority9Effect>().isMyCard;
        AllSearch[10] = Priority10Field.GetComponent<Priority10Effect>().isMyCard;
    }

    public void AllSetIntercept(bool _Judge)
    {
        SetInterceptJudge(0, Priority0Field, _Judge);
        SetInterceptJudge(1, Priority1Field, _Judge);
        SetInterceptJudge(2, Priority2Field, _Judge);
        SetInterceptJudge(3, Priority3Field, _Judge);
        SetInterceptJudge(4, Priority4Field, _Judge);
        SetInterceptJudge(5, Priority5Field, _Judge);
        SetInterceptJudge(6, Priority6Field, _Judge);
        SetInterceptJudge(7, Priority7Field, _Judge);
        SetInterceptJudge(8, this.gameObject, _Judge);
        SetInterceptJudge(9, Priority9Field, _Judge);
        SetInterceptJudge(10, Priority10Field, _Judge);
    }

    public void SetInterceptJudge(int _Priority, GameObject _Field, bool _Judge)
    {
        if (AllSearch[_Priority] == -1)
        {
            foreach (Transform Card in _Field.transform)
            {
                Card.GetComponent<CardOverWriteEvent>().InterceptJudge = _Judge;
            }
        }
    }

    public void EffectClear()
    {
        TurnMamager.GetComponent<TurnController>().LimitEdit(2);
        MyCardScan();
        AllSetIntercept(false);
        MyField8Point.text = "";
        EnemyField8Point.text = "";
        ID8Total = 0;
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
        MyPointTextTemp = MyField8Point;
        EnemyPointTextTemp = EnemyField8Point;

        MyMarkerTemp = MyMarker8;
        EnemyMarkerTemp = EnemyMarker8;

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
        MyField8Point = MyPoint9.GetComponent<Text>();
        EnemyField8Point = EnemyPoint9.GetComponent<Text>();
        MyMarker8 = MyMarker9;
        EnemyMarker8 = EnemyMarker9;
        CardID = CopycardID;
    }

    public void PointAndMarkerTo9Clear()
    {
        MyField8Point = MyPointTextTemp;
        EnemyField8Point = EnemyPointTextTemp;
        MyMarker8 = MyMarkerTemp;
        EnemyMarker8 = EnemyMarkerTemp;
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
        if (isMyCard != 8 & CopycardID.Equals("") == false)
        {
            if (MyMarker8.activeSelf == true | EnemyMarker8.activeSelf == true)
            {
                To9SetToggle();
            }
        }
        if (isMyCard == 8 & CopycardID.Equals("") == false)
        {
            PointAndMarkerTo9Set();
            Priority8Boot();
            PointAndMarkerTo9Clear();
        }
    }
}

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

public class Priority7Effect : StrixBehaviour
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

    [SerializeField] GameObject Priority8Field;
    [SerializeField] GameObject Priority9Field;
    [SerializeField] GameObject Priority10Field;

    [SerializeField] Text MyField7Point;
    [SerializeField] Text EnemyField7Point;

    [SerializeField] GameObject MyMarker7;
    [SerializeField] GameObject EnemyMarker7;
    
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
            Priority7Boot();
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
        PointPositionReset();

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

    public void Priority7Boot()
    {
        
        switch (CardID)
        {
            case "7-1":
                CardID71();
                break;

            case "7-2":
                CardID72();
                break;

            case "7-3":
                CardID73();
                break;

            case "7-4":
                CardID74();
                break;

            default:
                break;
        }
    }

    public int ID7Total;

    int Card71Effect;

    public void CardID71()
    {
        CardID71Effect();
        ID7Total = Card71Effect * PlusMinus * Multiply;
        if (MyMarker7.activeSelf == true)
        {
            MyField7Point.text = ID7Total.ToString() + "P";
        }
        if (EnemyMarker7.activeSelf == true)
        {
            EnemyField7Point.text = ID7Total.ToString() + "P";
        }
    }

    int MyCard71Effect;
    int EnemyCard71Effect;

    public void CardID72()
    {
        CardID72Effect();
        if (MyCard71Effect == 0 & EnemyCard71Effect == 0)
        {
            PointPositionReset();
            MyField7Point.text = "";
            EnemyField7Point.text = "";
        }
        if (MyCard71Effect != 0 & EnemyCard71Effect == 0)
        {
            PointPositionReset();
            ID7Total = MyCard71Effect * PlusMinus * Multiply;
            MyField7Point.text = ID7Total.ToString() + "P";
            EnemyField7Point.text = "";
        }
        if (MyCard71Effect == 0 & EnemyCard71Effect != 0)
        {
            PointPositionReset();
            ID7Total = EnemyCard71Effect * PlusMinus * Multiply;
            MyField7Point.text = "";
            EnemyField7Point.text = ID7Total.ToString() + "P";
        }
        if (MyCard71Effect != 0 & EnemyCard71Effect != 0)
        {
            Vector3 My7PointPos = MyField7Point.gameObject.transform.position;
            My7PointPos.x = 42.60001f / 45.0f;
            MyField7Point.gameObject.transform.position = My7PointPos;
            int MyID7Total = MyCard71Effect * PlusMinus * Multiply;
            MyField7Point.text = MyID7Total.ToString() + "P";

            Vector3 Enemy7PointPos = EnemyField7Point.gameObject.transform.position;
            Enemy7PointPos.x = 68.60001f / 45.0f;
            EnemyField7Point.gameObject.transform.position = Enemy7PointPos;
            int EnemyID7Total = EnemyCard71Effect * PlusMinus * Multiply;
            EnemyField7Point.text = EnemyID7Total.ToString() + "P";
        }
    }

    int MyCard73Effect;
    int EnemyCard73Effect;

    public void CardID73()
    {
        CardID73Effect();

        Vector3 My7PointPos = MyField7Point.gameObject.transform.position;
        My7PointPos.x = 42.60001f / 45.0f;
        MyField7Point.gameObject.transform.position = My7PointPos;

        Vector3 Enemy7PointPos = EnemyField7Point.gameObject.transform.position;
        Enemy7PointPos.x = 68.60001f / 45.0f;
        EnemyField7Point.gameObject.transform.position = Enemy7PointPos;

        int MyID7Total = MyCard73Effect * PlusMinus * Multiply;
        int EnemyID7Total = EnemyCard73Effect * PlusMinus * Multiply;

        MyField7Point.text = MyID7Total.ToString() + "P";
        EnemyField7Point.text = EnemyID7Total.ToString() + "P";
    }

    int Card74Effect;

    public void CardID74()
    {
        CardID74Effect();
        ID7Total = Card74Effect * PlusMinus * Multiply;
        if (MyMarker7.activeSelf == true)
        {
            MyField7Point.text = ID7Total.ToString() + "P";
        }
        if (EnemyMarker7.activeSelf == true)
        {
            EnemyField7Point.text = ID7Total.ToString() + "P";
        }
    }

    public void CardID71Effect()
    {
        if (MyMarker7.activeSelf == true)
        {
            string MyHandCountString = MyHandCountText.text.ToString();
            int MyHandCountNumber = int.Parse(MyHandCountString);
            Card71Effect = -1 * MyHandCountNumber;
        }
        if (EnemyMarker7.activeSelf == true)
        {
            string EnemyHandCountString = EnemyHandCountText.text.ToString();
            int EnemyHandCountNumber = int.Parse(EnemyHandCountString);
            Card71Effect = -1 * EnemyHandCountNumber;
        }
    }

    public void CardID72Effect()
    {
        Priority8Field.GetComponent<Priority8Effect>().EffectActive = false;

        int[] Field8And9 = new int [2];
        Field8And9[0] = Priority8Field.GetComponent<Priority8Effect>().isMyCard;
        Field8And9[1] = Priority9Field.GetComponent<Priority9Effect>().isMyCard;

        int MyCount = 0;
        int EnemyCount = 0;
        foreach (int Field in Field8And9)
        {
            if (Field == 1)
            {
                MyCount++ ;
            }
            if (Field == -1)
            {
                EnemyCount++ ;
            }
        }
        MyCard71Effect = MyCount * 5;
        EnemyCard71Effect = EnemyCount * 5;
    }

    public void CardID73Effect()
    {
        string MyHandCountString = MyHandCountText.text.ToString();
        int MyHandCountNumber = int.Parse(MyHandCountString);

        string EnemyHandCountString = EnemyHandCountText.text.ToString();
        int EnemyHandCountNumber = int.Parse(EnemyHandCountString);

        if (MyHandCountNumber % 2 != 0)
        {
            MyCard73Effect = 3;
        }
        if (MyHandCountNumber % 2 == 0)
        {
            MyCard73Effect = 7;
        }

        if (EnemyHandCountNumber % 2 != 0)
        {
            EnemyCard73Effect = 3;
        }
        if (EnemyHandCountNumber % 2 == 0)
        {
            EnemyCard73Effect = 7;
        }
    }

    public void CardID74Effect()
    {
        int[] Field1To6Search = new int [6];
        Field1To6Search[0] = Priority1Field.GetComponent<Priority1Effect>().isMyCard;
        Field1To6Search[1] = Priority2Field.GetComponent<Priority2Effect>().isMyCard;
        Field1To6Search[2] = Priority3Field.GetComponent<Priority3Effect>().isMyCard;
        Field1To6Search[3] = Priority4Field.GetComponent<Priority4Effect>().isMyCard;
        Field1To6Search[4] = Priority5Field.GetComponent<Priority5Effect>().isMyCard;
        Field1To6Search[5] = Priority6Field.GetComponent<Priority6Effect>().isMyCard;

        int SearchCounter = 0;
        foreach (int Field in Field1To6Search)
        {
            if (Field == 1)
            {
                SearchCounter++ ;
            }
        }
        if (SearchCounter >= 3)
        {
            Card74Effect = 9;
        }
        if (SearchCounter < 3)
        {
            Card74Effect = 1;
        }
    }

    public void PointPositionReset()
    {
        Vector3 My7PointPos = MyField7Point.gameObject.transform.position;
        My7PointPos.x = 55.60001f / 45.0f;
        MyField7Point.gameObject.transform.position = My7PointPos;

        Vector3 Enemy7PointPos = EnemyField7Point.gameObject.transform.position;
        Enemy7PointPos.x = 55.60001f / 45.0f;
        EnemyField7Point.gameObject.transform.position = Enemy7PointPos;
    }

    public void EffectClear()
    {
        MyField7Point.text = "";
        EnemyField7Point.text = "";
        ID7Total = 0;
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
        MyPointTextTemp = MyField7Point;
        EnemyPointTextTemp = EnemyField7Point;

        MyMarkerTemp = MyMarker7;
        EnemyMarkerTemp = EnemyMarker7;

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
        MyField7Point = MyPoint9.GetComponent<Text>();
        EnemyField7Point = EnemyPoint9.GetComponent<Text>();
        MyMarker7 = MyMarker9;
        EnemyMarker7 = EnemyMarker9;
        CardID = CopycardID;
    }

    public void PointAndMarkerTo9Clear()
    {
        MyField7Point = MyPointTextTemp;
        EnemyField7Point = EnemyPointTextTemp;
        MyMarker7 = MyMarkerTemp;
        EnemyMarker7 = EnemyMarkerTemp;
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
        if (isMyCard != 7 & CopycardID.Equals("") == false)
        {
            if (MyMarker7.activeSelf == true | EnemyMarker7.activeSelf == true)
            {
                To9SetToggle();
            }
        }
        if (isMyCard == 7 & CopycardID.Equals("") == false)
        {
            PointAndMarkerTo9Set();
            Priority7Boot();
            PointAndMarkerTo9Clear();
        }
    }
}

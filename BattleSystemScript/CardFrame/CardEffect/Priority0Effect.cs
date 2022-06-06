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

public class Priority0Effect : StrixBehaviour
{
    public int PlusMinus;
    public int Multiply;
    public int EffectPoint;

    [SerializeField] GameObject Priority1Field;
    [SerializeField] GameObject Priority2Field;
    [SerializeField] GameObject Priority3Field;
    [SerializeField] GameObject Priority4Field;
    [SerializeField] GameObject Priority5Field;
    [SerializeField] GameObject Priority6Field;
    [SerializeField] GameObject Priority7Field;
    [SerializeField] GameObject Priority8Field;
    [SerializeField] GameObject Priority9Field;
    [SerializeField] GameObject Priority10Field;

    [SerializeField] Text MyField0Point;
    [SerializeField] Text EnemyField0Point;

    [SerializeField] GameObject MyMarker0;
    [SerializeField] GameObject EnemyMarker0;


    string CardID = "";
    public int isMyCard = 0; //0=中立、1=自分、-1=敵
    public bool EffectActive = true;
    bool DidClear;

    void Update()
    {
        CopyEffectUpdate();
        if (EffectActive == true)
        {
            Priority0Boot();
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
        CardIDTemp = _CardID;
        EffectClear();
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

    public void Priority0Boot()
    {
        switch (CardID)
        {
            /* case "0-0":
                CardID00();
                break; */
            case "0-1":
                CardID01();
                break;

            case "0-2":
                CardID02();
                break;

            case "0-3":
                CardID03();
                break;

            case "0-4":
                CardID04();
                break;

            default:
                break;
        }
    }

    public void CardID01()
    {
        ActiveSet159(false);
        MyField0Point.text = "";
        EnemyField0Point.text = "";
    }

    int Effect1Point;
    int Effect2Point;

    public int ID0Total;

    public void CardID02()
    {
        CardID02Efect1();
        CardID02Efect2();
        if (Effect1Point + Effect2Point != 0)
        {
            ID0Total = Effect1Point + Effect2Point;
            //Debug.Log("点数="+ID0Total+"符号="+PlusMinus+"乗算数値="+Multiply);
            ID0Total = ID0Total * PlusMinus * Multiply;
            if (MyMarker0.activeSelf == true)
            {
                MyField0Point.text = ID0Total.ToString() + "P";
            }
            if (EnemyMarker0.activeSelf == true)
            {
                EnemyField0Point.text = ID0Total.ToString() + "P";
            }
        }
        if (Effect1Point + Effect2Point == 0)
        {
            MyField0Point.text = "";
            EnemyField0Point.text = "";
        }

    }

    public void CardID03()
    {
        ActiveSet18(false);
        MultiplySet47(2);
        MyField0Point.text = "";
        EnemyField0Point.text = "";
    }

    public void CardID04()
    {
        PlusMinusSet(-1);
        MyField0Point.text = "";
        EnemyField0Point.text = "";
    }

    public void CardID02Efect1()
    {
        int[] OneEffect = new int[4];
        OneEffect[0] = Priority1Field.GetComponent<Priority1Effect>().isMyCard;
        OneEffect[1] = Priority2Field.GetComponent<Priority2Effect>().isMyCard;
        OneEffect[2] = Priority3Field.GetComponent<Priority3Effect>().isMyCard;
        OneEffect[3] = Priority4Field.GetComponent<Priority4Effect>().isMyCard;

        if (MyMarker0.activeSelf == true)
        {
            int OneEffectCount = 0;

            foreach (int n in OneEffect)
            {
                if (n == 1)
                {
                    OneEffectCount++ ;
                }
            }

            if (OneEffectCount >= 2)
            {
                Effect1Point = -15;
            }
            else
            {
                Effect1Point = 0;
            }
        }
        if (EnemyMarker0.activeSelf == true)
        {
            int OneEffectCount = 0;

            foreach (int n in OneEffect)
            {
                if (n == -1)
                {
                    OneEffectCount++ ;
                }
            }

            if (OneEffectCount >= 2)
            {
                Effect1Point = -15;
            }
            else
            {
                Effect1Point = 0;
            }
        }
    }
    
    public void CardID02Efect2()
    {
        int[] TwoEffect = new int[4];
        TwoEffect[0] = Priority6Field.GetComponent<Priority6Effect>().isMyCard;
        TwoEffect[1] = Priority7Field.GetComponent<Priority7Effect>().isMyCard;
        TwoEffect[2] = Priority8Field.GetComponent<Priority8Effect>().isMyCard;
        TwoEffect[3] = Priority9Field.GetComponent<Priority9Effect>().isMyCard;
        
        if (MyMarker0.activeSelf == true)
        {
            int TwoEffectCount = 0;

            foreach (int n in TwoEffect)
            {
                if (n == 1)
                {
                    TwoEffectCount++ ;
                }
            }

            if (TwoEffectCount < 2)
            {
                Effect2Point = -15;
            }
            else
            {
                Effect2Point = 0;
            }
        }
        if (EnemyMarker0.activeSelf == true)
        {
            int TwoEffectCount = 0;

            foreach (int n in TwoEffect)
            {
                if (n == -1)
                {
                    TwoEffectCount++ ;
                }
            }

            if (TwoEffectCount < 2)
            {
                Effect2Point = -15;
            }
            else
            {
                Effect2Point = 0;
            }
        }

        
    }

    public void ActiveSet159(bool _Active)
    {
        Priority1Field.GetComponent<Priority1Effect>().EffectActive = _Active;
        Priority5Field.GetComponent<Priority5Effect>().EffectActive = _Active;
        Priority9Field.GetComponent<Priority9Effect>().EffectActive = _Active;
    }

    public void ActiveSet18(bool _Active)
    {
        Priority1Field.GetComponent<Priority1Effect>().EffectActive = _Active;
        Priority8Field.GetComponent<Priority8Effect>().EffectActive = _Active;
    }

    public void MultiplySet47(int _Multiply)
    {
        Priority4Field.GetComponent<Priority4Effect>().Multiply = _Multiply;
        Priority7Field.GetComponent<Priority7Effect>().Multiply = _Multiply;
    }

    public void PlusMinusSet(int _PlusMinus)
    {
        Priority1Field.GetComponent<Priority1Effect>().PlusMinus = _PlusMinus;
        Priority2Field.GetComponent<Priority2Effect>().PlusMinus = _PlusMinus;
        Priority3Field.GetComponent<Priority3Effect>().PlusMinus = _PlusMinus;
        Priority4Field.GetComponent<Priority4Effect>().PlusMinus = _PlusMinus;
        Priority5Field.GetComponent<Priority5Effect>().PlusMinus = _PlusMinus;
        Priority6Field.GetComponent<Priority6Effect>().PlusMinus = _PlusMinus;
        Priority7Field.GetComponent<Priority7Effect>().PlusMinus = _PlusMinus;
        Priority8Field.GetComponent<Priority8Effect>().PlusMinus = _PlusMinus;
        Priority9Field.GetComponent<Priority9Effect>().PlusMinus = _PlusMinus;
        Priority10Field.GetComponent<Priority10Effect>().PlusMinus = _PlusMinus;
    }

    public void EffectClear()
    {
        ActiveSet159(true);
        ActiveSet18(true);
        MultiplySet47(1);
        PlusMinusSet(1);
        MyField0Point.text = "";
        EnemyField0Point.text = "";
        ID0Total = 0;
    }

    /* public void CardID00()
    {
        GameObject MyHandCountObject = GameObject.Find ("MyCount");
        Text MyHandCountText = MyHandCountObject.GetComponent<Text>();
        string MyHandCountString = MyHandCountText.text.ToString();
        int MyHandCountNumber = 0;
        int.TryParse(MyHandCountString, out MyHandCountNumber);

        Debug.Log("自分の手札"+MyHandCountNumber);

        GameObject EnemyHandCountObject = GameObject.Find ("EnemyCount");
        Text EnemyHandCountText = EnemyHandCountObject.GetComponent<Text>();
        string EnemyHandCountString = EnemyHandCountText.text.ToString();
        int EnemyHandCountNumber = 0;
        int.TryParse(EnemyHandCountString, out EnemyHandCountNumber);
        Debug.Log("相手の手札"+EnemyHandCountNumber);
    } */
    
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
        MyPointTextTemp = MyField0Point;
        EnemyPointTextTemp = EnemyField0Point;

        MyMarkerTemp = MyMarker0;
        EnemyMarkerTemp = EnemyMarker0;

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
        MyField0Point = MyPoint9.GetComponent<Text>();
        EnemyField0Point = EnemyPoint9.GetComponent<Text>();
        MyMarker0 = MyMarker9;
        EnemyMarker0 = EnemyMarker9;
        CardID = CopycardID;
    }

    public void PointAndMarkerTo9Clear()
    {
        MyField0Point = MyPointTextTemp;
        EnemyField0Point = EnemyPointTextTemp;
        MyMarker0 = MyMarkerTemp;
        EnemyMarker0 = EnemyMarkerTemp;
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
        if (isMyCard != 0 & CopycardID.Equals("") == false)
        {
            if (MyMarker0.activeSelf == true | EnemyMarker0.activeSelf == true)
            {
                To9SetToggle();
            }
        }
        if (isMyCard == 0 & CopycardID.Equals("") == false)
        {
            PointAndMarkerTo9Set();
            Priority0Boot();
            PointAndMarkerTo9Clear();
        }
    }
    
}

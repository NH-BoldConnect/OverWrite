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

public class Priority4Effect : StrixBehaviour
{
    public int PlusMinus;
    public int Multiply;
    public int EffectPoint;

    [SerializeField] GameObject Priority0Field;
    [SerializeField] GameObject Priority1Field;
    [SerializeField] GameObject Priority2Field;
    [SerializeField] GameObject Priority3Field;

    [SerializeField] GameObject Priority5Field;
    [SerializeField] GameObject Priority6Field;
    [SerializeField] GameObject Priority7Field;
    [SerializeField] GameObject Priority8Field;
    [SerializeField] GameObject Priority9Field;
    [SerializeField] GameObject Priority10Field;

    [SerializeField] Text MyField4Point;
    [SerializeField] Text EnemyField4Point;

    [SerializeField] GameObject MyMarker4;
    [SerializeField] GameObject EnemyMarker4;
    
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
            Priority4Boot();
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

    public void Priority4Boot()
    {
        
        switch (CardID)
        {
            case "4-1":
                CardID41();
                break;

            case "4-2":
                CardID42();
                break;

            case "4-3":
                CardID43();
                break;

            case "4-4":
                CardID44();
                break;

            default:
                break;
        }
    }

    public int ID4Total;

    int Effect41;

    public void CardID41()
    {
        CardID41Effect();
        ID4Total = Effect41 * PlusMinus * Multiply;
        if (MyMarker4.activeSelf == true)
        {
            MyField4Point.text = ID4Total.ToString() + "P";
        }
        if (EnemyMarker4.activeSelf == true)
        {
            EnemyField4Point.text = ID4Total.ToString() + "P";
        }
    }

    int MyCardCount;
    int EnemyCardCount;

    public void CardID42()
    {
        CardID42Effect();
        ID4Total = 7 * PlusMinus * Multiply;
        if (MyCardCount > EnemyCardCount)
        {
            MyField4Point.text = ID4Total.ToString() + "P";
        }
        if (EnemyCardCount > MyCardCount)
        {
            EnemyField4Point.text = ID4Total.ToString() + "P";
        }
        if (EnemyCardCount == MyCardCount)
        {
            MyField4Point.text = "";
            EnemyField4Point.text = "";
        }
    }

    int Effect43One;
    int Effect43Two;

    public void CardID43()
    {
        CardID43Effect();
        Effect43One = Effect43One * PlusMinus * Multiply;
        Effect43Two = Effect43Two * PlusMinus * Multiply;
        if (MyMarker4.activeSelf == true)
        {
            if (Effect43One != 0 && Effect43Two == 0)
            {
                PointPositionReset();
                MyField4Point.text = Effect43One.ToString() + "P";
                EnemyField4Point.text = "";
            }
            if (Effect43One == 0 && Effect43Two != 0)
            {
                PointPositionReset();
                EnemyField4Point.text = Effect43Two.ToString() + "P";
                MyField4Point.text = "";
            }
            if (Effect43One != 0 && Effect43Two != 0)
            {
                Vector3 My4PointPos = MyField4Point.gameObject.transform.position;
                My4PointPos.x = 0.0f;
                My4PointPos.x -= 14.2f / 45.0f;
                My4PointPos.x += 215.55f / 45.0f;
                MyField4Point.gameObject.transform.position = My4PointPos;
                MyField4Point.text = Effect43One.ToString() + "P";
                
                Vector3 Enemy4PointPos = EnemyField4Point.gameObject.transform.position;
                Enemy4PointPos.x = 0.0f;
                Enemy4PointPos.x += 14.25f / 45.0f;
                Enemy4PointPos.x += 215.6f / 45.0f;
                EnemyField4Point.gameObject.transform.position = Enemy4PointPos;
                EnemyField4Point.text = Effect43Two.ToString() + "P";
            }
            if (Effect43One == 0 && Effect43Two == 0)
            {
                PointPositionReset();
                MyField4Point.text = "";
                EnemyField4Point.text = "";
            }
        }
        if (EnemyMarker4.activeSelf == true)
        {
            if (Effect43One != 0 && Effect43Two == 0)
            {
                PointPositionReset();
                EnemyField4Point.text = Effect43One.ToString() + "P";
                MyField4Point.text = "";
            }
            if (Effect43One == 0 && Effect43Two != 0)
            {
                PointPositionReset();
                MyField4Point.text = Effect43Two.ToString() + "P";
                EnemyField4Point.text = "";
            }
            if (Effect43One != 0 && Effect43Two != 0)
            {
                Vector3 Enemy4PointPos = EnemyField4Point.gameObject.transform.position;
                Enemy4PointPos.x = 0.0f;
                Enemy4PointPos.x -= 14.2f / 45.0f;
                Enemy4PointPos.x += 215.6f / 45.0f;
                EnemyField4Point.gameObject.transform.position = Enemy4PointPos;
                EnemyField4Point.text = Effect43One.ToString() + "P";

                Vector3 My4PointPos = MyField4Point.gameObject.transform.position;
                My4PointPos.x = 0.0f;
                My4PointPos.x += 14.25f / 45.0f;
                My4PointPos.x += 215.55f / 45.0f;
                MyField4Point.gameObject.transform.position = My4PointPos;
                MyField4Point.text = Effect43Two.ToString() + "P";
            }
            if (Effect43One == 0 && Effect43Two == 0)
            {
                PointPositionReset();
                MyField4Point.text = "";
                EnemyField4Point.text = "";
            }
        }
    }

    int Effect44One;
    int Effect44Two;

    public void CardID44()
    {
        CardID44EffectOne();
        CardID44EffectTwo();
        ID4Total = Effect44One + Effect44Two;
        ID4Total = ID4Total * PlusMinus * Multiply;
        if (MyMarker4.activeSelf == true)
        {
            if (ID4Total != 0)
            {
                MyField4Point.text = ID4Total.ToString() + "P";
            }
            if (ID4Total == 0)
            {
                MyField4Point.text = "";
            }
        }
        if (EnemyMarker4.activeSelf == true)
        {
            if (ID4Total != 0)
            {
                EnemyField4Point.text = ID4Total.ToString() + "P";
            }
            if (ID4Total == 0)
            {
                EnemyField4Point.text = "";
            }
        }
    }

    public void CardID41Effect()
    {
        int[] AllSearch = new int[11];
        AllSearch[0] = Priority0Field.GetComponent<Priority0Effect>().isMyCard;
        AllSearch[1] = Priority1Field.GetComponent<Priority1Effect>().isMyCard;
        AllSearch[2] = Priority2Field.GetComponent<Priority2Effect>().isMyCard;
        AllSearch[3] = Priority3Field.GetComponent<Priority3Effect>().isMyCard;
        AllSearch[4] = isMyCard;
        AllSearch[5] = Priority5Field.GetComponent<Priority5Effect>().isMyCard;
        AllSearch[6] = Priority6Field.GetComponent<Priority6Effect>().isMyCard;
        AllSearch[7] = Priority7Field.GetComponent<Priority7Effect>().isMyCard;
        AllSearch[8] = Priority8Field.GetComponent<Priority8Effect>().isMyCard;
        AllSearch[9] = Priority9Field.GetComponent<Priority9Effect>().isMyCard;
        AllSearch[10] = Priority10Field.GetComponent<Priority10Effect>().isMyCard;

        int MyCardCount = 0;

        if (MyMarker4.activeSelf == true)
        {
            foreach (int n in AllSearch)
            {
                if (n == 1)
                {
                    MyCardCount++ ;
                }
            }
            

        }
        if (EnemyMarker4.activeSelf == true)
        {
            foreach (int n in AllSearch)
            {
                if (n == -1)
                {
                    MyCardCount++ ;
                }
            }
        }
        if (MyCardCount == 5)
        {
            Effect41 = 3;
        }
        if (MyCardCount != 5)
        {
            Effect41 = -7;
        }

    }

    public void CardID42Effect()
    {
        int[] AllSearch = new int[11];
        AllSearch[0] = Priority0Field.GetComponent<Priority0Effect>().isMyCard;
        AllSearch[1] = Priority1Field.GetComponent<Priority1Effect>().isMyCard;
        AllSearch[2] = Priority2Field.GetComponent<Priority2Effect>().isMyCard;
        AllSearch[3] = Priority3Field.GetComponent<Priority3Effect>().isMyCard;
        AllSearch[4] = isMyCard;
        AllSearch[5] = Priority5Field.GetComponent<Priority5Effect>().isMyCard;
        AllSearch[6] = Priority6Field.GetComponent<Priority6Effect>().isMyCard;
        AllSearch[7] = Priority7Field.GetComponent<Priority7Effect>().isMyCard;
        AllSearch[8] = Priority8Field.GetComponent<Priority8Effect>().isMyCard;
        AllSearch[9] = Priority9Field.GetComponent<Priority9Effect>().isMyCard;
        AllSearch[10] = Priority10Field.GetComponent<Priority10Effect>().isMyCard;

        MyCardCount = 0;
        EnemyCardCount = 0;
        foreach (int n in AllSearch)
        {
            if (n == 1)
            {
                MyCardCount++ ;
            }
            if (n == -1)
            {
                EnemyCardCount++ ;
            }
        }
    }

    public void CardID43Effect()
    {
        int Priority49Count = 0;
        int Priority6Count = 0;
        if (GraveContent.childCount != 0)
        {
           foreach (Transform Card in GraveContent)
            {
                int Priority = Card.gameObject.GetComponent<CardView>()._Priority;
                if (Priority == 4 | Priority == 9)
                {
                    Priority49Count++ ;
                }
                if (Priority == 6)
                {
                    Priority6Count++ ;
                }
            }
        }
        Effect43One = Priority49Count * 2;
        Effect43Two = Priority6Count;
    }

    public void CardID44EffectOne()
    {
        int[] Search0to3 = new int[4];
        Search0to3[0] = Priority0Field.GetComponent<Priority0Effect>().isMyCard;
        Search0to3[1] = Priority1Field.GetComponent<Priority1Effect>().isMyCard;
        Search0to3[2] = Priority2Field.GetComponent<Priority2Effect>().isMyCard;
        Search0to3[3] = Priority3Field.GetComponent<Priority3Effect>().isMyCard;
        int My0to3Count = 0;
        if (MyMarker4.activeSelf == true)
        {
            foreach (int n in Search0to3)
            {
                if (n == 1)
                {
                    My0to3Count++ ;
                }
            }
        }
        if (EnemyMarker4.activeSelf == true)
        {
            foreach (int n in Search0to3)
            {
                if (n == -1)
                {
                    My0to3Count++ ;
                }
            }
        }
        if (My0to3Count >= 2)
        {
            Effect44One = 3;
        }
        if (My0to3Count < 2)
        {
            Effect44One = 0;
        }
    }

    public void CardID44EffectTwo()
    {
        int[] Search5to9 = new int[5];
        Search5to9[0] = Priority5Field.GetComponent<Priority5Effect>().isMyCard;
        Search5to9[1] = Priority6Field.GetComponent<Priority6Effect>().isMyCard;
        Search5to9[2] = Priority7Field.GetComponent<Priority7Effect>().isMyCard;
        Search5to9[3] = Priority8Field.GetComponent<Priority8Effect>().isMyCard;
        Search5to9[4] = Priority9Field.GetComponent<Priority9Effect>().isMyCard;
        int My5to9Count = 0;
        if (MyMarker4.activeSelf == true)
        {
            foreach (int n in Search5to9)
            {
                if (n == 1)
                {
                    My5to9Count++ ;
                }
            }
        }
        if (EnemyMarker4.activeSelf == true)
        {
            foreach (int n in Search5to9)
            {
                if (n == -1)
                {
                    My5to9Count++ ;
                }
            }
        }
        if (My5to9Count >= 3)
        {
            Effect44Two = 4;
        }
        if (My5to9Count < 3)
        {
            Effect44Two = 0;
        }
    }

    public void PointPositionReset()
    {
        Vector3 My4PointPos = MyField4Point.gameObject.transform.position;
        My4PointPos.x = 0.0f;
        My4PointPos.x += 215.6f / 45.0f;
        MyField4Point.gameObject.transform.position = My4PointPos;

        Vector3 Enemy4PointPos = EnemyField4Point.gameObject.transform.position;
        Enemy4PointPos.x = 0.0f;
        Enemy4PointPos.x += 215.6f / 45.0f;
        EnemyField4Point.gameObject.transform.position = Enemy4PointPos;
    }

    public void EffectClear()
    {

        MyField4Point.text = "";
        EnemyField4Point.text = "";
        ID4Total = 0;
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
        MyPointTextTemp = MyField4Point;
        EnemyPointTextTemp = EnemyField4Point;

        MyMarkerTemp = MyMarker4;
        EnemyMarkerTemp = EnemyMarker4;

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
        MyField4Point = MyPoint9.GetComponent<Text>();
        EnemyField4Point = EnemyPoint9.GetComponent<Text>();
        MyMarker4 = MyMarker9;
        EnemyMarker4 = EnemyMarker9;
        CardID = CopycardID;
    }

    public void PointAndMarkerTo9Clear()
    {
        MyField4Point = MyPointTextTemp;
        EnemyField4Point = EnemyPointTextTemp;
        MyMarker4 = MyMarkerTemp;
        EnemyMarker4 = EnemyMarkerTemp;
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
        if (isMyCard != 4 & CopycardID.Equals("") == false)
        {
            if (MyMarker4.activeSelf == true | EnemyMarker4.activeSelf == true)
            {
                To9SetToggle();
            }
        }
        if (isMyCard == 4 & CopycardID.Equals("") == false)
        {
            PointAndMarkerTo9Set();
            Priority4Boot();
            PointAndMarkerTo9Clear();
        }
    }
}

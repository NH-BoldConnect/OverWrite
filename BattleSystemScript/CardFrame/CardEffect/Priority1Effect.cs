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

public class Priority1Effect : StrixBehaviour
{
    public int PlusMinus;
    public int Multiply;
    public int EffectPoint;

    [SerializeField] GameObject Priority0Field;

    [SerializeField] GameObject Priority2Field;
    [SerializeField] GameObject Priority3Field;
    [SerializeField] GameObject Priority4Field;
    [SerializeField] GameObject Priority5Field;
    [SerializeField] GameObject Priority6Field;
    [SerializeField] GameObject Priority7Field;
    [SerializeField] GameObject Priority8Field;
    [SerializeField] GameObject Priority9Field;
    [SerializeField] GameObject Priority10Field;

    [SerializeField] Text MyField1Point;
    [SerializeField] Text EnemyField1Point;

    [SerializeField] GameObject MyMarker1;
    [SerializeField] GameObject EnemyMarker1;

    GameObject SystemManager;
    GameObject TurnManager;

    string CardID = "";
    public int isMyCard = 0; //0=中立、1=自分、-1=敵
    public bool EffectActive = true;
    bool DidClear;

    void Update()
    {
        CopyEffectUpdate();
        if (EffectActive == true)
        {
            Priority1Boot();
            DidClear = false;
        }
        if (EffectActive == false & DidClear == false)
        {
            EffectClear();
            CardID14DidCheck = true;
            DidClear = true;
        }

        OverWriteAllow();
    }

    public void SetCardData(string _CardID, int _isMyCard)
    {
        CardID = _CardID;
        isMyCard = _isMyCard;
        EffectClear();
        CardID14DidCheck = false;
        CardIDTemp = _CardID;
    }

    void Start()
    {
        SystemManager = GameObject.Find("SystemManager");
        TurnManager = GameObject.Find("TurnMamager");
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

    public void Priority1Boot()
    {
        
        switch (CardID)
        {
            case "1-1":
                CardID11();
                break;

            case "1-2":
                CardID12();
                break;

            case "1-3":
                CardID13();
                break;

            case "1-4":
                CardID14();
                break;

            default:
                break;
        }
    }

    int Effect11point;
    public int Total11Point;

    public void CardID11()
    {
        CardID11Effect();
        if (Effect11point != 0)
        {
            Total11Point = Effect11point * PlusMinus * Multiply;
            if (MyMarker1.activeSelf == true)
            {
                MyField1Point.text = Total11Point.ToString() + "P";
            }
            if (EnemyMarker1.activeSelf == true)
            {
                EnemyField1Point.text = Total11Point.ToString() + "P";
            }
        }
        if (Effect11point == 0)
        {
            MyField1Point.text = "";
            EnemyField1Point.text = "";
        }
    }

    int Effect12point;
    public int ID1Total;

    public void CardID12()
    {
        CardID12Effect();
        if (Effect12point != 0)
        {
            ID1Total = Effect12point * PlusMinus * Multiply;
            if (MyMarker1.activeSelf == true)
            {
                MyField1Point.text = ID1Total.ToString() + "P";
            }
            if (EnemyMarker1.activeSelf == true)
            {
                EnemyField1Point.text = ID1Total.ToString() + "P";
            }
        }
        if (Effect12point == 0)
        {
            MyField1Point.text = "";
            EnemyField1Point.text = "";
        }
    }

    public void CardID13()
    {
        if (EnemyMarker1.activeSelf == true)
        {
            Priority1to9BanSet(true);
        }
    }

    bool CardID14DidCheck = false;

    public void CardID14()
    {
        if (MyMarker1.activeSelf == true)
        {
            TurnManager.GetComponent<TurnController>().EndPhaseEffect2 = true;
            bool EndPhaseAlert2 = TurnManager.GetComponent<TurnController>().EndPhaseAlert2;
            if (CardID14DidCheck == false & EndPhaseAlert2 == true)
            {
                SystemManager.GetComponent<EraserAndDelete>().EraserBoot(1);
                CardID14DidCheck = true;
            }
        }
    }

    public void CardID11Effect()
    {
        int[] AllSearch = new int[11];
        AllSearch[0] = Priority0Field.GetComponent<Priority0Effect>().isMyCard;
        AllSearch[1] = isMyCard;
        AllSearch[2] = Priority2Field.GetComponent<Priority2Effect>().isMyCard;
        AllSearch[3] = Priority3Field.GetComponent<Priority3Effect>().isMyCard;
        AllSearch[4] = Priority4Field.GetComponent<Priority4Effect>().isMyCard;
        AllSearch[5] = Priority5Field.GetComponent<Priority5Effect>().isMyCard;
        AllSearch[6] = Priority6Field.GetComponent<Priority6Effect>().isMyCard;
        AllSearch[7] = Priority7Field.GetComponent<Priority7Effect>().isMyCard;
        AllSearch[8] = Priority8Field.GetComponent<Priority8Effect>().isMyCard;
        AllSearch[9] = Priority9Field.GetComponent<Priority9Effect>().isMyCard;
        AllSearch[10] = Priority10Field.GetComponent<Priority10Effect>().isMyCard;

        if (MyMarker1.activeSelf == true)
        {
            int AllSearchCount = 0;
            foreach (int n in AllSearch)
            {
                if (n == 1)
                {
                    AllSearchCount++ ;
                }
            }
            Effect11point = AllSearchCount * 2;
        }
        if (EnemyMarker1.activeSelf == true)
        {
            int AllSearchCount = 0;
            foreach (int n in AllSearch)
            {
                if (n == -1)
                {
                    AllSearchCount++ ;
                }
            }
            Effect11point = AllSearchCount * 2;
        }

    }

    [SerializeField] Transform HandField;

    public void  CardID12Effect()
    {
        int Priority3Card = Priority3Field.GetComponent<Priority3Effect>().isMyCard;
        if (MyMarker1.activeSelf == true)
        {
            int Priority3HandCount = 0;
            int Priority3FieldCount = 0;
            foreach (Transform n in HandField)
            {
                int Priority = n.gameObject.GetComponent<CardView>()._Priority;
                if (Priority == 3)
                {
                    Priority3HandCount++ ;
                }
            }
            RpcToOtherMembers("Priority3HandSync", Priority3HandCount);
            if (Priority3Card == 1)
            {
                Priority3FieldCount = 1;
            }
            Effect12point = (Priority3HandCount + Priority3FieldCount) * 4;
        }
        if (EnemyMarker1.activeSelf == true)
        {
            string Enemy3CardCountString = Effect12Memo.text.ToString();
            int Enemy3CardCountNumber = int.Parse(Enemy3CardCountString);
            Debug.Log("実行数"+Enemy3CardCountNumber);
            int Priority3FieldCount = 0;
            if (Priority3Card == -1)
            {
                Priority3FieldCount = 1;
            }
            Effect12point = (Enemy3CardCountNumber + Priority3FieldCount) * 4;
        }
    }

    [SerializeField] Text Effect12Memo;

    [StrixRpc]
    public void Priority3HandSync(int _Priority3Count)
    {
        Effect12Memo.text = _Priority3Count.ToString();
    }

    public void Priority1to9BanSet(bool _Ban)
    {
        this.gameObject.GetComponent<Priority1Effect>().OverWriteBan = _Ban;
        Priority2Field.GetComponent<Priority2Effect>().OverWriteBan = _Ban;
        Priority3Field.GetComponent<Priority3Effect>().OverWriteBan = _Ban;
        Priority4Field.GetComponent<Priority4Effect>().OverWriteBan = _Ban;
        Priority5Field.GetComponent<Priority5Effect>().OverWriteBan = _Ban;
        Priority6Field.GetComponent<Priority6Effect>().OverWriteBan = _Ban;
        Priority7Field.GetComponent<Priority7Effect>().OverWriteBan = _Ban;
        Priority8Field.GetComponent<Priority8Effect>().OverWriteBan = _Ban;
        Priority9Field.GetComponent<Priority9Effect>().OverWriteBan = _Ban;
    }

    public void EffectClear()
    {
        Priority1to9BanSet(false);
        MyField1Point.text = "";
        EnemyField1Point.text = "";
        Total11Point = 0;
        ID1Total = 0;
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
        MyPointTextTemp = MyField1Point;
        EnemyPointTextTemp = EnemyField1Point;

        MyMarkerTemp = MyMarker1;
        EnemyMarkerTemp = EnemyMarker1;

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
        MyField1Point = MyPoint9.GetComponent<Text>();
        EnemyField1Point = EnemyPoint9.GetComponent<Text>();
        MyMarker1 = MyMarker9;
        EnemyMarker1 = EnemyMarker9;
        CardID = CopycardID;
    }

    public void PointAndMarkerTo9Clear()
    {
        MyField1Point = MyPointTextTemp;
        EnemyField1Point = EnemyPointTextTemp;
        MyMarker1 = MyMarkerTemp;
        EnemyMarker1 = EnemyMarkerTemp;
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
        if (isMyCard != 1 & CopycardID.Equals("") == false)
        {
            if (MyMarker1.activeSelf == true | EnemyMarker1.activeSelf == true)
            {
                To9SetToggle();
            }
        }
        if (isMyCard == 1 & CopycardID.Equals("") == false)
        {
            PointAndMarkerTo9Set();
            Priority1Boot();
            PointAndMarkerTo9Clear();
        }
    }
}

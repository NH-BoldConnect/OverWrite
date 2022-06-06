using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Net.Logging;
using SoftGear.Strix.Unity.Runtime.Event;

public class TurnController : StrixBehaviour
{
    [SerializeField] GameObject MyTurnEndButton;
    [SerializeField] GameObject EnemyTurnPanel;
    //[SerializeField] GameObject TurnCountDown;
    [SerializeField] Text Counter;
    [SerializeField] Text Limit;

    [SerializeField] Transform Field0;
    [SerializeField] Transform Field1;
    [SerializeField] Transform Field2;
    [SerializeField] Transform Field3;
    [SerializeField] Transform Field4;
    [SerializeField] Transform Field5;
    [SerializeField] Transform Field6;
    [SerializeField] Transform Field7;
    [SerializeField] Transform Field8;
    [SerializeField] Transform Field9;
    [SerializeField] Transform Field10;
    [SerializeField] Transform HandField;

    [SerializeField] Text DeckCount;

    Transform[] FieldArray = new Transform[11];

    int OverWriteCounter = 0;
    int OverWriteLimit = 2;
    bool OverWriteLimited;

    GameObject SystemManager;
    GameObject TurnMamager;

    bool EndPhaseCountStart;
    int EndPhaseCounter;

    public bool EndPhaseEffect;
    public bool EndPhaseAlert;

    public bool EndPhaseEffect2;
    public bool EndPhaseAlert2;

    public int FirstJudgeCounter = 0;

    bool EndSystemDid;

    public void OWLimitJudge()
    {
        OverWriteLimited = true;
        if (OverWriteCounter >= OverWriteLimit) //召喚権が無い
        {
            foreach (Transform Field in FieldArray)
            {
                Field.GetComponent<DropPlace>().OnDropActive = false;
                foreach (Transform Card in Field)
                {
                    Card.GetComponent<CardOverWriteEvent>().CardOverWriteActive = false;
                }
            }
        }
        if (OverWriteCounter < OverWriteLimit & MyTurnEndButton.activeSelf)
        {
            foreach (Transform Field in FieldArray)
            {
                Field.GetComponent<DropPlace>().OnDropActive = true;
                foreach (Transform Card in Field)
                {
                    Card.GetComponent<CardOverWriteEvent>().CardOverWriteActive = true;
                }
            }
        }
        if (EnemyTurnPanel.activeSelf)
        {
            foreach (Transform HandCard in HandField)
            {
                HandCard.GetComponent<CardMovement>().enabled = false;
            }
            foreach (Transform Field in FieldArray)
            {
                Field.GetComponent<DropPlace>().OnDropActive = false;
                foreach (Transform Card in Field)
                {
                    Card.GetComponent<CardOverWriteEvent>().CardOverWriteActive = false;
                }
            }
        }
    }

    void Awake()
    {
        FieldArray[0] = Field0;
        FieldArray[1] = Field1;
        FieldArray[2] = Field2;
        FieldArray[3] = Field3;
        FieldArray[4] = Field4;
        FieldArray[5] = Field5;
        FieldArray[6] = Field6;
        FieldArray[7] = Field7;
        FieldArray[8] = Field8;
        FieldArray[9] = Field9;
        FieldArray[10] = Field10;
        Counter.text = OverWriteCounter.ToString();
        Limit.text = OverWriteLimit.ToString();
        TurnMamager = GameObject.Find("TurnMamager");
        SystemManager = GameObject.Find("SystemManager");
    }

    void Update()
    {
        DeckCountZeroObserve();
        OWLimitJudge();
    }

    public void CounterAdd()
    {
        OverWriteCounter++ ;
        Counter.text = OverWriteCounter.ToString();
    }

    public void LimitEdit(int _Limit)
    {
        OverWriteLimit = _Limit;
        Limit.text = OverWriteLimit.ToString();
    }

    [StrixRpc]
    public void OnClick_TurnEndButton()
    {
        TrunEndButton();
        if (FirstJudgeCounter == 0)
        {
            RpcToOtherMembers("FirstCardAdd");
        }
    }

    public void TrunEndButton()
    {
        OverWriteLimited = false;
        OverWriteCounter = 0;
        Counter.text = OverWriteCounter.ToString();
        MyTurnEnd();
        RpcToOtherMembers("RemoteTurnStart");
        if (EndPhaseCountStart == true)
        {
            EndPhaseCounter++ ;
        }
    }

    [StrixRpc]
    public void RemoteTurnStart()
    {
        MyTurnStart();
    }

    [StrixRpc]
    public void MyTurnStart() //自分のターンが開始、相手のターンが終了
    {
        MyTurnEndButton.SetActive(true);
        EnemyTurnPanel.SetActive(false);
        if (FirstJudgeCounter > 0)
        {
            SystemManager.GetComponent<BattleSystem>().ClickAddCard();
        }
        foreach (Transform HandCard in HandField)
        {
            HandCard.GetComponent<CardMovement>().enabled = true;
        }
        if (OverWriteLimited == false)
        {
           foreach (Transform Field in FieldArray)
            {
                Field.GetComponent<DropPlace>().OnDropActive = true;
                foreach (Transform Card in Field)
                {
                    Card.GetComponent<CardOverWriteEvent>().CardOverWriteActive = true;
                }
            } 
        }
        FirstJudgeCounter++ ;
        RpcToOtherMembers("FirstJudgeCounterAdd");
    }

    [StrixRpc]
    public void MyTurnEnd() //相手のターンが開始、自分のターンが終了
    {
        MyTurnEndButton.SetActive(false);
        EnemyTurnPanel.SetActive(true);
        foreach (Transform HandCard in HandField)
        {
            HandCard.GetComponent<CardMovement>().enabled = false;
        }
        foreach (Transform Field in FieldArray)
        {
            Field.GetComponent<DropPlace>().OnDropActive = false;
            foreach (Transform Card in Field)
            {
                Card.GetComponent<CardOverWriteEvent>().CardOverWriteActive = false;
            }
        }
    }

    public void FirstAttackerjudge()
    {
        EndSystemDid = false;
        EndPhaseCounter = 0;
        EndPhaseCountStart = false;
        int RandInt = Random.Range(0, 2);
        if (RandInt == 0)
        {
            MyTurnStart();
            RpcToOtherMembers("MyTurnEnd");
        }
        else if (RandInt == 1)
        {
            TrunEndButton();
        }
    }

    public void DeckCountZeroObserve()
    {
        string DeckCountStr = DeckCount.text.ToString();
        int DeckCountInt = int.Parse(DeckCountStr);
        if (DeckCountInt == 0)
        {
            EndPhaseCountStart = true;
            EndPanelSwitch();
        }
    }
    public void EndPanelSwitch()
    {
        if (EndPhaseCounter == 2)
        {
            EndPhaseAlert = true;
            if (EndPhaseEffect == false & EndSystemDid == false)
            {
                EndPhaseAlert2 = true;
                if (EndPhaseEffect2 == false & EndSystemDid == false)
                {
                    this.gameObject.GetComponent<TotalPointManager>().EndSystemBoot();
                    EndSystemDid = true;
                }
                
            }
        }
    }

    [StrixRpc]
    public void FirstJudgeCounterAdd()
    {
        FirstJudgeCounter++ ;
    }

    [StrixRpc]
    public void FirstCardAdd()
    {
        SystemManager.GetComponent<BattleSystem>().ClickAddCard();
    }
}

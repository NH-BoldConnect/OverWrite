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
using System.Linq;

public class BattleSystem : StrixBehaviour
{

    public static string[] P2Deck = new string[40];
    public static string[] P1Deck = new string[P2Deck.Length];
    public Text MynameTag;
    public Text EnemynameTag;
    private string MyName;
    public Text MyCardCount;
    public Text EnemyCardCount;
    public GameObject CardHandField;
    private int PlayerNumberJudge;
    private long primaryKey;
    public int DrowCount;
    private bool StartCheck;
    public GameObject Waitpanel;
    public Text PassWatch;
    private string PasswordCont;
    private int TotalCardCount;
    public GameObject StartWaitWindow;
    public Text StartCountDown;
    public Text TestText;
    public Text DeckCount;
    private bool CountCheck;
    public GameObject EnemyRPCWaitpanel;
    private int CardCount;
    private bool AlreadyP1;
    GameObject TurnMamager;

    void Awake()
    {
        P2Deck = new string[40];
        string[] P2DeckTemp = new string[40] {"0-1","0-2","0-3","0-4","1-1","1-2","1-3","1-4",
           "2-1","2-2","2-3","2-4","3-1","3-2","3-3","3-4",
           "4-1","4-2","4-3","4-4","5-1","5-2","5-3","5-4",
           "6-1","6-2","6-3","6-4","7-1","7-2","7-3","7-4",
           "8-1","8-2","8-3","8-4","9-1","9-2","9-3","9-4"};
        Array.Copy(P2DeckTemp, P2Deck, P2DeckTemp.Length);
        primaryKey = StrixNetwork.instance.selfRoomMember.GetPrimaryKey();
        PassWatch.text = PlayerPrefs.GetString("Password");
        Waitpanel.SetActive(true);
        TurnMamager = GameObject.Find("TurnMamager");
    }

    void Start()
    {
        MyName = PlayerPrefs.GetString("MyName");
        MynameTag.text = MyName;
        StartCheck = true;
        CountCheck = false;
        AlreadyP1 = false;
        if (StrixNetwork.instance.room.GetMemberCount() == 2)
        {
            Shuffle();
        }
        DeckCount.text = "40";
    }

    void Update()
    {
        if (StrixNetwork.instance.room.GetMemberCount() == 2 && StartCheck == true)
        {
            RpcToOtherMembers("NameTagSet", MyName);
            RpcToOtherMembers("RootJudge", primaryKey);
            Waitpanel.SetActive(false);
            StartCoroutine("CountDown");
            StartCheck = false;
            CountCheck = true;
        }
        if (CountCheck == true)
        {
            if (PlayerNumberJudge == 1)
            {
                SetRoomKey1();
                int DeckInt = P1Deck.Length;
                DeckCount.text = DeckInt.ToString();
                EnemyRPCWaitpanel.SetActive(false);
                if (DeckInt == 0)
                {
                    RpcToOtherMembers("P2DeckToZero");
                }
            }
            if (PlayerNumberJudge == 2)
            {
                int DeckInt = P2Deck.Length;
                DeckCount.text = DeckInt.ToString();
                if (DeckInt == 0)
                {
                    RpcToOtherMembers("P1DeckToZero");
                }
            }
            if (AlreadyP1 == true)
            {
                EnemyRPCWaitpanel.SetActive(false);
            }
        }
        CardCount = CardHandField.transform.childCount;
        MyCardCount.text = CardCount.ToString();
        RpcToOtherMembers("CardCountSet", CardCount.ToString());
        HandCardPoint();
        HandCardOverWriteBan();
    }

    IEnumerator CountDown()
    {
        StartWaitWindow.SetActive(true);
        StartCountDown.text = "3";
        yield return new WaitForSeconds(1);
        StartCountDown.text = "2";
        yield return new WaitForSeconds(1);
        StartCountDown.text = "1";
        yield return new WaitForSeconds(1);
        StartWaitWindow.SetActive(false);
        EnemyRPCWaitpanel.SetActive(true);
        if (PlayerNumberJudge == 1)
        {
            TurnMamager.GetComponent<TurnController>().FirstAttackerjudge();
            CreateCard(P1Deck[0]);
            CreateCard(P1Deck[1]);
            CreateCard(P1Deck[2]);
            CreateCard(P1Deck[3]);
            Array.Reverse(P1Deck);
            Array.Resize(ref P1Deck, P1Deck.Length - 8);
            Array.Reverse(P1Deck);
            RpcToOtherMembers("CardGeneOrder");
        }
    }

    [StrixRpc]
    public void NameTagSet(string _MyName)
    {
        EnemynameTag.text = _MyName;
    }

    [StrixRpc]
    public void CardCountSet(string _CardCount)
    {
        EnemyCardCount.text = _CardCount;
    }

    [StrixRpc]
    public void RootJudge(long _primaryKey )
    {
        if ( primaryKey < _primaryKey )
        {
            PlayerNumberJudge = 1;
        }
        else
        {
            PlayerNumberJudge = 2;
        }
    }

    [StrixRpc]
    public void CardGeneOrder()
    {
        CreateCard(P2Deck[4]);
        CreateCard(P2Deck[5]);
        CreateCard(P2Deck[6]);
        CreateCard(P2Deck[7]);
        Array.Reverse(P2Deck);
        Array.Resize(ref P2Deck, P2Deck.Length - 8);
        Array.Reverse(P2Deck);
        AlreadyP1 = true;
    }

    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform playerHand;

    [StrixRpc]
    public void CreateCard(string cardID)
    {
        CardController card = Instantiate(cardPrefab, playerHand);
        card.Init(cardID);
    }

    public void ClickAddCard()
    {
        if (PlayerNumberJudge == 1 && P1Deck.Length != 0)
        {
            CreateCard(P1Deck[0]);
            RemoveDeckTop();

        }
        if (PlayerNumberJudge == 2 &&  P2Deck.Length != 0)
        {
            CreateCard(P2Deck[0]);
            RemoveDeckTop();
        }
    }

    void Shuffle()
    {
        int n = P2Deck.Length;
        while (n > 1)
        {
            n --;

            int k = UnityEngine.Random.Range(0, n + 1);
 
            string temp = P2Deck[k];
            P2Deck[k] = P2Deck[n];
            P2Deck[n] = temp;
        }
        string P2DeckStr = string.Join(",", P2Deck);
        RpcToOtherMembers("P2to1SyncList", P2DeckStr);
    }

    [StrixRpc]
    public void P2to1SyncList(string _P2DeckStr)
    {
        if (_P2DeckStr.Equals("0") == false)
        {
            P1Deck = _P2DeckStr.Split(',');
        }
        if (_P2DeckStr.Equals("0") == true)
        {
            P1Deck = new string[0];
        }
    }

    [StrixRpc]
    public void P1to2SyncList(string _P1DeckStr)
    {
        if (_P1DeckStr.Equals("0") == false)
        {
            P2Deck = _P1DeckStr.Split(',');
        }
        if (_P1DeckStr.Equals("0") == true)
        {
            P2Deck = new string[0];
        }
    }

    public void RemoveDeckTop()
    {
        if (PlayerNumberJudge == 1)
        {
            Array.Reverse(P1Deck);
            Array.Resize(ref P1Deck, P1Deck.Length - 1);
            Array.Reverse(P1Deck);
            if (P1Deck.Length > 0)
            {
                string P1DeckStr = string.Join(",", P1Deck);
                RpcToOtherMembers("P1to2SyncList", P1DeckStr);
            }
            if (P1Deck.Length == 0)
            {
                RpcToOtherMembers("P1to2SyncList", "0");
            }
        }
        if (PlayerNumberJudge == 2)
        {
            Array.Reverse(P2Deck);
            Array.Resize(ref P2Deck, P2Deck.Length - 1);
            Array.Reverse(P2Deck);
            if (P2Deck.Length > 0)
            {
                string P2DeckStr = string.Join(",", P2Deck);
                RpcToOtherMembers("P2to1SyncList", P2DeckStr);
            }
            if (P1Deck.Length == 0)
            {
                RpcToOtherMembers("P2to1SyncList", "0");
            }
        }
    }

    [StrixRpc]
    public void P1DeckToZero()
    {
        P1Deck = new string[0];
    }

    [StrixRpc]
    public void P2DeckToZero()
    {
        P2Deck = new string[0];
    }

    [SerializeField] Transform HandField;
    [SerializeField] Text MyHandPointText;
    [SerializeField] Text EnemyHandPointText;
    [SerializeField] Text HandPointAddMemo;

    public void HandCardPoint()
    {
        
        if ("2".Equals(HandPointAddMemo.text.ToString()))
        {
            int MyHandPoint = 0;
            foreach (Transform Card in HandField)
            {
                MyHandPoint += Card.gameObject.GetComponent<CardView>()._Point;
            }
            
            MyHandPointText.text = (MyHandPoint + 2).ToString();
            RpcToOtherMembers("HandPointSync", MyHandPoint + 2);
        }
        else
        {
            int MyHandPoint = 0;
            foreach (Transform Card in HandField)
            {
                MyHandPoint += Card.gameObject.GetComponent<CardView>()._Point;
            }
            
            MyHandPointText.text = MyHandPoint.ToString();
            RpcToOtherMembers("HandPointSync", MyHandPoint);
        }
    }

    [StrixRpc]
    public void HandPointSync(int _EnemyHandPoint)
    {
        EnemyHandPointText.text = _EnemyHandPoint.ToString();
    }

    public void HandCardOverWriteBan()
    {
        foreach (Transform Card in HandField)
        {
            Card.gameObject.GetComponent<CardOverWriteEvent>().enabled = false;
        }
    }

    public void SetRoomKey1()
    {
        StrixNetwork.instance.SetRoom(
            roomId: StrixNetwork.instance.selfRoomMember.GetRoomId(),
            roomProperties: new RoomProperties {
                key1 = 2                                        
            },
            handler: setRoomResult => Debug.Log("Capacity changed.Current capacity"),  
            failureHandler: setRoomError => Debug.LogError("Search failed.Reason: " + setRoomError.cause)
        );
    }
}
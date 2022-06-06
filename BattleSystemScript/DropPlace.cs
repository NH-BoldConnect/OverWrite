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
using System;
 
// フィールドにアタッチするクラス
public class DropPlace : StrixBehaviour, IDropHandler
{
    public bool BanJudge;
    public bool OnDropActive = true;
    GameObject SystemManager;
    GameObject TurnMamager;


    void Start()
    {
        BanJudge = false;
        
        SystemManager = GameObject.Find("SystemManager");
        TurnMamager = GameObject.Find("TurnMamager");
    }

    [SerializeField] GameObject Field;

    void Update()
    {
        foreach (Transform childTransform in Field.transform)
        {
            CardMovement cardMovement = childTransform.gameObject.GetComponent<CardMovement>();
            Destroy(cardMovement);
        }
    }

    public void OnDrop(PointerEventData eventData) // ドロップされた時に行う処理
    {
        if (OnDropActive == true & eventData.pointerDrag == true)
        {
            CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>(); // ドラッグしてきた情報からCardMovementを取得

            CardView view = eventData.pointerDrag.GetComponent<CardView>(); // ドラッグしてきた情報からCardViewを取得
            string PriorityStr = view._Priority.ToString();
            int PriorityNum = view._Priority;
            string CardID = view._CardID;

            GameObject MyObj = transform.gameObject;
            string[] FieldNum = MyObj.name.Split(':');

            if (BanJudge == false)
            {
                if (card != null && FieldNum[1].Equals(PriorityStr)) // もしカードがあり、かつ優先度が一致していれば
                {
                    card.cardParent = this.transform; // カードの親要素を自分（アタッチされてるオブジェクト）にする
                    Debug.Log("OnDrop起動");
                    RpcToOtherMembers("CreateCard", CardID);
                    MyCardMarker();
                    PriorityJudge(PriorityNum, CardID, 1);
                    TurnMamager.GetComponent<TurnController>().CounterAdd();
                }
            }
        }
    }

    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform EnemyField;
    [StrixRpc]
    public void CreateCard(string cardID)
    {
        CardController card = Instantiate(cardPrefab, EnemyField);
        card.Init(cardID);
    }

    [SerializeField] Transform GraveContent;
    public void SendGrave()
    {
        CardView View = Field.transform.GetChild(0).gameObject.GetComponent<CardView>();
        //CardView View = GetComponentInChildren<CardView>();
        int PriorityNum = View._Priority;
        string CardID = View._CardID;

        GraveCardCopy(View._CardID);
        RpcToOtherMembers("GraveCardCopy", View._CardID);

        Destroy(Field.transform.GetChild(0).gameObject);
        /* foreach (Transform ChildCard in Field.transform)
        {
            Destroy(ChildCard.gameObject); //相手フィールドはSendTrueFieldにて削除
        } */
        MyCardMarker();
    }

    public void FieldUpdate(string _NewCardID, int _PriorityNum)
    {
        PriorityJudge(_PriorityNum, _NewCardID, 1);
        RpcToOtherMembers("CreateCard", _NewCardID);
        PriorityEffectClear(_PriorityNum);
    }
    
    [StrixRpc]
    public void GraveCardCopy(string _CardID)
    {
        CardController card = Instantiate(cardPrefab, GraveContent);
        card.Init(_CardID);
    }

    public void MyCardMarker()
    {
        GameObject MyObj = transform.gameObject;
        string[] FieldNum = MyObj.name.Split(':');
        int Fieldint = int.Parse(FieldNum[1]);

        SystemManager.GetComponent<MarkerController>().MarkerSwitch(Fieldint, true);
    }
    
    public void PriorityJudge(int _PriorityNum, string _CardID, int _isMyCard)
    {
        switch (_PriorityNum)
        {
            case 0:
                Field.GetComponent<Priority0Effect>().SetCardData(_CardID, _isMyCard);
                break;
            case 1:
                Field.GetComponent<Priority1Effect>().SetCardData(_CardID, _isMyCard);
                break;
            case 2:
                Field.GetComponent<Priority2Effect>().SetCardData(_CardID, _isMyCard);
                break;
            case 3:
                Field.GetComponent<Priority3Effect>().SetCardData(_CardID, _isMyCard);
                break;
            case 4:
                Field.GetComponent<Priority4Effect>().SetCardData(_CardID, _isMyCard);
                break;
            case 5:
                Field.GetComponent<Priority5Effect>().SetCardData(_CardID, _isMyCard);
                break;
            case 6:
                Field.GetComponent<Priority6Effect>().SetCardData(_CardID, _isMyCard);
                break;
            case 7:
                Field.GetComponent<Priority7Effect>().SetCardData(_CardID, _isMyCard);
                break;
            case 8:
                Field.GetComponent<Priority8Effect>().SetCardData(_CardID, _isMyCard);
                break;
            case 9:
                Field.GetComponent<Priority9Effect>().SetCardData(_CardID, _isMyCard);
                break;
            case 10:
                Field.GetComponent<Priority10Effect>().SetCardData(_CardID, _isMyCard);
                break;
        }
    }
    public void PriorityEffectClear(int _PriorityNum)
    {
        switch (_PriorityNum)
        {
            case 0:
                Field.GetComponent<Priority0Effect>().EffectClear();
                break;
            case 1:
                Field.GetComponent<Priority1Effect>().EffectClear();
                break;
            case 2:
                Field.GetComponent<Priority2Effect>().EffectClear();
                break;
            case 3:
                Field.GetComponent<Priority3Effect>().EffectClear();
                break;
            case 4:
                Field.GetComponent<Priority4Effect>().EffectClear();
                break;
            case 5:
                Field.GetComponent<Priority5Effect>().EffectClear();
                break;
            case 6:
                Field.GetComponent<Priority6Effect>().EffectClear();
                break;
            case 7:
                Field.GetComponent<Priority7Effect>().EffectClear();
                break;
            case 8:
                Field.GetComponent<Priority8Effect>().EffectClear();
                break;
            case 9:
                Field.GetComponent<Priority9Effect>().EffectClear();
                break;
        }
    }

    public void FreeCreateCard(string _CardID, int _CreateField)
    {
        GameObject MyObj = transform.gameObject;
        string[] FieldNum = MyObj.name.Split(':');
        if (FieldNum[1].Equals(_CreateField.ToString()))
        {
            CardController card = Instantiate(cardPrefab, this.transform);
            card.Init(_CardID);
        }
    }
}
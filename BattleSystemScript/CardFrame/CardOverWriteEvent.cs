using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardOverWriteEvent : MonoBehaviour, IDropHandler
{
    public bool OverWriteJudge;
    public bool InterceptJudge;
    public bool CardOverWriteActive = true;
    GameObject HandField;
    GameObject SystemManager;
    GameObject TurnMamager;

    void Awake()
    {
        HandField = GameObject.Find("HandContent");
        SystemManager = GameObject.Find("SystemManager");
        TurnMamager = GameObject.Find("TurnMamager");
    }
    void Start()
    {
        OverWriteJudge = true;
        InterceptJudge = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (CardOverWriteActive == true & eventData.pointerDrag == true)
        {
            CardMovement NewCard = eventData.pointerDrag.GetComponent<CardMovement>(); // ドラッグしてきた情報からCardMovementを取得
            CardView NewView = eventData.pointerDrag.GetComponent<CardView>(); // ドラッグしてきた情報からCardViewを取得
            int NewPriorityNum = NewView._Priority;
            string NewCardID = NewView._CardID;
            CardModel NewModel = NewView._cardModel;

            CardView OldView = GetComponent<CardView>(); // ドラッグしてきた情報からCardViewを取得
            int OldPriorityNum = OldView._Priority;
            string OldCardID = OldView._CardID;
            CardModel OldModel = OldView._cardModel;

            GameObject ParentObj = transform.parent.gameObject;
            string[] FieldName = ParentObj.name.Split(':');

            if (NewCard != null && NewPriorityNum == OldPriorityNum && FieldName[0].Equals("Field"))
            {
                if (OverWriteJudge == true & InterceptJudge == false) //上書き成功処理
                {
                    GameObject Parent = this.transform.parent.gameObject;
                    NewCardSet(NewCardID, NewPriorityNum);
                    NewCard.cardParent = Parent.transform;
                }
                if (OverWriteJudge == true & InterceptJudge == true) //上書き阻止が起動
                {
                    GameObject Parent = this.transform.parent.gameObject;
                    NewCard.cardParent = Parent.transform;
                    SystemManager.GetComponent<InterceptOverWrite>().InterceptRemote(NewModel, OldModel, NewPriorityNum, NewCardID, OldCardID);
                }
                if (OverWriteJudge == false) //上書き失敗処理
                {
                    NewCard.cardParent = HandField.transform;
                }
            }
        }
        
        
    }

    public void NewCardSet(string _NewCardID, int _NewPriorityNum)
    {
        this.transform.GetComponentInParent<DropPlace>().FieldUpdate(_NewCardID, _NewPriorityNum);
        this.transform.GetComponentInParent<DropPlace>().SendGrave();
        TurnMamager.GetComponent<TurnController>().CounterAdd();
    }
}

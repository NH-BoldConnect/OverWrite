using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour
{

    [SerializeField] Image CardImage;
    public CardModel _cardModel;
    public int _Priority;
    public int _Point;
    public string _CardID;
    public bool _Reverse;
    GameObject SystemManager;
    public int _PlusMinus;
    public int _Multiply;
    int _PointTemp;

    public void Show(CardModel cardModel) // cardModelのデータ取得と反映
    {
        CardImage.sprite = cardModel.Image;
        _cardModel = cardModel;
        _Priority = cardModel.Priority;
        _PointTemp = cardModel.Point;
        _CardID = cardModel.CardID;
        this.gameObject.name = _CardID;
        
    }

    void Awake()
    {
        SystemManager = GameObject.Find("SystemManager");
    }

    void Update()
    {
        _Point = _PointTemp * _PlusMinus * _Multiply;
    }

    public void ZoomSender()
    {
        SystemManager.GetComponent<ZoomSystem>().ZoomReceptor(_cardModel.Image);
        Debug.Log("カードを感知しました");
    }

    public void EffectEraserSend()
    {
        SystemManager.GetComponent<EraserAndDelete>().EraserCatcher(_Priority);
    }

    public void ZoomSenderMove()
    {
        Debug.Log("ZoomSenderが移動しました");
        EventTrigger Trigger = this.gameObject.GetComponent<EventTrigger>();
        Destroy(Trigger);
        foreach (Transform Child in this.transform)
        {
            if ("CardImage".Equals(Child.gameObject.name))
            {
                Child.gameObject.AddComponent<EventTrigger>();
                EventTrigger trigger = Child.gameObject.GetComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerDown;
                entry.callback.AddListener((eventDate) => { ZoomSender(); });
                trigger.triggers.Add(entry);
            }
        }
        
    }

    public void ZoomSenderComeback()
    {
        Debug.Log("ZoomSenderが復帰しました");
        this.gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = this.gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((eventDate) => { ZoomSender(); });
        trigger.triggers.Add(entry);
        foreach (Transform Child in this.transform)
        {
            if ("CardImage".Equals(Child.gameObject.name))
            {
                EventTrigger Trigger = Child.gameObject.GetComponent<EventTrigger>();
                Destroy(Trigger);
            }
        }
    }

    public void ThisObjectToGrave()
    {
        SystemManager.GetComponent<EraserAndDelete>().ToGraveCatcher(_CardID);
        ParentNameNumber();
        SystemManager.GetComponent<EraserAndDelete>().DeleteSurroundCleanup(FieldNum);
        SystemManager.GetComponent<EraserAndDelete>().ToGraveCancel();

        Destroy(this.gameObject);
    }

    int FieldNum;

    public void ParentNameNumber()
    {
        if ("HandContent".Equals(this.transform.parent.gameObject.name))
        {
            FieldNum = -1;
        }
        else
        {
            FieldNum = _Priority;
        }
    }

    public void ThisObjectToHand()
    {
        SystemManager.GetComponent<EraserAndDelete>().ToHandCatcher(_CardID);
        SystemManager.GetComponent<EraserAndDelete>().GraveToHandCancel();

        Destroy(this.gameObject);
    }

    public void ThisObjectReverse()
    {
        SystemManager.GetComponent<EraserAndDelete>().ReverseCatcher(_Priority);
    }

    public void ReverseView()
    {
        CardImage.sprite = Resources.Load<Sprite>("Card/カード裏面");
        _Reverse = true;
    }

    public void ThisObjectUnReverse()
    {
        SystemManager.GetComponent<EraserAndDelete>().UnReverseCatcher(_Priority);
    }

    public void UnReverseView()
    {
        CardImage.sprite = Resources.Load<Sprite>("Card/" + _CardID);
        _Reverse = false;
    }

}

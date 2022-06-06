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

public class InterceptOverWrite : StrixBehaviour
{

    int CountDownSync;
    bool CanCountDown;
    bool BootEffect;
    bool CountDownStop;

    [SerializeField] GameObject InterceptWindow;
    [SerializeField] Image NowCardImage;
    [SerializeField] Image AfterCardImage;
    [SerializeField] Text CountDownText;

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
    [SerializeField] Transform GraveContent;
    [SerializeField] CardController cardPrefab;

    Transform CurrentField;
    int AfterPriority;
    bool CancelJudge;
    Vector3 Angle;

    [SerializeField] GameObject InterceptWaitPanel;
    [SerializeField] Text WaitPanelCountdown;
    [SerializeField] Transform RotateCircle;

    [SerializeField] Text InterceptAfterCardIDMemo;
    [SerializeField] Text InterceptNowCardIDMemo;
    [SerializeField] Text InterceptDestroyMemo;
    GameObject DeleteCard;
    GameObject OldCard;

    void Start()
    {
        Angle = RotateCircle.localEulerAngles;
    }

    public void InterceptRemote(CardModel NewCardModel, CardModel OldCardModel, 
                                int NewPriority, string NewCardID, string OldCardID)
    {
        CountDownStop = false;
        BootEffect = false;
        RpcToOtherMembers("InterceptPanelOpen", NewCardModel.CardID, NewPriority, OldCardModel.CardID);
        StartCoroutine("CloseCountDown");
        InterceptAfterCardIDMemo.text = NewCardID;
        InterceptNowCardIDMemo.text = OldCardID;
        RpcToOtherMembers("SetCardIDMemo", NewCardID, OldCardID);
        CancelJudge = false;
        CurrentFieldInput(NewPriority);
    }

    [StrixRpc]
    public void InterceptPanelOpen(string _NewCardID, int _Priority, string _OldCardID)
    {
        CurrentFieldInput(_Priority);
        InterceptWindow.SetActive(true);
        NowCardImage.sprite = Resources.Load<Sprite>("Card/" + _OldCardID);
        AfterCardImage.sprite = Resources.Load<Sprite>("Card/" + _NewCardID);
    }
    
    public void InterceptPanelClose()
    {
        InterceptWindow.SetActive(false);
        RpcToOtherMembers("InterceptCancelRemote", InterceptAfterCardIDMemo.text.ToString(), AfterPriority);
        RpcToOtherMembers("CancelJudgeSet");
    }

    [StrixRpc]
    public void InterceptCancelRemote(string _AfterCardID, int _AfterPriority)
    {
        CountDownStop = true;
        CurrentFieldInput(_AfterPriority);
        foreach (Transform Card in CurrentField)
        {
            OldCard = Card.gameObject;
            break;
        }
        if (CurrentField.childCount > 1)
        {
            OldCard.GetComponent<CardOverWriteEvent>().NewCardSet(_AfterCardID, _AfterPriority);
        }
    }

    IEnumerator CloseCountDown()
    {
        InterceptWaitPanel.SetActive(true);
        CanCountDown = true;
        for (int i = 10; i >= 0; i--)
        {
            WaitPanelCountdown.text = i.ToString();
            RpcToOtherMembers("SyncCountText", i);
            if (CancelJudge == true)
            {
                InterceptWaitPanel.SetActive(false);
                CanCountDown = false;
            }
            if (i == 0)
            {
                InterceptWaitPanel.SetActive(false);
                CanCountDown = false;
            }
            yield return new WaitForSeconds(1);
        }
    
    }

    [StrixRpc]
    public void SyncCountText(int _CountDownSync)
    {
        CountDownText.text = _CountDownSync.ToString();
        if (_CountDownSync == 0)
        {
            InterceptWindow.SetActive(false);
            RpcToOtherMembers("InterceptCancelRemote", InterceptAfterCardIDMemo.text.ToString(), AfterPriority);
        }
    }

    [StrixRpc]
    public void CancelJudgeSet()
    {
        CancelJudge = true;
    }

    void Update()
    {
        if (CanCountDown == true)
        {
            Angle.z += 0.3f;
            RotateCircle.localEulerAngles = Angle;
        }
        if ("".Equals(InterceptAfterCardIDMemo.text.ToString()) == false & BootEffect == true)
        {
            InterceptEffect(InterceptAfterCardIDMemo.text.ToString());
            BootEffect = false;
        }
        if ("".Equals(InterceptDestroyMemo.text.ToString()) == false)
        {
            foreach (Transform Card in CurrentField)
            {
                DeleteCard = Card.gameObject;
            }
            if (CurrentField.childCount > 1)
            {
                Destroy(DeleteCard);
            }
            InterceptDestroyMemo.text = "";
            BootEffect = false;
        }
        if (CountDownStop == true)
        {
            CanCountDown = false;
            InterceptWaitPanel.SetActive(false);
            CountDownStop = false;
        }
    }

    public void NowCardClick_ZoomSender()
    {
        this.gameObject.GetComponent<ZoomSystem>().ZoomReceptor(NowCardImage.sprite);
    }

    public void AfterCardClick_ZoomSender()
    {
        this.gameObject.GetComponent<ZoomSystem>().ZoomReceptor(AfterCardImage.sprite);
    }

    public void InterceptBoot()
    {
        BootEffect = true;
        RpcToOtherMembers("BootEffectSet");
        RpcToOtherMembers("DestroyRemoteMarker");
        RpcToOtherMembers("CancelJudgeSet");
        InterceptWindow.SetActive(false);
        Card84ToGrave();
    }

    public void Card84ToGrave()
    {
        this.gameObject.GetComponent<EraserAndDelete>().ToGraveCatcher("8-4");
        this.gameObject.GetComponent<EraserAndDelete>().DeleteSurroundCleanup(8);
        Field8.gameObject.GetComponent<Priority8Effect>().EffectClear();
        foreach (Transform Card in Field8)
        {
            Destroy(Card.gameObject);
        }
    }

    public void InterceptEffect(string _CardID)
    {
        CardController card = Instantiate(cardPrefab, GraveContent);
        card.Init(_CardID);
    }

    [StrixRpc]
    public void BootEffectSet()
    {
        BootEffect = true;
        CountDownStop = true;
    }

    [StrixRpc]
    public void SetCardIDMemo(string _AfterCardID, string _NowCardID)
    {
        InterceptAfterCardIDMemo.text = _AfterCardID;
        InterceptNowCardIDMemo.text = _NowCardID;
    }

    [StrixRpc]
    public void DestroyRemoteMarker()
    {
        InterceptDestroyMemo.text = "A"; //空白でないならなんでもいい
    }

    public void CurrentFieldInput(int _Priority)
    {
        switch (_Priority)
        {
            case 0:
                CurrentField = Field0;
                break;
            case 1:
                CurrentField = Field1;
                break;
            case 2:
                CurrentField = Field2;
                break;
            case 3:
                CurrentField = Field3;
                break;
            case 4:
                CurrentField = Field4;
                break;
            case 5:
                CurrentField = Field5;
                break;
            case 6:
                CurrentField = Field6;
                break;
            case 7:
                CurrentField = Field7;
                break;
            case 8:
                CurrentField = Field8;
                break;
            case 9:
                CurrentField = Field9;
                break;
            case 10:
                CurrentField = Field10;
                break;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
 
public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform cardParent;
 
    public void OnBeginDrag(PointerEventData eventData) // ドラッグを始めるときに行う処理
    {
        cardParent = transform.parent;
        transform.SetParent(cardParent.parent.parent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false; // blocksRaycastsをオフにする
        Debug.Log("OnBeginDrag起動");
        //GameObject SystemManager = GameObject.Find("SystemManager");
        //SystemManager.GetComponent<BattleSystem>().CardDragChecker();
    }
 
    public void OnDrag(PointerEventData eventData) // ドラッグしてる時に起こす処理
    {
        Vector3 cardPos = Camera.main.ScreenToWorldPoint(eventData.position);
        cardPos.z = 0;
        transform.position = cardPos;

        Debug.Log("OnDrag起動");
    }
 
    public void OnEndDrag(PointerEventData eventData) // カードを離したときに行う処理
    {
        transform.SetParent(cardParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true; // blocksRaycastsをオンにする
        Debug.Log("OnEndDrag起動");
        eventData.pointerDrag.GetComponent<CardOverWriteEvent>().enabled = true;
        //GameObject SystemManager = GameObject.Find("SystemManager");
        //SystemManager.GetComponent<BattleSystem>().CardDragEndChecker();
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SoftGear.Strix.Unity.Runtime;
using UnityEngine.EventSystems;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core.Model.Manager.Filter.Builder;
using SoftGear.Strix.Unity.Runtime.Event;
using System.Linq;

public class LobbyListGenerator : StrixBehaviour
{
    public GameObject RoomListElement;
    public GameObject RoomParent;
    private bool isPasswordProtected;
    public bool ClickedCheck;
    bool StartDid;

    void Start()
    {
        Debug.Log("開始");
        ClickedCheck = false;
        StartCoroutine("ListGeneWaiter");
        StartCoroutine("ListUpdate");
    }

    public void ListGenerate()
    {
        StrixNetwork.instance.SearchJoinableRoom(
            condition: null,                             
            order: new Order("memberCount", OrderType.Ascending),       // 最もすいているルームが最初になるように並べます
            limit: 100,                                                                            // 結果を10件のみ取得します
            offset: 0,                                                                            // 結果を先頭から取得します
            handler: searchResults => {
                
                // 検索が終わったら、見つかった全てのルームに関する情報を出力します
                foreach (var roomInfo in searchResults.roomInfoCollection)
                {
                    if (roomInfo.key1 == 1)
                    {
                        Debug.Log("Key1は" + roomInfo.key1);
                        GameObject RoomElement = GameObject.Instantiate(RoomListElement);
                        
                        //RoomElementをcontentの子オブジェクトとしてセット    
                        RoomElement.transform.SetParent(RoomParent.transform, false);
                        //RoomElementにルーム情報をセット
                        object passAdd = roomInfo.properties["passAdd"];
                        Debug.Log(passAdd.ToString());
                        if ( roomInfo.properties["passAdd"] != "")
                        {
                            isPasswordProtected = true;
                        }
                        else 
                        {
                            isPasswordProtected = false;
                        }
                        RoomElement.GetComponent<RoomListPlefab>().SetRoomInfo(
                            roomInfo.name,
                            roomInfo.stringKey,
                            isPasswordProtected,
                            roomInfo.host,
                            roomInfo.port,
                            roomInfo.protocol,
                            roomInfo.roomId,
                            passAdd.ToString()
                        );
                    }
                    
                }
            
            },
            failureHandler: searchError => Debug.LogError("Search failed.Reason: " + searchError.cause)
        );
    }
    public void UpdateListButton()
    {
        foreach ( Transform n in RoomParent.transform )
        {
            GameObject.Destroy(n.gameObject);
        }
        ListGenerate();
        
        
    }
    IEnumerator ListGeneWaiter()
    {
        yield return new WaitForSeconds(0.00001f);
        UpdateListButton();
    }

    IEnumerator ListUpdate()
    {
        while (ClickedCheck == false)
        {
            yield return new WaitForSeconds(1);
            UpdateListButton();
        }
    }

    public void ClickedSet()
    {
        ClickedCheck = true;
    }
}

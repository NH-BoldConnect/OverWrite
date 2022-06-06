/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SoftGear.Strix.Unity.Runtime;
using UnityEngine.EventSystems;

public class GeneDest : StrixBehaviour
{
    public GameObject RoomListElement;
    public GameObject RoomParent;
    public void OnClick_JouButton()
    {
        GameObject RoomElement = GameObject.Instantiate(RoomListElement);
                
        //RoomElementをcontentの子オブジェクトとしてセット    
        RoomElement.transform.SetParent(RoomParent.transform, false);

        //RoomElementにルーム情報をセット
        RoomElement.GetComponent<RoomListPlefab>().SetRoomInfo("ウンチーコング","jou211",true);
    }
    public void OnClick_NatuButton()
    {
        GameObject RoomElement = GameObject.Instantiate(RoomListElement);
                
        //RoomElementをcontentの子オブジェクトとしてセット    
        RoomElement.transform.SetParent(RoomParent.transform, false);

        //RoomElementにルーム情報をセット
        RoomElement.GetComponent<RoomListPlefab>().SetRoomInfo("ブルーアイズ！","natu7D",false);
        
    }
    public void BreakMake()
        {
            foreach ( Transform n in RoomParent.transform )
            {
                GameObject.Destroy(n.gameObject);
            };
            for (int i = 0; i < 5; i++)
            {
                GameObject RoomElement = GameObject.Instantiate(RoomListElement);
                
                //RoomElementをcontentの子オブジェクトとしてセット    
                RoomElement.transform.SetParent(RoomParent.transform, false);

                //RoomElementにルーム情報をセット
                RoomElement.GetComponent<RoomListPlefab>().SetRoomInfo("ウンチーコング","jou211",true);
            }

        }
}*/

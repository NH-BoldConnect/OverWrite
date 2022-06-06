using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core.Model.Manager.Filter.Builder;
using SoftGear.Strix.Client.Core;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Net.Logging;
using SoftGear.Strix.Unity.Runtime.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetListTest : StrixBehaviour
{
    [StrixSyncField]
    public Dictionary<string, string> Table = new Dictionary<string, string>();
    void OnClick_SetList()
    {
        // これは仮の値です。実際のアプリケーションIDに変更してください
        // Strix Cloudのアプリケーション情報タブにあります: https://www.strixcloud.net/app/applist
        StrixNetwork.instance.applicationId = "6ccc46e9-7ae1-4d8d-bb76-3749091bad49";

        // まずマスターサーバーに接続します
        StrixNetwork.instance.ConnectMasterServer(
            // これは仮の値です。実際のマスターホスト名に変更してください。
            // Strix Cloudのアプリケーション情報タブにあります: https://www.strixcloud.net/app/applist
            host: "d14971138f453a6f67873860.game.strixcloud.net",
            connectEventHandler: _ => {
                Debug.Log("Connection established.");
            },
            errorEventHandler: connectError => Debug.LogError("Connection failed.Reason: " + connectError.cause)
        );
    }
    public void SetList()
    {
        StrixNetwork.instance.CreateRoom(
                    new RoomProperties {
                        name = "Room1",                       // このルームはパスワードで保護されているため、パスワードのないクライアントは参加できません
                        capacity = 2,
                        key1 = 3.14
                    },
                    new RoomMemberProperties {
                        name = "A"                                                        // これがプレイヤーの名前になります
                    },
                    handler: __ => {
                        Debug.Log("Room created.");
                    },
                    failureHandler: createRoomError => Debug.LogError("Could not create room.Reason: " + createRoomError.cause)
                );
        Table.Add("Name","Tester");
        Table.Add("Password","114514");

    }
    public void GetList()
    {
        string Ahost = "";
        int Aport = 0;
        string Aprotocol = "";
        long AroomID = 0;
        StrixNetwork.instance.SearchRoom(
                            condition: ConditionBuilder.Builder().Field("key1").EqualTo(3.14).Build(),  //「My Game Room」という名前のすべての部屋を検索します
                            limit: 50,                                                                            // 結果を10件のみ取得します
                            offset: 0,                                                                            // 結果を先頭から取得します
                            handler: searchResults => {
                                Debug.Log(searchResults.roomInfoCollection.Count + " rooms found.");

                                // 検索が終わったら、見つかった全てのルームに関する情報を出力します
                                foreach (var roomInfo in searchResults.roomInfoCollection)
                                {    
                                    Ahost = roomInfo.host;
                                    Aport = roomInfo.port;
                                    Aprotocol = roomInfo.protocol;
                                    AroomID = roomInfo.roomId;
                                    Debug.Log("Ahost:" + roomInfo.host + "Aport:" + roomInfo.port 
                                    +"Aprotocol:" + roomInfo.protocol + "AroomID:" + roomInfo.roomId);
                                };
                            },
                            failureHandler: searchError => Debug.LogError("Search failed.Reason: " + searchError.cause)
                        );
        StrixNetwork.instance.JoinRoom(
            host : Ahost,
            port : Aport,
            protocol : Aprotocol,
            roomId : AroomID,
            playerName: "B",
            handler: __ => Debug.Log("Room joined."),
            failureHandler: joinError => Debug.LogError("Join failed.Reason: " + joinError.cause)
        );
        Debug.Log(Table["Name"]);
        Debug.Log(Table["Password"]);
    }
}

using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core.Model.Manager.Filter.Builder;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Unity.Runtime.Event;
using SoftGear.Strix.Unity.Runtime.Session;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LobbyUIScript : StrixBehaviour
{
    public InputField RoomName;
    private string password;  
    private string InputPassword;
    private string khost;
    private int kport;
    private string kprotcol;
    private long kroomId;
    private string kpassAdd;
    public GameObject UnConnectMessage;
    [SerializeField] GameObject RoomCreatePanel;
    [SerializeField] GameObject LobyGenerater;
    bool EnterPressed;
    void Start()
    {
        EnterPressed = false;
        password = "";
        var strixNetwork = StrixNetwork.instance;

        // これは仮の値です。実際のアプリケーションIDに変更してください
        // Strix Cloudのアプリケーション情報タブにあります: https://www.strixcloud.net/app/applist
        strixNetwork.applicationId = "6ccc46e9-7ae1-4d8d-bb76-3749091bad49";

        // まずマスターサーバーに接続します
        strixNetwork.ConnectMasterServer(
            // これは仮の値です。実際のマスターホスト名に変更してください。
            // Strix Cloudのアプリケーション情報タブにあります: https://www.strixcloud.net/app/applist
            host: "595b138b14629448e6c00087.game.strixcloud.net",
            connectEventHandler: _ => {
                Debug.Log("Connection established.");
            },
            errorEventHandler: connectError => Debug.LogError("Connection failed.Reason: " + connectError.cause)
        );
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return) & EnterPressed == false & RoomCreatePanel.activeSelf == true)
        {
            OnClick_RoomCreateButton();
            EnterPressed = true;
        }
    }

    public void PassChange(string NewPassword)
    {
        
        password = NewPassword;

    }
    public void OnClick_RoomCreateButton()
    {
        var strixNetwork = StrixNetwork.instance;
        string MyName = PlayerPrefs.GetString("MyName");
        PlayerPrefs.SetString("Password" , password);
        PlayerPrefs.Save();
        // マスターサーバーに接続した後でルームを作成できます
        if (password == "")
        {
            strixNetwork.CreateRoom(
                new RoomProperties {
                    name = RoomName.text,                                      // このルームはパスワードで保護されているため、パスワードのないクライアントは参加できません
                    capacity = 2,                                                    // ルームが保持できるクライアントの最大数
                    key1 = 1,
                    stringKey = MyName,
                    properties = new Dictionary<string, object> { {                     // カスタムプロパティを使用してルームに説明を付けます
                        "passAdd", password  // 後でルームを検索するときにこの説明を表示できます
                    } }                                                       // key1を使用してこの試合で使用するNPCの難易度を表すことにします
                },
                new RoomMemberProperties {
                    name = MyName                                                           // これがプレイヤーの名前になります
                    },
                handler: __ => {
                    Debug.Log("Room created.");
                    SceneManager.LoadScene("Battle");
                },
                failureHandler: createRoomError => Debug.LogError("Could not create room.Reason: " + createRoomError.cause)
            ); 
        }
        else
        {
        
            strixNetwork.CreateRoom(
                new RoomProperties {
                    name = RoomName.text,
                    capacity = 2,                                                      // ルームが保持できるクライアントの最大数
                    key1 = 1,
                    stringKey = MyName,
                    properties = new Dictionary<string, object> { {                     // カスタムプロパティを使用してルームに説明を付けます
                        "passAdd", password  // 後でルームを検索するときにこの説明を表示できます
                    } }                                                  // key1を使用してこの試合で使用するNPCの難易度を表すことにします
                },
                new RoomMemberProperties {
                    name = MyName                                                           // これがプレイヤーの名前になります
                    },
                handler: __ => {
                    Debug.Log("Room created.");
                    SceneManager.LoadScene("Battle");
                },
                failureHandler: createRoomError => Debug.LogError("Could not create room.Reason: " + createRoomError.cause)
            );
        }
    }
    public void CopyRoomInfo(
        string _host, int _port, string _protcol, long _roomId, string _passAdd)
    {
        khost = _host;
        kport = _port;
        kprotcol = _protcol;
        kroomId = _roomId;
        kpassAdd = _passAdd;
    }
    public void passInputChange(string _InputPassword)
    {
        InputPassword = _InputPassword; 
        Debug.Log(_InputPassword);
        Debug.Log(khost+":"+kport+":"+kprotcol+":"+kroomId);
    }
    public void OnClick_PassInputButton()
    {
        string MyName = PlayerPrefs.GetString("MyName");
        var strixNetwork = StrixNetwork.instance;
        if (InputPassword.Equals(kpassAdd))
        {
            strixNetwork.JoinRoom(
                    host: khost,
                    port: kport,
                    protocol: kprotcol,
                    roomId: kroomId,
                    playerName: MyName,
                handler: joinResult => {
                    Debug.Log("Room joined.");
                    SceneManager.LoadScene("Battle");
                    LobyGenerater.GetComponent<LobbyListGenerator>().ClickedCheck = true;
                },
                failureHandler: joinError => {Debug.LogError("Join failed.Reason: " + joinError.cause);
                }
            );
        }
        else
        {
            UnConnectMessage.SetActive(true);
        }
        
    }
    public void Onclick_AnotherButton()
    {
        Debug.Log(kpassAdd);
    }
}

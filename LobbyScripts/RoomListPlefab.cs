using UnityEngine;
using UnityEngine.UI;
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
using System.Linq;
using UnityEngine.SceneManagement;

public class RoomListPlefab : StrixBehaviour
{
    GameObject LobbyManager;
    GameObject LobyGenerater;
    public Text RoomName;
    public Text MakerName;
    private bool PasswordCheck;
    public GameObject Passtrue;
    public GameObject Passfalse;
    private string khost;
    private int kport;
    private string kprotcol;
    private long kroomId;
    private string kpassAdd;
    void Start()
    {
        LobbyManager = GameObject.Find("LobbyManager");
        LobyGenerater = GameObject.Find("LobbyListGenerator");
    }
    // Start is called before the first frame update
    public void SetRoomInfo(string _RoomName, string _MakerName,
                            bool _PasswordCheck, string _host,
                            int _port, string _protcol,
                            long _roomId, string _passAdd)
    {
        //入室ボタン用Number取得
        RoomName.text = _RoomName;
        MakerName.text = _MakerName;
        khost = _host;
        kport = _port;
        kprotcol = _protcol;
        kroomId = _roomId;
        kpassAdd = _passAdd;
        PasswordCheck = _PasswordCheck;
        if (PasswordCheck == true)
        {
            Passtrue.SetActive(true);
        }
        else
        {
            Passfalse.SetActive(true);
        }
    }
    public void OnClick_RoomListElement()
    {
        if (PasswordCheck == true)
        {
            LobbyManager.GetComponent<LobbySwitch>().PasswordWindowOpen();
            LobbyManager.GetComponent<LobbyUIScript>().CopyRoomInfo(khost, kport, kprotcol, kroomId, kpassAdd);
        }
        else
        {
            var strixNetwork = StrixNetwork.instance;
            string MyName = PlayerPrefs.GetString("MyName");
            strixNetwork.JoinRoom(
                host: khost,
                port: kport,
                protocol: kprotcol,
                roomId: kroomId,
                playerName: MyName,
                handler: ___ => {
                    Debug.Log("Room joined.");
                    SceneManager.LoadScene("Battle");
                    LobyGenerater.GetComponent<LobbyListGenerator>().ClickedCheck = true;
                },
                failureHandler: joinError => Debug.LogError("Join failed.Reason: " + joinError.cause)
            );
        }
    }

}

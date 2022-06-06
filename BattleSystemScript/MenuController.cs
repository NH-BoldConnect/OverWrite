using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SoftGear.Strix.Unity.Runtime;

public class MenuController : StrixBehaviour
{
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject EnemyLeavedMessage;
    bool LeaveCheck;

    public void MenuPanelOpen()
    {
        if (MenuPanel.activeSelf == false)
        {
            MenuPanel.SetActive(true);
        }
        else if (MenuPanel.activeSelf == true)
        {
            MenuPanel.SetActive(false);
        }
    }
    
    public void MenuPanelClose()
    {
        MenuPanel.SetActive(false);
    }

    public void OnClick_LeaveRoom()
    {
        RpcToOtherMembers("EnemyLeaveSend");
        StrixNetwork.instance.LeaveRoom(
                            handler: __ => Debug.Log("Room Leave: " + (StrixNetwork.instance.room == null)),
                            failureHandler: LeaveRoomError => Debug.LogError("Could not Leave room.Reason: " + LeaveRoomError.cause));
        SceneManager.LoadScene("Lobby");
    }

    [StrixRpc]
    public void EnemyLeaveSend()
    {
        EnemyLeavedMessage.SetActive(true);
    }

    public void FollowLeave()
    {
        OnClick_LeaveRoom();
        EnemyLeavedMessage.SetActive(false);
    }

    public void LeaveRoom()
    {
        StrixNetwork.instance.LeaveRoom(
                            handler: __ => Debug.Log("Room Leave: " + (StrixNetwork.instance.room == null)),
                            failureHandler: LeaveRoomError => Debug.LogError("Could not Leave room.Reason: " + LeaveRoomError.cause));
        SceneManager.LoadScene("Lobby");
    }
}
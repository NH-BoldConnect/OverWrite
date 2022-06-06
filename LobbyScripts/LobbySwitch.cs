using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Linq;

public class LobbySwitch : MonoBehaviour
{
    //部屋作成ウインドウ
    public GameObject CreateRoomPanel;  //部屋作成ウインドウ
    public GameObject PassPanel;        //パス入力欄
    public GameObject OnIcon;           //オンアイコン
    public GameObject OffIcon;          //オフアイコン
    public int PassCheck;               //ボタン状態判別
    public GameObject PassInputWindow;
    public GameObject PassDefinMesseage;

    void Start()
    {
        CreateRoomPanel.SetActive(false);
        PassCheck = 0;
    }

    void Update()
    {
        if (PassCheck % 2 != 0)
        {
            PassPanel.SetActive(true);
            OnIcon.SetActive(true);
            OffIcon.SetActive(false);
        }
        else
        {
            PassPanel.SetActive(false);
            OnIcon.SetActive(false);
            OffIcon.SetActive(true);
        }
    }
 
    //部屋作成ウインドウ表示用ボタンを押したときの処理
    public void OnClick_OpenRoomPanelButton()
    {
        //部屋作成ウインドウが表示していれば
        if (CreateRoomPanel.activeSelf)
        {
            //部屋作成ウインドウを非表示に
            CreateRoomPanel.SetActive(false);
        }
        else //そうでなければ
        {
            //部屋作成ウインドウを表示
            CreateRoomPanel.SetActive(true);
        }
    }
 
    public void OnClick_PasswordActive()
    {
        PassCheck += 1;
    }
    public void PasswordWindowOpen()
    {
        PassInputWindow.SetActive(true);
        PassDefinMesseage.SetActive(false);
    }
    public void PassInputWindowClose()
    {
        PassInputWindow.SetActive(false);
    }
    public void PassMessageClose()
    {
        PassDefinMesseage.SetActive(false);
    }
}

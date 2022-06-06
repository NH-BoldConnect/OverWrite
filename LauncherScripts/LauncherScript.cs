using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LauncherScript : MonoBehaviour
{
    public InputField playerNameInputField;
    
    public void OnClick_LaunchButton()
    {
        PlayerPrefs.SetString("MyName" , playerNameInputField.text);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Lobby");
    }

    void Update()
    {
        if (Input.GetKey (KeyCode.Return))
        {
            OnClick_LaunchButton();
        }

    }
/* 
    [SerializeField] GameObject RedBox;
    Vector3 Pos;
    void Start()
    {
        Pos.x = 175.2f / 45.0f;
        RedBox.transform.position = Pos;
    } */
}

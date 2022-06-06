using System;
using System.Collections.Generic;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Net.Logging;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using SoftGear.Strix.Unity.Runtime.Event;

public class StrixConnectGUI : MonoBehaviour {
    public string host = "d14971138f453a6f67873860.game.strixcloud.net";
    public int port = 9122;
    public string applicationId = "6ccc46e9-7ae1-4d8d-bb76-3749091bad49";
    public Level logLevel = Level.INFO;
    public InputField playerNameInputField;
    public Button connectButton;
    public UnityEvent OnConnect;

    // Use this for initialization
    void Start()
    {
    }

    void OnEnable()
    {
        connectButton.interactable = true;
    }

    public void Connect() {

        LogManager.Instance.Filter = logLevel;

        StrixNetwork.instance.applicationId = applicationId;
        StrixNetwork.instance.playerName = playerNameInputField.text;
        StrixNetwork.instance.ConnectMasterServer(host, port, OnConnectCallback, OnConnectFailedCallback);


        connectButton.interactable = false;
    }

    private void OnConnectCallback(StrixNetworkConnectEventArgs args)
    {

        OnConnect.Invoke();

        gameObject.SetActive(false);
    }

    private void OnConnectFailedCallback(StrixNetworkConnectFailedEventArgs args) {
        string error = "";

        if (args.cause != null) {
            error = args.cause.Message;
        }

        connectButton.interactable = true;
    }
}

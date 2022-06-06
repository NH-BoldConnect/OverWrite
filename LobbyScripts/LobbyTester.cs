using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string MyName = PlayerPrefs.GetString("MyName");
        Debug.Log("名前は" + MyName );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

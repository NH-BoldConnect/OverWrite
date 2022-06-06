using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabTester : MonoBehaviour
{
    public Text Number;
    // Start is called before the first frame update
    public void SetRoomInfo(string _Number)
    {
        //入室ボタン用Number取得
        Number.text = _Number;
    }
}

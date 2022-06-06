using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHeight : MonoBehaviour
{
    int Check;
    void Start()
    {
        Check = 3;
    }
    
    // Update is called once per frame
    void Update()
    {
        int ObjCount = this.transform.childCount;
        
        while (3 >= ObjCount)
        {
             Vector2 pos = GetComponent<RectTransform>().anchoredPosition;

            pos.y -= 44.88f;

            GetComponent<RectTransform>().anchoredPosition = pos;
        }

        if (ObjCount > Check)
        {
        
            Vector2 pos = GetComponent<RectTransform>().anchoredPosition;

            pos.y -= 44.88f;

            GetComponent<RectTransform>().anchoredPosition = pos;

            Check++;
            
        }
        
    }
}

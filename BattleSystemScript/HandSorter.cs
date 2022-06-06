using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HandSorter : MonoBehaviour 
{
    void Update()
    {
        Sort();
    }
    
    [SerializeField] Transform HandField;
    public void Sort()
    {
        List<Transform> CardList = new List<Transform>();

        int ChildCount = HandField.childCount;

        for (int i = 0; i < ChildCount; i++)
        {
            CardList.Add(HandField.GetChild(i));
        }

        CardList.Sort((obj1, obj2) => string.Compare(obj1.name, obj2.name));

        foreach (Transform Card in CardList)
        {
            Card.SetSiblingIndex(ChildCount - 1);
        }
    }
}

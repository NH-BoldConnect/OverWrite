using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SendTrueField : MonoBehaviour
{
    [SerializeField] Transform TrueField;
    [SerializeField] Transform FalseField;
    string CardID;
    GameObject SystemManager;

    void Start()
    {
        SystemManager = GameObject.Find("SystemManager");
    }

    void Update()
    {
        if (FalseField.childCount != 0)
        {
            foreach (Transform ChildDestroy in TrueField)
            {
                Destroy(ChildDestroy.gameObject);
            }
            foreach (Transform ChildTrans in FalseField)
            {
                CardID = ChildTrans.gameObject.GetComponent<CardView>()._CardID;

                ChildTrans.SetParent(TrueField);
            }

            GameObject MyObj = transform.gameObject;
            string[] FieldNum = MyObj.name.Split(':');
            int Fieldint = int.Parse(FieldNum[1]);

            SystemManager.GetComponent<MarkerController>().MarkerSwitch(Fieldint, false);

            switch (Fieldint)
            {
                case 0:
                    TrueField.gameObject.GetComponent<Priority0Effect>().SetCardData(CardID, -1);
                    break;
                case 1:
                    TrueField.gameObject.GetComponent<Priority1Effect>().SetCardData(CardID, -1);
                    break;
                case 2:
                    TrueField.gameObject.GetComponent<Priority2Effect>().SetCardData(CardID, -1);
                    break;
                case 3:
                    TrueField.gameObject.GetComponent<Priority3Effect>().SetCardData(CardID, -1);
                    break;
                case 4:
                    TrueField.gameObject.GetComponent<Priority4Effect>().SetCardData(CardID, -1);
                    break;
                case 5:
                    TrueField.gameObject.GetComponent<Priority5Effect>().SetCardData(CardID, -1);
                    break;
                case 6:
                    TrueField.gameObject.GetComponent<Priority6Effect>().SetCardData(CardID, -1);
                    break;
                case 7:
                    TrueField.gameObject.GetComponent<Priority7Effect>().SetCardData(CardID, -1);
                    break;
                case 8:
                    TrueField.gameObject.GetComponent<Priority8Effect>().SetCardData(CardID, -1);
                    break;
                case 9:
                    TrueField.gameObject.GetComponent<Priority9Effect>().SetCardData(CardID, -1);
                    break;
                case 10:
                    TrueField.gameObject.GetComponent<Priority10Effect>().SetCardData(CardID, -1);
                    break;
                
            }
            switch (Fieldint)
            {
                case 0:
                    TrueField.gameObject.GetComponent<Priority0Effect>().EffectClear();
                    break;
                case 1:
                    TrueField.gameObject.GetComponent<Priority1Effect>().EffectClear();
                    break;
                case 2:
                    TrueField.gameObject.GetComponent<Priority2Effect>().EffectClear();
                    break;
                case 3:
                    TrueField.gameObject.GetComponent<Priority3Effect>().EffectClear();
                    break;
                case 4:
                    TrueField.gameObject.GetComponent<Priority4Effect>().EffectClear();
                    break;
                case 5:
                    TrueField.gameObject.GetComponent<Priority5Effect>().EffectClear();
                    break;
                case 6:
                    TrueField.gameObject.GetComponent<Priority6Effect>().EffectClear();
                    break;
                case 7:
                    TrueField.gameObject.GetComponent<Priority7Effect>().EffectClear();
                    break;
                case 8:
                    TrueField.gameObject.GetComponent<Priority8Effect>().EffectClear();
                    break;
                case 9:
                    TrueField.gameObject.GetComponent<Priority9Effect>().EffectClear();
                    break;
                case 10:
                    TrueField.gameObject.GetComponent<Priority10Effect>().EffectClear();
                    break;
            }
        }

    }
}

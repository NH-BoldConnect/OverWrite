using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Net.Logging;
using SoftGear.Strix.Unity.Runtime.Event;
using System;

public class TotalPointManager : StrixBehaviour
{
    public void EndSystemBoot()
    {
        EndSystemRemote();
        RpcToOtherMembers("EndSystemRemote");
    }

    [StrixRpc]
    public void EndSystemRemote()
    {
        StartCoroutine("EndElementSwitch");
    }

    IEnumerator EndElementSwitch()
    {
        DetaSet();
        TotalPanel.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Field0.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Field1.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Field2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Field3.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Field4.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Field5.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Field6.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Field7.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Field8.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Field9.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Field10.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        HandField.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        TotalPointElement.SetActive(true);
        yield return new WaitForSeconds(1);
        WinOrLoseBox.SetActive(true);
        LobyBackButton.SetActive(true);
    }

    [SerializeField] GameObject TotalPanel;
    [SerializeField] GameObject TotalPointElement;
    [SerializeField] Text MyTotalPointText;
    [SerializeField] Text EnemyTotalPointText;
    int MyTotalPoint = 0;
    int EnemyTotalPoint = 0;
    [SerializeField] GameObject WinOrLoseBox;
    [SerializeField] GameObject MyWin, MyDraw, MyLose;
    [SerializeField] GameObject EnemyWin, EnemyDraw, EnemyLose;
    [SerializeField] GameObject LobyBackButton;

    public void DetaSet()
    {
        TotalVarSet();
        ProcessVarSet();
        ProcessPointSum();

        MyPoint0.GetComponent<Text>().text = MyPointString[0];
        MyPoint1.GetComponent<Text>().text = MyPointString[1];
        MyPoint2.GetComponent<Text>().text = MyPointString[2];
        MyPoint3.GetComponent<Text>().text = MyPointString[3];
        MyPoint4.GetComponent<Text>().text = MyPointString[4];
        MyPoint5.GetComponent<Text>().text = MyPointString[5];
        MyPoint6.GetComponent<Text>().text = MyPointString[6];
        MyPoint7.GetComponent<Text>().text = MyPointString[7];
        MyPoint8.GetComponent<Text>().text = MyPointString[8];
        MyPoint9.GetComponent<Text>().text = MyPointString[9];
        MyPoint10.GetComponent<Text>().text = MyPointString[10];
        MyPointHand.GetComponent<Text>().text = MyPointString[11];

        EnemyPoint0.GetComponent<Text>().text = EnemyPointString[0];
        EnemyPoint1.GetComponent<Text>().text = EnemyPointString[1];
        EnemyPoint2.GetComponent<Text>().text = EnemyPointString[2];
        EnemyPoint3.GetComponent<Text>().text = EnemyPointString[3];
        EnemyPoint4.GetComponent<Text>().text = EnemyPointString[4];
        EnemyPoint5.GetComponent<Text>().text = EnemyPointString[5];
        EnemyPoint6.GetComponent<Text>().text = EnemyPointString[6];
        EnemyPoint7.GetComponent<Text>().text = EnemyPointString[7];
        EnemyPoint8.GetComponent<Text>().text = EnemyPointString[8];
        EnemyPoint9.GetComponent<Text>().text = EnemyPointString[9];
        EnemyPoint10.GetComponent<Text>().text = EnemyPointString[10];
        EnemyPointHand.GetComponent<Text>().text = EnemyPointString[11];

        MyTotalPointText.text = MyTotalPoint.ToString() + "P";
        EnemyTotalPointText.text = EnemyTotalPoint.ToString() + "P";

        if (MyTotalPoint > EnemyTotalPoint)
        {
            MyWin.SetActive(true);
            EnemyLose.SetActive(true);
        }
        if (MyTotalPoint == EnemyTotalPoint)
        {
            MyDraw.SetActive(true);
            EnemyDraw.SetActive(true);
        }
        if (MyTotalPoint < EnemyTotalPoint)
        {
            MyLose.SetActive(true);
            EnemyWin.SetActive(true);
        }

    }

    void Start()
    {
        MyWin.SetActive(false);
        MyDraw.SetActive(false);
        MyLose.SetActive(false);

        EnemyWin.SetActive(false);
        EnemyDraw.SetActive(false);
        EnemyLose.SetActive(false);
    }

    [SerializeField] GameObject Field0 ,Field1 ,Field2 ,Field3 ,Field4 ,Field5 ,
                                Field6 ,Field7 ,Field8 ,Field9 ,Field10 ,HandField;

    GameObject MyPoint0 ,MyPoint1 ,MyPoint2 ,MyPoint3 ,MyPoint4 ,MyPoint5 ,
               MyPoint6 ,MyPoint7 ,MyPoint8 ,MyPoint9 ,MyPoint10 ,MyPointHand;
    GameObject EnemyPoint0 ,EnemyPoint1 ,EnemyPoint2 ,EnemyPoint3 ,EnemyPoint4 ,EnemyPoint5 ,
               EnemyPoint6 ,EnemyPoint7 ,EnemyPoint8 ,EnemyPoint9 ,EnemyPoint10 ,EnemyPointHand;

    public void TotalVarSet()
    {
        MyPoint0 = Field0.transform.Find("TotalMyPoint").gameObject;
        MyPoint1 = Field1.transform.Find("TotalMyPoint").gameObject;
        MyPoint2 = Field2.transform.Find("TotalMyPoint").gameObject;
        MyPoint3 = Field3.transform.Find("TotalMyPoint").gameObject;
        MyPoint4 = Field4.transform.Find("TotalMyPoint").gameObject;
        MyPoint5 = Field5.transform.Find("TotalMyPoint").gameObject;
        MyPoint6 = Field6.transform.Find("TotalMyPoint").gameObject;
        MyPoint7 = Field7.transform.Find("TotalMyPoint").gameObject;
        MyPoint8 = Field8.transform.Find("TotalMyPoint").gameObject;
        MyPoint9 = Field9.transform.Find("TotalMyPoint").gameObject;
        MyPoint10 = Field10.transform.Find("TotalMyPoint").gameObject;
        MyPointHand = HandField.transform.Find("TotalMyPoint").gameObject;

        EnemyPoint0 = Field0.transform.Find("TotalEnemyPoint").gameObject;
        EnemyPoint1 = Field1.transform.Find("TotalEnemyPoint").gameObject;
        EnemyPoint2 = Field2.transform.Find("TotalEnemyPoint").gameObject;
        EnemyPoint3 = Field3.transform.Find("TotalEnemyPoint").gameObject;
        EnemyPoint4 = Field4.transform.Find("TotalEnemyPoint").gameObject;
        EnemyPoint5 = Field5.transform.Find("TotalEnemyPoint").gameObject;
        EnemyPoint6 = Field6.transform.Find("TotalEnemyPoint").gameObject;
        EnemyPoint7 = Field7.transform.Find("TotalEnemyPoint").gameObject;
        EnemyPoint8 = Field8.transform.Find("TotalEnemyPoint").gameObject;
        EnemyPoint9 = Field9.transform.Find("TotalEnemyPoint").gameObject;
        EnemyPoint10 = Field10.transform.Find("TotalEnemyPoint").gameObject;
        EnemyPointHand = HandField.transform.Find("TotalEnemyPoint").gameObject;
    }

    [SerializeField] Transform PointBox0 ,PointBox1 ,PointBox2 ,PointBox3 ,PointBox4 ,PointBox5 ,
                               PointBox6 ,PointBox7 ,PointBox8 ,PointBox9 ,PointBox10;

    [SerializeField] Text MyHandText ,EnemyHandText;

    string[] MyPointString = new string [12];
    
    string[] EnemyPointString = new string [12];

    public void ProcessVarSet()
    {
        MyPointString[0] = PointBox0.Find("MyPoint0").gameObject.GetComponent<Text>().text.ToString();
        MyPointString[1] = PointBox1.Find("MyPoint1").gameObject.GetComponent<Text>().text.ToString();
        MyPointString[2] = PointBox2.Find("MyPoint2").gameObject.GetComponent<Text>().text.ToString();
        MyPointString[3] = PointBox3.Find("MyPoint3").gameObject.GetComponent<Text>().text.ToString();
        MyPointString[4] = PointBox4.Find("MyPoint4").gameObject.GetComponent<Text>().text.ToString();
        MyPointString[5] = PointBox5.Find("MyPoint5").gameObject.GetComponent<Text>().text.ToString();
        MyPointString[6] = PointBox6.Find("MyPoint6").gameObject.GetComponent<Text>().text.ToString();
        MyPointString[7] = PointBox7.Find("MyPoint7").gameObject.GetComponent<Text>().text.ToString();
        MyPointString[8] = PointBox8.Find("MyPoint8").gameObject.GetComponent<Text>().text.ToString();
        MyPointString[9] = PointBox9.Find("MyPoint9").gameObject.GetComponent<Text>().text.ToString();
        MyPointString[10] = PointBox10.Find("MyPoint10").gameObject.GetComponent<Text>().text.ToString();
        MyPointString[11] = MyHandText.text.ToString() + "P";
        
        EnemyPointString[0] = PointBox0.Find("EnemyPoint0").gameObject.GetComponent<Text>().text.ToString();
        EnemyPointString[1] = PointBox1.Find("EnemyPoint1").gameObject.GetComponent<Text>().text.ToString();
        EnemyPointString[2] = PointBox2.Find("EnemyPoint2").gameObject.GetComponent<Text>().text.ToString();
        EnemyPointString[3] = PointBox3.Find("EnemyPoint3").gameObject.GetComponent<Text>().text.ToString();
        EnemyPointString[4] = PointBox4.Find("EnemyPoint4").gameObject.GetComponent<Text>().text.ToString();
        EnemyPointString[5] = PointBox5.Find("EnemyPoint5").gameObject.GetComponent<Text>().text.ToString();
        EnemyPointString[6] = PointBox6.Find("EnemyPoint6").gameObject.GetComponent<Text>().text.ToString();
        EnemyPointString[7] = PointBox7.Find("EnemyPoint7").gameObject.GetComponent<Text>().text.ToString();
        EnemyPointString[8] = PointBox8.Find("EnemyPoint8").gameObject.GetComponent<Text>().text.ToString();
        EnemyPointString[9] = PointBox9.Find("EnemyPoint9").gameObject.GetComponent<Text>().text.ToString();
        EnemyPointString[10] = PointBox10.Find("EnemyPoint10").gameObject.GetComponent<Text>().text.ToString();
        EnemyPointString[11] = EnemyHandText.text.ToString() + "P";
    }

    public void ProcessPointSum()
    {
        for (int i = 0; i < 12; i++)
        {
            if (MyPointString[i].Equals("") == false)
            {
                string MyPoint = MyPointString[i].TrimEnd('P');
                int MyTempInt = 0;
                int.TryParse(MyPoint, out MyTempInt);
                MyTotalPoint += MyTempInt;
            }
        }

        for (int i = 0; i < 12; i++)
        {
            if (EnemyPointString[i].Equals("") == false)
            {
                string EnemyPoint = EnemyPointString[i].TrimEnd('P');
                int EnemyTempInt = 0;
                int.TryParse(EnemyPoint, out EnemyTempInt);
                EnemyTotalPoint += EnemyTempInt;
            }
        }
    }
}

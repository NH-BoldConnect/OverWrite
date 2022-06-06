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

public class EraserAndDelete : StrixBehaviour
{
    GameObject SystemManager;
    GameObject TurnManager;

    [SerializeField] GameObject Priority0Field;
    [SerializeField] GameObject Priority1Field;
    [SerializeField] GameObject Priority2Field;
    [SerializeField] GameObject Priority3Field;
    [SerializeField] GameObject Priority4Field;
    [SerializeField] GameObject Priority5Field;
    [SerializeField] GameObject Priority6Field;
    [SerializeField] GameObject Priority7Field;
    [SerializeField] GameObject Priority8Field;
    [SerializeField] GameObject Priority9Field;
    [SerializeField] GameObject Priority10Field;
    [SerializeField] Transform HandField;

    [SerializeField] GameObject EraserCancelButton;
    [SerializeField] GameObject ToGraveCancelButton;
    [SerializeField] GameObject ReverseCancelButton;

    [SerializeField] GameObject MyMarker0;
    [SerializeField] GameObject MyMarker1;
    [SerializeField] GameObject MyMarker2;
    [SerializeField] GameObject MyMarker3;
    [SerializeField] GameObject MyMarker4;
    [SerializeField] GameObject MyMarker5;
    [SerializeField] GameObject MyMarker6;
    [SerializeField] GameObject MyMarker7;
    [SerializeField] GameObject MyMarker8;
    [SerializeField] GameObject MyMarker9;
    [SerializeField] GameObject MyMarker10;

    public bool Effect93ToGraveBoot;

    void Start()
    {
        SystemManager = GameObject.Find("SystemManager");
        TurnManager = GameObject.Find("TurnMamager");
    }

    public void EraserBoot(int _Priority)
    {
        EraserCancelButton.SetActive(true);
        if (Priority0Field.transform.childCount != 0 & _Priority != 0)
        {
            foreach (Transform Child in Priority0Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority1Field.transform.childCount != 0 & _Priority != 1)
        {
            foreach (Transform Child in Priority1Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority2Field.transform.childCount != 0 & _Priority != 2)
        {
            foreach (Transform Child in Priority2Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority3Field.transform.childCount != 0 & _Priority != 3)
        {
            foreach (Transform Child in Priority3Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority4Field.transform.childCount != 0 & _Priority != 4)
        {
            foreach (Transform Child in Priority4Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority5Field.transform.childCount != 0 & _Priority != 5)
        {
            foreach (Transform Child in Priority5Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority6Field.transform.childCount != 0 & _Priority != 6)
        {
            foreach (Transform Child in Priority6Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority7Field.transform.childCount != 0 & _Priority != 7)
        {
            foreach (Transform Child in Priority7Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority8Field.transform.childCount != 0 & _Priority != 8)
        {
            foreach (Transform Child in Priority8Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority9Field.transform.childCount != 0 & _Priority != 9)
        {
            foreach (Transform Child in Priority9Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority10Field.transform.childCount != 0 & _Priority != 10)
        {
            foreach (Transform Child in Priority10Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser10".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
    }

    public void EraserCancel()
    {
        TurnManager.GetComponent<TurnController>().EndPhaseEffect2 = false;
        EraserCancelButton.SetActive(false);
        if (Priority0Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority0Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority1Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority1Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority2Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority2Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority3Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority3Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority4Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority4Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority5Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority5Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority6Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority6Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority7Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority7Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority8Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority8Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority9Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority9Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority10Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority10Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("EffectEraser10".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
    }

    public void EraserCatcher(int _Priority)
    {
        EraserAction(_Priority);
        RpcToOtherMembers("EraserAction", _Priority);
        EraserCancel();
    }

    [StrixRpc] 
    public void EraserAction(int _Priority)
    {
        switch (_Priority)
        {
            case 0:
                Priority0Field.GetComponent<Priority0Effect>().EffectActive = false;
                break;
            case 1:
                Priority1Field.GetComponent<Priority1Effect>().EffectActive = false;
                break;
            case 2:
                Priority2Field.GetComponent<Priority2Effect>().EffectActive = false;
                break;
            case 3:
                Priority3Field.GetComponent<Priority3Effect>().EffectActive = false;
                break;
            case 4:
                Priority4Field.GetComponent<Priority4Effect>().EffectActive = false;
                break;
            case 5:
                Priority5Field.GetComponent<Priority5Effect>().EffectActive = false;
                break;
            case 6:
                Priority6Field.GetComponent<Priority6Effect>().EffectActive = false;
                break;
            case 7:
                Priority7Field.GetComponent<Priority7Effect>().EffectActive = false;
                break;
            case 8:
                Priority8Field.GetComponent<Priority8Effect>().EffectActive = false;
                break;
            case 9:
                Priority9Field.GetComponent<Priority9Effect>().EffectActive = false;
                break;
            case 10:
                Priority10Field.GetComponent<Priority10Effect>().EffectActive = false;
                break;
        }
    }

    /////////////////////////////////////////////////////

    public void ToGraveBoot(int _Priority)
    {
        ToGraveCancelButton.SetActive(true);
        if (HandField.childCount != 0)
        {
            foreach (Transform Child in HandField)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                Child.gameObject.GetComponent<CardMovement>().enabled = false;
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                    }
                }
            }
        }
        if (Priority0Field.transform.childCount != 0 && MyMarker0.activeSelf == true & _Priority != 0)
        {
            Priority0Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority0Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority1Field.transform.childCount != 0 && MyMarker1.activeSelf == true & _Priority != 1)
        {
            Priority1Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority1Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority2Field.transform.childCount != 0 && MyMarker2.activeSelf == true & _Priority != 2)
        {
            Priority2Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority2Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority3Field.transform.childCount != 0 && MyMarker3.activeSelf == true & _Priority != 3)
        {
            Priority3Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority3Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority4Field.transform.childCount != 0 && MyMarker4.activeSelf == true & _Priority != 4)
        {
            Priority4Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority4Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority5Field.transform.childCount != 0 && MyMarker5.activeSelf == true & _Priority != 5)
        {
            Priority5Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority5Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority6Field.transform.childCount != 0 && MyMarker6.activeSelf == true & _Priority != 6)
        {
            Priority6Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority6Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority7Field.transform.childCount != 0 && MyMarker7.activeSelf == true & _Priority != 7)
        {
            Priority7Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority7Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority8Field.transform.childCount != 0 && MyMarker8.activeSelf == true & _Priority != 8)
        {
            Priority8Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority8Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority9Field.transform.childCount != 0 && MyMarker9.activeSelf == true & _Priority != 9)
        {
            Priority9Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority9Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority10Field.transform.childCount != 0 && MyMarker10.activeSelf == true & _Priority != 10)
        {
            foreach (Transform Child in Priority10Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave10".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
    }

    public void ToGraveCancel()
    {
        ToGraveCancelButton.SetActive(false);
        if (HandField.childCount != 0)
        {
            foreach (Transform Child in HandField)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                Child.gameObject.GetComponent<CardMovement>().enabled = true;
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority0Field.transform.childCount != 0)
        {
            Priority0Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority0Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority1Field.transform.childCount != 0)
        {
            Priority1Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority1Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority2Field.transform.childCount != 0)
        {
            Priority2Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority2Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority3Field.transform.childCount != 0)
        {
            Priority3Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority3Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority4Field.transform.childCount != 0)
        {
            Priority4Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority4Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority5Field.transform.childCount != 0)
        {
            Priority5Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority5Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority6Field.transform.childCount != 0)
        {
            Priority6Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority6Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority7Field.transform.childCount != 0)
        {
            Priority7Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority7Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority8Field.transform.childCount != 0)
        {
            Priority8Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority8Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority9Field.transform.childCount != 0)
        {
            Priority9Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority9Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        if (Priority10Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority10Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave10".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
    }

    public void ToGraveHandOnlyBoot(bool _CanCancel) // 2022/04/08更新
    {
        if (_CanCancel == true)
        {
            ToGraveCancelButton.SetActive(true);
        }
        if (HandField.childCount != 0)
        {
            foreach (Transform Child in HandField)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                Child.gameObject.GetComponent<CardMovement>().enabled = false;
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    public void ToGraveFieldOnlyBoot(int _Priority) // 2022/04/08更新
    {
        if (Priority0Field.transform.childCount != 0 && MyMarker0.activeSelf == true & _Priority != 0)
        {
            Priority0Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority0Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority1Field.transform.childCount != 0 && MyMarker1.activeSelf == true & _Priority != 1)
        {
            Priority1Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority1Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority2Field.transform.childCount != 0 && MyMarker2.activeSelf == true & _Priority != 2)
        {
            Priority2Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority2Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority3Field.transform.childCount != 0 && MyMarker3.activeSelf == true & _Priority != 3)
        {
            Priority3Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority3Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority4Field.transform.childCount != 0 && MyMarker4.activeSelf == true & _Priority != 4)
        {
            Priority4Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority4Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority5Field.transform.childCount != 0 && MyMarker5.activeSelf == true & _Priority != 5)
        {
            Priority5Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority5Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority6Field.transform.childCount != 0 && MyMarker6.activeSelf == true & _Priority != 6)
        {
            Priority6Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority6Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority7Field.transform.childCount != 0 && MyMarker7.activeSelf == true & _Priority != 7)
        {
            Priority7Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority7Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority8Field.transform.childCount != 0 && MyMarker8.activeSelf == true & _Priority != 8)
        {
            Priority8Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority8Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority9Field.transform.childCount != 0 && MyMarker9.activeSelf == true & _Priority != 9)
        {
            Priority9Field.GetComponent<DropPlace>().OnDropActive = true;
            foreach (Transform Child in Priority9Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority10Field.transform.childCount != 0 && MyMarker10.activeSelf == true & _Priority != 10)
        {
            foreach (Transform Child in Priority10Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToGrave10".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
    }

    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform GraveContent;

    public void ToGraveCatcher(string _CardID)
    {
        CardController card = Instantiate(cardPrefab, GraveContent);
        card.Init(_CardID);
        RpcToOtherMembers("GraveCardCopy", _CardID);
        CardID93ToGraveCheck();
    }

    [StrixRpc]
    public void GraveCardCopy(string _CardID)
    {
        CardController card = Instantiate(cardPrefab, GraveContent);
        card.Init(_CardID);
    }

    /* -1 = 手札
    0 = Field:0
    1 = Field:1
    2 = Field:2
    3 = Field:3
    4 = Field:4
    5 = Field:5
    6 = Field:6
    7 = Field:7
    8 = Field:8
    9 = Field:9
    10 = Field:10 */

    public void DeleteSurroundCleanup(int _DeletePlaceNumber)
    {
        RpcToOtherMembers("TargetFieldCleanup", _DeletePlaceNumber);
        SystemManager.GetComponent<MarkerController>().MarkerClear(_DeletePlaceNumber);
        switch (_DeletePlaceNumber)
        {
            case 0:
                Priority0Field.GetComponent<Priority0Effect>().SetCardData("", 0);
                Debug.Log("0が無効化し墓地へ送られました");
                break;
            case 1:
                Priority1Field.GetComponent<Priority1Effect>().SetCardData("", 0);
                break;
            case 2:
                Priority2Field.GetComponent<Priority2Effect>().SetCardData("", 0);
                break;
            case 3:
                Priority3Field.GetComponent<Priority3Effect>().SetCardData("", 0);
                break;
            case 4:
                Priority4Field.GetComponent<Priority4Effect>().SetCardData("", 0);
                break;
            case 5:
                Priority5Field.GetComponent<Priority5Effect>().SetCardData("", 0);
                break;
            case 6:
                Priority6Field.GetComponent<Priority6Effect>().SetCardData("", 0);
                break;
            case 7:
                Priority7Field.GetComponent<Priority7Effect>().SetCardData("", 0);
                break;
            case 8:
                Priority8Field.GetComponent<Priority8Effect>().SetCardData("", 0);
                break;
            case 9:
                Priority9Field.GetComponent<Priority9Effect>().SetCardData("", 0);
                break;
            case 10:
                Priority10Field.GetComponent<Priority10Effect>().SetCardData("", 0);
                break;
        }
    }

    [StrixRpc]
    public void TargetFieldCleanup(int _DeletePlaceNumber)
    {
        DeleteSurroundCleanup(_DeletePlaceNumber);
        switch (_DeletePlaceNumber)
        {
            case 0:
                foreach (Transform Card in Priority0Field.transform)
                {
                    Destroy(Card.gameObject);
                }
                break;
            case 1:
                foreach (Transform Card in Priority1Field.transform)
                {
                    Destroy(Card.gameObject);
                }
                break;
            case 2:
                foreach (Transform Card in Priority2Field.transform)
                {
                    Destroy(Card.gameObject);
                }
                break;
            case 3:
                foreach (Transform Card in Priority3Field.transform)
                {
                    Destroy(Card.gameObject);
                }
                break;
            case 4:
                foreach (Transform Card in Priority4Field.transform)
                {
                    Destroy(Card.gameObject);
                }
                break;
            case 5:
                foreach (Transform Card in Priority5Field.transform)
                {
                    Destroy(Card.gameObject);
                }
                break;
            case 6:
                foreach (Transform Card in Priority6Field.transform)
                {
                    Destroy(Card.gameObject);
                }
                break;
            case 7:
                foreach (Transform Card in Priority7Field.transform)
                {
                    Destroy(Card.gameObject);
                }
                break;
            case 8:
                foreach (Transform Card in Priority8Field.transform)
                {
                    Destroy(Card.gameObject);
                }
                break;
            case 9:
                foreach (Transform Card in Priority9Field.transform)
                {
                    Destroy(Card.gameObject);
                }
                break;
            case 10:
                foreach (Transform Card in Priority10Field.transform)
                {
                    Destroy(Card.gameObject);
                }
                break;
        }
    }

    ///////////////////////////////////////////////////////////////

    //5-3以外に使用する際は注意
    public void GraveToHandBoot()
    {
        
        this.gameObject.GetComponent<GraveSystem>().Onclick_GraveOpenButton();
        if (GraveContent.childCount != 0)
        {
            foreach (Transform Child in GraveContent)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("ToHand".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    public void GraveToHandCancel()
    {
        this.gameObject.GetComponent<GraveSystem>().OnClick_GraveCloseButton();
        if (GraveContent.childCount != 0)
        {
            foreach (Transform Child in GraveContent)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                Child.gameObject.GetComponent<CardMovement>().enabled = true;
                foreach (Transform GChild in Child)
                {
                    if ("ToHand".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        TurnManager.GetComponent<TurnController>().EndPhaseEffect = false;
    }

    public void ToHandCatcher(string _CardID)
    {
        CardController card = Instantiate(cardPrefab, HandField);
        card.Init(_CardID);
        RpcToOtherMembers("GraveDeleteSync", _CardID);
    }

    [StrixRpc]
    public void GraveDeleteSync(string _CardID)
    {
        foreach (Transform Card in GraveContent)
        {
            string CardID = Card.gameObject.GetComponent<CardView>()._CardID;
            if (_CardID.Equals(CardID))
            {
                Destroy(Card.gameObject);
            }
        }
    }

    ///////////////////////////////////////////////////////////////

    public void ReverseBoot(int _Priority)
    {
        ReverseCancelButton.SetActive(true);
        if (Priority0Field.transform.childCount != 0 & _Priority != 0)
        {
            foreach (Transform Child in Priority0Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority1Field.transform.childCount != 0 & _Priority != 1)
        {
            foreach (Transform Child in Priority1Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority2Field.transform.childCount != 0 & _Priority != 2)
        {
            foreach (Transform Child in Priority2Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority3Field.transform.childCount != 0 & _Priority != 3)
        {
            foreach (Transform Child in Priority3Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority4Field.transform.childCount != 0 & _Priority != 4)
        {
            foreach (Transform Child in Priority4Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority5Field.transform.childCount != 0 & _Priority != 5)
        {
            foreach (Transform Child in Priority5Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority6Field.transform.childCount != 0 & _Priority != 6)
        {
            foreach (Transform Child in Priority6Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority7Field.transform.childCount != 0 & _Priority != 7)
        {
            foreach (Transform Child in Priority7Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority8Field.transform.childCount != 0 & _Priority != 8)
        {
            foreach (Transform Child in Priority8Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority9Field.transform.childCount != 0 & _Priority != 9)
        {
            foreach (Transform Child in Priority9Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (Priority10Field.transform.childCount != 0 & _Priority != 10)
        {
            foreach (Transform Child in Priority10Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse10".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
    }

    public void ReverseCancel()
    {
        ReverseCancelButton.SetActive(false);
        if (Priority0Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority0Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority1Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority1Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority2Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority2Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority3Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority3Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority4Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority4Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority5Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority5Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority6Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority6Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority7Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority7Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority8Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority8Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority9Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority9Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority10Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority10Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("Reverse10".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    public void ReverseCatcher(int _Priority)
    {
        ReverseAction(_Priority);
        RpcToOtherMembers("ReverseAction", _Priority);
        ReverseCancel();
    }

    [StrixRpc]
    public void ReverseAction(int _Priority)
    {
        switch (_Priority)
        {
            case 0:
                ReverseViewSync(Priority0Field);
                Priority0Field.GetComponent<Priority0Effect>().EffectActive = false;
                Priority0Field.GetComponent<Priority0Effect>().OverWriteBan = true;
                break;
            case 1:
                ReverseViewSync(Priority1Field);
                Priority1Field.GetComponent<Priority1Effect>().EffectActive = false;
                Priority1Field.GetComponent<Priority1Effect>().OverWriteBan = true;
                break;
            case 2:
                ReverseViewSync(Priority2Field);
                Priority2Field.GetComponent<Priority2Effect>().EffectActive = false;
                Priority2Field.GetComponent<Priority2Effect>().OverWriteBan = true;
                break;
            case 3:
                ReverseViewSync(Priority3Field);
                Priority3Field.GetComponent<Priority3Effect>().EffectActive = false;
                Priority3Field.GetComponent<Priority3Effect>().OverWriteBan = true;
                break;
            case 4:
                ReverseViewSync(Priority4Field);
                Priority4Field.GetComponent<Priority4Effect>().EffectActive = false;
                Priority4Field.GetComponent<Priority4Effect>().OverWriteBan = true;
                break;
            case 5:
                ReverseViewSync(Priority5Field);
                Priority5Field.GetComponent<Priority5Effect>().EffectActive = false;
                Priority5Field.GetComponent<Priority5Effect>().OverWriteBan = true;
                break;
            case 6:
                ReverseViewSync(Priority6Field);
                Priority6Field.GetComponent<Priority6Effect>().EffectActive = false;
                Priority6Field.GetComponent<Priority6Effect>().OverWriteBan = true;
                break;
            case 7:
                ReverseViewSync(Priority7Field);
                Priority7Field.GetComponent<Priority7Effect>().EffectActive = false;
                Priority7Field.GetComponent<Priority7Effect>().OverWriteBan = true;
                break;
            case 8:
                ReverseViewSync(Priority8Field);
                Priority8Field.GetComponent<Priority8Effect>().EffectActive = false;
                Priority8Field.GetComponent<Priority8Effect>().OverWriteBan = true;
                break;
            case 9:
                ReverseViewSync(Priority9Field);
                Priority9Field.GetComponent<Priority9Effect>().EffectActive = false;
                Priority9Field.GetComponent<Priority9Effect>().OverWriteBan = true;
                break;
            case 10:
                ReverseViewSync(Priority10Field);
                Priority10Field.GetComponent<Priority10Effect>().EffectActive = false;
                Priority10Field.GetComponent<Priority10Effect>().OverWriteBan = true;
                break;
        }
    }

    public void ReverseViewSync(GameObject _Field)
    {
        foreach (Transform Card in _Field.transform)
        {
            Card.gameObject.GetComponent<CardView>().ReverseView();
        }
    }

    /////////////////////////////////////

    public void UnReverseBoot()
    {
        Debug.Log("裏返し取り消しが起動しました");
        ReverseCancelButton.SetActive(true);
        if (Priority0Field.transform.childCount != 0)
        {
            Debug.Log("フィールドにカードがあります");
           foreach (Transform Child in Priority0Field.transform)
            {
               bool Reverse = Child.gameObject.GetComponent<CardView>()._Reverse;
               if (Reverse == true)
                {
                    Debug.Log("裏返しのカードがあります");
                    Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                    foreach (Transform GChild in Child)
                        {
                            if ("UnReverse".Equals(GChild.gameObject.name))
                            {
                                Debug.Log("裏返しを取り消すボタンが見つかりました");
                                GChild.gameObject.SetActive(true);
                                break;
                            }
                        }
                }
            }
        }
        if (Priority1Field.transform.childCount != 0)
        {
           foreach (Transform Child in Priority1Field.transform)
           {
               bool Reverse = Child.gameObject.GetComponent<CardView>()._Reverse;
               if (Reverse == true)
               {
                   Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                   foreach (Transform GChild in Child)
                    {
                        if ("UnReverse".Equals(GChild.gameObject.name))
                        {
                            GChild.gameObject.SetActive(true);
                            break;
                        }
                    }
               }
           } 
        }
        if (Priority2Field.transform.childCount != 0)
        {
           foreach (Transform Child in Priority2Field.transform)
           {
               bool Reverse = Child.gameObject.GetComponent<CardView>()._Reverse;
               if (Reverse == true)
               {
                   Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                   foreach (Transform GChild in Child)
                    {
                        if ("UnReverse".Equals(GChild.gameObject.name))
                        {
                            GChild.gameObject.SetActive(true);
                            break;
                        }
                    }
               }
           } 
        }
        if (Priority3Field.transform.childCount != 0)
        {
           foreach (Transform Child in Priority3Field.transform)
           {
               bool Reverse = Child.gameObject.GetComponent<CardView>()._Reverse;
               if (Reverse == true)
               {
                   Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                   foreach (Transform GChild in Child)
                    {
                        if ("UnReverse".Equals(GChild.gameObject.name))
                        {
                            GChild.gameObject.SetActive(true);
                            break;
                        }
                    }
               }
           } 
        }
        if (Priority4Field.transform.childCount != 0)
        {
           foreach (Transform Child in Priority4Field.transform)
           {
               bool Reverse = Child.gameObject.GetComponent<CardView>()._Reverse;
               if (Reverse == true)
               {
                   Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                   foreach (Transform GChild in Child)
                    {
                        if ("UnReverse".Equals(GChild.gameObject.name))
                        {
                            GChild.gameObject.SetActive(true);
                            break;
                        }
                    }
               }
           } 
        }
        if (Priority5Field.transform.childCount != 0)
        {
           foreach (Transform Child in Priority5Field.transform)
           {
               bool Reverse = Child.gameObject.GetComponent<CardView>()._Reverse;
               if (Reverse == true)
               {
                   Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                   foreach (Transform GChild in Child)
                    {
                        if ("UnReverse".Equals(GChild.gameObject.name))
                        {
                            GChild.gameObject.SetActive(true);
                            break;
                        }
                    }
               }
           } 
        }
        if (Priority6Field.transform.childCount != 0)
        {
           foreach (Transform Child in Priority6Field.transform)
           {
               bool Reverse = Child.gameObject.GetComponent<CardView>()._Reverse;
               if (Reverse == true)
               {
                   Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                   foreach (Transform GChild in Child)
                    {
                        if ("UnReverse".Equals(GChild.gameObject.name))
                        {
                            GChild.gameObject.SetActive(true);
                            break;
                        }
                    }
               }
           } 
        }
        if (Priority7Field.transform.childCount != 0)
        {
           foreach (Transform Child in Priority7Field.transform)
           {
               bool Reverse = Child.gameObject.GetComponent<CardView>()._Reverse;
               if (Reverse == true)
               {
                   Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                   foreach (Transform GChild in Child)
                    {
                        if ("UnReverse".Equals(GChild.gameObject.name))
                        {
                            GChild.gameObject.SetActive(true);
                            break;
                        }
                    }
               }
           } 
        }
        if (Priority8Field.transform.childCount != 0)
        {
           foreach (Transform Child in Priority8Field.transform)
           {
               bool Reverse = Child.gameObject.GetComponent<CardView>()._Reverse;
               if (Reverse == true)
               {
                   Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                   foreach (Transform GChild in Child)
                    {
                        if ("UnReverse".Equals(GChild.gameObject.name))
                        {
                            GChild.gameObject.SetActive(true);
                            break;
                        }
                    }
               }
           } 
        }
        if (Priority9Field.transform.childCount != 0)
        {
           foreach (Transform Child in Priority9Field.transform)
           {
               bool Reverse = Child.gameObject.GetComponent<CardView>()._Reverse;
               if (Reverse == true)
               {
                   Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                   foreach (Transform GChild in Child)
                    {
                        if ("UnReverse".Equals(GChild.gameObject.name))
                        {
                            GChild.gameObject.SetActive(true);
                            break;
                        }
                    }
               }
           } 
        }
        if (Priority10Field.transform.childCount != 0)
        {
           foreach (Transform Child in Priority10Field.transform)
           {
               bool Reverse = Child.gameObject.GetComponent<CardView>()._Reverse;
               if (Reverse == true)
               {
                   Child.gameObject.GetComponent<CardView>().ZoomSenderMove();
                   foreach (Transform GChild in Child)
                    {
                        if ("UnReverse10".Equals(GChild.gameObject.name))
                        {
                            GChild.gameObject.SetActive(true);
                            break;
                        }
                    }
               }
           } 
        }
    }

    public void UnReverseCancel()
    {
        ReverseCancelButton.SetActive(false);
        if (Priority0Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority0Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("UnReverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority1Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority1Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("UnReverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority2Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority2Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("UnReverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority3Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority3Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("UnReverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority4Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority4Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("UnReverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority5Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority5Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("UnReverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority6Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority6Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("UnReverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority7Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority7Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("UnReverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority8Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority8Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("UnReverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority9Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority9Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("UnReverse".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        if (Priority10Field.transform.childCount != 0)
        {
            foreach (Transform Child in Priority10Field.transform)
            {
                Child.gameObject.GetComponent<CardView>().ZoomSenderComeback();
                foreach (Transform GChild in Child)
                {
                    if ("UnReverse10".Equals(GChild.gameObject.name))
                    {
                        GChild.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    public void UnReverseCatcher(int _Priority)
    {
        UnReverseAction(_Priority);
        RpcToOtherMembers("UnReverseAction", _Priority);
        UnReverseCancel();
    }

    [StrixRpc]
    public void UnReverseAction(int _Priority)
    {
        switch (_Priority)
        {
            case 0:
                UnReverseViewSync(Priority0Field);
                Priority0Field.GetComponent<Priority0Effect>().EffectActive = true;
                Priority0Field.GetComponent<Priority0Effect>().OverWriteBan = false;
                break;
            case 1:
                UnReverseViewSync(Priority1Field);
                Priority1Field.GetComponent<Priority1Effect>().EffectActive = true;
                Priority1Field.GetComponent<Priority1Effect>().OverWriteBan = false;
                break;
            case 2:
                UnReverseViewSync(Priority2Field);
                Priority2Field.GetComponent<Priority2Effect>().EffectActive = true;
                Priority2Field.GetComponent<Priority2Effect>().OverWriteBan = false;
                break;
            case 3:
                UnReverseViewSync(Priority3Field);
                Priority3Field.GetComponent<Priority3Effect>().EffectActive = true;
                Priority3Field.GetComponent<Priority3Effect>().OverWriteBan = false;
                break;
            case 4:
                UnReverseViewSync(Priority4Field);
                Priority4Field.GetComponent<Priority4Effect>().EffectActive = true;
                Priority4Field.GetComponent<Priority4Effect>().OverWriteBan = false;
                break;
            case 5:
                UnReverseViewSync(Priority5Field);
                Priority5Field.GetComponent<Priority5Effect>().EffectActive = true;
                Priority5Field.GetComponent<Priority5Effect>().OverWriteBan = false;
                break;
            case 6:
                UnReverseViewSync(Priority6Field);
                Priority6Field.GetComponent<Priority6Effect>().EffectActive = true;
                Priority6Field.GetComponent<Priority6Effect>().OverWriteBan = false;
                break;
            case 7:
                UnReverseViewSync(Priority7Field);
                Priority7Field.GetComponent<Priority7Effect>().EffectActive = true;
                Priority7Field.GetComponent<Priority7Effect>().OverWriteBan = false;
                break;
            case 8:
                UnReverseViewSync(Priority8Field);
                Priority8Field.GetComponent<Priority8Effect>().EffectActive = true;
                Priority8Field.GetComponent<Priority8Effect>().OverWriteBan = false;
                break;
            case 9:
                UnReverseViewSync(Priority9Field);
                Priority9Field.GetComponent<Priority9Effect>().EffectActive = true;
                Priority9Field.GetComponent<Priority9Effect>().OverWriteBan = false;
                break;
            case 10:
                UnReverseViewSync(Priority10Field);
                Priority10Field.GetComponent<Priority10Effect>().EffectActive = true;
                Priority10Field.GetComponent<Priority10Effect>().OverWriteBan = false;
                break;
        }
    }

    public void UnReverseViewSync(GameObject _Field)
    {
        foreach (Transform Card in _Field.transform)
        {
            Card.gameObject.GetComponent<CardView>().UnReverseView();
        }
    }

    ////////////////////////////////////////////

    public void CardID33Exception()
    {
        if (MyMarker3.activeSelf == true && Priority3Field.transform.childCount != 0)
        {
            foreach (Transform Card in Priority3Field.transform)
            {
                string cardID = Card.gameObject.GetComponent<CardView>()._CardID;
                if (cardID.Equals("3-3") == true)
                {
                    Card.gameObject.GetComponent<CardView>().ZoomSenderMove();
                    foreach (Transform GChild in Card)
                    {
                        if ("ToGrave".Equals(GChild.gameObject.name))
                        {
                            GChild.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }

    //////////////////////////////////////////////////

    public void CardID93ToGraveCheck()
    {
        if (Effect93ToGraveBoot == true)
        {
            Priority9Field.GetComponent<Priority9Effect>().Card93To10FieldEffect();
            Effect93ToGraveBoot = false;
        }
    }

    /////////////////////////////////////////////////////
}
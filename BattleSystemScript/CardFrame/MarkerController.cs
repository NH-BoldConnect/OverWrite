using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerController : MonoBehaviour
{
    [SerializeField] GameObject My0;
    [SerializeField] GameObject Enemy0;
    
    [SerializeField] GameObject My1;
    [SerializeField] GameObject Enemy1;
    
    [SerializeField] GameObject My2;
    [SerializeField] GameObject Enemy2;
    
    [SerializeField] GameObject My3;
    [SerializeField] GameObject Enemy3;
    
    [SerializeField] GameObject My4;
    [SerializeField] GameObject Enemy4;
    
    [SerializeField] GameObject My5;
    [SerializeField] GameObject Enemy5;
    
    [SerializeField] GameObject My6;
    [SerializeField] GameObject Enemy6;
    
    [SerializeField] GameObject My7;
    [SerializeField] GameObject Enemy7;
    
    [SerializeField] GameObject My8;
    [SerializeField] GameObject Enemy8;
    
    [SerializeField] GameObject My9;
    [SerializeField] GameObject Enemy9;
    
    [SerializeField] GameObject My10;
    [SerializeField] GameObject Enemy10;

    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform HandField;
    public InputField CardIDInputField;
    public void AimCreateCard()
    {
        CardController card = Instantiate(cardPrefab, HandField);
        card.Init(CardIDInputField.text);
    }

    bool EnterPressed = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && EnterPressed == false)
        {
            AimCreateCard();
            EnterPressed = true;
            StartCoroutine("KeyWait");
        }
    }

    IEnumerator KeyWait()
    {
        yield return new WaitForSeconds(0.2f);
        EnterPressed = false;
    }

    public void MarkerSwitch(int _FieldNum ,bool _isMyCard)
    {
        switch (_FieldNum)
        {
            case 0:
                if (_isMyCard == true)
                {
                    My0.SetActive(true);
                    Enemy0.SetActive(false);
                }
                if (_isMyCard == false)
                {
                    My0.SetActive(false);
                    Enemy0.SetActive(true);
                }

                break;
            
            case 1:
                if (_isMyCard == true)
                {
                    My1.SetActive(true);
                    Enemy1.SetActive(false);
                }
                if (_isMyCard == false)
                {
                    My1.SetActive(false);
                    Enemy1.SetActive(true);
                }
                break;
            
            case 2:
                if (_isMyCard == true)
                {
                    My2.SetActive(true);
                    Enemy2.SetActive(false);
                }
                if (_isMyCard == false)
                {
                    My2.SetActive(false);
                    Enemy2.SetActive(true);
                }
                break;
            
            case 3:
                if (_isMyCard == true)
                {
                    My3.SetActive(true);
                    Enemy3.SetActive(false);
                }
                if (_isMyCard == false)
                {
                    My3.SetActive(false);
                    Enemy3.SetActive(true);
                }
                break;
            
            case 4:
                if (_isMyCard == true)
                {
                    My4.SetActive(true);
                    Enemy4.SetActive(false);
                }
                if (_isMyCard == false)
                {
                    My4.SetActive(false);
                    Enemy4.SetActive(true);
                }
                break;
            
            case 5:
                if (_isMyCard == true)
                {
                    My5.SetActive(true);
                    Enemy5.SetActive(false);
                }
                if (_isMyCard == false)
                {
                    My5.SetActive(false);
                    Enemy5.SetActive(true);
                }
                break;
            
            case 6:
                if (_isMyCard == true)
                {
                    My6.SetActive(true);
                    Enemy6.SetActive(false);
                }
                if (_isMyCard == false)
                {
                    My6.SetActive(false);
                    Enemy6.SetActive(true);
                }
                break;
            
            case 7:
                if (_isMyCard == true)
                {
                    My7.SetActive(true);
                    Enemy7.SetActive(false);
                }
                if (_isMyCard == false)
                {
                    My7.SetActive(false);
                    Enemy7.SetActive(true);
                }
                break;
            
            case 8:
                if (_isMyCard == true)
                {
                    My8.SetActive(true);
                    Enemy8.SetActive(false);
                }
                if (_isMyCard == false)
                {
                    My8.SetActive(false);
                    Enemy8.SetActive(true);
                }
                break;
            
            case 9:
                if (_isMyCard == true)
                {
                    My9.SetActive(true);
                    Enemy9.SetActive(false);
                }
                if (_isMyCard == false)
                {
                    My9.SetActive(false);
                    Enemy9.SetActive(true);
                }
                break;
            
            case 10:
                if (_isMyCard == true)
                {
                    My10.SetActive(true);
                    Enemy10.SetActive(false);
                }
                if (_isMyCard == false)
                {
                    My10.SetActive(false);
                    Enemy10.SetActive(true);
                }
                break;
        }
    }

    public void MarkerClear(int _FieldNum)
    {
        switch (_FieldNum)
        {
            case 0:
                My0.SetActive(false);
                Enemy0.SetActive(false);
                break;
            case 1:
                My1.SetActive(false);
                Enemy1.SetActive(false);
                break;
            case 2:
                My2.SetActive(false);
                Enemy2.SetActive(false);
                break;
            case 3:
                My3.SetActive(false);
                Enemy3.SetActive(false);
                break;
            case 4:
                My4.SetActive(false);
                Enemy4.SetActive(false);
                break;
            case 5:
                My5.SetActive(false);
                Enemy5.SetActive(false);
                break;
            case 6:
                My6.SetActive(false);
                Enemy6.SetActive(false);
                break;
            case 7:
                My7.SetActive(false);
                Enemy7.SetActive(false);
                break;
            case 8:
                My8.SetActive(false);
                Enemy8.SetActive(false);
                break;
            case 9:
                My9.SetActive(false);
                Enemy9.SetActive(false);
                break;
            case 10:
                My10.SetActive(false);
                Enemy10.SetActive(false);
                break;
            default:
                break;
        }
    }
}

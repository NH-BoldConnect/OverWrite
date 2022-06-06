using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveSystem : MonoBehaviour
{
    [SerializeField] GameObject GraveField;
    [SerializeField] GameObject GraveOpenButton;
    [SerializeField] GameObject GraveCloseButton;

    public void Onclick_GraveOpenButton()
    {
        GraveField.SetActive(true);
        GraveOpenButton.SetActive(false);
        GraveCloseButton.SetActive(true);
    }
    public void OnClick_GraveCloseButton()
    {
        GraveField.SetActive(false);
        GraveOpenButton.SetActive(true);
        GraveCloseButton.SetActive(false);
    }
    [SerializeField] Transform GraveContent;
    void Update()
    {
        foreach (Transform childTransform in GraveContent)
        {
            childTransform.gameObject.GetComponent<CardMovement>().enabled = false;
            childTransform.gameObject.GetComponent<CardOverWriteEvent>().enabled = false;
        }
    }
}

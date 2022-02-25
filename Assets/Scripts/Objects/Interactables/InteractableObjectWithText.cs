using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableObjectWithText : MonoBehaviour
{
    [SerializeField] private GameObject popupText;

    private void Start()
    {
        popupText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        popupText.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        popupText.gameObject.SetActive(false);
    }
}

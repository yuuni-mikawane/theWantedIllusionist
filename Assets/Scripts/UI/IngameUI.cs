using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IngameUI : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private TextMeshProUGUI deathCount;
    [SerializeField] private TextMeshProUGUI manaOrbCount;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        //HP
        for (int i = 0; i < hearts.Length; i++)
        {
            if (gameManager.PlayerHP - 1 >= i)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
        //deathcount
        deathCount.text = gameManager.Deaths + " deaths";

        //manaOrbCount
        manaOrbCount.text = gameManager.FocalLevel - 1 + "/5";
    }
}
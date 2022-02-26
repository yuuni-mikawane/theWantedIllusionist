using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneController : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI manaOrbCount;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI deathCount;

    void Start()
    {
        gameManager = GameManager.Instance;

        UI.SetActive(false);
        manaOrbCount.text = gameManager.FocalLevel - 1 + "/5";
        //time.text = gameManager.
        deathCount.text = "Deaths: " + gameManager.Deaths;
    }
}

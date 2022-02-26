using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI manaOrbCount;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI deathCount;
    [SerializeField] private GameObject loadScreen;

    void Start()
    {
        gameManager = GameManager.Instance;

        UI.SetActive(false);
        manaOrbCount.text = gameManager.FocalLevel - 1 + "/5";
        time.text = gameManager.GetTimeOfRun();
        deathCount.text = "Deaths: " + gameManager.Deaths;
    }

    public void ToMainMenu()
    {
        loadScreen.SetActive(true);
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}

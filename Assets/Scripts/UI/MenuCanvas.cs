using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject loadScreen;
    [SerializeField] private GameObject creditScreen;
    [SerializeField] private Scrollbar scroll;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void StartGame()
    {
        loadScreen.SetActive(true);
        StartCoroutine(LoadAsyncScene());
        gameManager.StartRunTimer();
    }

    public void Credits(bool state)
    {
        creditScreen.SetActive(state);
        if (state)
        {
            scroll.value = 1f;
        }
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}

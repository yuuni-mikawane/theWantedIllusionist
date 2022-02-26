using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject loadScreen;
    [SerializeField] private Texture2D cursor;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void StartGame()
    {
        loadScreen.SetActive(true);
        StartCoroutine(LoadAsyncScene());
        Cursor.SetCursor(cursor, Vector2.one * cursor.width/2, CursorMode.ForceSoftware);
        gameManager.StartRunTimer();
    }

    public void Credits()
    {

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

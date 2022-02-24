using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private GameObject[] cutsceneElements;
    [SerializeField] private GameObject clickToContinueText;
    private int currentElement = 0;
    private GameManager gameManager;
    [SerializeField] private bool hasFadeIn = false;
    [SerializeField] private float fadeInOutDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        background.gameObject.SetActive(true);
        foreach(GameObject cutsceneElement in cutsceneElements)
        {
            cutsceneElement.SetActive(false);
        }
        cutsceneElements[0].SetActive(true);

        gameManager = GameManager.Instance;
        gameManager.gameState = GameState.Cutscene;
        if (hasFadeIn)
        {
            //set background to transparent
            background.color = new Color(background.color.r, background.color.g, background.color.b, 0f);
            //start fade in
            background.DOFade(1, fadeInOutDuration);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            End();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Space))
        {
            Continue();
        }
    }

    private void Continue()
    {
        cutsceneElements[currentElement].SetActive(false);
        currentElement++;
        if (currentElement >= cutsceneElements.Length)
            End();
        else
            cutsceneElements[currentElement].SetActive(true);
    }

    private void End()
    {
        foreach(GameObject cutsceneElement in cutsceneElements)
        {
            cutsceneElement.SetActive(false);
        }
        background.DOFade(0, fadeInOutDuration);
        gameManager.gameState = GameState.Playing;
        clickToContinueText.SetActive(false);
        this.enabled = false;
    }
}
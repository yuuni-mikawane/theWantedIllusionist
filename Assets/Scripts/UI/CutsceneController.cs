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
    public float fadeInOutDuration = 1f;
    private bool canContinue = false;

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
            background.DOFade(1, fadeInOutDuration).OnComplete(() => {
                canContinue = true;
            });
        }
        else
        {
            canContinue = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canContinue && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Space)))
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
        background.DOFade(0, fadeInOutDuration).OnComplete(() => {
            gameObject.SetActive(false);
        });
        gameManager.gameState = GameState.Playing;
        clickToContinueText.SetActive(false);
        enabled = false;
    }
}

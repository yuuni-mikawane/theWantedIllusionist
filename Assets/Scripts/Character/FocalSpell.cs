using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FocalSpell : MonoBehaviour
{
    private Vector2 cursorPos;
    private GameManager gameManager;
    private bool activated = false;
    private float scaleSinceLastLevelUp;
    [SerializeField] private float scalingDuration = 0.5f;

    private void Start()
    {
        transform.localScale = Vector3.zero;
        gameManager = GameManager.Instance;
    }

    private void LateUpdate()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //update new scale after level up if there is any
        if (gameManager.CurrentFocalSize() != scaleSinceLastLevelUp && activated)
        {
            scaleSinceLastLevelUp = gameManager.CurrentFocalSize();
            TurnOn();
        }
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }

    public void TurnOff()
    {
        float duration = scalingDuration * transform.localScale.x / gameManager.CurrentFocalSize();
        if (duration == 0)
            duration = scalingDuration;
        transform.DOKill();
        transform.DOScale(0, duration);
        activated = false;
        Cursor.visible = true;
    }
    public void TurnOn()
    {
        float duration = scalingDuration * (1 - transform.localScale.x / gameManager.CurrentFocalSize());
        if (duration == 0)
            duration = scalingDuration;
        transform.DOKill();
        transform.DOScale(gameManager.CurrentFocalSize(), duration);
        activated = true;
        Cursor.visible = false;
    }

    public void ToggleFocalSpell()
    {
        if (!activated)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }
}
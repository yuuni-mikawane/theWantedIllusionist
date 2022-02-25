using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using GameCommon;

public class FocalSpell : SingletonBind<FocalSpell>
{
    private Vector2 cursorPos;
    private GameManager gameManager;
    private bool activated = false;
    private float scaleSinceLastLevelUp;
    [SerializeField] private float scalingDuration = 0.5f;
    private PlayerStats player;
    [SerializeField] private float maxReach;
    private Vector2 clampedPos;
    private Vector2 playerPos;

    private void Start()
    {
        transform.localScale = Vector3.zero;
        gameManager = GameManager.Instance;
        player = PlayerStats.Instance;
    }

    private void LateUpdate()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos = (Vector2)player.transform.position;

        //update new scale after level up if there is any
        if (gameManager.CurrentFocalSize() != scaleSinceLastLevelUp && activated)
        {
            scaleSinceLastLevelUp = gameManager.CurrentFocalSize();
            TurnOn();
        }

        clampedPos = cursorPos;

        if (maxReach !=0 && Vector2.Distance(cursorPos, player.transform.position) > maxReach)
        {
            clampedPos = (cursorPos - playerPos).normalized * maxReach + playerPos;
        }

        transform.position = clampedPos;
    }

    public void TurnOff()
    {
        float duration = scalingDuration * transform.localScale.x / gameManager.CurrentFocalSize();
        if (duration == 0)
            duration = scalingDuration;
        transform.DOKill();
        transform.DOScale(0, duration);
        activated = false;
    }
    public void TurnOn()
    {
        float duration = scalingDuration * (1 - transform.localScale.x / gameManager.CurrentFocalSize());
        if (duration == 0)
            duration = scalingDuration;
        transform.DOKill();
        transform.DOScale(gameManager.CurrentFocalSize(), duration);
        activated = true;
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
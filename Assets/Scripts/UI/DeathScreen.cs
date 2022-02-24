using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    private Image screen;
    [SerializeField] private float deathRespawnDuration = 0.2f;
    private GameManager gameManager;

    private void Start()
    {
        screen = GetComponent<Image>();
        gameManager = GameManager.Instance;
    }

    public void FadeIn()
    {
        screen.DOKill();
        gameManager.gameState = GameState.Respawning;
        screen.DOFade(1f, deathRespawnDuration).OnComplete(() => {
            gameManager.gameState = GameState.Respawned;
        });
    }

    public void FadeOut()
    {
        screen.DOKill();
        screen.DOFade(0f, deathRespawnDuration).OnComplete(() => {
            gameManager.gameState = GameState.Playing;
        });
    }
}

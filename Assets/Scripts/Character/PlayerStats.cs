using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCommon;
using System;

public class PlayerStats : SingletonBind<PlayerStats>
{
    [SerializeField] private int hp;
    [SerializeField] private int maxHp = 3;
    [SerializeField] private float invincibilityTime = 1f;
    [SerializeField] private float currentInvincibilityTime;
    [SerializeField] private bool isInvincible = false;

    [SerializeField] private SpriteRenderer playerRenderer;
    [SerializeField] private Material normalMat;
    [SerializeField] private Material whiteFlashMat;
    [SerializeField] private bool isDead = false;
    [SerializeField] private DeathScreen deathScreen;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        gameManager = GameManager.Instance;
        gameManager.PlayerHP = hp;
    }

    private void Update()
    {
        if (isInvincible)
        {
            currentInvincibilityTime += Time.deltaTime;
            if (currentInvincibilityTime > invincibilityTime)
            {
                isInvincible = false;
                currentInvincibilityTime = 0;
            }

            playerRenderer.material = whiteFlashMat;
        }
        else
        {
            playerRenderer.material = normalMat;
        }

        if (isDead)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        if (gameManager.gameState == GameState.Respawned)
        {
            isDead = false;
            ResetStats();
            gameObject.transform.position = gameManager.currentCheckpoint.transform.position;
            deathScreen.FadeOut();
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible && hp > 0)
        {
            hp -= damage;
            gameManager.PlayerHP = hp;
            StartInvincibility();
        }
        if (hp <= 0)
            Die();
    }

    private void StartInvincibility()
    {
        currentInvincibilityTime = 0;
        isInvincible = true;
    }

    public void ResetStats()
    {
        hp = maxHp;
        gameManager.PlayerHP = hp;
    }

    public void HardResetStats()
    {
        maxHp = 3;
        hp = maxHp;
        gameManager.PlayerHP = hp;
    }

    private void Die()
    {
        //die
        if (!isDead)
        {
            isDead = true;
            gameManager.IncreaseDeathCount();
            deathScreen.FadeIn();
        }
    }
}

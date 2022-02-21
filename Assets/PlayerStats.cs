using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int maxHp = 3;
    [SerializeField] private float invincibilityTime = 1f;
    [SerializeField] private float currentInvincibilityTime;
    [SerializeField] private bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
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
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible && hp > 0)
        {
            hp -= damage;
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
    }

    public void HardResetStats()
    {
        maxHp = 3;
        hp = maxHp;
    }

    private void Die()
    {
        //die
    }
}

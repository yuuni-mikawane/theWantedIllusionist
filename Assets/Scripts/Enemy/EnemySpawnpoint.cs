using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCommon;

public class EnemySpawnpoint : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject thisEnemy;

    void Awake()
    {
        thisEnemy = enemyPrefab.Spawn();
    }

    public void Deactivate()
    {
        thisEnemy.Recycle();
        gameObject.SetActive(false);
    }
}
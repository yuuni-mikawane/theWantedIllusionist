using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCommon;

public class EnemySpawnpoint : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject thisEnemy;
    private GameManager gameManager;
    private bool allowedToSpawn;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void Activate()
    {
        if (gameManager.gameState == GameState.Respawned)
        {
            if (allowedToSpawn)
                SpawnEnemy();
            allowedToSpawn = false;
        }
        else
        {
            allowedToSpawn = true;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (thisEnemy != null)
            thisEnemy.Recycle();
        thisEnemy = enemyPrefab.Spawn(transform.position, transform.rotation);
    }

    public void Deactivate()
    {
        if (thisEnemy != null)
            thisEnemy.Recycle();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}
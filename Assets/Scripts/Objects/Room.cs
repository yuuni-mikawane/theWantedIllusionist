using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject virtualCam;
    [SerializeField] private EnemySpawnpoint[] enemies;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)LayerInGame.Player)
        {
            virtualCam.SetActive(true);
            foreach(EnemySpawnpoint enemy in enemies)
            {
                enemy.Activate();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)LayerInGame.Player)
        {
            if (gameManager.gameState == GameState.Respawned)
            {
                foreach (EnemySpawnpoint enemy in enemies)
                {
                    enemy.Activate();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)LayerInGame.Player)
        {
            virtualCam.SetActive(false);
            foreach (EnemySpawnpoint enemy in enemies)
            {
                enemy.Deactivate();
            }
        }
    }
}

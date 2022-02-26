using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaOrb : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;

    [SerializeField] private int levelValue = 1;

    private void Start()
    {
        gameManager = GameManager.Instance;
        audioManager = AudioManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager != null && collision.gameObject.layer == (int)LayerInGame.Player)
        {
            gameManager.LevelUpFocal(levelValue);
            audioManager.OrbSFX();
            gameObject.SetActive(false);
        }
    }
}

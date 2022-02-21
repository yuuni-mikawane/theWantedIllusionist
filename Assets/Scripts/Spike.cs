using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private PlayerStats player;
    [SerializeField] private int damage = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == ((int)LayerInGame.Player))
        {
            player = collision.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(damage);
        }
    }
}

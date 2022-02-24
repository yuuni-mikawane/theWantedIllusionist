using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCommon;

public class Bullet : CanTakeDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float duration = 10f;
    private PlayerStats player;

    void Start()
    {
        player = PlayerStats.Instance;
        Vector2 vel = (player.transform.position - transform.position).normalized * speed;
        GetComponent<Rigidbody2D>().velocity = vel;
        StartCoroutine(Expire());
    }

    private IEnumerator Expire()
    {
        yield return new WaitForSeconds(duration);
        gameObject.Recycle();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            player.TakeDamage(hp);
            TakeDamage(hp);
        }
        if (collision.gameObject.layer == (int)LayerInGame.Environment)
            gameObject.Recycle();
    }
}
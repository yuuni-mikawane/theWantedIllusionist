using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCommon;

public class Enemy : CanTakeDamage
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float minFirerate = 1f;
    [SerializeField] private float maxFirerate = 2f;
    [SerializeField] private float actualFirerate;
    [SerializeField] private Transform shootingPos;

    private void Start()
    {
        actualFirerate = Random.Range(minFirerate, maxFirerate);
        StartCoroutine(ShootPeriodically());
    }

    private IEnumerator ShootPeriodically()
    {
        yield return new WaitForSeconds(actualFirerate);
        bulletPrefab.Spawn(shootingPos.position, Quaternion.identity);
        StartCoroutine(ShootPeriodically());
    }
}

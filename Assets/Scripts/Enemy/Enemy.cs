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
    [SerializeField] private GameObject explosionFX;
    private List<GameObject> bulletsShot = new List<GameObject>();
    private float lastShotTime;

    private void Start()
    {
        actualFirerate = Random.Range(minFirerate, maxFirerate);
    }

    void Update()
    {
        //shoot
        if (lastShotTime + actualFirerate < Time.time)
        {
            lastShotTime = Time.time;
            GameObject newBullet = bulletPrefab.Spawn(shootingPos.position, Quaternion.identity);
            bulletsShot.Add(newBullet);
        }
    }

    private void OnDisable()
    {
        if (bulletsShot.Count != 0 && hp != 0)
        {
            foreach(GameObject bullet in bulletsShot)
            {
                if (bullet != null)
                    bullet.Recycle();
            }
        }

        if (hp == 0)
        {
            explosionFX.Spawn(transform.position);
        }
    }
}

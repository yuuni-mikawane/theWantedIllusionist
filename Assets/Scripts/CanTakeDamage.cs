using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCommon;

public class CanTakeDamage : MonoBehaviour
{
    public int hp;

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            gameObject.Recycle();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCommon;

public class RecycleTimer : MonoBehaviour
{
    public float duration;

    private void Awake()
    {
        StartCoroutine(RecycleAfter());
    }

    private IEnumerator RecycleAfter()
    {
        yield return new WaitForSeconds(duration);
        gameObject.Recycle();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spin : MonoBehaviour
{
    [SerializeField] private Vector3 rot = Vector3.forward * 90;

    void Start()
    {
        transform.DORotate(rot, 1f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}

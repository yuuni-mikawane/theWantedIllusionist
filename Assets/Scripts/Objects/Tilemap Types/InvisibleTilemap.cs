using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InvisibleTilemap : MonoBehaviour
{
    void Awake()
    {
        TilemapRenderer tilemapRenderer = GetComponent<TilemapRenderer>();
        if (tilemapRenderer != null)
        {
            tilemapRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
    }
}

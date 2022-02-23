using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }
}

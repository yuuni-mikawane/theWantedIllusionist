using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocalSpell : MonoBehaviour
{
    Vector2 cursorPos;

    private void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }
}
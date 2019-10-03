using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guidance : MonoBehaviour
{
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Texture2D CursorPointer;
    public void OnMouseOver()
    {
        if (CursorClick.cursorTexture == false) Cursor.SetCursor(CursorPointer, Vector2.zero, cursorMode);
    }
    public void OnMouseExit()
    {
        if (CursorClick.cursorTexture == false) Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorClick : MonoBehaviour
{
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public CabelButton cabelButton;
    public static bool cursorTexture;

    void Update(){
	    if (Input.GetMouseButton(1) && cursorTexture == true){
	        Cursor.SetCursor(null, Vector2.zero, cursorMode);
	        cursorTexture = false;
	        CabelButton.freeCableEnds[CabelButton.currentEnd] = false;
	    }
    }
   	
}

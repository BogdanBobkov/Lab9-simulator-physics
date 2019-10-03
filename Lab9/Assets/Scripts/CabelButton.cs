using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabelButton : MonoBehaviour
{
    public Sprite[] cableEnds;
    public GameObject[] cables = new GameObject[6];
    public Texture2D[] TextureCableEnds;
    public Texture2D CursorPointer;
    public static bool[] freeCableEnds = new bool[12];
    public static float[,] coordinateHoles = new float[2,12];
    public Sprite TakeButtonOff, TakeButtonOn;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public static int currentEnd;
    void OnMouseDown()
    {
        if(GetComponent<SpriteRenderer>().sprite == TakeButtonOn){
		    transform.localScale = new Vector3(1.5f, 1.1f, 1);
		    if(CursorClick.cursorTexture == false){
                CursorClick.cursorTexture = true;
		        for(int i=0;i<12;i++){
			        if(freeCableEnds[i] == false){
				        Cursor.SetCursor(TextureCableEnds[i], hotSpot, cursorMode);
				        freeCableEnds[i] = true;
				        currentEnd = i;
				        break;
				    }
			        if(i==11 && freeCableEnds[i] == true) GetComponent<SpriteRenderer>().sprite = TakeButtonOff;
		    	}
		    }
	    }
    }
    void Update(){
	    if(EnableButton.conditionButton == false){
	        for(int j=0;j<12;j++){
			    if(freeCableEnds[j] == false){
				    if(GetComponent<SpriteRenderer>().sprite == TakeButtonOff) GetComponent<SpriteRenderer>().sprite = TakeButtonOn;
				    break;
			    }
			    if(j==11 && freeCableEnds[j] == true) GetComponent<SpriteRenderer>().sprite = TakeButtonOff;
		    }
	    }
    }
    void OnMouseUp()
    {
        transform.localScale = new Vector3(1.412654f, 1f, 1);
    }
}

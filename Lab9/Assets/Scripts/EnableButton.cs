using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableButton : MonoBehaviour
{
    public Sprite lightred, lightblack, CabelButtonOff, CabelButtonOn;
    public GameObject lamp, CabelButton;
    public EngineScroll engineButton;
    public static bool conditionButton = false;

    void OnMouseDown()
    {
        transform.localScale = new Vector3(0.15f, 0.15f, 1);
	    if(conditionButton == false){
	    	lamp.GetComponent<SpriteRenderer>().sprite = lightred;
		    CabelButton.GetComponent<SpriteRenderer>().sprite = CabelButtonOff;
            conditionButton = true;
	    }
        else {
	    	lamp.GetComponent<SpriteRenderer>().sprite = lightblack;
	    	CabelButton.GetComponent<SpriteRenderer>().sprite = CabelButtonOn;
            conditionButton = false;
            engineButton.Amperemeter.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void OnMouseUp()
    {
        transform.localScale = new Vector3(0.1367766f, 0.1287964f, 1);
    }

}

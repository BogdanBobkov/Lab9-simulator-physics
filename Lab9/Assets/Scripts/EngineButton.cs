using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine.UI;
using UnityEngine;

public class EngineButton : MonoBehaviour
{
    public static float startValue, startAngleArrow = 0, currentAngleEngine = 0, currentAngleArrow = 0, currentCounter = 0, currentInteger = 0, currentFractional = 0;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public float [] rightLengths;
    public GameObject Amperemeter, textInteger, textFractional;
    public Texture2D CursorPointer;
    public SecondEnableButton secondEnableButton;

    void OnMouseDown(){
        startValue = Input.mousePosition.x;
    }

    void OnMouseDrag() {
        if (CursorClick.cursorTexture == false) Cursor.SetCursor(CursorPointer, Vector2.zero, cursorMode);
        if ((currentAngleArrow >= 57 && (startValue - Input.mousePosition.x) < 0 || currentAngleArrow <= -57 && (startValue - Input.mousePosition.x) > 0 || currentAngleArrow < 57 && currentAngleArrow > -57) && (currentCounter + (startValue - Input.mousePosition.x) / 3 < 0))
        {
            currentAngleEngine += startValue - Input.mousePosition.x;
            currentCounter += (startValue - Input.mousePosition.x) / 3;
            currentFractional += (startValue - Input.mousePosition.x) / 3;
            transform.rotation = Quaternion.Euler(0, 0, currentAngleEngine);
            startValue = Input.mousePosition.x;
        }
        if (secondEnableButton.conditionCables == true && EnableButton.conditionButton == true) {
            currentAngleArrow = startAngleArrow - currentCounter * 0.05f;
            Amperemeter.transform.rotation = Quaternion.Euler(0, 0, currentAngleArrow);
        }
        if (System.Math.Abs(System.Math.Round(currentFractional, 0)) >= 100)
        {
            ++currentInteger;
            currentFractional += 100;
        } else if (System.Math.Round(currentFractional, 0) > 0)
        {
            --currentInteger;
            currentFractional -= 100;
        }
        textFractional.GetComponent<Text>().text = "  "+System.Math.Abs(System.Math.Round(currentFractional, 0)).ToString();
        textInteger.GetComponent<Text>().text = currentInteger.ToString();
    }
    void OnMouseUp()
    {
        if (CursorClick.cursorTexture == false) Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class Hole : MonoBehaviour
{
    public Sprite spriteHole, cablesAreRight, cablesAreWrong;
    public SecondEnableButton secondEnableButton;
    public GameObject cable, cablesConditionInscription;  
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public CabelButton cabelButton;
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && EnableButton.conditionButton == false){
		    for(int i=0; i<12; i++)
			    if(cabelButton.cableEnds[i] == GetComponent<SpriteRenderer>().sprite){
                    CabelButton.freeCableEnds[i] = false;
				    if(i % 2 == 0 && CabelButton.freeCableEnds[i+1] == true || i % 2 == 1 && CabelButton.freeCableEnds[i-1])
				    Destroy(cabelButton.cables[i/2]);
			    }
		    GetComponent<SpriteRenderer>().sprite = spriteHole;
            if (secondEnableButton.checkCables() == true) cablesConditionInscription.GetComponent<SpriteRenderer>().sprite = cablesAreRight;
            else cablesConditionInscription.GetComponent<SpriteRenderer>().sprite = cablesAreWrong;
        }
        if (Input.GetMouseButtonDown(0) && EnableButton.conditionButton == false)
        {
            if (CursorClick.cursorTexture == true && GetComponent<SpriteRenderer>().sprite == spriteHole)
            {
                GetComponent<SpriteRenderer>().sprite = cabelButton.cableEnds[CabelButton.currentEnd];
                CabelButton.coordinateHoles[0, CabelButton.currentEnd] = transform.position.x;
                CabelButton.coordinateHoles[1, CabelButton.currentEnd] = transform.position.y;
                if ((CabelButton.currentEnd % 2 == 0 && CabelButton.freeCableEnds[CabelButton.currentEnd + 1] == false) || (CabelButton.currentEnd % 2 == 1 && CabelButton.freeCableEnds[CabelButton.currentEnd - 1] == false))
                {
                    if (CabelButton.currentEnd % 2 == 0)
                    {
                        ++CabelButton.currentEnd;
                        CabelButton.freeCableEnds[CabelButton.currentEnd] = true;
                        Cursor.SetCursor(cabelButton.TextureCableEnds[CabelButton.currentEnd], Vector2.zero, cursorMode);
                    }
                    else
                    {
                        --CabelButton.currentEnd;
                        CabelButton.freeCableEnds[CabelButton.currentEnd] = true;
                        Cursor.SetCursor(cabelButton.TextureCableEnds[CabelButton.currentEnd], Vector2.zero, cursorMode);
                    }
                    cablesConditionInscription.GetComponent<SpriteRenderer>().sprite = cablesAreWrong;
                }
                else
                {
                    CursorClick.cursorTexture = false;
                    Cursor.SetCursor(null, Vector2.zero, cursorMode);
                    if (CabelButton.currentEnd % 2 == 0)
                        setCable(ref CabelButton.coordinateHoles[0, CabelButton.currentEnd], ref CabelButton.coordinateHoles[1, CabelButton.currentEnd], ref CabelButton.coordinateHoles[0, CabelButton.currentEnd + 1], ref CabelButton.coordinateHoles[1, CabelButton.currentEnd + 1]);
                    else
                        setCable(ref CabelButton.coordinateHoles[0, CabelButton.currentEnd], ref CabelButton.coordinateHoles[1, CabelButton.currentEnd], ref CabelButton.coordinateHoles[0, CabelButton.currentEnd - 1], ref CabelButton.coordinateHoles[1, CabelButton.currentEnd - 1]);
                    if (secondEnableButton.checkCables() == true) cablesConditionInscription.GetComponent<SpriteRenderer>().sprite = cablesAreRight;
                    else cablesConditionInscription.GetComponent<SpriteRenderer>().sprite = cablesAreWrong;
                }
            }
        }
    }

    // Cable installation
    void setCable(ref float Cabel1x, ref float Cabel1y, ref float Cabel2x, ref float Cabel2y)
    {
        float coorX = (Cabel1x + Cabel2x) / 2;
        float coorY = (Cabel1y + Cabel2y) / 2;
        float angle = 0;
        if (Cabel1x > Cabel2x)
            if (Cabel1y > Cabel2y)
                angle = (float)(180 * System.Math.Atan(System.Math.Abs((Cabel1y - Cabel2y) / (Cabel1x - Cabel2x))) / 3.14);
            else angle = (float)(180 - 180 * System.Math.Atan(System.Math.Abs((Cabel1y - Cabel2y) / (Cabel1x - Cabel2x))) / 3.14);
        else if (Cabel1y < Cabel2y)
            angle = (float)(180 * System.Math.Atan(System.Math.Abs((Cabel1y - Cabel2y) / (Cabel1x - Cabel2x))) / 3.14);
        else angle = (float)(180 - 180 * System.Math.Atan(System.Math.Abs((Cabel1y - Cabel2y) / (Cabel1x - Cabel2x))) / 3.14);
        float sizeOfCable = (float)0.01439952694 * (float)System.Math.Sqrt(System.Math.Pow((Cabel1y - Cabel2y), 2) + System.Math.Pow((Cabel1x - Cabel2x), 2));
        cabelButton.cables[CabelButton.currentEnd / 2] = Instantiate(cable, new Vector3(coorX, coorY, -2), Quaternion.Euler(0, 0, angle));
        cabelButton.cables[CabelButton.currentEnd / 2].transform.localScale = new Vector3(sizeOfCable, (float)0.0974, 1);
    }

}

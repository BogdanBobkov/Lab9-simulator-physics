using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;

public class SecondEnableButton : MonoBehaviour
{
    public bool enable = false, conditionCables = false;
    public float startAngleArrow = 0;
    public Sprite SecondButtonOn, SecondButtonOff;
    public CabelButton cabelButton;
    public EngineButton engineButton;
    System.Random rnd = new System.Random();

    void OnMouseDown()
    {
        if (enable == false) {
            GetComponent<SpriteRenderer>().sprite = SecondButtonOn;
            enable = true;
            if (checkCables() == true && EnableButton.conditionButton == true)
            {
                startAngleArrow *= -(26.31f/5.2631f);
                EngineButton.startAngleArrow = startAngleArrow;
                engineButton.Amperemeter.transform.rotation = Quaternion.Euler(0, 0, startAngleArrow - EngineButton.currentCounter * 0.05f);
            }
        }
        else {
            GetComponent<SpriteRenderer>().sprite = SecondButtonOff;
            enable = false;
            conditionCables = false;
            engineButton.Amperemeter.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Function for checking the correct position of the cables
    public bool checkCables()
    {
        int sumCablesInstalled = 0;
        for (int i = 0; i < 12; i += 2)
        {
            if (CabelButton.freeCableEnds[i] == true && CabelButton.freeCableEnds[i + 1] == true)
                ++sumCablesInstalled;
            else if (CabelButton.freeCableEnds[i] == false && CabelButton.freeCableEnds[i + 1] == true || CabelButton.freeCableEnds[i] == true && CabelButton.freeCableEnds[i + 1] == false)
                return false;
        }
        if (sumCablesInstalled == 5) conditionCables = true;
        else return false;
        for (int i = 0; i < sumCablesInstalled; ++i)
            for (int j = 0; j < engineButton.rightLengths.Length; ++j)
            {
                if (cabelButton.cables[i].transform.localScale.x.ToString().Equals(engineButton.rightLengths[j].ToString()))
                {
                    switch (j)
                    {
                        case 0: // G1
                            startAngleArrow = (float)System.Math.Round(2.47f + (float)rnd.NextDouble() * 0.05f, 2);
                            break;
                        case 1: // G1 with R
                            startAngleArrow = (float)System.Math.Round(2.46f + (float)rnd.NextDouble() * 0.06f, 2);
                            break;
                        case 2: // G2
                            startAngleArrow = (float)System.Math.Round(1.66f + (float)rnd.NextDouble() * 0.03f, 2);
                            break;
                    }
                    break;
                }
                if (j == engineButton.rightLengths.Length - 1 && cabelButton.cables[i].transform.localScale.x != engineButton.rightLengths[j])
                    conditionCables = false;
            }
        return conditionCables;
    }
}

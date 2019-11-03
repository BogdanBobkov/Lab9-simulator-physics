using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;

public class SecondEnableButton : MonoBehaviour
{
    public bool conditionCables = false;
    public static bool enable = false;
    public float startAngleArrow = 0;
    public Sprite SecondButtonOn, SecondButtonOff;
    public CabelButton cabelButton;
    public EngineScroll engineButton;
    public GameObject slider;
    System.Random rnd = new System.Random();

    void OnMouseDown()
    {
        if (enable == false) {
            GetComponent<SpriteRenderer>().sprite = SecondButtonOn;
            enable = true;
            if (checkCables() == true && EnableButton.conditionButton == true)
            {
                startAngleArrow *= -5f;
                EngineScroll.currentAngleArrow = EngineScroll.startAngleArrow = startAngleArrow;
                engineButton.Amperemeter.transform.rotation = Quaternion.Euler(0, 0, EngineScroll.currentAngleArrow + EngineScroll.startValue);
            }
        }
        else {
            GetComponent<SpriteRenderer>().sprite = SecondButtonOff;
            enable = false;
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
        if (sumCablesInstalled == 5/* Only 5 cables must be installed */) conditionCables = true;
        else return false;
        for (int i = 0; i < sumCablesInstalled; ++i)
            for (int j = 0; j < engineButton.rightLengths.Length; ++j)
            {
                if (cabelButton.cables[i].transform.localScale.x.ToString().Equals(engineButton.rightLengths[j].ToString()))
                {
                    switch (j)
                    {
                        case 0: // G1
                            startAngleArrow = (float)System.Math.Round(2.47f + (float)rnd.NextDouble() * 1.1f, 2);
                            break;
                        case 1: // G1 with R
                            startAngleArrow = (float)System.Math.Round(2.46f + (float)rnd.NextDouble() * 1.0f, 2);
                            break;
                        case 2: // G2
                            startAngleArrow = (float)System.Math.Round(1.66f + (float)rnd.NextDouble() * 0.08f, 2);
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

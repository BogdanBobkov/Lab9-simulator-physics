using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineScroll : MonoBehaviour
{
    public static float currentAngleArrow = 0, startAngleArrow = 0, startValue = 0;
    public float currentFractional = 0, currentInteger = 0;
    public float []rightLengths;
    public GameObject Amperemeter, textInteger, textFractional;
    public Slider slider;
    void Update()
    {
        startValue = slider.value;
        currentAngleArrow = startAngleArrow + startValue;
        if (EnableButton.conditionButton == true && SecondEnableButton.enable == true)
            Amperemeter.transform.rotation = Quaternion.Euler(0, 0, currentAngleArrow);
        currentFractional = 19f * (slider.value) - 100*currentInteger;
        if(currentFractional >= 100)
        {
            currentInteger += 1;
            currentFractional -= 100;
        } else if(currentFractional < 0 && currentInteger > 0)
        {
            currentFractional += 100;
            currentInteger -= 1;
        }
        textFractional.GetComponent<Text>().text = " " + System.Math.Round(currentFractional, 0).ToString();
        textInteger.GetComponent<Text>().text = currentInteger.ToString();
    }
}

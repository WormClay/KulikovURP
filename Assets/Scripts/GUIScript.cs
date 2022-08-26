using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour
{
    [SerializeField] private Color myColor;
    //[SerializeField] [Range(0, 100)] private int myHelth;
    void OnGUI()
    {
        myColor = RGBASlider(new Rect(10, 10, 200, 20), myColor);

    }
    Color RGBASlider(Rect screenRect, Color rgba)
    {
        rgba.r = LabelSlider(screenRect, rgba.r, 0f, 1.0f, "Red");
        screenRect.y += 20;
        rgba.g = LabelSlider(screenRect, rgba.g, 0f, 1.0f, "Green");
        screenRect.y += 20;
        rgba.b = LabelSlider(screenRect, rgba.b, 0f, 1.0f, "Blue");
        screenRect.y += 20;
        rgba.a = LabelSlider(screenRect, rgba.a, 0f, 1.0f, "Alpha");
        //screenRect.y += 20;
        //GUI.Label(screenRect, $"Helth: {myHelth.ToString()}");
        return rgba;
    }
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += screenRect.width;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, sliderMinValue, sliderMaxValue);
        return sliderValue;
    }
}

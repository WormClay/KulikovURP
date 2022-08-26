using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] CharacterSettings settings;
    [SerializeField] [Range(0, 100)] private int myHelth;

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 100, 200, 20), $"Helth: {myHelth}");
    }

    void Start()
    {
        myHelth = settings.maxHelth;
    }
}

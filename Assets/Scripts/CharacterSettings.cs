using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "SO/Character", order = 51)]
public class CharacterSettings : ScriptableObject
{
    [Range(5, 100)] public int maxHelth;
    [Range(5, 20)] public float speed;
    public bool isEnemy = true;
}

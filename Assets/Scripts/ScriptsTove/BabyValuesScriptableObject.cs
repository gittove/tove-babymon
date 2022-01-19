using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Editable Baby Values SO", menuName = "ScriptableObjects/Baby")]
public class BabyValuesScriptableObject : ScriptableObject
{
    [Range (0f,240f)] [SerializeField] public float needTimer;
    [Range(0, 100)] [SerializeField] public float decreaseHPTimer;
    [Range(0, 5)] [SerializeField] public int maxHP;
    [Range(1f, 60f)] [SerializeField] public int decreaseHPValue;
}

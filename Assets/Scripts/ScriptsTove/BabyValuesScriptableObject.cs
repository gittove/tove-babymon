using UnityEngine;

[CreateAssetMenu(fileName = "new Editable Baby Values SO", menuName = "ScriptableObjects/Baby")]
public class BabyValuesScriptableObject : ScriptableObject
{
    // TODO: add headers and hover info
    [Header("Baby's internal timer until baby gets new need (in seconds):")]
    [Range (1f,240f)] [SerializeField] public float needTimer;
    [Header("Max happiness points:")]
    [Range(1, 100)] [SerializeField] public int maxHP;
    [Header("Multiplier for the decreasing happiness points.:")]
    [Tooltip("Multiplied by pointvalue. (multiplier * 1 per second)")][Range(0.01f, 1f)] [SerializeField] public float decreaseHPTimer;
    
    [Header("Internal values (hidden from player)")]
    [Header("Max hunger value:")]
    [Range(1, 100)] [SerializeField] public int maxHunger; 
    [Header("Max comfort value:")]
    [Range(1, 100)] [SerializeField] public int maxComfort;
    [Header("Max love value:")]
    [Range(1, 100)] [SerializeField] public int maxHygiene;
}

using UnityEngine;

[CreateAssetMenu(fileName = "new Editable Baby Values SO", menuName = "ScriptableObjects/Baby")]
public class BabyValuesScriptableObject : ScriptableObject
{
    [Header("Baby's internal timer until baby gets new need (in seconds):")]
    [Range (1f,240f)] [SerializeField] public float needTimer;
    [Header("Max happiness points:")]
    [Range(1, 100)] [SerializeField] public int maxHP;
    [Header("Multiplier for the decreasing happiness points.:")]
    [Tooltip("Multiplied by pointvalue. (multiplier * 1 per second)")][Range(0.01f, 1f)] [SerializeField] public float decreaseHPMultiplier;

    // TODO: make minimum and maximum values limit eachother
    [HeaderAttribute("Internal moodvalues (hidden from player):")] 
    
    [Tooltip("Minimum object moodvalue:")] [Range(1, 100)] [SerializeField] public int minObject;
    [Tooltip("Maximum object moodvalue:")] [Range(1, 100)] [SerializeField] 
    public int maxObject;
    [Tooltip("Minimum wellbeing  moodvalue:")] [Range(1, 100)] [SerializeField]
    public int minWellbeing;
    [Tooltip("Maximum wellbeing moodvalue:")] [Range(1, 100)] [SerializeField] 
    public int maxWellbeing;
    [Tooltip("Minimum love moodvalue:")] [Range(1, 100)] [SerializeField]
    public int minLove;
    [Tooltip("Maximum love moodvalue:")] [Range(1, 100)] [SerializeField] 
    public int maxLove;
    [Header("Internal mood decrease multiplier:")] [Range(0.1f, 1f)] [SerializeField] 
    public float decreaseStatsMultiplier;
}

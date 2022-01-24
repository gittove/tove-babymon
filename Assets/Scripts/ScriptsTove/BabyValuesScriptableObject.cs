using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "new Editable Baby Values SO", menuName = "ScriptableObjects/Baby")]
public class BabyValuesScriptableObject : ScriptableObject
{
    [Header("Max happiness points:")]
    [Range(1, 100)] [SerializeField] public int maxHP;
    [Header("Value for the decreasing happiness points.:")]
    [Tooltip("Subtracting this value per second)")][Range(0.01f, 1f)] [SerializeField] public float decreaseHpValue;

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

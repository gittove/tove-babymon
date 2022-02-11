using UnityEngine;

[CreateAssetMenu(fileName = "new Editable Baby Values SO", menuName = "ScriptableObjects/Baby")]
public class BabyValuesScriptableObject : ScriptableObject
{
    [Header("Max happiness points:")]
    [Range(1, 100)] [SerializeField] public int maxHP;
    [Header("Value for the decreasing happiness points:")]
    [Tooltip("Subtracting this value per second)")][Range(0.01f, 1f)] [SerializeField] 
    public float decreaseHpValue;

    [Header("Value for the increasing happiness points:")]
    [Tooltip("Increases once player has completed task")] [Range(1, 20)] [SerializeField] 
    public int increaseHpValue;

    [Header("Value for activating angry effect:")]
    [Tooltip("When a baby's happiness has reached this value, a sad mood-shader will appear around the baby.")] [Range(1, 50)] [SerializeField]
    public int sadHpValue;
    
    
    // TODO: make minimum and maximum values limit eachother
    [HeaderAttribute("Internal moodvalues (hidden from player):")] 
    
    [Tooltip("Minimum object moodvalue:")] [Range(1, 100)] [SerializeField] 
    public int minObject;
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

    [Header("Internal mood increase value:")]
    [Tooltip("Increases once player has completed task")] [Range(0, 20)] [SerializeField]
    public int increaseMoodValue;
}

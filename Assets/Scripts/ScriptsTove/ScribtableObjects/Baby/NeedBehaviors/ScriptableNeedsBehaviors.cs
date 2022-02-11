using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new List of States and Behaviors", menuName = "ScriptableObjects/State and Behavior overview", order = 0)]
public class ScriptableNeedsBehaviors : ScriptableObject
{
    [Header("Please make sure the behaviors come in the same order as the enums.")]
    [Header("Object behavior assets:")]
    public List<ScriptableObjectBehavior> objectBehaviors;
    [Header("Wellbeing behavior assets:")]
    public List<ScriptableWellbeingBehavior> wellbeingBehaviors;
    [Header("Love behavior assets:")]
    public List<ScriptableLoveBehavior> loveBehaviors;
    [Header("Idle behavior:")] 
    public ScriptableBehaviorBase idleBehavior;

    [Header("Need Enums (REMEMBER TO UPDATE ENUM CLASS BabyNeeds.cs)")] 
    public List<BabyNeeds> objectNeeds;
    public List<BabyNeeds> wellbeingNeeds;
    public List<BabyNeeds> loveNeeds;
}

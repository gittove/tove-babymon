using UnityEngine;

[CreateAssetMenu(fileName = "new Wellbeing Behavior", menuName = "ScriptableObjects/ScriptableNeeds/Wellbeing Behavior", order = 0)]
public class ScriptableWellbeingBehavior : ScriptableBehaviorBase
{
    [SerializeField] private int _animParValue;
    [SerializeField] private string _needID;
    [SerializeField] private Sprite _uiSprite;

    public override Sprite UiSprite 
    {
        get
        {
            return _uiSprite;
        }
    }

    public override string NeedID 
    {
        get
        {
            return _needID;
        }
    }
    public override int AnimParValue
    {
        get
        {
            return _animParValue;
        }
    }

    public override bool           IsPreference   { get; }
    public override PreferenceType PreferenceType { get; }
    public override Effect         ParticleEffect { get; }
}

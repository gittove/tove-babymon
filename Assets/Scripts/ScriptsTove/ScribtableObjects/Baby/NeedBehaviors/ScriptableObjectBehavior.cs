using UnityEngine;

[CreateAssetMenu(fileName = "new Object Behavior", menuName = "ScriptableObjects/ScriptableNeeds/Object Behavior", order = 0)]
public class ScriptableObjectBehavior : ScriptableBehaviorBase
{
    [SerializeField] private int _animParValue;
    [SerializeField] private string _needID;
    [SerializeField] private Sprite _uiSprite;
    [SerializeField] private bool _isPreference;
    [SerializeField] public PreferenceType _preferenceType;
    [SerializeField] public Effect _particleEffect;

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

    public override bool IsPreference
    {
        get
        {
            return _isPreference;
        }
    }

    public override PreferenceType PreferenceType
    {
        get
        {
            return _preferenceType;
        }
    }

    public override Effect ParticleEffect
    {
        get
        {
            return _particleEffect;
        }
    }
}

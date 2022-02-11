using UnityEngine;

public enum PreferenceType
{
    None,
    Food,
    Toy
}

public abstract class ScriptableBehaviorBase : ScriptableObject
{
    public abstract Sprite UiSprite { get; }
    
    public abstract string NeedID { get; }
    
    public abstract int AnimParValue { get; }

    public abstract bool IsPreference { get; }
    
    public abstract PreferenceType PreferenceType { get; }
    
    public abstract Effect ParticleEffect { get; }
}
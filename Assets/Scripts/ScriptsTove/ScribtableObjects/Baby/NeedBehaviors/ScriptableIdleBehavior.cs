using UnityEngine;

[CreateAssetMenu(fileName = "new Scriptable Behavior Base", menuName = "ScriptableObjects/ScriptableNeeds/Scriptable Base (Idle)")]
public class ScriptableIdleBehavior : ScriptableBehaviorBase
{
    public override Sprite UiSprite
    {
        get
        {
             return null;
        }
    }

    public override string         NeedID         { get; }
    public override int            AnimParValue   { get; }
    public override bool           IsPreference   { get; }
    public override PreferenceType PreferenceType { get; }
    public override Effect         ParticleEffect { get; }
}

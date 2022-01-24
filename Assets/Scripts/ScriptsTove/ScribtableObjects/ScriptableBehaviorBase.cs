using UnityEngine;

public abstract class ScriptableBehaviorBase : ScriptableObject
{
    public abstract void OnStart();

    public abstract void OnRepeat();

    public abstract void OnInteract(int actionID);

    public abstract void OnComplete();
}
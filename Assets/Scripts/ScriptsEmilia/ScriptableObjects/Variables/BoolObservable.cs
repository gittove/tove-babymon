using UnityEngine;

[CreateAssetMenu(fileName = "new Bool Observable", menuName = "ScriptableObjects/Variables/Bool Observable")]
public class BoolObservable : BoolVariable
{
    [SerializeField] 
    private ScriptableEvent<bool> onPauseChanged;
    
    public override void SetValue(bool newValue)
    {
        base.SetValue(newValue);
        onPauseChanged.RaiseEvent(newValue); //why new in asteroid
    }
}

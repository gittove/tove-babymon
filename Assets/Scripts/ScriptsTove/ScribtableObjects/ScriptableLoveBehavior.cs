using UnityEngine;

[CreateAssetMenu(fileName = "new Love Behavior", menuName = "ScriptableObjects/ScriptableNeeds/Love Behavior", order = 0)]
public class ScriptableLoveBehavior : ScriptableBehaviorBase
{
    // TODO insert serialized properties
    [SerializeField] private int _needID;

    [SerializeField] private Sprite _uiSprite;
    [SerializeField] private Animation _animation;
    [SerializeField] private ScriptableEvent _onCompleteEvent;
    
    public override void OnStart()
    {
        // TODO update ui sprite
        throw new System.NotImplementedException();
    }

    public override void OnRepeat()
    {
        // TODO run animation or particle effect
        throw new System.NotImplementedException();
    }

    public override void OnInteract(int actionID)
    {
        if (_needID == actionID)
        {
            OnComplete();
        }
    }

    public override void OnComplete()
    {
        _onCompleteEvent.RaiseEvent();
        
        // TODO on raised event, listener (state machine?) invokes event which updates the state
    }
}

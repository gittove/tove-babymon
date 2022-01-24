using UnityEngine;

public class BabyEventHandler : MonoBehaviour
{
    private BabyController _controller;
    private BabyStateMachine _stateMachine;
    
    private void Awake()
    {
        _controller = GetComponent<BabyController>();
        _stateMachine = new BabyStateMachine(_controller);
    }
    
    public void OnObjectMoodEvent()
    {
        _stateMachine.SetObject();
    }

    public void OnWellbeingMoodEvent()
    {
        _stateMachine.SetWellbeing();
    }

    public void OnLoveMoodEvent()
    {
        _stateMachine.SetLove();
    }

    public void OnObjectComplete()
    {
        _stateMachine.ReturnObjectState();
    }

    public void OnWellbeingComplete()
    {
        _stateMachine.ReturnWellbeingState();
    }

    public void OnLoveComplete()
    {
        _stateMachine.ReturnLoveState();
    }
}

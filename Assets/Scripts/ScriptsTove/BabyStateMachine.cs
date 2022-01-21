using System.Collections.Generic;

public class BabyStateMachine
{
    public BabyState currentState;

    private Stack<BabyState> _stateStack;
    private BabyController _babyController;

    public BabyStateMachine(BabyController controller)
    {
        _babyController = controller;
        _stateStack = new Stack<BabyState>();
        currentState = BabyState.Happy;
        _stateStack.Push(currentState);
    }

    public void SetNewState(BabyState newState)
    {
        PushState(currentState);
        currentState = newState;
    }
    
    public void ReturnToPreviousState()
    {
        currentState = _stateStack.Peek();
     // _babyController.CurrentBabyState = currentState; // property if controller needs to know state switch
    }

    public void TryPopStack()
    {
        if (_stateStack.Count > 1)
        {
            _stateStack.Pop();
        }
    }

    public void PushState(BabyState stateToStack)
    {
        if (stateToStack == _stateStack.Peek())
        {
            return;
        }

        _stateStack.Push(stateToStack);
    }
}
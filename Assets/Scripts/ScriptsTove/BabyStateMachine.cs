using System.Collections.Generic;

public class BabyStateMachine
{
    public BabyNeeds currentNeed;
    
    // TODO three different stacks
    private Stack<BabyNeeds> _needStack;
    private BabyController _babyController;
    private NeedGenerator _generator;

    public BabyStateMachine(BabyController controller)
    {
        _babyController = controller;
        
        _needStack = new Stack<BabyNeeds>();
        currentNeed = BabyNeeds.None;
        _needStack.Push(currentNeed);
        
        _generator = new NeedGenerator();
    }

    public void SetObject()
    {
        BabyNeeds item;
        item = _generator.GetObjectItem();
        SetNewState(item);
    }
    
    public void SetLove()
    {
        BabyNeeds item;
        item = _generator.GetLoveItem();
        SetNewState(item);
    }

    public void SetWellbeing()
    {
        BabyNeeds item;
        item = _generator.GetWellbeingItem();
        SetNewState(item);
    }
    
    public void SetNewState(BabyNeeds newNeed)
    {
        PushState(currentNeed);
        
        // this does not belong here: newNeed = _generator.GetItem();
        currentNeed = newNeed;
    }

    public void ReturnToPreviousState()
    { 
        _generator.ReturnItem(_needStack.Peek());
        TryPopStack();
        currentNeed = _needStack.Peek();
        // _babyController.CurrentBabyState = currentState; // property if controller needs to know state switch
    }

    public void TryPopStack()
    {
        if (_needStack.Count > 1)
        {
            _needStack.Pop();
        }
    }

    public void PushState(BabyNeeds needsToStack)
    {
        if (needsToStack == _needStack.Peek())
        {
            return;
        }

        _needStack.Push(needsToStack);
    }
}
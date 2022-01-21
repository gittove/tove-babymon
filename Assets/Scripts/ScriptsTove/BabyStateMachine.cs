using System.Collections.Generic;

public class BabyStateMachine
{
    public BabyNeeds currentNeed;
    
    private Stack<BabyNeeds> _objectStack;
    private Stack<BabyNeeds> _wellbeingStack;
    private Stack<BabyNeeds> _loveStack;
    private BabyController _babyController;
    private NeedGenerator _generator;

    public BabyStateMachine(BabyController controller)
    {
        // TODO evaluate if the controller is actually neccessary?
        _babyController = controller;

        _objectStack = new Stack<BabyNeeds>();
        _wellbeingStack = new Stack<BabyNeeds>();
        _loveStack = new Stack<BabyNeeds>();
        currentNeed = BabyNeeds.None;
        _loveStack.Push(currentNeed);
        
        _generator = new NeedGenerator();
    }

    public void SetObject()
    {
        BabyNeeds item;
        item = _generator.GetObjectItem();
        SetNewState(item, _objectStack);
    }
    
    public void SetLove()
    {
        BabyNeeds item;
        item = _generator.GetLoveItem();
        SetNewState(item, _loveStack);
    }

    public void SetWellbeing()
    {
        BabyNeeds item;
        item = _generator.GetWellbeingItem();
        SetNewState(item, _wellbeingStack);
    }
    
    public void SetNewState(BabyNeeds newNeed, Stack<BabyNeeds> stack)
    {
        PushState(currentNeed, stack);
        
        // this does not belong here: newNeed = _generator.GetItem();
        currentNeed = newNeed;
    }

    public void ReturnObjectState()
    { 
        _generator.ReturnItem(_objectStack.Peek());
        TryPopStack(_objectStack);
        currentNeed = _objectStack.Peek();
        // _babyController.CurrentBabyState = currentState; // property if controller needs to know state switch
    }
    
    public void ReturnWellbeingState()
    { 
        _generator.ReturnItem(_wellbeingStack.Peek());
        TryPopStack(_wellbeingStack);
        currentNeed = _wellbeingStack.Peek();
        // _babyController.CurrentBabyState = currentState; // property if controller needs to know state switch
    }
    
    public void ReturnLoveState()
    { 
        _generator.ReturnItem(_loveStack.Peek());
        TryPopStack(_loveStack);
        currentNeed = _loveStack.Peek();
        // _babyController.CurrentBabyState = currentState; // property if controller needs to know state switch
    }

    public Stack<BabyNeeds> TryPopStack(Stack<BabyNeeds> stack)
    {
        if (stack.Count > 1)
        {
            stack.Pop();
        }

        return stack;
    }

    public Stack<BabyNeeds> PushState(BabyNeeds needsToStack, Stack<BabyNeeds> stack)
    {
        if (needsToStack == stack.Peek())
        {
            return stack;
        }

        stack.Push(needsToStack);
        return stack;
    }
}
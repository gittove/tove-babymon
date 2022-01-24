using System.Collections.Generic;
using UnityEngine;

public class BabyStateMachine
{
    public BabyNeeds currentNeed;
    
    private Stack<BabyNeeds> _objectStack;
    private Stack<BabyNeeds> _wellbeingStack;
    private Stack<BabyNeeds> _loveStack;
    private BabyController _babyController;
    private NeedGenerator _generator;

    // TODO the state None can be assigned to the player, even though the player might have active needs in
    // .. other categories. That is a problem, fix thank
    
    public BabyStateMachine(BabyController controller)
    {
        _babyController = controller;

        _objectStack = new Stack<BabyNeeds>();
        _wellbeingStack = new Stack<BabyNeeds>();
        _loveStack = new Stack<BabyNeeds>();
        
        currentNeed = BabyNeeds.None;
        _loveStack.Push(currentNeed);
        _objectStack.Push(currentNeed);
        _wellbeingStack.Push(currentNeed);
        
        _generator = new NeedGenerator();
    }

    public void SetObject()
    {
        if (!_generator.isObjectInList())
        {
            Debug.Log("Object list is empty!");
            return;
        }
        BabyNeeds item;
        item = _generator.GetObjectItem();
        SetNewState(item, _objectStack);
    }
    
    public void SetLove()
    {
        if (!_generator.isLoveInList())
        {
            Debug.Log("Love list is empty!");
            return;
        }
        BabyNeeds item;
        item = _generator.GetLoveItem();
        SetNewState(item, _loveStack);
    }

    public void SetWellbeing()
    {
        if (!_generator.IsWellbeingInList())
        {
            Debug.Log("Wellbeing list is empty!");
            return;
        }
        BabyNeeds item;
        item = _generator.GetWellbeingItem();
        SetNewState(item, _wellbeingStack);
    }
    
    public void SetNewState(BabyNeeds newNeed, Stack<BabyNeeds> stack)
    {
        PushState(currentNeed, stack);
        currentNeed = newNeed;
        _babyController.CurrentBabyNeed = currentNeed;
    }

    public void ReturnObjectState()
    { 
        _generator.ReturnItem(_objectStack.Peek());
        TryPopStack(_objectStack);
        currentNeed = _objectStack.Peek();
        _babyController.CurrentBabyNeed = currentNeed;
    }
    
    public void ReturnWellbeingState()
    { 
        _generator.ReturnItem(_wellbeingStack.Peek());
        TryPopStack(_wellbeingStack);
        currentNeed = _wellbeingStack.Peek();
        _babyController.CurrentBabyNeed = currentNeed;
    }
    
    public void ReturnLoveState()
    { 
        _generator.ReturnItem(_loveStack.Peek());
        TryPopStack(_loveStack);
        currentNeed = _loveStack.Peek();
        _babyController.CurrentBabyNeed = currentNeed;
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
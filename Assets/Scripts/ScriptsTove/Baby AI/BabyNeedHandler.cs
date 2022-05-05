using System.Collections.Generic;
using UnityEngine;

public class BabyNeedHandler
{
    public BabyNeeds currentNeed;
    
    private int _overallStackCount;
    private Stack<BabyNeeds> _objectStack;
    private Stack<BabyNeeds> _wellbeingStack;
    private Stack<BabyNeeds> _loveStack;
    private BabyController _babyController;
    private NeedGenerator _generator;

    public BabyNeedHandler(BabyController controller, BehaviorDictionary dictionary)
    {
        _babyController = controller;

        _generator = new NeedGenerator(dictionary);
        _objectStack = new Stack<BabyNeeds>();
        _wellbeingStack = new Stack<BabyNeeds>();
        _loveStack = new Stack<BabyNeeds>();

        currentNeed = BabyNeeds.None;
        _babyController.Idle = BabyNeeds.TotalIdle;
        _loveStack.Push(currentNeed);
        _objectStack.Push(currentNeed);
        _wellbeingStack.Push(currentNeed);
        _overallStackCount = 3;
    }

    public void SetObject()
    {
        if (!_generator.isObjectInList())
        {
            return;
        }
        BabyNeeds item;
        item = _generator.GetObjectItem();
        currentNeed = item;
        _babyController.ObjectNeed = currentNeed;
        PushState(currentNeed, _objectStack);
    }
    
    public void SetLove()
    {
        if (!_generator.isLoveInList())
        {
            return;
        }
        BabyNeeds item;
        item = _generator.GetLoveItem();
        currentNeed = item;
        _babyController.LoveNeed = currentNeed;
        PushState(currentNeed, _loveStack);
    }

    public void SetWellbeing()
    {
        if (!_generator.IsWellbeingInList())
        {
            return;
        }
        BabyNeeds item;
        item = _generator.GetWellbeingItem();
        currentNeed = item;
        _babyController.WellbeingNeed = currentNeed;
        PushState(currentNeed, _wellbeingStack);
    }

    public void ReturnObjectState()
    {
        _generator.ReturnItem(_objectStack.Peek());
        TryPopStack(_objectStack);
        currentNeed                 = _objectStack.Peek();
        if (_overallStackCount == 3)
        {
            _babyController.ObjectNeed = currentNeed;
            _babyController.Idle = currentNeed;
        }
        else _babyController.ObjectNeed = currentNeed;
    }
    
    public void ReturnWellbeingState()
    {
        _generator.ReturnItem(_wellbeingStack.Peek());
        TryPopStack(_wellbeingStack);
        currentNeed                 = _wellbeingStack.Peek();
        if (_overallStackCount == 3)
        {
            _babyController.WellbeingNeed = currentNeed;
            _babyController.Idle = currentNeed;
        }
        else _babyController.WellbeingNeed = currentNeed;
    }
    
    public void ReturnLoveState()
    {
        _generator.ReturnItem(_loveStack.Peek());
        TryPopStack(_loveStack);
        currentNeed                 = _loveStack.Peek();
        if (_overallStackCount == 3)
        {
            _babyController.LoveNeed = currentNeed;
            _babyController.Idle = currentNeed;
        }
        else _babyController.LoveNeed = currentNeed;
    }

    public void TryPopStack(Stack<BabyNeeds> stack)
    {
        if (stack.Count > 1)
        {
            stack.Pop();
            _overallStackCount--;
            BabiesRuntimeSet.RaiseActiveNeedsCountChanged(-1);
        }
        _babyController.ActiveNeeds = _overallStackCount - 3;
    }

    public void PushState(BabyNeeds needsToStack, Stack<BabyNeeds> stack)
    {
        if (needsToStack == stack.Peek())
        {
            return;
        }
        
        stack.Push(needsToStack);
        BabiesRuntimeSet.RaiseActiveNeedsCountChanged(1);
        _overallStackCount++;
        _babyController.ActiveNeeds = _overallStackCount - 3;
    }
}
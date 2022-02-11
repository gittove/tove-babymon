using System.Collections.Generic;

public struct BehaviorDictionary
{
    public ScriptableBehaviorBase idleBehavior;
    
    private Dictionary<BabyNeeds, ScriptableBehaviorBase> _objectDictionary;
    private Dictionary<BabyNeeds, ScriptableBehaviorBase> _wellbeingDictionary;
    private Dictionary<BabyNeeds, ScriptableBehaviorBase> _loveDictionary;
    
    private List<BabyNeeds> _objectNeedList;
    private List<BabyNeeds> _wellbeingNeedList;
    private List<BabyNeeds> _loveNeedList;

    public BehaviorDictionary(ScriptableNeedsBehaviors inSO)
    {
        _objectDictionary = new Dictionary<BabyNeeds, ScriptableBehaviorBase>();
        _wellbeingDictionary = new Dictionary<BabyNeeds, ScriptableBehaviorBase>();
        _loveDictionary = new Dictionary<BabyNeeds, ScriptableBehaviorBase>();
        
        _objectNeedList = new List<BabyNeeds>();
        _wellbeingNeedList = new List<BabyNeeds>();
        _loveNeedList = new List<BabyNeeds>();
        
        idleBehavior = inSO.idleBehavior;

        SetupDictionaries(inSO);
        SetUpLists(inSO);
    }

    public ScriptableBehaviorBase LookUpObject(BabyNeeds lookUp)
    {
        return _objectDictionary[lookUp];
    }

    public ScriptableBehaviorBase LookUpWellbeing(BabyNeeds lookUp)
    {
        return _wellbeingDictionary[lookUp];
    }

    public ScriptableBehaviorBase LookUpLove(BabyNeeds lookUp)
    {
        return _loveDictionary[lookUp];
    }

    public List<BabyNeeds> ObjectList
    {
        get
        {
            return _objectNeedList;
        }
    }

    public List<BabyNeeds> WellbeingList
    {
        get
        {
            return _wellbeingNeedList;
        }
    }

    public List<BabyNeeds> LoveList
    {
        get
        {
            return _loveNeedList;
        }
    }

    private void SetupDictionaries(ScriptableNeedsBehaviors inSO)
    {
        for (int i = 0; i < inSO.objectBehaviors.Count; i++)
        {
            _objectDictionary.Add(inSO.objectNeeds[i], inSO.objectBehaviors[i]);
        }

        for (int i = 0; i < inSO.wellbeingBehaviors.Count; i++)
        {
            _wellbeingDictionary.Add(inSO.wellbeingNeeds[i], inSO.wellbeingBehaviors[i]);
        }

        for (int i = 0; i < inSO.loveBehaviors.Count; i++)
        {
            _loveDictionary.Add(inSO.loveNeeds[i], inSO.loveBehaviors[i]);
        }
    }

    private void SetUpLists(ScriptableNeedsBehaviors inSO)
    {
        for (int i = 0; i < inSO.objectNeeds.Count; i++)
        {
            _objectNeedList.Add(inSO.objectNeeds[i]);
        }

        for (int i = 0; i < inSO.wellbeingNeeds.Count; i++)
        {
            _wellbeingNeedList.Add(inSO.wellbeingNeeds[i]);
        }

        for (int i = 0; i < inSO.loveNeeds.Count; i++)
        {
            _loveNeedList.Add(inSO.loveNeeds[i]);
        }
    }
}

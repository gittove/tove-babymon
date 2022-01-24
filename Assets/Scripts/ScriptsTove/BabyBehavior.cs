using System.Collections.Generic;
using UnityEngine;

public class BabyBehavior : MonoBehaviour
{
    //todo react on need values from BabyProfile
    
    [Header("Object behavior assets:")]
    [SerializeField] private ScriptableObjectBehavior _foodBehavior;
    [Header("Wellbeing behavior assets:")]
    [SerializeField] private ScriptableWellbeingBehavior _wellbeingBehavior;
    [Header("Love behavior assets:")]
    [SerializeField] private ScriptableLoveBehavior _loveBehavior;

    private BabyNeeds _currentObjectNeed;
    private BabyNeeds _currentWellbeingNeed;
    private BabyNeeds _currentLoveNeed;
    private ScriptableObjectBehavior _currentObjectBehavior;
    private ScriptableWellbeingBehavior _currentWellbeingBehavior;
    private ScriptableLoveBehavior _currentLoveBehavior;
    private Dictionary<BabyNeeds, ScriptableObjectBehavior> _objectDictionary;
    private Dictionary<BabyNeeds, ScriptableWellbeingBehavior> _wellbeingDictionary;
    private Dictionary<BabyNeeds, ScriptableLoveBehavior> _loveDictionary;

    public BabyBehavior()
    {
        // TODO fill 'em
        _objectDictionary = new Dictionary<BabyNeeds, ScriptableObjectBehavior>();
        _objectDictionary.Add(BabyNeeds.Food, _foodBehavior);
        
        _wellbeingDictionary = new Dictionary<BabyNeeds, ScriptableWellbeingBehavior>();
        
        // TODO you were here
        
        _loveDictionary = new Dictionary<BabyNeeds, ScriptableLoveBehavior>();
    }
    
    public BabyNeeds ObjectNeed
    {
        set
        {
            _currentObjectNeed = value;
        }
    }
    
    public BabyNeeds WellbeingNeed
    {
        set
        {
            _currentWellbeingNeed = value;
        }
    }
    
    public BabyNeeds LoveNeed
    {
        set
        {
            _currentLoveNeed = value;
        }
    }
    
    public ScriptableObjectBehavior ObjectBehavior
    {
        set
        {
            _currentObjectBehavior = _objectDictionary[_currentObjectNeed];
            _currentObjectBehavior.OnStart();
        }
    }
    
    public ScriptableWellbeingBehavior WellbeingBehavior
    {
        set
        {
            _currentWellbeingBehavior = _wellbeingDictionary[_currentWellbeingNeed];
            _currentWellbeingBehavior.OnStart();
        }
    }
    
    public ScriptableLoveBehavior LoveBehavior
    {
        set
        {
            _currentLoveBehavior = _loveDictionary[_currentLoveNeed];
            _currentLoveBehavior.OnStart();
        }
    }
}

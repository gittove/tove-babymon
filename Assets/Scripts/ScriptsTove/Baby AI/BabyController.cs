using UnityEngine;

public class BabyController : MonoBehaviour
{
    public BabyNeedHandler _needHandler;
    [SerializeField] private string _foodPreferenceID;
    [SerializeField] private string _toyPreferenceID;
    [SerializeField] private ScriptableNeedsBehaviors _overview;

    [HideInInspector] public BabyNeeds currentObjectNeed;
    [HideInInspector] public BabyNeeds currentWellbeingNeed;
    [HideInInspector] public BabyNeeds currentLoveNeed;
    public string objectNeedID;
    public string loveNeedID;
    public string wellbeingNeedID;

    private int _activeNeedsCount;
    private bool _isPreference;
    private Effect _particleEffect;
    private PreferenceType _preferenceType;
    private BabyNeeds _currentNeed;
    
    
    private ChangeNeedSprites _imageChanger;
    private ScriptableBehaviorBase _currentObjectBehavior;
    private ScriptableBehaviorBase _currentWellbeingBehavior;
    private ScriptableBehaviorBase _currentLoveBehavior;
    private BabyProfile _profile;
    private BabyEventHandler _eventHandler;
    private Sprite _objectImage;
    private Sprite _wellbeingImage;
    private Sprite _loveImage;

    private BehaviorDictionary _dictionary;

    private void Awake()
    {
        _profile = GetComponent<BabyProfile>();
        _eventHandler = GetComponent<BabyEventHandler>();
        _imageChanger = GetComponentInChildren<ChangeNeedSprites>();
        _dictionary = new BehaviorDictionary(_overview);
        _needHandler = new BabyNeedHandler(this, _dictionary);

        // TODO hi hello nitpick; right now, a new dictionary is instantiated for each baby. That is not neccessary lmao, this only needs to be instantiated ONCE
        // this dictionary should maybe be instantiated on start?
    }
    
    public BehaviorDictionary Dictionary
    {
        get
        {
            return _dictionary;
        } 
    }

    public int ActiveNeeds
    {
        set
        {
            _activeNeedsCount = value;
        }
    }

    public BabyNeeds ObjectNeed
    {
        set
        {
            if (_currentNeed == BabyNeeds.TotalIdle) _profile.StartHPEnumerator();
            
            _currentNeed           = value;
            currentObjectNeed     = value;
            _currentObjectBehavior = _dictionary.LookUpObject(value);
            
            _imageChanger.ObjectImage = _currentObjectBehavior.UiSprite;
            objectNeedID              = _currentObjectBehavior.NeedID;
            _isPreference             = _currentObjectBehavior.IsPreference;
            _particleEffect           = _currentObjectBehavior.ParticleEffect;
            
            // if (_isPreference) _preferenceType = _currentObjectBehavior.PreferenceType;

            // if decision to use separate animations for each state:
            //_animValue = _currentObjectBehavior.AnimParValue;
            //_animationManager.SetParameterInt("BabyAnimState", _animValue);
            // Debug.Log(_currentNeed);
        }
    }

    public BabyNeeds WellbeingNeed
    {
        set
        {
            if (_currentNeed == BabyNeeds.TotalIdle) _profile.StartHPEnumerator();
            
            _currentNeed              = value;
            currentWellbeingNeed     = value;
            _currentWellbeingBehavior = _dictionary.LookUpWellbeing(value);
            
            _imageChanger.Wellbeing = _currentWellbeingBehavior.UiSprite;
            wellbeingNeedID        = _currentWellbeingBehavior.NeedID;
            
            // if decision to use separate animations for each state:
            //_animValue = _currentObjectBehavior.AnimParValue;
            //_animationManager.SetParameterInt("BabyAnimState", _animValue);
            // Debug.Log(_currentNeed);
        }
    }

    public BabyNeeds LoveNeed
    {
        set
        {
            if (_currentNeed == BabyNeeds.TotalIdle) _profile.StartHPEnumerator();
            
            _currentNeed         = value;
            currentLoveNeed     = value;
            _currentLoveBehavior = _dictionary.LookUpLove(value);
            
            _imageChanger.Love = _currentLoveBehavior.UiSprite;
            loveNeedID        = _currentLoveBehavior.NeedID;
            
            // if decision to use separate animations for each state:
            //_animValue = _currentObjectBehavior.AnimParValue;
            //_animationManager.SetParameterInt("BabyAnimState", _animValue);
            // Debug.Log(_currentNeed);
        }
    }

    public BabyNeeds Idle
    {
        set
        {
            _profile?.StopHPEnumerator();
            _currentNeed = BabyNeeds.TotalIdle;
        }
    }

    public void OnObjectInteract(string actionID)
    {
        if (objectNeedID == "001")
        {
            _eventHandler.OnObjectComplete(_activeNeedsCount, currentObjectNeed, _isPreference);
            return;
        }
        if (_isPreference)
        {
            if (currentObjectNeed == BabyNeeds.WantFood) objectNeedID     = _foodPreferenceID;
            else if (currentObjectNeed == BabyNeeds.Toy) objectNeedID = _toyPreferenceID;
        }
        
        if (objectNeedID == actionID) _eventHandler.OnObjectComplete(_activeNeedsCount, currentObjectNeed, _isPreference); 
        else _eventHandler.OnTaskFailed(_isPreference);
    }

    public void OnWellbeingInteract(string actionID)
    {
        if (wellbeingNeedID == "001") _eventHandler.OnWellbeingComplete(_activeNeedsCount, currentWellbeingNeed);
        else if (wellbeingNeedID == actionID) _eventHandler.OnWellbeingComplete(_activeNeedsCount, currentWellbeingNeed);
        else _eventHandler.OnTaskFailed(false);
    }

    public void OnLoveInteract(string actionID)
    {
        if (loveNeedID == "001")_eventHandler.OnLoveComplete(_activeNeedsCount);
        else if (loveNeedID == actionID) _eventHandler.OnLoveComplete(_activeNeedsCount);
        else _eventHandler.OnTaskFailed(false);
    }
}
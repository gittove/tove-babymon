using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TBabyController : MonoBehaviour
{
    private int _maxHP;
    private int _timeUntilDecrease;
    private int _happyIncreaseValue;
    private float _babyHappiness;
    private float _happyDecreaseValue;
    private float _timerResetValue = 0f;
    private float _timerMaxValue = 1f;
    private bool _needIsActive;
    private string _needID;

    private MaterialPropertyBlock _mpb;
    private Coroutine HPCoroutine;
    private MeshRenderer _renderer;
    private BehaviorDictionary _dictionary;
    private ChangeNeedSprites _imageChanger;
    private ScriptableBehaviorBase _currentBehavior;

    [SerializeField] 
    private UnityEvent onFirstNeedComplete;
    [SerializeField] 
    private UnityEvent onSecondNeedComplete;
    [SerializeField] 
    private UnityEvent onThirdNeedComplete;
    [SerializeField] 
    private UnityEvent onSecondNeedSpawn;

    private string playerTag = "Player";

    [SerializeField] private string _toyPreferenceID;
    [SerializeField] private AnimationManager _animationManager;
    [SerializeField] private GameObject _child;
    [SerializeField] private ScriptableNeedsBehaviors _overview;
    [SerializeField] private Sprite _checkMarkSprite;
    [SerializeField] private ScriptableEventParticleSystem _eventParticleSystem;
    [SerializeField] private BabyValuesScriptableObject _babyValues;
    
    [SerializeField] private UnityEvent _burpAudioEvent;
    [SerializeField] private UnityEvent _happyAudioEvent;
    [SerializeField] private UnityEvent _toyAudioEvent;
    [SerializeField] private UnityEvent _sadAudioEvent;
    
    private void Awake()
    {
        _imageChanger = GetComponentInChildren<ChangeNeedSprites>();
        _renderer     = _child.GetComponent<MeshRenderer>();
        _dictionary   = new BehaviorDictionary(_overview);
        _mpb          = new MaterialPropertyBlock();
        

        _maxHP              = _babyValues.maxHP;
        _babyHappiness      = _maxHP;
        _happyDecreaseValue = 1 * _babyValues.decreaseHpValue;
        _happyIncreaseValue = _babyValues.increaseHpValue;
        _timeUntilDecrease  = 1;
    }

    private void Start()
    {
        _currentBehavior        = _dictionary.LookUpWellbeing(BabyNeeds.Burp);
        _imageChanger.Wellbeing = _currentBehavior.UiSprite;
        _needID                 = "420";
        HPCoroutine             = StartCoroutine(HappinessBar());
        _needIsActive           = true;
    }

    public void OnBurpInteraction(string id)
    {
        if (id == _needID)
        {
            _imageChanger.Wellbeing = _checkMarkSprite;
            _eventParticleSystem.RaiseEvent(Effect.Burp, transform.position);
            _burpAudioEvent.Invoke();
            IncreaseHappiness();
            StopCoroutine(HPCoroutine);
            _needIsActive = false;
            StartCoroutine(SpawnLoveNeed());
            onFirstNeedComplete.Invoke();
        }
    }

    private void GenerateLoveNeed()
    {
        _currentBehavior   = _dictionary.LookUpLove(BabyNeeds.SingSong);
        _imageChanger.Love = _currentBehavior.UiSprite;
        _needID            = "666";
        HPCoroutine        = StartCoroutine(HappinessBar());
        
        onSecondNeedSpawn.Invoke();
    }

    public void OnLoveInteraction(string id)
    {
        if (id == _needID)
        {
            _imageChanger.Love = _checkMarkSprite;
            _eventParticleSystem.RaiseEvent(Effect.Happy, transform.position);
            _happyAudioEvent.Invoke();
            IncreaseHappiness();
            StopCoroutine(HPCoroutine);
            _needIsActive = false;
            StartCoroutine(SpawnObjectNeed());
            onSecondNeedComplete.Invoke();
        }
    }

    private void GenerateObjectNeed()
    {
        _currentBehavior          = _dictionary.LookUpObject(BabyNeeds.Toy);
        _imageChanger.ObjectImage = _currentBehavior.UiSprite;
        _needID                   = _toyPreferenceID;
        HPCoroutine               = StartCoroutine(HappinessBar());
    }

    public void OnObjectInteraction(string id)
    {
        if (id == _needID)
        {
            _animationManager.SetParameterTrigger("IsHappy");
            _imageChanger.ObjectImage = _checkMarkSprite;
            _eventParticleSystem.RaiseEvent(Effect.Happy, transform.position);
            _toyAudioEvent.Invoke();
            IncreaseHappiness();
            StopCoroutine(HPCoroutine);
            _needID       = "001";
            _needIsActive = false;
            onThirdNeedComplete.Invoke();
            // TUTORIAL DONE :)
        }
        else OnInteractFail();
    }

    public void OnInteractFail()
    {
        _eventParticleSystem.RaiseEvent(Effect.Fail, transform.position);
        _animationManager.SetParameterTrigger("isAngry");
        _sadAudioEvent.Invoke();
    }
    
    private void UpdateHappinessBar()
    {
        _mpb.SetFloat("_HappinessValue", _babyHappiness);
        _renderer.SetPropertyBlock(_mpb);
    }
    
    private void DecreaseHappiness()
    {
        _babyHappiness -= _happyDecreaseValue;
        _babyHappiness =  Mathf.Clamp(_babyHappiness,0, _maxHP);
    }

    public void IncreaseHappiness()
    {
        _babyHappiness += _happyIncreaseValue;
        _babyHappiness =  Mathf.Clamp(_babyHappiness,0, _maxHP);
        UpdateHappinessBar();
    }
    
    public void OnPauseEvent(bool isPause)
    {
        if (isPause)
        {
            if (_needIsActive)
            {
                StopCoroutine(HPCoroutine);
            }
        }
        else
        {
            if (_needIsActive)
            {
                HPCoroutine = StartCoroutine(HappinessBar());
            }
        }
    }
    
    private IEnumerator HappinessBar()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeUntilDecrease);
            DecreaseHappiness();
            UpdateHappinessBar();
            yield return null;
        }
    }

    private IEnumerator SpawnLoveNeed()
    {
        yield return new WaitForSeconds(4);
        GenerateLoveNeed();
        _needIsActive = true;
        yield break;
    }

    private IEnumerator SpawnObjectNeed()
    {
        yield return new WaitForSeconds(4);
        GenerateObjectNeed();
        _needIsActive = true;
        yield break;
    }
}

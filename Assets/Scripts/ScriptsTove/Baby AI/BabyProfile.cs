using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class BabyProfile : MonoBehaviour
{
    [FormerlySerializedAs("_babyHappiness")] public float babyHappiness;
    
    private int _timeUntilDecrease;
    [SerializeField] private int _objectIndex;
    [SerializeField] private int _wellbeingIndex;
    [SerializeField] private int _loveIndex;
    private int[] _objectTicks;
    private int[] _wellbeingTicks;
    private int[] _loveTicks;
    private int _happyIncreaseValue;
    private int _moodIncreaseValue;
    private int _sadLimit;
    private int _maxObject;
    private int _maxWellbeing;
    private int _maxLove;
    private int _maxHP;

    private bool _objectIndexMaxed;
    private bool _wellbeingIndexMaxed;
    private bool _loveIndexMaxed;
    private bool _isSad;
    private bool _needIsActive;
    
    private float _happyDecreaseValue;
    private float _timerResetValue = 0f;
    private float _timerMaxValue = 1f;
    
    private MaterialPropertyBlock _mpb;
 //   private Material _happinessBar;
    private MeshRenderer _renderer;
    private BabyEventHandler _eventHandler;
    private Coroutine HPCoroutine;
    private Coroutine MoodCoroutine;

    [SerializeField] private float _object;
    [SerializeField] private float _love;
    [SerializeField] private float _wellbeing;
    [SerializeField] private bool randomizeStats;

    [SerializeField] private BabiesRuntimeSet _runtimeSet;
    [SerializeField] private BabyValuesScriptableObject _babyValues;
    [SerializeField] private MoodTicks _tickValues;
    [SerializeField] private GameObject _child;
    [SerializeField] private GameObject _sadRing;

    private void Awake()
    {
        _renderer     = _child.GetComponent<MeshRenderer>();
        _eventHandler = GetComponent<BabyEventHandler>();
        _mpb          = new MaterialPropertyBlock();

       // _needIsActive = false;
    }

    private void Start()
    {
        _objectTicks    = _tickValues.objectTicks;
        _wellbeingTicks = _tickValues.wellbeingTicks;
        _loveTicks      = _tickValues.loveTicks;

        _objectIndexMaxed    = false;
        _wellbeingIndexMaxed = false;
        _loveIndexMaxed      = false;
        _isSad               = false;

        _objectIndex    = 0;
        _wellbeingIndex = 0;
        _loveIndex      = 0;
        
        _sadRing.SetActive(false);

        if (randomizeStats)
        {
            SetUpRandomStats();
        }
        else
        {
            SetUpMaxStats();
        }
        UpdateHappinessBar();
        MoodCoroutine = StartCoroutine(Countdown1());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightControl))
        {
            babyHappiness = _maxHP;
        }
    }

    private void OnEnable()
    {
        _runtimeSet.Add(this);
    }

    private void OnDisable()
    {
        _runtimeSet.Remove(this);
    }

    private void DecreaseStats()
    {
        _object    -= 1 * _babyValues.decreaseStatsMultiplier;
        _object    =  Mathf.Clamp(_object, 0, _maxObject);
        _love      -= 1 * _babyValues.decreaseStatsMultiplier;
        _love      =  Mathf.Clamp(_love, 0, _maxLove);
        _wellbeing -= 1 * _babyValues.decreaseStatsMultiplier;
        _wellbeing =  Mathf.Clamp(_wellbeing, 0, _maxWellbeing);
        
        MoodCheck();
    }

    private void SetUpRandomStats()
    {
        _maxObject          = _babyValues.maxObject;
        _maxWellbeing       = _babyValues.maxWellbeing;
        _maxLove            = _babyValues.maxLove;
        _object             = Random.Range(_babyValues.minObject, _babyValues.maxObject);
        _love               = Random.Range(_babyValues.minLove, _babyValues.maxLove);
        _wellbeing          = Random.Range(_babyValues.minWellbeing, _babyValues.maxWellbeing);
        _maxHP              = _babyValues.maxHP;
        babyHappiness      = _maxHP;
        _happyDecreaseValue = 1 * _babyValues.decreaseHpValue;
        _happyIncreaseValue = _babyValues.increaseHpValue;
        _moodIncreaseValue  = _babyValues.increaseMoodValue;
        _timeUntilDecrease  = 1;
        _sadLimit           = _babyValues.sadHpValue;
    }

    private void SetUpMaxStats()
    {
        _maxObject          = _babyValues.maxObject;
        _maxWellbeing       = _babyValues.maxWellbeing;
        _maxLove            = _babyValues.maxLove;
        _object             = _maxObject;
        _wellbeing          = _maxWellbeing;
        _love               = _maxLove;
        _maxHP              = _babyValues.maxHP;
        babyHappiness      = _maxHP;
        _happyDecreaseValue = 1 * _babyValues.decreaseHpValue;
        _happyIncreaseValue = _babyValues.increaseHpValue;
        _moodIncreaseValue  = _babyValues.increaseMoodValue;
        _timeUntilDecrease  = 1;
        _sadLimit           = _babyValues.sadHpValue;
    }

    private void MoodCheck()
    {
        if (!_objectIndexMaxed && _object < _objectTicks[_objectIndex])
        {
            // Debug.Log("Object event raised");
            _eventHandler.OnObjectMood();
            if (_objectIndex < _objectTicks.Length - 1)
            {
                _objectIndex++;
                if (_objectIndex == _objectTicks.Length-1) _objectIndexMaxed = true;
            }
        }
        
        if (!_wellbeingIndexMaxed && _wellbeing < _wellbeingTicks[_wellbeingIndex])
        {
            // Debug.Log("Wellbeing event raised");
            _eventHandler.OnWellbeingMood();

            if (_wellbeingIndex < _wellbeingTicks.Length - 1)
            {
                _wellbeingIndex++;
                if (_wellbeingIndex == _wellbeingTicks.Length-1) _wellbeingIndexMaxed = true;
            }
            if (_wellbeingIndex == _wellbeingTicks.Length) _wellbeingIndexMaxed = true;
        }
        
        if (!_loveIndexMaxed && _love < _loveTicks[_loveIndex])
        {
            // Debug.Log("Love event raised");
            _eventHandler.OnLoveMood();
            if (_loveIndex < _loveTicks.Length - 1)
            {
                _loveIndex++;
                if (_loveIndex >= _loveTicks.Length-1) _loveIndexMaxed = true;
            }
        }
        
        SadCheck();
    }

    private void SadCheck()
    {
        if (!_isSad && babyHappiness < _sadLimit)
        {
            _isSad = true;
            _sadRing.SetActive(true);
        }
        
        else if (_isSad && babyHappiness > _sadLimit)
        {
            _isSad = false;
            _sadRing.SetActive(false);
        }
    }
    
    private void UpdateHappinessBar()
    {
        _mpb.SetFloat("_HappinessValue", babyHappiness);
        _renderer.SetPropertyBlock(_mpb);
    }

    private void DecreaseHappiness()
    {
        babyHappiness -= _happyDecreaseValue;
        babyHappiness =  Mathf.Clamp(babyHappiness,0, _maxHP);
    }

    public void IncreaseHappiness(int needDivider)
    {
        babyHappiness += _maxHP / needDivider;
        babyHappiness =  Mathf.Clamp(babyHappiness,0, _maxHP);
        UpdateHappinessBar();
    }

    public void IncreaseObjectMood()
    {
        if (_objectIndex == 0) _object = _maxObject;
        else if (!_objectIndexMaxed) _object += _objectTicks[_objectIndex - 1] + _moodIncreaseValue;
        else _object                    += _objectTicks[_objectIndex] + _moodIncreaseValue;
        _object =  Mathf.Clamp(_object, 0, _maxObject);
        int tempIndex = _objectIndex;

        for (int i = tempIndex; i > 0; i--)
        {
            if (_object > _objectTicks[i])
            {
                _objectIndex--;
                _objectIndexMaxed = false;
            }
        }
    }

    public void IncreaseWellbeingMood()
    {
        if (_wellbeingIndex == 0) _wellbeing = _maxWellbeing;
        else if (!_wellbeingIndexMaxed) _wellbeing += _wellbeingTicks[_wellbeingIndex - 1] + _moodIncreaseValue;
        else _wellbeing                       += _wellbeingTicks[_wellbeingIndex] + _moodIncreaseValue;
        _wellbeing =  Mathf.Clamp(_wellbeing, 0, _maxWellbeing);
        int tempIndex = _wellbeingIndex;

        for (int i = tempIndex; i > 0; i--)
        {
            if (_wellbeing > _wellbeingTicks[i])
            {
                _wellbeingIndex--;
                _wellbeingIndexMaxed = false;
            }
        }
    }

    public void IncreaseLoveMood()
    {
        if (_loveIndex == 0) _love = _maxLove;
        else if (!_loveIndexMaxed) _love += _loveTicks[_loveIndex - 1] + _moodIncreaseValue;
        else _love                  += _loveTicks[_loveIndex] + _moodIncreaseValue;
        _love =  Mathf.Clamp(_love, 0, _maxLove);
        int tempIndex = _loveIndex;

        for (int i = tempIndex; i > 0; i--)
        {
            if (_love > _loveTicks[i])
            {
                _loveIndex--;
                _wellbeingIndexMaxed = false;
            }
        }
    }

    public void OnPauseEvent(bool isPause)
    {
        if (isPause)
        {
            if (_needIsActive)
            {
                StopCoroutine(HPCoroutine);
            }
            
            StopCoroutine(MoodCoroutine);
        }
        else
        {
            if (_needIsActive)
            {
                HPCoroutine = StartCoroutine(HappinessBar());
            }

            MoodCoroutine = StartCoroutine(Countdown1());
        }
    }

    public void StartHPEnumerator()
    {
        _needIsActive = true;
        HPCoroutine = StartCoroutine(HappinessBar());
    }

    public void StopHPEnumerator()
    {
        _needIsActive = false;
        if (HPCoroutine != null) StopCoroutine(HPCoroutine);
    }

    private IEnumerator Countdown1()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeUntilDecrease);
            DecreaseStats();
            yield return null;
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
}
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BabyProfile : MonoBehaviour
{
    private int _objectIndex;
    private int _wellbeingIndex;
    private int _loveIndex;
    private int[] _objectTicks;
    private int[] _wellbeingTicks;
    private int[] _loveTicks;
    
    
    private float _timer;
    private float _timerResetValue = 0f;
    private float _timerMaxValue = 1f;

    [SerializeField] private float _object;
    [SerializeField] private float _love;
    [SerializeField] private float _wellbeing;
    [SerializeField] private bool randomizeStats;
    
    [SerializeField] private ScriptableEvent _objectEvent;
    [SerializeField] private ScriptableEvent _wellbeingEvent;
    [SerializeField] private ScriptableEvent _loveEvent;
    [SerializeField] private BabyValuesScriptableObject _babyValues;
    [SerializeField] private MoodTicks _tickValues;
    
    private void Start()
    {
        _objectTicks = _tickValues.objectTicks;
        _wellbeingTicks = _tickValues.wellbeingTicks;
        _loveTicks = _tickValues.loveTicks;

        ResetTimer();

        _objectIndex = 0;
        _wellbeingIndex = 0;
        _loveIndex = 0;

        if (randomizeStats)
        {
            SetUpRandomStats();
        }
        else
        {
            SetUpMaxStats();
        }
    }

    private void Update()
    {
        // TODO make this a coroutine
        _timer += Time.deltaTime;

        if (_timer > _timerMaxValue)
        {
            DecreaseStats();
            ResetTimer();
        }
    }

    private void DecreaseStats()
    {
        _object -= 1 * _babyValues.decreaseStatsMultiplier;
        _love -= 1 * _babyValues.decreaseStatsMultiplier;
        _wellbeing -= 1 * _babyValues.decreaseStatsMultiplier;
        
        MoodCheck();
    }

    private void SetUpRandomStats()
    {
        _object = Random.Range(_babyValues.minObject, _babyValues.maxObject);
        _love = Random.Range(_babyValues.minLove, _babyValues.maxLove);
        _wellbeing = Random.Range(_babyValues.minWellbeing, _babyValues.maxWellbeing);
    }

    private void SetUpMaxStats()
    {
        _object = _babyValues.maxObject;
        _love = _babyValues.maxLove;
        _wellbeing = _babyValues.maxWellbeing;
    }

    // TODO needcheck
    // important: control that the mood-check only runs ONCE and then changes the criteria ..
    // .. based on if the need is satisfied or if the mood continues decreasing

    private void MoodCheck()
    {
        if (_object < _objectTicks[_objectIndex])
        {
            Debug.Log("Object event raised");
            _objectEvent.RaiseEvent();
            // activate need
            _objectIndex++;
        }

        if (_wellbeing < _wellbeingTicks[_wellbeingIndex])
        {
            Debug.Log("Wellbeing event raised");
            _wellbeingEvent.RaiseEvent();
            // activate need
            _wellbeingIndex++;
        }

        if (_love < _loveTicks[_loveIndex])
        {
            Debug.Log("Love event raised");
            _loveEvent.RaiseEvent();
            // activate need
            _loveIndex++;
        }
    }

    private void moveObjectIndex()
    {
        _objectIndex++;
    }

    private void moveWellbeingIndex()
    {
        _wellbeingIndex++;
    }

    private void moveLoveIndex()
    {
        _loveIndex++;
    }

    private void ResetTimer()
    {
        _timer = _timerResetValue;
    }
}
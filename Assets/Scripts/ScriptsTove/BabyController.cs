using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class BabyController : MonoBehaviour
{
    private float _newNeedTimer;
    private float _timeUntilDecrease;
    private int _babyHappiness;
    private int _happyDecreaseValue;
    [SerializeField] private BabyValuesScriptableObject _babyValues;
    
    private float _needTimer;
    private BabyStateMachine _stateMachine;
    private MeshRenderer _meshRenderer;
    private Pointer _pointer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _stateMachine = new BabyStateMachine(this);
        _pointer = GetComponent<Pointer>();

        SetBabyValues();
        ResetTimer();
    }

    private void Update()
    {
        _needTimer += Time.deltaTime;
        
        if (_needTimer > _newNeedTimer)
        {
            //debugging
            Debug.Log("new need added");
            _meshRenderer.material.SetColor("_Color", Color.cyan);
            //end of debugging
            
            ResetTimer();
            _stateMachine.SetNewState(BabyState.Hungry);
        }
    }

    private void OnMouseDown()
    {
        //debugging
        Debug.Log("baby all good!");
        //end of debugging
        
        _stateMachine.ReturnToPreviousState();
    }

    private void ResetTimer()
    {
        _needTimer = 0f;
    }

    private void SetBabyValues()
    {
        _newNeedTimer = _babyValues.needTimer;
        _babyHappiness = _babyValues.maxHP;
        _happyDecreaseValue = _babyValues.decreaseHPValue;
        _timeUntilDecrease = _babyValues.decreaseHPTimer;
    }
}

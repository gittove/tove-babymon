using System.Collections;
using UnityEngine;

public class BabyController : MonoBehaviour
{
    private int _timeUntilDecrease;

    // TODO i don't wanna hardcode this range, pls
    [Range(0, 100)] private float _babyHappiness;
    private float _happyDecreaseValue;

    [SerializeField] private BabyValuesScriptableObject _babyValues;
    [SerializeField] private GameObject _child;

    private BabyNeeds _currentNeed;
    private BabyStateMachine _stateMachine;
    private MeshRenderer _meshRenderer;
    private Pointer _pointer;
    private Material _happinessBar;

    public BabyNeeds CurrentBabyNeed
    {
        set
        {
            if (value != _currentNeed)
            {
                if (_currentNeed == BabyNeeds.None) StartCoroutine(HappinessBar());
                else if (value == BabyNeeds.None) StopCoroutine(HappinessBar());
                _currentNeed = value;
            }
        }
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _pointer = GetComponent<Pointer>();
        _happinessBar = _child.GetComponent<Renderer>().material;
        _stateMachine = new BabyStateMachine(this);

        SetBabyValues();
        UpdateHappinessBar();
    }
    
    public void OnObjectMoodEvent()
    {
        _stateMachine.SetObject();
    }

    public void OnWellbeingMoodEvent()
    {
        _stateMachine.SetWellbeing();
    }

    public void OnLoveMoodEvent()
    {
        _stateMachine.SetLove();
    }

    public void OnObjectComplete()
    {
        _stateMachine.ReturnObjectState();
    }

    public void OnWellbeingComplete()
    {
        _stateMachine.ReturnWellbeingState();
    }

    public void OnLoveComplete()
    {
        _stateMachine.ReturnLoveState();
    }

    private void OnMouseDown()
    {
        //debugging
        Debug.Log("baby all good!");
        //end of debugging

        _stateMachine.ReturnObjectState();
    }

    private void SetBabyValues()
    {
        _babyHappiness = _babyValues.maxHP;
        _happyDecreaseValue = 1 * _babyValues.decreaseStatsMultiplier;
        _timeUntilDecrease = 1;
    }

    private void UpdateHappinessBar()
    {
        _happinessBar.SetFloat("_HappinessValue", _babyHappiness);
    }

    private void DecreaseHappiness()
    {
        _babyHappiness -= _happyDecreaseValue;
    }

    private IEnumerator HappinessBar()
    {
        while (true)
        {
            DecreaseHappiness();
            UpdateHappinessBar();
            yield return new WaitForSeconds(_timeUntilDecrease);
        }
    }
}
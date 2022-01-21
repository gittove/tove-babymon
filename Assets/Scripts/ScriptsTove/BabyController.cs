using UnityEngine;

public class BabyController : MonoBehaviour
{
    private float _timeUntilDecrease;
    // TODO i don't wanna hardcode this range, pls
    [Range(0, 100)] private float _babyHappiness;
    private float _happyDecreaseValue;
    
    [SerializeField] private BabyValuesScriptableObject _babyValues;
    [SerializeField] private GameObject _child;
    
    private float _needTimer;
    private BabyStateMachine _stateMachine;
    private MeshRenderer _meshRenderer;
    private Pointer _pointer;
    private Material _happinessBar;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _stateMachine = new BabyStateMachine(this);
        _pointer = GetComponent<Pointer>();
        _happinessBar = _child.GetComponent<Renderer>().material;

        SetBabyValues();
        UpdateHappinessBar();
        ResetTimer();
    }

    // TODO move this from update
    // TODO connect happiness sinking to active needs
    private void Update()
    {
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

    private void OnMouseDown()
    {
        //debugging
        Debug.Log("baby all good!");
        //end of debugging
        
        _stateMachine.ReturnObjectState();
    }

    private void ResetTimer()
    {
        _needTimer = 0f;
    }

    private void SetBabyValues()
    {
        _babyHappiness = _babyValues.maxHP;
        _happyDecreaseValue = 1;
        _timeUntilDecrease = _babyValues.decreaseHPMultiplier;
    }

    private void UpdateHappinessBar()
    {
        _happinessBar.SetFloat("_HappinessValue", _babyHappiness);
    }
}

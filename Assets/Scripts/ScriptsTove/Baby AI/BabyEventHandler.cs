using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class BabyEventHandler : MonoBehaviour
{
    private NavMeshAgentController _navController;
    private BabyController _controller;
    private BabyNeedHandler _needHandler;
    private BabyProfile _profile;

    [Header("Drag 3D-model object here:")] 
    [SerializeField] private AnimationManager _animationManager;
    [Header("Particle system event:")]
    [SerializeField] private ScriptableEventParticleSystem _eventParticleSystem;
    [Header("Audio Events:")]
    [SerializeField] private UnityEvent _needAudioEvent;
    [SerializeField] private UnityEvent _happyAudioEvent;
    [SerializeField] private UnityEvent _sadAudioEvent;
    [SerializeField] private UnityEvent _burpAudioEvent;
    [SerializeField] private UnityEvent _foodAudioEvent;
    [SerializeField] private UnityEvent _toyAudioEvent;

    private void Awake()
    {
        _navController = GetComponent<NavMeshAgentController>();
        _controller = GetComponent<BabyController>();
        _profile = GetComponent<BabyProfile>();
    }

    private void Start()
    {
        _needHandler = _controller._needHandler;
    }

    public void OnObjectMood()
    {
        _needAudioEvent.Invoke();
        _needHandler.SetObject();
    }

    public void OnWellbeingMood()
    {
        _needAudioEvent.Invoke();
        _needHandler.SetWellbeing();
    }

    public void OnLoveMood()
    {
        _needAudioEvent.Invoke();
        _needHandler.SetLove();
    }

    public void OnObjectComplete(int needDivider, BabyNeeds need, bool isPreference)
    {
        if (isPreference)
        {
            _animationManager.SetParameterTrigger("IsHappy");
            StartCoroutine(DelayBabyMovement());
        }
        
        if (need == BabyNeeds.Toy)
        {
            _toyAudioEvent.Invoke();
        }
        
        else if (need == BabyNeeds.WantFood)
        {
            _foodAudioEvent.Invoke();
        }

        _eventParticleSystem.RaiseEvent(Effect.Happy, transform.position);
        
        _profile.IncreaseHappiness(needDivider);
        _profile.IncreaseObjectMood();
        _needHandler.ReturnObjectState();
    }

    public void OnWellbeingComplete(int needDivider, BabyNeeds need)
    {
        if (need == BabyNeeds.Burp)
        {
            _burpAudioEvent.Invoke();
        }
        
        else if (need == BabyNeeds.Carry)
        {
            _happyAudioEvent.Invoke();
        }
        
        if (need == BabyNeeds.Burp)
        {
            _eventParticleSystem.RaiseEvent(Effect.Burp, transform.position);
        }
        
        else
        {
            _eventParticleSystem.RaiseEvent(Effect.Happy, transform.position);
        }
        
        _profile.IncreaseHappiness(needDivider);
        _profile.IncreaseWellbeingMood();
        _needHandler.ReturnWellbeingState();
    }

    public void OnLoveComplete(int needDivider)
    {
        _eventParticleSystem.RaiseEvent(Effect.Happy, transform.position);
        _happyAudioEvent.Invoke();
        _profile.IncreaseHappiness(needDivider);
        _profile.IncreaseLoveMood();
        _needHandler.ReturnLoveState();
    }

    public void OnTaskFailed(bool isPreference)
    {
        if (isPreference)
        {
            _animationManager.SetParameterTrigger("isAngry");
            StartCoroutine(DelayBabyMovement());
        }
        _eventParticleSystem.RaiseEvent(Effect.Fail, transform.position);
        _sadAudioEvent.Invoke();
    }

    IEnumerator DelayBabyMovement()
    {   
        _navController.enabled = false;
        yield return new WaitForSeconds(2f);
        _navController.enabled = true;
    }
}

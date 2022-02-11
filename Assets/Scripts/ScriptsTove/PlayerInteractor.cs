using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerInteractor : MonoBehaviour
{
    [HideInInspector] public bool isHoldingBaby;
    public KeyCode objectInteractKey;
    public KeyCode wellbeingInteractKey;
    public KeyCode loveInteractKey;

    private float _startTime = 0f;
    [HideInInspector] public float timer;
    private float _holdTime;
    private bool _babyInRange;
    private bool _readyForInteraction;
    private bool _isHolding;
    private string _actionID;

    [SerializeField] private GameObject _holdKeyCanvas;
    [SerializeField] private GameObject _holdKeyBar;
    [SerializeField] private ScriptableVariableInt _holdDownKeyTime;
    [SerializeField] private UnityEvent _bookAudioEvent;
    [SerializeField] private UnityEvent _stopBookAudioEvent;
    [SerializeField] private UnityEvent _singSongAudioEvent;
    [SerializeField] private UnityEvent _stopSingSongAudioEvent;
    [SerializeField] private UnityEvent _pickUpAudioEvent;
    private Material _keyBarMat;
    private BabyController _controller;
    private CollisionDetector _detector;
    private GameObject _grabber;
    private Collider _baby;

    private void Awake()
    {
        _keyBarMat = _holdKeyBar.GetComponent<Image>().material;
        _detector  = GetComponent<CollisionDetector>();

        _holdTime            = _holdDownKeyTime.Value;
        timer                = _startTime;
        _actionID            = null;
        _readyForInteraction = true;
        isHoldingBaby        = false;
        _babyInRange         = false;

        _keyBarMat.SetFloat("_StartTime", _holdTime);
        _holdKeyCanvas.SetActive(false);
    }

    private void Update()
    {
        if (_babyInRange)
        {
            if (!isHoldingBaby && Input.GetKeyDown(objectInteractKey))
            {
                _controller.OnObjectInteract(_actionID);
            }

            else if (!isHoldingBaby && Input.GetKeyDown(wellbeingInteractKey))
            {
                if (_controller.currentWellbeingNeed == BabyNeeds.Carry)
                {
                    _pickUpAudioEvent.Invoke();
                    _detector.PickUpBaby(_controller.gameObject);
                    return;
                }
                
                _controller.OnWellbeingInteract(_actionID);
            }
            
            else if (!isHoldingBaby && Input.GetKey(loveInteractKey))
            {
                if (!_readyForInteraction)
                {
                    return;
                }

                if (Input.GetKeyDown(loveInteractKey))
                {
                    if (_controller.currentLoveNeed == BabyNeeds.ReadStory) _bookAudioEvent.Invoke();
                    else if (_controller.currentLoveNeed == BabyNeeds.SingSong) _singSongAudioEvent.Invoke();
                }
                
                _holdKeyCanvas.SetActive(true);
                _baby.gameObject.GetComponent<NavMeshAgent>().isStopped =  true;
                timer                                                   += Time.deltaTime;
                _keyBarMat.SetFloat("_TimeValue", timer);

                if (timer > _holdTime)
                {
                    if (_controller.currentLoveNeed == BabyNeeds.ReadStory) _stopBookAudioEvent.Invoke();
                    else if (_controller.currentLoveNeed == BabyNeeds.SingSong) _stopSingSongAudioEvent.Invoke();
                    _holdKeyCanvas.SetActive(false);
                    timer = _startTime;
                    _controller.OnLoveInteract(_actionID);
                    StartCoroutine(Wait(2));
                }
            }

            else if (Input.GetKeyUp(loveInteractKey))
            {
                InterruptLoveNeed();
            }
        }
    }

    private void InterruptLoveNeed()
    {
        if (_controller.currentLoveNeed == BabyNeeds.ReadStory) _stopBookAudioEvent.Invoke();
        else if (_controller.currentLoveNeed == BabyNeeds.SingSong) _stopSingSongAudioEvent.Invoke();
        
        _readyForInteraction                                    = true;
        _baby.gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        timer                                                   = _startTime;
        _holdKeyCanvas.SetActive(false);
    }

    private IEnumerator Wait(int time)
    {
        float timer = 0f;
        _readyForInteraction = false;

        while (true)
        {
            timer += Time.deltaTime;

            if (this.timer > time)
            {
                _readyForInteraction = true;
                yield break;
            }

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Baby"))
        {
            _actionID = _detector.playerID;

            _controller = collisionInfo.gameObject.GetComponent<BabyController>();
        }
    }

    private void OnTriggerStay(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Baby"))
        {
            _baby        = collisionInfo;
            _babyInRange = true;
        }
    }

    private void OnTriggerExit(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Baby"))
        {
            _babyInRange = false;
        }
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class TPlayerInteractor : MonoBehaviour
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
    private TBabyController _controller;
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
                Debug.Log("Interacting with object need");
                _controller.OnObjectInteraction(_actionID);
            }

            else if (!isHoldingBaby && Input.GetKeyDown(wellbeingInteractKey))
            {
           //     if (_controller.currentWellbeingNeed == BabyNeeds.Carry)
           //     {
           //         _pickUpAudioEvent.Invoke();
           //         _detector.PickUpBaby(_controller.gameObject);
           //         return;
           //     }

                Debug.Log("Interacting with wellbeing need");
                _controller.OnBurpInteraction("420");
            }

            else if (!isHoldingBaby && Input.GetKey(loveInteractKey))
            {
                if (!_readyForInteraction)
                {
                    return;
                }
                
                if (Input.GetKeyDown(loveInteractKey))
                {
                    _singSongAudioEvent.Invoke();
                }
                
                _holdKeyCanvas.SetActive(true);
               // _baby.gameObject.GetComponent<NavMeshAgent>().isStopped =  true;
                timer                                                   += Time.deltaTime;
                _keyBarMat.SetFloat("_TimeValue", timer);

                if (timer > _holdTime)
                {
                    _stopSingSongAudioEvent.Invoke();
                    _holdKeyCanvas.SetActive(false);
                    Debug.Log("Interacting with love need");
                    timer = _startTime;
                    _controller.OnLoveInteraction("666");
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
        _stopSingSongAudioEvent.Invoke();
        
        _readyForInteraction                                    = true;
      //  _baby.gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        Debug.Log("Love need interrupted");
        timer = _startTime;
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

            _controller = collisionInfo.gameObject.GetComponent<TBabyController>();
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

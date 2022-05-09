using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public enum NavMeshStates
{
    Patrol,
    Idle
}

public class NavMeshAgentController : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent navMeshAgent;
    public UnityEvent navMeshReleased;
    [HideInInspector] public bool wantPickUp;
    [HideInInspector] public bool isPickedUp;
    [HideInInspector] public bool paused;

    [Header("Length of pathfinding (in units)")]
    [SerializeField][Range(1,10)] private int _pathLength;
    [SerializeField] private Transform groundCheck;

    private bool _destinationReached;
    private bool _isGrounded;
    private bool _isMoving;
    private bool _test;
    private bool _isObserving;
    private NavMeshStates _currentState;
    private NavMeshStates[] _actionProbability;
    public Vector3 _nextDirection;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _actionProbability = new NavMeshStates[4] {NavMeshStates.Idle, NavMeshStates.Idle, NavMeshStates.Idle, NavMeshStates.Patrol};

        _isMoving = false;
        paused = false;
        _nextDirection = transform.position;
        _isGrounded = true;
        wantPickUp = false;
        _test = true;
    }

    private void Update()
    {
        if (isPickedUp) return;
        _isGrounded = GroundCheck();
        if (!_isGrounded) return;
        
        if (_currentState != NavMeshStates.Idle && !_destinationReached && !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            _destinationReached = true;
            _isMoving = false;
            StartCoroutine(BeIdle(2f));
        }
    }

    private void OnEnable()
    {
        navMeshAgent.SamplePathPosition(NavMesh.AllAreas, 0.0f, out NavMeshHit meshHit);
        navMeshAgent.areaMask = meshHit.mask;
    }

    private void Decide()
    {
        StopAllCoroutines();
        int randomIndex = Random.Range(0, _actionProbability.Length);
        _currentState = _actionProbability[randomIndex];
        
        if (_currentState == NavMeshStates.Patrol)
        {
            CalculateNextDirection();
        }
        
        else if (_currentState == NavMeshStates.Idle)
        {
            StartCoroutine(BeIdle(5f));
        }
    }

    private void Patrol(Vector3 destination)
    {
        _destinationReached = false;
        _isMoving = true;
        navMeshAgent.SetDestination(destination);
    }

    public void Pause()
    {
        navMeshAgent.isStopped = true;
        paused = true;
        StartCoroutine("Pausing");
    }

    private IEnumerator Pausing()
    {
        float _elapsedTime = 0f;
        float _pauseTime = 2f;

        while (paused && _elapsedTime <= _pauseTime)
        {
            _elapsedTime += Time.deltaTime;
            yield return Time.deltaTime;
        }

        navMeshAgent.isStopped = false;
        if (paused)
        {
            paused = false;
        }
    }

    private IEnumerator BeIdle(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            Decide();
            yield break;
        }
    }

    private void CalculateNextDirection()
    {
        Vector3 randomDirection = Random.onUnitSphere;
        
        float dotProduct = Vector3.Dot(transform.forward, new Vector3(randomDirection.x, 0f, randomDirection.z));

        if (dotProduct > 0)
        {
            randomDirection = new Vector3(-randomDirection.x, 0f, -randomDirection.z);
        }
        
        _nextDirection = (randomDirection * _pathLength) + transform.position;
        
        Patrol(_nextDirection);
    }

    private bool GroundCheck()
    {
        if (!isPickedUp)
        {
            if (_test && wantPickUp)
            {
                _currentState = NavMeshStates.Idle;
                navMeshAgent.areaMask = NavMesh.AllAreas;
                navMeshAgent.enabled = false;
                navMeshReleased.Invoke();
                _test = false;
                isPickedUp = true;
                return false;
            }
            else if (!_isGrounded && !wantPickUp)
            {
                navMeshAgent.SamplePathPosition(NavMesh.AllAreas, 0.0f, out NavMeshHit meshHit);
                navMeshAgent.areaMask = meshHit.mask;
                Decide();
                _test = true;
            }
            return true;
        }

        return false;
    }
}

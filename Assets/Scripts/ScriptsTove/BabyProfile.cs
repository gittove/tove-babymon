using UnityEngine;

public class BabyProfile : MonoBehaviour
{
    private float _timer;
    private float _timerResetValue = 0f;
    private float _timerMaxValue = 1f;
    [SerializeField] private float _hunger;
    [SerializeField] private float _love;
    [SerializeField] private float _comfort;
    [SerializeField] private bool randomizeStats;
    [SerializeField] private BabyValuesScriptableObject _babyValues;

    private void Start()
    {
        ResetTimer();
        
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
        _timer += Time.deltaTime;

        if (_timer > _timerMaxValue)
        {
            DecreaseStats();
            ResetTimer();
        }
    }

    private void DecreaseStats()
    {
        _hunger -= 1 * _babyValues.decreaseStatsMultiplier;
        _love -= 1 * _babyValues.decreaseStatsMultiplier;
        _comfort -= 1 * _babyValues.decreaseStatsMultiplier;
    }

    private void SetUpRandomStats()
    {
        _hunger = Random.Range(_babyValues.minHunger, _babyValues.maxHunger);
        _love = Random.Range(_babyValues.minLove, _babyValues.maxLove);
        _comfort = Random.Range(_babyValues.minComfort, _babyValues.maxComfort);
    }

    private void SetUpMaxStats()
    {
        _hunger = _babyValues.maxHunger;
        _love = _babyValues.maxLove;
        _comfort = _babyValues.maxComfort;
    }

    private void ResetTimer()
    {
        _timer = _timerResetValue;
    }
}

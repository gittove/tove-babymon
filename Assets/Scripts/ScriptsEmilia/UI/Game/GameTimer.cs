using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Header("Scriptable objects:")] 
    [SerializeField]
    private ScriptableEventBase onTimeEnd;
    [SerializeField] 
    private BoolObservable pauseObservable;

    [SerializeField] private GameObject player;
    
    [Header("Timer values, in seconds:")]
    [SerializeField,Range(1,180)]
    private int gameTime;
    
    [Header("References:")]
    [SerializeField] 
    private TextMeshProUGUI timerText;
    [SerializeField] 
    private Material timerMaterial;
    
    private int remainingDuration;
    private bool isPause; 
    
    void Start()
    {
        isPause = false;
        StartTimer(gameTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            remainingDuration = 0;
            EndRound();
        }
    }

    private void StartTimer(int seconds)
    {
        timerMaterial.SetFloat("_StartTime", seconds);
        remainingDuration = seconds;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            if (!isPause)
            {
                timerText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
                timerMaterial.SetFloat("_Timer", remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f); //Todo hard code?
            }
            yield return null;
        }
        EndRound();
    }
   
    public void GamePause(bool value)
    {
        isPause = value;
    }

    private void EndRound()
    {
        pauseObservable.SetValue(true);
        onTimeEnd.RaiseEvent();
    }
}

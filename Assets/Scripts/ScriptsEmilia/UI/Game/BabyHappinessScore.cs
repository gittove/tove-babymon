using System;
using TMPro;
using UnityEngine;

public class BabyHappinessScore : MonoBehaviour
{
    [Header("Win condition: ")] 
    [SerializeField, Range(0, 900)] 
    private int winThreshold = 300;
    
    [Header("Runtime Sets:")] 
    [SerializeField]
    private BabiesRuntimeSet babiesRuntimeSet;

    [Header("Scriptable Events: ")] 
    [SerializeField]
    private ScriptableEventBase onWin;
    [SerializeField] 
    private ScriptableEventBase onLose;

    [Header("References: ")]
    [SerializeField] 
    private TextMeshProUGUI textBox;

    [SerializeField] 
    private GameObject timeUpCanvas;

    private float totalScore;

    private void Start()
    {
        timeUpCanvas.SetActive(false);
    }

    private void OnDisable()
    {
        babiesRuntimeSet.ClearSet();
    }

    public void DisplayTotalScore()
    {
        totalScore = babiesRuntimeSet.GetTotalScore();
        
        textBox.text = $"Total score is:{Mathf.Round(totalScore)}";
    }

    public void EvaluateScore()
    {
        if (totalScore >= winThreshold)
        {
            onWin.RaiseEvent();
        }
        else
        {
            onLose.RaiseEvent();
        }
    }
}

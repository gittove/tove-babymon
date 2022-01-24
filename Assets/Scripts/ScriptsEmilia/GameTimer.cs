using System.Collections;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Header("Timer values, in seconds")]
    [SerializeField,Range(1,180)]
    public int gameTime; //Todo make to scriptable int? why tho
    
    [Header("References")]
    [SerializeField] 
    private TextMeshProUGUI timerText;
    
    private int remainingDuration;
    private bool isPause; 
    
    void Start()
    {
        StartTimer(gameTime);
        isPause = true;
    }

    private void StartTimer(int seconds)
    {
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
                remainingDuration--;
                yield return new WaitForSeconds(1f); //Todo hard code?
            }
            yield return null;
        }
        EndRound();
    }

    public void StartCanvasClose()
    {
        isPause = false;
    }
    
    public void GamePause(bool value)
    {
        isPause = value;
    }
    
    private void EndRound() //Todo change name
    {
        timerText.text = $"out of time!";
    }
}

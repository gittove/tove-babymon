using System.Collections;
using UnityEngine;

public class AnimationCurveButton : MonoBehaviour 
{
    [Header("References")]
    [SerializeField] 
    private AnimationCurve animationCurve;
    [SerializeField] 
    private HooverOverButton button; //Rename button

    private Coroutine routine;
    private Vector3 startScale;
    
    private void Awake()
    {
        startScale = gameObject.transform.localScale;
    }

    private void OnEnable()
    {
        button.OnHooverEnter += EnterButton;
        button.OnHooverExit += ExitButton;
    }

    private void OnDisable()
    {
        button.OnHooverEnter -= EnterButton;
        button.OnHooverExit -= ExitButton;
    }

    //Todo reset if hoover starts several times
    private void EnterButton()
    {
        routine = StartCoroutine(ScaleButton());
    }

    private void ExitButton()
    {
        StopCoroutine(routine);
        gameObject.transform.localScale = startScale;
    }

    private IEnumerator ScaleButton()
    {
        var frame = animationCurve[animationCurve.length - 1];
        float time = frame.time;
        float elapsedTime = 0;
        while (elapsedTime <= time)
        {
            elapsedTime += Time.deltaTime;
            float curveValue = animationCurve.Evaluate(elapsedTime);
            button.transform.localScale = startScale*curveValue;
            yield return null;
        }
    }
}

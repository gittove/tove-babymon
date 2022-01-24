using System.Collections;
using UnityEngine;

public class AnimationCurveButton : MonoBehaviour
{
    public AnimationCurve animationCurveButton;
    public HooverOverButton resumeButton;

    private Coroutine cr;
    private Vector3 startScale;

    private void Awake()
    {
        startScale = gameObject.transform.localScale;
        resumeButton.OnHooverEnter += OnEnter;
        resumeButton.OnHooverExit += OnExit;
    }
//Todo reset if hoover starts several times
    public void OnEnter()
    {
        cr =StartCoroutine(TestScale());
    }

    public void OnExit()
    {
        StopCoroutine(cr);
        gameObject.transform.localScale = startScale;
    }

    public IEnumerator TestScale()
    {
        var frame = animationCurveButton[animationCurveButton.length - 1];
        float time = frame.time;
        float elapsedTime = 0;
        while (elapsedTime <= time)
        {
            elapsedTime += Time.deltaTime;
            float curveValue = animationCurveButton.Evaluate(elapsedTime);
            resumeButton.transform.localScale = startScale*curveValue;
            yield return null;
        }
    }
}

using System.Collections;
using UnityEngine;

public class BounceAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] 
    private AnimationCurve animationCurve;

    private Coroutine routine;
    private Vector3 startPosition;
    
    private void Awake()
    {
        // startPosition = gameObject.transform.position;
        startPosition = gameObject.transform.localPosition;
    }

    private void OnEnable()
    {
        routine = StartCoroutine(Bounce());
    }

    private void OnDisable()
    {
        StopCoroutine(routine);
        // gameObject.transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
        gameObject.transform.localPosition = new Vector3(transform.position.x, startPosition.y, transform.position.z);
    }

    private IEnumerator Bounce()
    {
        var frame = animationCurve[animationCurve.length - 1];
        float time = frame.time;
        float elapsedTime = 0;
        while (elapsedTime <= time)
        {
            elapsedTime += Time.deltaTime;
            float curveValue = animationCurve.Evaluate(elapsedTime);
            // gameObject.transform.position = new Vector3(startPosition.x, startPosition.y * curveValue, startPosition.z);
            gameObject.transform.localPosition = new Vector3(startPosition.x, (startPosition.y * -curveValue) + (startPosition.y*2), startPosition.z);
            yield return null;
        }
        routine = StartCoroutine(Bounce());
    }
}

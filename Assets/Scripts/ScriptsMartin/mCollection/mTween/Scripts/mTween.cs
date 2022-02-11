using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("mTween/mTween/mTween")]
public class mTween : MonoBehaviour
{
    #region Monobehaviour

    public static mTween instance;
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }
    private void OnValidate()
    {
        if (instance == null)
        {
            if (GameObject.Find("mTween"))
                instance = this;
            else
                CreateNewInstance();
        }

        instance.gameObject.name = "mTween";
    }
    void LateUpdate() => StartCoroutine(LateLateUpdate());
    private IEnumerator LateLateUpdate()
    {
        yield return new WaitForEndOfFrame();
        UpdateQueuedTweens();
    }
    private static mTween CreateNewInstance()
    {
        if (instance == null)
        {
            GameObject t = new GameObject("mTween");
            t.hideFlags = HideFlags.HideInHierarchy;
            mTween x = t.AddComponent<mTween>();
            instance = x;
            return x;
        }
        else
            return instance;
    }

#endregion

    #region New Tween Instance

    [SerializeField] private static List<Tween> activeTweens = new List<Tween>();

    /// <summary>
    /// Queue new tween to be called after a period of time, returns call onComplete and onUpdate
    /// </summary>
    public static Tween NewTween(float time)
    {
        CreateNewInstance();

        Tween i = new Tween(time).SetID();
        activeTweens.Add(i);

        return i;
    }
    public static Tween NewTween(GameObject id, float time)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time);
        activeTweens.Add(i);

        return i;
    }
    public static Tween NewTween(string id, float time)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time);
        activeTweens.Add(i);

        return i;
    }
    public static Tween NewTween(object id, float time)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time);
        activeTweens.Add(i);

        return i;
    }

    /// <summary>
    /// Triggers an action after x amount of time
    /// </summary>
    public static Tween DelayedCall(Action OnComplete, float time)
    {
        CreateNewInstance();

        Tween i = new Tween(time).SetOnComplete(OnComplete);
        activeTweens.Add(i);

        return i;
    }
    public static Tween DelayedCall(GameObject id, Action OnComplete, float time)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).SetOnComplete(OnComplete);
        activeTweens.Add(i);

        return i;
    }
    public static Tween DelayedCall(string id, Action OnComplete, float time)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).SetOnComplete(OnComplete);
        activeTweens.Add(i);

        return i;
    }
    public static Tween DelayedCall(object id, Action OnComplete, float time)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).SetOnComplete(OnComplete);
        activeTweens.Add(i);

        return i;
    }


    /// <summary>
    /// Returns a new tween in which one value is interpolated.
    /// </summary>
    public static Tween value(float a, float b, float time, Action<float> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(time).LerpFloat(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(GameObject id, float a, float b, float time, Action<float> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpFloat(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(string id, float a, float b, float time, Action<float> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpFloat(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(object id, float a, float b, float time, Action<float> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpFloat(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(float a, float b, float time, Action<float> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(time).LerpFloat(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(GameObject id, float a, float b, float time, Action<float> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpFloat(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(string id, float a, float b, float time, Action<float> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpFloat(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(object id, float a, float b, float time, Action<float> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpFloat(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }

    public static Tween value(Vector2 a, Vector2 b, float time, Action<Vector2> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(time).LerpVector2(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(GameObject id, Vector2 a, Vector2 b, float time, Action<Vector2> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpVector2(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(string id, Vector2 a, Vector2 b, float time, Action<Vector2> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpVector2(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(object id, Vector2 a, Vector2 b, float time, Action<Vector2> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpVector2(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(Vector2 a, Vector2 b, float time, Action<Vector2> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(time).LerpVector2(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(GameObject id, Vector2 a, Vector2 b, float time, Action<Vector2> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpVector2(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(string id, Vector2 a, Vector2 b, float time, Action<Vector2> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpVector2(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(object id, Vector2 a, Vector2 b, float time, Action<Vector2> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpVector2(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }

    public static Tween value(Vector3 a, Vector3 b, float time, Action<Vector3> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(time).LerpVector3(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(GameObject id, Vector3 a, Vector3 b, float time, Action<Vector3> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpVector3(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(string id, Vector3 a, Vector3 b, float time, Action<Vector3> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpVector3(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(object id, Vector3 a, Vector3 b, float time, Action<Vector3> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpVector3(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(Vector3 a, Vector3 b, float time, Action<Vector3> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(time).LerpVector3(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(GameObject id, Vector3 a, Vector3 b, float time, Action<Vector3> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpVector3(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(string id, Vector3 a, Vector3 b, float time, Action<Vector3> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpVector3(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(object id, Vector3 a, Vector3 b, float time, Action<Vector3> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpVector3(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }

    public static Tween value(Color a, Color b, float time, Action<Color> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(time).LerpColor(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(GameObject id, Color a, Color b, float time, Action<Color> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpColor(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(string id, Color a, Color b, float time, Action<Color> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpColor(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(object id, Color a, Color b, float time, Action<Color> OnUpdate)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpColor(OnUpdate, a, b);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(Color a, Color b, float time, Action<Color> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(time).LerpColor(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(GameObject id, Color a, Color b, float time, Action<Color> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpColor(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(string id, Color a, Color b, float time, Action<Color> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpColor(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }
    public static Tween value(object id, Color a, Color b, float time, Action<Color> OnUpdate, AnimationCurve curve)
    {
        CreateNewInstance();

        Tween i = new Tween(id, time).LerpColor(OnUpdate, a, b, curve);
        activeTweens.Add(i);

        return i;
    }


    #endregion

    #region Class Methods

    /// <summary>
    /// Cancels all tweens
    /// </summary>
    public static void CancelAllTweens()
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            activeTweens[i].Cancel();
    }

    /// <summary>
    /// Cancel tween by ID
    /// </summary>
    public static void CancelTween(string id)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id)
                activeTweens[i].Cancel();
    }
    public static void CancelTween(GameObject id)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.GetInstanceID().ToString())
                activeTweens[i].Cancel();
    }
    public static void CancelTween(object id)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.ToString())
                activeTweens[i].Cancel();
    }
    public static void CancelTween(GameObject id, float t)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.GetInstanceID().ToString())
                activeTweens.Add(new Tween(t).SetOnComplete(() => activeTweens[i].Cancel()));
    }
    public static void CancelTween(string id, float t)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id)
            {
                activeTweens[i].Cancel();
                activeTweens.Add(new Tween(t).SetOnComplete(() => activeTweens[i].Cancel()));
            }
    }
    public static void CancelTween(object id, float t)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.ToString())
            {
                activeTweens[i].Cancel();
                activeTweens.Add(new Tween(t).SetOnComplete(() => activeTweens[i].Cancel()));
            }
    }

    /// <summary>
    /// Pause tween by ID
    /// </summary>
    public static void PauseTween(string id)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id && !activeTweens[i].paused)
                activeTweens[i].Pause();
    }
    public static void PauseTween(GameObject id)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.GetInstanceID().ToString() && !activeTweens[i].paused)
                activeTweens[i].Pause();
    }
    public static void PauseTween(object id)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.ToString() && !activeTweens[i].paused)
                activeTweens[i].Pause();
    }
    public static void PauseTween(string id, float duration)
    {
        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id && !activeTweens[i].paused)
                activeTweens[i].Pause(duration);
    }
    public static void PauseTween(GameObject id, float duration)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.GetInstanceID().ToString() && !activeTweens[i].paused)
                activeTweens[i].Pause(duration);
    }
    public static void PauseTween(object id, float duration)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.ToString() && !activeTweens[i].paused)
                activeTweens[i].Pause(duration);
    }

    /// <summary>
    /// Continue tween by ID
    /// </summary>
    public static void ContinueTween(string id)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id && activeTweens[i].paused)
                activeTweens[i].Resume();
    }
    public static void ContinueTween(GameObject id)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.GetInstanceID().ToString() && activeTweens[i].paused)
                activeTweens[i].Resume();
    }
    public static void ContinueTween(object id)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.ToString() && activeTweens[i].paused)
                activeTweens[i].Resume();
    }

    /// <summary>
    /// Return tween by ID
    /// </summary>
    public static Tween GetTween(string id)
    {
        if (activeTweens.Count == 0 || instance == null) return null;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id)
                return activeTweens[i];

        return null;
    }
    public static Tween GetTween(GameObject id)
    {
        if (activeTweens.Count == 0 || instance == null) return null;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.GetInstanceID().ToString())
                return activeTweens[i];

        return null;
    }
    public static Tween GetTween(object id)
    {
        if (activeTweens.Count == 0 || instance == null) return null;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.ToString())
                return activeTweens[i];

        return null;
    }

    /// <summary>
    /// Pause all tweens
    /// </summary>
    public static void PauseAllTweens()
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            activeTweens[i].Pause();
    }

    /// <summary>
    /// Continue all tweens
    /// </summary>
    public static void ContinueAllTweens()
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            activeTweens[i].Resume();
    }

    /// <summary>
    /// Adds more time to a tween
    /// </summary>
    public static void DelayTween(string id, float delay)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id)
                activeTweens[i].AddDuration(delay);
    }
    public static void DelayTween(GameObject id, float delay)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.GetInstanceID().ToString())
                activeTweens[i].AddDuration(delay);
    }
    public static void DelayTween(object id, float delay)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.ToString())
                activeTweens[i].AddDuration(delay);
    }

    /// <summary>
    /// Adds more time to a tween. Adds to the total progress time which will continually delay the tween if used in repeat
    /// </summary>
    public static void DelayTweenUnsafe(string id, float delay)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id)
                activeTweens[i].AddDurationUnsafe(delay);
    }
    public static void DelayTweenUnsafe(GameObject id, float delay)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.GetInstanceID().ToString())
                activeTweens[i].AddDurationUnsafe(delay);
    }
    public static void DelayTweenUnsafe(object id, float delay)
    {
        if (activeTweens.Count == 0 || instance == null) return;

        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].GetID() == id.ToString())
                activeTweens[i].AddDurationUnsafe(delay);
    }

    /// <summary>
    /// Get the number of active tweens
    /// </summary>
    public static int GetActiveTweensCount() => activeTweens.Count;

    private void UpdateQueuedTweens()
    {
        if (activeTweens.Count == 0) return;

        for (int i = 0; i < activeTweens.Count; i++)
        {
            //Check if tween was canceled, remove current timeline if true
            if (activeTweens[i].canceled)
            {
                activeTweens.Remove(activeTweens[i]);
                i--;
                continue;
            }

            //Check if tween was paused, resume after unscaledPauseTime if one was provided
            if (activeTweens[i].paused)
            {
                activeTweens[i].UpdatePauseTime();

                if (activeTweens[i].unscaledPauseTime >= activeTweens[i].pauseTime && activeTweens[i].pauseTime != 0f)
                {
                    activeTweens[i].unscaledPauseTime = 0f;
                    activeTweens[i].Resume();
                }
                continue;
            }

            //Check if tween has an interval, delay the call between Complete and Start if true
            if (activeTweens[i].onInterval)
            {
                activeTweens[i].UpdateIntervalTime();

                if (activeTweens[i].unscaledIntervalTime >= activeTweens[i].intervalTime && activeTweens[i].intervalTime != 0f)
                {
                    activeTweens[i].unscaledIntervalTime = 0f;
                    activeTweens[i].onInterval = false;
                    activeTweens[i].unscaledProgress = 0f;
                }
                continue;
            }

            //Check if unscaledProgress is 0, call Start if true
            if (activeTweens[i].unscaledProgress == 0f)
                activeTweens[i].Start();

            //Check if unscaledProgress is same as durationWithDelay, try call Complete if true
            if (activeTweens[i].unscaledProgress > (activeTweens[i].durationWithDelay))
            {
                //Check if tween is set to repeat
                if (activeTweens[i].repeat)
                {
                    activeTweens[i].durationWithDelay = activeTweens[i].duration;
                    activeTweens[i].ResetCustomActionsList();
                    activeTweens[i].CompletedRun();

                    //Check if activeRepeatCount is same as repeatCount. Call Complete if true, else increment activeRepeatCount
                    if (activeTweens[i].activeRepeatCount == activeTweens[i].repeatCount && activeTweens[i].repeatCount != 0)
                    {
                        activeTweens[i].repeat = false;
                        activeTweens[i].activeRepeatCount = 0;
                        activeTweens[i].Complete();
                        activeTweens.Remove(activeTweens[i]);
                        continue;
                    }
                    else if (activeTweens[i].activeRepeatCount < activeTweens[i].repeatCount && activeTweens[i].repeatCount != 0)
                        activeTweens[i].activeRepeatCount++;

                    //Set interval
                    if (activeTweens[i].interval)
                        activeTweens[i].onInterval = true;
                    else
                        activeTweens[i].unscaledProgress = 0f;
                        
                    continue;
                }

                activeTweens[i].unscaledProgress = activeTweens[i].durationWithDelay;

                //Call Complete and remove self from active tweens
                activeTweens[i].Complete();
                activeTweens.Remove(activeTweens[i]);
                continue;
            }

            //Update time of active tweens
            activeTweens[i].UpdateTime();
            activeTweens[i].Update();
        }
    }

    #endregion
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Audio;
using UnityEngine;
using System;

/// <summary>
/// A Tween instance used to interpolate values
/// </summary>
[Serializable] public partial class Tween
{
    string ID;
    public string GetID() => ID;

    public Action onStart;
    public Action<float> onUpdate01;
    public Action<float> onUpdateFloat;
    public Action onUpdate;
    public Action onCompletedRun;
    public Action onComplete;
    public Action onCancel;
    public Action onPause;
    public Action onContinue;

    public float duration;
    public float durationWithDelay;
    public float unscaledProgress;
    public float progress;
    public float pauseTime;
    public float unscaledPauseTime;
    public float intervalTime;
    public float unscaledIntervalTime;

    public int repeatCount;
    public int activeRepeatCount;

    public bool canceled;
    public bool paused;
    public bool interval;
    public bool onInterval;
    public bool repeat;
    public bool completeTriggeredOnCancel;
    public bool completeLoopTriggeredOnCancel;
    public bool restoreOnCancel = false;

    public float min = 0f;
    public float max = 1f;

    public AnimationCurve curve;

    public Tween GetDuration(out float duration)
    {
        duration = this.duration;
        return this;
    }
    public Tween GetDurationWithDelay(out float durationWithDelay)
    {
        durationWithDelay = this.durationWithDelay;
        return this;
    }
    public Tween GetProgress(out float progress)
    {
        progress = this.progress;
        return this;
    }
    public Tween GetUnscaledProgress(out float unscaledProgress)
    {
        unscaledProgress = this.unscaledProgress;
        return this;
    }
    public Tween GetPauseTime(out float pauseTime)
    {
        pauseTime = this.pauseTime;
        return this;
    }
    public Tween GetUnscaledPauseTime(out float unscaledPauseTime)
    {
        unscaledPauseTime = this.unscaledPauseTime;
        return this;
    }
    public Tween GetIntervalTime(out float intervalTime)
    {
        intervalTime = this.intervalTime;
        return this;
    }
    public Tween GetUnscaledIntervalTime(out float unscaledIntervalTime)
    {
        unscaledIntervalTime = this.unscaledIntervalTime;
        return this;
    }
    public Tween GetRepeatCount(out int repeatCount)
    {
        repeatCount = this.repeatCount;
        return this;
    }
    public Tween GetActiveRepeatCount(out int activeRepeatCount)
    {
        activeRepeatCount = this.activeRepeatCount;
        return this;
    }
    public Tween GetCanceled(out bool canceled)
    {
        canceled = this.canceled;
        return this;
    }
    public Tween GetPaused(out bool paused)
    {
        paused = this.paused;
        return this;
    }
    public Tween GetInterval(out bool interval)
    {
        interval = this.interval;
        return this;
    }
    public Tween GetOnInterval(out bool onInterval)
    {
        onInterval = this.onInterval;
        return this;
    }
    public Tween GetRepeat(out bool repeat)
    {
        repeat = this.repeat;
        return this;
    }
    public Tween GetCompleteTriggeredOnCancel(out bool completeTriggeredOnCancel)
    {
        completeTriggeredOnCancel = this.completeTriggeredOnCancel;
        return this;
    }
    public Tween GetCompleteLoopTriggeredOnCancel(out bool completeLoopTriggeredOnCancel)
    {
        completeLoopTriggeredOnCancel = this.completeLoopTriggeredOnCancel;
        return this;
    }
    public Tween GetRestoreOnCancel(out bool restoreOnCancel)
    {
        restoreOnCancel = this.restoreOnCancel;
        return this;
    }
    public Tween GetMin(out float min)
    {
        min = this.min;
        return this;
    }
    public Tween GetMax(out float max)
    {
        max = this.max;
        return this;
    }
    public Tween GetMinMax(out float min, out float max)
    {
        min = this.min;
        max = this.max;
        return this;
    }
    public Tween GetCurve(out AnimationCurve curve)
    {
        curve = this.curve;
        return this;
    }

    /// <summary>
    /// Creates a new tween with a duration
    /// </summary>
    public Tween(float duration)
    {
        curve = new AnimationCurve();
        curve.AddKey(0f, 0f);
        curve.AddKey(1f, 1f);
        this.duration = duration;
        durationWithDelay = duration;
        unscaledProgress = 0f;
    }
    public Tween(GameObject id, float duration)
    {
        curve = new AnimationCurve();
        curve.AddKey(0f, 0f);
        curve.AddKey(1f, 1f);
        this.duration = duration;
        durationWithDelay = duration;
        ID = id.GetInstanceID().ToString();
        unscaledProgress = 0f;
    }
    public Tween(string id, float duration)
    {
        curve = new AnimationCurve();
        curve.AddKey(0f, 0f);
        curve.AddKey(1f, 1f);
        this.duration = duration;
        durationWithDelay = duration;
        ID = id;
        unscaledProgress = 0f;
    }
    public Tween(object id, float duration)
    {
        curve = new AnimationCurve();
        curve.AddKey(0f, 0f);
        curve.AddKey(1f, 1f);
        this.duration = duration;
        durationWithDelay = duration;
        ID = id.ToString();
        unscaledProgress = 0f;
    }

    /// <summary>
    /// Returns progress based on input curve
    /// </summary>
    public Tween SetCurve(AnimationCurve newCurve)
    {
        curve = newCurve;
        return this;
    }

    /// <summary>
    /// Repeats the tween
    /// </summary>
    public Tween Repeat()
    {
        repeat = true;
        return this;
    }
    public Tween Repeat(int n)
    {
        repeat = true;
        repeatCount = n;
        return this;
    }
    public Tween Repeat(bool state)
    {
        repeat = state;
        return this;
    }

    /// <summary>
    /// Cancels the tween
    /// </summary>
    public Tween Cancel()
    {
        ResetLerps();
        this.canceled = true;
        return this;
    }

    /// <summary>
    /// Pause tween
    /// </summary>
    public Tween Pause(float duration)
    {
        if (canceled) return this;

        pauseTime = duration;
        paused = true;
        onPause?.Invoke();

        return this;
    }
    public Tween Pause()
    {
        if (canceled) return this;

        paused = true;
        onPause?.Invoke();

        return this;
    }

    /// <summary>
    /// Resumes tween
    /// </summary>
    public Tween Resume()
    {
        if (canceled) return this;

        paused = false;
        onContinue?.Invoke();

        return this;
    } 

    /// <summary>
    /// Executes the tween n times
    /// </summary>
    public Tween ExecuteNTimes(int n)
    {
        repeat = true;
        repeatCount = n - 1;
        return this;
    }

    /// <summary>
    /// Delay between tween repetition
    /// </summary>
    public Tween SetInterval(float duration)
    {
        interval = true;
        if (duration > 0f)
        {
            intervalTime = duration;
        }
        return this;
    }

    /// <summary>
    /// Play the tween in reverse
    /// </summary>
    public Tween PlayReversed()
    {
        float a = min;
        float b = max;
        min = b;
        max = a;
        return this;
    }

    /// <summary>
    /// Triggers an action at the start of a tween
    /// </summary>
    public Tween SetOnStart(Action onStart)
    {
        this.onStart = onStart;
        return this;
    }

    /// <summary>
    /// Triggers an action for every update of the tween. Returns progress from 0 to 1
    /// </summary>
    public Tween SetOnUpdate01(Action<float> onUpdate)
    {
        onUpdate01 = onUpdate;
        return this;
    }

    /// <summary>
    /// Triggers an action for every update of the tween
    /// </summary>
    public Tween SetOnUpdate(Action onUpdate)
    {
        this.onUpdate = onUpdate;
        return this;
    }
    public Tween SetOnUpdate(Action<float> onUpdate)
    {
        onUpdateFloat = onUpdate;
        return this;
    }

    /// <summary>
    /// Triggers an action on tween completion
    /// </summary>
    public Tween SetOnComplete(Action onComplete)
    {
        this.onComplete = onComplete;
        return this;
    }
    public Tween SetOnComplete(Action onComplete, bool triggerOnCancel)
    {
        this.onComplete = onComplete;
        completeTriggeredOnCancel = triggerOnCancel;
        return this;
    }

    /// <summary>
    /// Triggers an action if the tween is canceled
    /// </summary>
    public Tween SetOnCancel(Action onCancel)
    {
        this.onCancel = onCancel;
        return this;
    }

    /// <summary>
    /// Triggers an action if the tween is paused
    /// </summary>
    public Tween SetOnPause(Action onPause)
    {
        this.onPause = onPause;
        return this;
    }

    /// <summary>
    /// Triggers an action if the tween is continued
    /// </summary>
    public Tween SetOnContinue(Action onContinue)
    {
        this.onContinue = onContinue;
        return this;
    }

    /// <summary>
    /// Triggers an action on repeat completion
    /// </summary>
    public Tween SetOnRepeat(Action onFinished)
    {
        this.onCompletedRun = onFinished;
        return this;
    }
    public Tween SetOnRepeat(Action onFinished, bool triggerOnCanceled)
    {
        this.onCompletedRun = onFinished;
        completeLoopTriggeredOnCancel = triggerOnCanceled;
        return this;
    }

    /// <summary>
    /// Restore the state of the tweened object when the tween is canceled
    /// </summary>
    public Tween RestoreOnCancel()
    {
        restoreOnCancel = true;
        return this;
    }
    public Tween RestoreOnCancel(bool restore)
    {
        restoreOnCancel = restore;
        return this;
    }

    /// <summary>
    /// Sets a unique ID for this tween
    /// </summary>
    public Tween SetID()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        System.Random random = new System.Random();

        ID = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        return this;
    }
    public Tween SetID(string id)
    {
        ID = id;
        return this;
    }
    public Tween SetID(GameObject id)
    {
        ID = id.GetInstanceID().ToString();
        return this;
    }
    public Tween SetID(object id)
    {
        ID = id.ToString();
        return this;
    }

    /// <summary>
    /// Set progress min max. onUpdate returns progress from the new min max values
    /// </summary>
    public Tween SetMinMax(float min, float max)
    {
        this.min = min;
        this.max = max;
        return this;
    }

    /// <summary>
    /// Calls action after t seconds during the tween
    /// </summary>
    public Tween CallOnTime(float t, Action a)
    {
        if (t >= 0f && a != null)
            customActions.Add(new CustomAction(t, a));

        return this;
    }
    /// <summary>
    /// Calls action after t seconds during the tween, scaling determines if the time used is scaled (0 to 1) or unscaled time (0 to tween duration)
    /// </summary>
    public Tween CallOnTime(float t, Action a, bool scaling)
    {
        if (t >= 0f && a != null)
            customActions.Add(new CustomAction(t, a, scaling));

        return this;
    }

    /// <summary>
    /// Resets list of custom actions, DO NOT USE UNLESS NECESSARY
    /// </summary>
    public Tween ResetCustomActionsList()
    {
        if (completedCustomActions.Count == 0f) return this;

        for (int i = 0; i < completedCustomActions.Count; i++)
            customActions.Add(completedCustomActions[i]);

        completedCustomActions.Clear();

        return this;
    }

    /// <summary>
    /// Reset all tweens lerps to the tween lerp start values
    /// </summary>
    private void ResetLerps()
    {
        if (!restoreOnCancel)
            return;

        foreach (floatLerp i in lerpFloat)
            i.Reset();

        foreach (Vector2Lerp i in lerpVector2)
            i.Reset();

        foreach (Vector3Lerp i in lerpVector3)
            i.Reset();

        foreach (ColorLerp i in lerpColor)
            i.Reset();
    }

    /// <summary>
    /// Interpolate Color
    /// </summary>
    public Tween LerpColor(Action<Color> sr, Color startColor, Color endColor)
    {
        List<Color> colors = new List<Color>();
        colors.Add(startColor);
        colors.Add(endColor);

        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[colors.Count];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[colors.Count];

        for (int i = 0; i < colorKeys.Length; i++)
        {
            colorKeys[i].color = colors[i];
            colorKeys[i].time = i / (colorKeys.Length - 1);
        }

        for (int i = 0; i < alphaKeys.Length; i++)
        {
            alphaKeys[i].alpha = colors[i].a;
            alphaKeys[i].time = i / (alphaKeys.Length - 1);
        }

        gradient.SetKeys(colorKeys, alphaKeys);

        ColorLerp newLerp = new ColorLerp(sr, gradient);
        lerpColor.Add(newLerp);
        return this;
    }
    public Tween LerpColor(Action<Color> sr, Color startColor, Color endColor, AnimationCurve curve)
    {
        List<Color> colors = new List<Color>();
        colors.Add(startColor);
        colors.Add(endColor);

        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[colors.Count];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[colors.Count];

        for (int i = 0; i < colorKeys.Length; i++)
        {
            colorKeys[i].color = colors[i];
            colorKeys[i].time = i / (colorKeys.Length - 1);
        }

        for (int i = 0; i < alphaKeys.Length; i++)
        {
            alphaKeys[i].alpha = colors[i].a;
            alphaKeys[i].time = i / (alphaKeys.Length - 1);
        }

        gradient.SetKeys(colorKeys, alphaKeys);

        ColorLerp newLerp = new ColorLerp(sr, gradient, curve);
        lerpColor.Add(newLerp);
        return this;
    }
    public Tween LerpColor(Action<Color> sr, Gradient g)
    {
        ColorLerp newLerp = new ColorLerp(sr, g);
        lerpColor.Add(newLerp);
        return this;
    }
    public Tween LerpColor(Action<Color> sr, Gradient g, AnimationCurve curve)
    {
        ColorLerp newLerp = new ColorLerp(sr, g, curve);
        lerpColor.Add(newLerp);
        return this;
    }
    public Tween LerpColor(Action<Color> sr, List<Color> myColors)
    {
        List<Color> colors = myColors;
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[colors.Count];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[colors.Count];

        for (int i = 0; i < colorKeys.Length; i++)
        {
            colorKeys[i].color = colors[i];
            colorKeys[i].time = i / (colorKeys.Length - 1);
        }

        for (int i = 0; i < alphaKeys.Length; i++)
        {
            alphaKeys[i].alpha = colors[i].a;
            alphaKeys[i].time = i / (alphaKeys.Length - 1);
        }

        gradient.SetKeys(colorKeys, alphaKeys);

        ColorLerp newLerp = new ColorLerp(sr, gradient);
        lerpColor.Add(newLerp);
        return this;
    }
    public Tween LerpColor(Action<Color> sr, List<Color> myColors, AnimationCurve curve)
    {
        List<Color> colors = myColors;
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[colors.Count];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[colors.Count];

        for (int i = 0; i < colorKeys.Length; i++)
        {
            colorKeys[i].color = colors[i];
            colorKeys[i].time = i / (colorKeys.Length - 1);
        }

        for (int i = 0; i < alphaKeys.Length; i++)
        {
            alphaKeys[i].alpha = colors[i].a;
            alphaKeys[i].time = i / (alphaKeys.Length - 1);
        }

        gradient.SetKeys(colorKeys, alphaKeys);

        ColorLerp newLerp = new ColorLerp(sr, gradient, curve);
        lerpColor.Add(newLerp);
        return this;
    }
    public Tween LerpColor(Action<Color> sr, List<ColorTimes> colortimes)
    {
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[colortimes.Count];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[colortimes.Count];

        for (int i = 0; i < colorKeys.Length; i++)
        {
            colorKeys[i].color = colortimes[i].color;
            colorKeys[i].time = colortimes[i].time / duration;
        }
        for (int i = 0; i < alphaKeys.Length; i++)
        {
            alphaKeys[i].alpha = colortimes[i].color.a;
            alphaKeys[i].time = colortimes[i].time / duration;
        }
        

        gradient.SetKeys(colorKeys, alphaKeys);

        ColorLerp newLerp = new ColorLerp(sr, gradient);
        lerpColor.Add(newLerp);
        return this;
    }
    public Tween LerpColor(Action<Color> sr, List<ColorTimes> colortimes, AnimationCurve curve)
    {
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[colortimes.Count];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[colortimes.Count];

        for (int i = 0; i < colorKeys.Length; i++)
        {
            colorKeys[i].color = colortimes[i].color;
            colorKeys[i].time = colortimes[i].time / duration;
        }

        for (int i = 0; i < alphaKeys.Length; i++)
        {
            alphaKeys[i].alpha = colortimes[i].color.a;
            alphaKeys[i].time = colortimes[i].time / duration;
        }

        gradient.SetKeys(colorKeys, alphaKeys);

        ColorLerp newLerp = new ColorLerp(sr, gradient, curve);
        lerpColor.Add(newLerp);
        return this;
    }
    public Tween LerpColor(Action<Color> sr, List<ColorTimes> colortimes, bool scaled)
    {
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[colortimes.Count];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[colortimes.Count];

        float divider = duration;
        if (scaled)
            divider = 1f;

        for (int i = 0; i < colorKeys.Length; i++)
        {
            colorKeys[i].color = colortimes[i].color;
            colorKeys[i].time = colortimes[i].time / divider;
        }
        for (int i = 0; i < alphaKeys.Length; i++)
        {
            alphaKeys[i].alpha = colortimes[i].color.a;
            alphaKeys[i].time = colortimes[i].time / divider;
        }


        gradient.SetKeys(colorKeys, alphaKeys);

        ColorLerp newLerp = new ColorLerp(sr, gradient);
        lerpColor.Add(newLerp);
        return this;
    }
    public Tween LerpColor(Action<Color> sr, List<ColorTimes> colortimes, bool scaled, AnimationCurve curve)
    {
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[colortimes.Count];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[colortimes.Count];

        float divider = duration;
        if (scaled)
            divider = 1f;

        for (int i = 0; i < colorKeys.Length; i++)
        {
            colorKeys[i].color = colortimes[i].color;
            colorKeys[i].time = colortimes[i].time / divider;
        }

        for (int i = 0; i < alphaKeys.Length; i++)
        {
            alphaKeys[i].alpha = colortimes[i].color.a;
            alphaKeys[i].time = colortimes[i].time / divider;
        }

        gradient.SetKeys(colorKeys, alphaKeys);

        ColorLerp newLerp = new ColorLerp(sr, gradient, curve);
        lerpColor.Add(newLerp);
        return this;
    }

    /// <summary>
    /// Interpolate float
    /// </summary>
    public Tween LerpFloat(Action<float> a, float from, float to)
    {
        lerpFloat.Add(new floatLerp(a, from, to));
        return this;
    }
    public Tween LerpFloat(Action<float> a, float from, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp(a, from, to, curve));
        return this;
    }

    /// <summary>
    /// Interpolate Vector2
    /// </summary>
    public Tween LerpVector2(Action<Vector2> a, Vector2 from, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp(a, from, to));
        return this;
    }
    public Tween LerpVector2(Action<Vector2> a, Vector2 from, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp(a, from, to, curve));
        return this;
    }

    /// <summary>
    /// Interpolate Vector3
    /// </summary>
    public Tween LerpVector3(Action<Vector3> a, Vector3 from, Vector3 to)
    {
        lerpVector3.Add(new Vector3Lerp(a, from, to));
        return this;
    }
    public Tween LerpVector3(Action<Vector3> a, Vector3 from, Vector3 to, AnimationCurve curve)
    {
        lerpVector3.Add(new Vector3Lerp(a, from, to, curve));
        return this;
    }

    /// <summary>
    /// Interpolate Quaternion
    /// </summary>
    public Tween LerpQuaternion(Action<Quaternion> t, Quaternion from, Quaternion to)
    {
        lerpRot.Add(new RotationLerp(t, from, to));
        return this;
    }
    public Tween LerpQuaternion(Action<Quaternion> t, Quaternion from, Quaternion to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp(t, from, to, curve));
        return this;
    }

    [Serializable] protected struct floatLerp
    {
        public Action<float> a;
        public float start;
        public float end;
        public AnimationCurve curve;

        public floatLerp(Action<float> a, float start, float end)
        {
            this.a = a;
            this.start = start;
            this.end = end;
            this.curve = new AnimationCurve();
            curve.AddKey(0f, 0f);
            curve.AddKey(1f, 1f);
        }
        public floatLerp(Action<float> a, float start, float end, AnimationCurve curve)
        {
            this.a = a;
            this.start = start;
            this.end = end;
            this.curve = curve;
        }

        public void Reset() => a?.Invoke(start);
    }
    [SerializeField] protected List<floatLerp> lerpFloat = new List<floatLerp>();

    [Serializable] protected struct Vector2Lerp
    {
        public Action<Vector2> a;
        public Vector2 start;
        public Vector2 end;
        public AnimationCurve curve;

        public Vector2Lerp(Action<Vector2> a, Vector2 start, Vector2 end)
        {
            this.a = a;
            this.start = start;
            this.end = end;
            this.curve = new AnimationCurve();
            curve.AddKey(0f, 0f);
            curve.AddKey(1f, 1f);
        }
        public Vector2Lerp(Action<Vector2> a, Vector2 start, Vector2 end, AnimationCurve curve)
        {
            this.a = a;
            this.start = start;
            this.end = end;
            this.curve = curve;
        }

        public void Reset() => a?.Invoke(start);
    }
    [SerializeField] protected List<Vector2Lerp> lerpVector2 = new List<Vector2Lerp>();

    [Serializable] protected struct Vector3Lerp
    {
        public Action<Vector3> a;
        public Vector3 start;
        public Vector3 end;
        public AnimationCurve curve;

        public Vector3Lerp(Action<Vector3> a, Vector3 start, Vector3 end)
        {
            this.a = a;
            this.start = start;
            this.end = end;
            this.curve = new AnimationCurve();
            curve.AddKey(0f, 0f);
            curve.AddKey(1f, 1f);
        }
        public Vector3Lerp(Action<Vector3> a, Vector3 start, Vector3 end, AnimationCurve curve)
        {
            this.a = a;
            this.start = start;
            this.end = end;
            this.curve = curve;
        }

        public void Reset() => a?.Invoke(start);
    }
    [SerializeField] protected List<Vector3Lerp> lerpVector3 = new List<Vector3Lerp>();

    [Serializable] protected struct RotationLerp
    {
        public Action<Quaternion> a;
        public Quaternion from;
        public Quaternion to;
        public AnimationCurve curve;

        public RotationLerp(Action<Quaternion> a, Quaternion from, Quaternion to, AnimationCurve curve)
        {
            this.a = a;
            this.from = from;
            this.to = to;
            this.curve = curve;
        }
        public RotationLerp(Action<Quaternion> a, Quaternion from, Quaternion to)
        {
            this.a = a;
            this.from = from;
            this.to = to;
            curve = new AnimationCurve();
            curve.AddKey(0f, 0f);
            curve.AddKey(1f, 1f);
        }

        public void Reset() => a?.Invoke(from);
    }
    [SerializeField] protected List<RotationLerp> lerpRot = new List<RotationLerp>();

    [Serializable] protected struct ColorLerp
    {
        public Action<Color> color;
        public Gradient gradient;
        public AnimationCurve curve;

        public ColorLerp(Action<Color> sr, Gradient gradient)
        {
            this.color = sr;
            this.gradient = gradient;
            this.curve = new AnimationCurve();
            curve.AddKey(0f, 0f);
            curve.AddKey(1f, 1f);
        }
        public ColorLerp(Action<Color> sr, Gradient gradient, AnimationCurve curve)
        {
            this.color = sr;
            this.gradient = gradient;
            this.curve = curve;
        }

        public void Reset() => color?.Invoke(gradient.colorKeys[0].color);
    }
    [SerializeField] protected List<ColorLerp> lerpColor = new List<ColorLerp>();
    protected Gradient GetGradient(Color from, Color to)
    {
        Gradient gradient;
        GradientColorKey[] colorKeys;
        GradientAlphaKey[] alphaKeys;

        List<Color> colors = new List<Color>();
        colors.Add(from);
        colors.Add(to);

        gradient = new Gradient();
        colorKeys = new GradientColorKey[colors.Count];
        alphaKeys = new GradientAlphaKey[colors.Count];
        for (int i = 0; i < colorKeys.Length; i++)
        {
            colorKeys[i].color = colors[i];
            colorKeys[i].time = i / (colorKeys.Length - 1);
        }

        for (int i = 0; i < alphaKeys.Length; i++)
        {
            alphaKeys[i].alpha = colors[i].a;
            alphaKeys[i].time = i / (alphaKeys.Length - 1);
        }

        gradient.SetKeys(colorKeys, alphaKeys);
        return gradient;
    }
    [Serializable] protected struct ContinuousTargetLerp
    {
        public Transform transform;
        public Transform target;
        public Vector3 worldUp;

        public ContinuousTargetLerp(Transform t, Transform Target)
        {
            this.transform = t;
            this.target = Target;
            this.worldUp = Vector3.up;
        }
        public ContinuousTargetLerp(Transform t, Transform target, Vector3 WorldUp)
        {
            this.transform = t;
            this.target = target;
            this.worldUp = WorldUp;
        }
    }
    [SerializeField] protected List<ContinuousTargetLerp> lerpTarget = new List<ContinuousTargetLerp>();

    [Serializable] protected struct CustomAction
    {
        public float time;
        public Action action;
        public bool scale;

        public CustomAction(float t, Action a)
        {
            this.time = t;
            this.action = a;
            this.scale = false;
        }
        public CustomAction(float t, Action a, bool scaling)
        {
            this.time = t;
            this.action = a;
            this.scale = scaling;
        }
    }
    [SerializeField] protected List<CustomAction> customActions = new List<CustomAction>();
    [SerializeField] protected List<CustomAction> completedCustomActions = new List<CustomAction>();

    /// <summary>
    /// Starts the tween. DO NOT USE
    /// </summary>
    public void Start() 
    {
        canceled = false;
        onStart?.Invoke(); 
    }

    /// <summary>
    /// Called on full tween completion. DO NOT USE
    /// </summary>
    public void Complete()
    {
        ResetLerps();
        onComplete?.Invoke();
    }

    /// <summary>
    /// Called on completed tween loop. DO NOT USE
    /// </summary>
    public void CompletedRun()
    {
        onCompletedRun?.Invoke();
    }
    public void Update()
    {
        if (canceled) return;

        progress = curve.Evaluate(Remap(unscaledProgress, 0f, duration, min, max));
        progress = Mathf.Clamp(progress, min, max);

        onUpdate?.Invoke();
        onUpdate01?.Invoke(curve.Evaluate(Remap(Mathf.Clamp(unscaledProgress, 0f, duration), 0f, duration, 0, 1)));
        onUpdateFloat?.Invoke(progress);

        if (lerpFloat.Count > 0)
        {
            for (int i = 0; i < lerpFloat.Count; i++)
            {
                if (lerpFloat[i].a == null)
                {
                    lerpFloat.Remove(lerpFloat[i]);
                    i--;
                }

                lerpFloat[i].a?.Invoke(Mathf.LerpUnclamped(lerpFloat[i].start, lerpFloat[i].end, lerpFloat[i].curve.Evaluate(progress)));
            }
        }

        if (lerpVector2.Count > 0)
        {
            for (int i = 0; i < lerpVector2.Count; i++)
            {
                if (lerpVector2[i].a == null)
                {
                    lerpVector2.Remove(lerpVector2[i]);
                    i--;
                }

                lerpVector2[i].a?.Invoke(Vector2.LerpUnclamped(lerpVector2[i].start, lerpVector2[i].end, lerpVector2[i].curve.Evaluate(progress)));
            }
        }

        if (lerpVector3.Count > 0)
        {
            for (int i = 0; i < lerpVector3.Count; i++)
            {
                if (lerpVector3[i].a == null)
                {
                    lerpVector3.Remove(lerpVector3[i]);
                    i--;
                }

                lerpVector3[i].a?.Invoke(Vector3.LerpUnclamped(lerpVector3[i].start, lerpVector3[i].end, lerpVector3[i].curve.Evaluate(progress)));
            }
        }

        if (lerpRot.Count > 0)
        {
            for (int i = 0; i < lerpRot.Count; i++)
            {
                if (lerpRot[i].a == null)
                {
                    lerpRot.Remove(lerpRot[i]);
                    i--;
                }
                
                lerpRot[i].a?.Invoke(Quaternion.SlerpUnclamped(lerpRot[i].from, lerpRot[i].to, lerpRot[i].curve.Evaluate(progress)));
            }
        }

        if (lerpColor.Count > 0)
        {
            for (int i = 0; i < lerpColor.Count; i++)
            {
                if (lerpColor[i].color == null)
                {
                    lerpColor.Remove(lerpColor[i]);
                    i--;
                }

                lerpColor[i].color?.Invoke(lerpColor[i].gradient.Evaluate(lerpColor[i].curve.Evaluate(progress)));
            }
        }

        if (lerpTarget.Count > 0)
        {
            for (int i = 0; i < lerpTarget.Count; i++)
            {
                if (lerpTarget[i].transform == null || lerpTarget[i].target == null)
                {
                    lerpTarget.Remove(lerpTarget[i]);
                    i--;
                }
                lerpTarget[i].transform.LookAt(lerpTarget[i].target, lerpTarget[i].worldUp);
            }
        }

        if (customActions.Count > 0)
        {
            for (int i = 0; i < customActions.Count; i++)
            {
                if (customActions[i].scale == false && unscaledProgress >= customActions[i].time - Mathf.Epsilon)
                {
                    customActions[i].action?.Invoke();
                    completedCustomActions.Add(customActions[i]);
                    customActions.Remove(customActions[i]);
                    i--;
                }
                else if (customActions[i].scale == true && progress >= customActions[i].time - Mathf.Epsilon)
                {
                    customActions[i].action?.Invoke();
                    completedCustomActions.Add(customActions[i]);
                    customActions.Remove(customActions[i]);
                    i--;
                }
            }
        }
    }

    /// <summary>
    /// Called on tween cancellation. DO NOT USE
    /// </summary>
    public void OnCancel()
    {
        if (canceled) return;

        onCancel?.Invoke();

        if (completeTriggeredOnCancel)
            onComplete?.Invoke();

        if (completeLoopTriggeredOnCancel)
            onCompletedRun?.Invoke();
    }
    public void UpdateTime() => unscaledProgress += Time.unscaledDeltaTime;
    public void UpdatePauseTime() => unscaledPauseTime += Time.unscaledDeltaTime;
    public void UpdateIntervalTime() => unscaledIntervalTime += Time.unscaledDeltaTime;

    /// <summary>
    /// Add time to the tween duration
    /// </summary>
    public void AddDuration(float additionalDelay) => durationWithDelay += additionalDelay;

    /// <summary>
    /// Add time to the tween duration, disposes the old duration value
    /// </summary>
    public void AddDurationUnsafe(float additionalDelay) => duration += additionalDelay;

    /// <summary>
    /// Remap the start and end values of tween time
    /// </summary>
    public static float Remap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}

/// <summary>
/// An Audio instance used to play AudioClips
/// </summary>
[Serializable] public struct Audio
{
    private string ID;
    private AudioSource source;
    private List<AudioClip> clips;
    private float volume;
    private float time;
    private Tween tween;

    /// <summary>
    /// Create new mAudio instance
    /// </summary>
    public static Audio NewClip(AudioClip clip)
    {
        mAudio.TryGetReference();

        if (clip == null)
        {
            Debug.LogError("No clip provided");
            return new Audio();
        }

        return new Audio(clip).SetID();
    }
    public static Audio NewClip(AudioClip[] clips)
    {
        mAudio.TryGetReference();

        if (clips == null)
        {
            Debug.LogError("Clips is null");
            return new Audio();
        }
        else if (clips.Length == 0)
        {
            Debug.LogError("Clips does not contain audioclips");
            return new Audio();
        }

        return new Audio(clips).SetID();
    }
    public static Audio NewClip(List<AudioClip> clips)
    {
        mAudio.TryGetReference();

        if (clips == null)
        {
            Debug.LogError("Clips is null");
            return new Audio();
        }
        else if (clips.Count == 0)
        {
            Debug.LogError("Clips does not contain audioclips");
            return new Audio();
        }

        return new Audio(clips).SetID();
    }

    /// <summary>
    /// Create new mAudio instance with ID
    /// </summary>
    public static Audio NewClip(string ID, AudioClip clip)
    {
        mAudio.TryGetReference();

        if (clip == null)
        {
            Debug.LogError("No clip provided");
            return new Audio();
        }

        return new Audio(clip).SetID(ID);
    }
    public static Audio NewClip(string ID, AudioClip[] clips)
    {
        mAudio.TryGetReference();

        if (clips == null)
        {
            Debug.LogError("Clips is null");
            return new Audio();
        }
        else if (clips.Length == 0)
        {
            Debug.LogError("Clips does not contain audioclips");
            return new Audio();
        }

        return new Audio(clips).SetID(ID);
    }
    public static Audio NewClip(string ID, List<AudioClip> clips)
    {
        mAudio.TryGetReference();

        if (clips == null)
        {
            Debug.LogError("Clips is null");
            return new Audio();
        }
        else if (clips.Count == 0)
        {
            Debug.LogError("Clips does not contain audioclips");
            return new Audio();
        }

        return new Audio(clips).SetID(ID);
    }
    public static Audio NewClip(GameObject ID, AudioClip clip)
    {
        mAudio.TryGetReference();

        if (clip == null)
        {
            Debug.LogError("No clip provided");
            return new Audio();
        }

        return new Audio(clip).SetID(ID);
    }
    public static Audio NewClip(GameObject ID, AudioClip[] clips)
    {
        mAudio.TryGetReference();

        if (clips == null)
        {
            Debug.LogError("Clips is null");
            return new Audio();
        }
        else if (clips.Length == 0)
        {
            Debug.LogError("Clips does not contain audioclips");
            return new Audio();
        }

        return new Audio(clips).SetID(ID);
    }
    public static Audio NewClip(GameObject ID, List<AudioClip> clips)
    {
        mAudio.TryGetReference();

        if (clips == null)
        {
            Debug.LogError("Clips is null");
            return new Audio();
        }
        else if (clips.Count == 0)
        {
            Debug.LogError("Clips does not contain audioclips");
            return new Audio();
        }

        return new Audio(clips).SetID(ID);
    }
    public static Audio NewClip(object ID, AudioClip clip)
    {
        mAudio.TryGetReference();

        if (clip == null)
        {
            Debug.LogError("No clip provided");
            return new Audio();
        }

        return new Audio(clip).SetID(ID);
    }
    public static Audio NewClip(object ID, AudioClip[] clips)
    {
        mAudio.TryGetReference();

        if (clips == null)
        {
            Debug.LogError("Clips is null");
            return new Audio();
        }
        else if (clips.Length == 0)
        {
            Debug.LogError("Clips does not contain audioclips");
            return new Audio();
        }

        return new Audio(clips).SetID(ID);
    }
    public static Audio NewClip(object ID, List<AudioClip> clips)
    {
        mAudio.TryGetReference();

        if (clips == null)
        {
            Debug.LogError("Clips is null");
            return new Audio();
        }
        else if (clips.Count == 0)
        {
            Debug.LogError("Clips does not contain audioclips");
            return new Audio();
        }

        return new Audio(clips).SetID(ID);
    }

    public Audio(AudioClip clip)
    {
        source = mAudio.instance.GetFirstFreeSource();
        clips = new List<AudioClip>();
        clips.Add(clip);
        volume = 1f;
        time = clip.length;
        tween = null;
        ID = null;
    }
    public Audio(AudioClip clip, float volume)
    {
        source = mAudio.instance.GetFirstFreeSource();
        clips = new List<AudioClip>();
        clips.Add(clip);
        time = clip.length;
        source.volume = volume;
        this.volume = volume;
        tween = null;
        ID = null;
    }
    public Audio(AudioClip clip, float volume, float pan)
    {
        source = mAudio.instance.GetFirstFreeSource();
        clips = new List<AudioClip>();
        clips.Add(clip);
        time = clip.length;
        source.volume = volume;
        this.volume = volume;
        source.panStereo = pan;
        tween = null;
        ID = null;
    }
    public Audio(AudioClip clip, float volume, float pan, float pitch)
    {
        source = mAudio.instance.GetFirstFreeSource();
        clips = new List<AudioClip>();
        clips.Add(clip);
        time = clip.length;
        source.volume = volume;
        this.volume = volume;
        source.panStereo = pan;
        source.pitch = pitch;
        tween = null;
        ID = null;
    }
    public Audio(AudioClip clip, float volume, float pan, float pitch, bool loop)
    {
        source = mAudio.instance.GetFirstFreeSource();
        clips = new List<AudioClip>();
        clips.Add(clip);
        time = clip.length;
        source.volume = volume;
        this.volume = volume;
        source.panStereo = pan;
        source.pitch = pitch;
        source.loop = loop;
        tween = null;
        ID = null;
    }
    public Audio(AudioClip[] clips)
    {
        source = mAudio.instance.GetFirstFreeSource();
        this.clips = new List<AudioClip>();

        foreach (AudioClip i in clips)
            this.clips.Add(i);

        time = 1f;
        volume = 1f;
        tween = null;
        ID = null;
    }
    public Audio(AudioClip[] clips, float volume)
    {
        source = mAudio.instance.GetFirstFreeSource();
        this.clips = new List<AudioClip>();

        foreach (AudioClip i in clips)
            this.clips.Add(i);

        time = 1f;
        source.volume = volume;
        this.volume = volume;
        tween = null;
        ID = null;
    }
    public Audio(AudioClip[] clips, float volume, float pan)
    {
        source = mAudio.instance.GetFirstFreeSource();
        this.clips = new List<AudioClip>();

        foreach (AudioClip i in clips)
            this.clips.Add(i);

        time = 1f;
        source.volume = volume;
        this.volume = volume;
        source.panStereo = pan;
        tween = null;
        ID = null;
    }
    public Audio(AudioClip[] clips, float volume, float pan, float pitch)
    {
        source = mAudio.instance.GetFirstFreeSource();
        this.clips = new List<AudioClip>();

        foreach (AudioClip i in clips)
            this.clips.Add(i);

        time = 1f;
        source.volume = volume;
        this.volume = volume;
        source.panStereo = pan;
        source.pitch = pitch;
        tween = null;
        ID = null;
    }
    public Audio(AudioClip[] clips, float volume, float pan, float pitch, bool loop)
    {
        source = mAudio.instance.GetFirstFreeSource();
        this.clips = new List<AudioClip>();

        foreach (AudioClip i in clips)
            this.clips.Add(i);

        time = 1f;
        source.volume = volume;
        this.volume = volume;
        source.panStereo = pan;
        source.pitch = pitch;
        source.loop = loop;
        tween = null;
        ID = null;
    }
    public Audio(List<AudioClip> clips)
    {
        source = mAudio.instance.GetFirstFreeSource();
        this.clips = new List<AudioClip>();

        foreach (AudioClip i in clips)
            this.clips.Add(i);

        time = 1f;
        volume = 1f;
        tween = null;
        ID = null;
    }
    public Audio(List<AudioClip> clips, float volume)
    {
        source = mAudio.instance.GetFirstFreeSource();
        this.clips = new List<AudioClip>();

        foreach (AudioClip i in clips)
            this.clips.Add(i);

        time = 1f;
        source.volume = volume;
        this.volume = volume;
        tween = null;
        ID = null;
    }
    public Audio(List<AudioClip> clips, float volume, float pan)
    {
        source = mAudio.instance.GetFirstFreeSource();
        this.clips = new List<AudioClip>();

        foreach (AudioClip i in clips)
            this.clips.Add(i);

        time = 1f;
        source.volume = volume;
        this.volume = volume;
        source.panStereo = pan;
        tween = null;
        ID = null;
    }
    public Audio(List<AudioClip> clips, float volume, float pan, float pitch)
    {
        source = mAudio.instance.GetFirstFreeSource();
        this.clips = new List<AudioClip>();

        foreach (AudioClip i in clips)
            this.clips.Add(i);

        time = 1f;
        source.volume = volume;
        this.volume = volume;
        source.panStereo = pan;
        source.pitch = pitch;
        tween = null;
        ID = null;
    }
    public Audio(List<AudioClip> clips, float volume, float pan, float pitch, bool loop)
    {
        source = mAudio.instance.GetFirstFreeSource();
        this.clips = new List<AudioClip>();

        foreach (AudioClip i in clips)
            this.clips.Add(i);

        time = 1f;
        source.volume = volume;
        this.volume = volume;
        source.panStereo = pan;
        source.pitch = pitch;
        source.loop = loop;
        tween = null;
        ID = null;
    }

    /// <summary>
    /// Sets a unique ID for this clip
    /// </summary>
    public Audio SetID()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        System.Random random = new System.Random();

        ID = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        return this;
    }
    public Audio SetID(string ID)
    {
        this.ID = ID;
        return this;
    }
    public Audio SetID(GameObject ID)
    {
        this.ID = ID.GetInstanceID().ToString();
        return this;
    }
    public Audio SetID(object ID)
    {
        this.ID = ID.ToString();
        return this;
    }

    /// <summary>
    /// Returns the ID of this clip
    /// </summary>
    public Audio GetID(out string ID)
    {
        ID = this.ID;
        return this;
    }

    public enum ChorusOption { Depth, Delay, Rate, Mix }
    /// <summary>
    /// Plays the clip with a chorus effect
    /// </summary>
    public Audio WithChorus()
    {
        source.gameObject.AddComponent<AudioChorusFilter>();
        return this;
    }
    public Audio WithChorus(float value, ChorusOption option)
    {
        AudioChorusFilter effect = source.gameObject.AddComponent<AudioChorusFilter>();

        switch (option)
        {
            case ChorusOption.Depth: effect.depth = value; break;
            case ChorusOption.Delay: effect.delay = value; break;
            case ChorusOption.Rate: effect.rate = value; break;
            case ChorusOption.Mix: effect.dryMix = value; break;
            default: break;
        }

        return this;
    }
    public Audio GetChorus(out AudioChorusFilter chorus)
    {
        chorus = source.gameObject.GetComponent<AudioChorusFilter>();
        return this;
    }

    public enum LowPassOption { Frequency, Resonance }
    /// <summary>
    /// Plays the clip with a lowpass effect
    /// </summary>
    public Audio WithLowPass(float value)
    {
        AudioLowPassFilter effect = source.gameObject.AddComponent<AudioLowPassFilter>();
        effect.cutoffFrequency = value;

        return this;
    }
    public Audio WithLowPass(float value, LowPassOption option)
    {
        AudioLowPassFilter effect = source.gameObject.AddComponent<AudioLowPassFilter>();

        switch (option)
        {
            case LowPassOption.Frequency: effect.cutoffFrequency = value; break;
            case LowPassOption.Resonance: effect.lowpassResonanceQ = value; break;
            default: break;
        }

        return this;
    }
    public Audio GetLowPass(out AudioLowPassFilter lowPass)
    {
        lowPass = source.gameObject.GetComponent<AudioLowPassFilter>();
        return this;
    }

    public enum HighPassOption { Frequency, Resonance }
    /// <summary>
    /// Plays the clip with a highpass effect
    /// </summary>
    public Audio WithHighPass(float value)
    {
        AudioHighPassFilter effect = source.gameObject.AddComponent<AudioHighPassFilter>();
        effect.cutoffFrequency = value;

        return this;
    }
    public Audio WithHighPass(float value, HighPassOption option)
    {
        AudioHighPassFilter effect = source.gameObject.AddComponent<AudioHighPassFilter>();

        switch (option)
        {
            case HighPassOption.Frequency: effect.cutoffFrequency = value; break;
            case HighPassOption.Resonance: effect.highpassResonanceQ = value; break;
            default: break;
        }

        return this;
    }
    public Audio GetHighPass(out AudioHighPassFilter highPass)
    {
        highPass = source.gameObject.GetComponent<AudioHighPassFilter>();
        return this;
    }

    public enum EchoOption { Delay, DecayRatio, Mix }
    /// <summary>
    /// Plays the clip with a echo effect
    /// </summary>
    public Audio WithEcho(float value)
    {
        AudioEchoFilter effect = source.gameObject.AddComponent<AudioEchoFilter>();
        effect.delay = value;

        return this;
    }
    public Audio WithEcho(float value, EchoOption option)
    {
        AudioEchoFilter effect = source.gameObject.AddComponent<AudioEchoFilter>();

        switch (option)
        {
            case EchoOption.Mix: effect.dryMix = value; break;
            case EchoOption.Delay: effect.delay = value; break;
            case EchoOption.DecayRatio: effect.decayRatio = value; break;
            default: break;
        }

        return this;
    }
    public Audio GetEcho(out AudioEchoFilter echo)
    {
        echo = source.gameObject.GetComponent<AudioEchoFilter>();
        return this;
    }

    public enum ReverbOption { Decay, Density, Diffusion, Mix }
    /// <summary>
    /// Plays the clip with a reverb effect
    /// </summary>
    public Audio WithReverb(float value)
    {
        AudioReverbFilter effect = source.gameObject.AddComponent<AudioReverbFilter>();
        effect.decayTime = value;

        return this;
    }
    public Audio WithReverb(float value, ReverbOption option)
    {
        AudioReverbFilter effect = source.gameObject.AddComponent<AudioReverbFilter>();

        switch (option)
        {
            case ReverbOption.Decay: effect.decayTime = value; break;
            case ReverbOption.Density: effect.density = value; break;
            default: break;
        }

        return this;
    }
    public Audio GetReverb(out AudioReverbFilter reverb)
    {
        reverb = source.gameObject.GetComponent<AudioReverbFilter>();
        return this;
    }

    /// <summary>
    /// Plays the clip at position
    /// </summary>
    public Audio AtPosition(Vector3 position)
    {
        source.transform.position = position;
        return this;
    }
    /// <summary>
    /// Plays the clip at position in local space
    /// </summary>
    public Audio AtLocalPosition(Vector3 position)
    {
        source.transform.localPosition = position;
        return this;
    }

    /// <summary>
    /// Set the volume of this instance
    /// </summary>
    public Audio SetVolume(float volume)
    {
        this.volume = volume;
        source.volume = volume;
        return this;
    }
    /// <summary>
    /// Set the stereo pan of this instance
    /// </summary>
    public Audio SetPan(float pan)
    {
        source.panStereo = pan;
        return this;
    }
    /// <summary>
    /// Set the pitch of this instance
    /// </summary>
    public Audio SetPitch(float pitch)
    {
        source.pitch = pitch;
        return this;
    }
    /// <summary>
    /// Loops this instance
    /// </summary>
    public Audio SetLoop()
    {
        source.loop = true;
        tween.Repeat();
        return this;
    }
    public Audio SetLoop(bool state)
    {
        source.loop = state;
        tween.Repeat();
        return this;
    }
    /// <summary>
    /// Set the output mixergroup of this instance
    /// </summary>
    public Audio SetOutput(AudioMixerGroup output)
    {
        source.outputAudioMixerGroup = output;
        return this;
    }
    /// <summary>
    /// Sets the spatial blend for this instance
    /// </summary>
    public Audio SetSpatialBlend(float spatial)
    {
        source.spatialBlend = spatial;
        return this;
    }
    /// <summary>
    /// Sets the rolloff curve for this clip
    /// </summary>
    public Audio SetRolloff(AnimationCurve curve)
    {
        source.rolloffMode = AudioRolloffMode.Custom;
        source.SetCustomCurve(AudioSourceCurveType.CustomRolloff, curve);
        return this;
    }
    public Audio SetRolloff(AnimationCurve curve, float maxDistance)
    {
        source.rolloffMode = AudioRolloffMode.Custom;
        source.SetCustomCurve(AudioSourceCurveType.CustomRolloff, curve);
        source.maxDistance = maxDistance;
        return this;
    }
    /// <summary>
    /// Sets the max distance for this clip
    /// </summary>
    public Audio SetMaxDistance(float distance)
    {
        source.maxDistance = distance;
        return this;
    }

    /// <summary>
    /// Returns the duration of this clip
    /// </summary>
    public Audio GetDuration(out float duration)
    {
        duration = time;
        return this;
    }
    /// <summary>
    /// Returns the volume of this clip
    /// </summary>
    public Audio GetVolume(out float volume)
    {
        volume = source.volume;
        return this;
    }
    /// <summary>
    /// Returns the pitch of this clip
    /// </summary>
    public Audio GetPitch(out float pitch)
    {
        pitch = source.pitch;
        return this;
    }
    /// <summary>
    /// Returns the stereoPan of this clip
    /// </summary>
    public Audio GetPan(out float pan)
    {
        pan = source.panStereo;
        return this;
    }
    /// <summary>
    /// Returns the spatialBlend of this clip
    /// </summary>
    public Audio GetSpatialBlend(out float spatialBlend)
    {
        spatialBlend = source.spatialBlend;
        return this;
    }
    /// <summary>
    /// Returns the AudioSource of this clip
    /// </summary>
    public Audio GetAudioSource(out AudioSource source)
    {
        source = this.source;
        return this;
    }
    /// <summary>
    /// Returns the AudioClip of this clip
    /// </summary>
    public Audio GetAudioClip(out AudioClip clip)
    {
        clip = source.clip;
        return this;
    }

    /// <summary>
    /// Set random pitch of this instance
    /// </summary>
    public Audio RandomPitch()
    {
        source.pitch = UnityEngine.Random.Range(0f, 1f);
        return this;
    }
    /// <summary>
    /// Set random pitch of this instance, min is clip pitch - range, max is clip pitch + range
    /// </summary>
    public Audio RandomPitch(float range)
    {
        source.pitch = UnityEngine.Random.Range(source.pitch + -range, source.pitch + range);
        return this;
    }
    /// <summary>
    /// Set random pitch of this instance between min and max
    /// </summary>
    public Audio RandomPitch(float min, float max)
    {
        source.pitch = UnityEngine.Random.Range(min, max);
        return this;
    }
    /// <summary>
    /// Set random pitch of this instance based on a probability curve
    /// </summary>
    public Audio RandomPitch(AnimationCurve probability)
    {
        source.pitch = probability.Evaluate(UnityEngine.Random.Range(0f, 1f));
        return this;
    }
    /// <summary>
    /// Set random pitch of this instance based on a probability curve, min is clip pitch - range, max is clip pitch + range
    /// </summary>
    public Audio RandomPitch(float range, AnimationCurve probability)
    {
        float value = probability.Evaluate(UnityEngine.Random.Range(0f, 1f));
        source.pitch = Tween.Remap(value, 0f, 1f, source.pitch - range, source.pitch + range);
        return this;
    }
    /// <summary>
    /// Set random pitch of this instance based on a probability curve scaled by min and max
    /// </summary>
    public Audio RandomPitch(float min, float max, AnimationCurve probability)
    {
        float value = probability.Evaluate(UnityEngine.Random.Range(0f, 1f));
        source.pitch = Tween.Remap(value, 0f, 1f, min, max);
        return this;
    }

    /// <summary>
    /// Set random volume of this instance
    /// </summary>
    public Audio RandomVolume()
    {
        source.volume = UnityEngine.Random.Range(0f, 1f);
        return this;
    }
    /// <summary>
    /// Set random volume of this instance, min is clip volume - range, max is clip volume + range
    /// </summary>
    public Audio RandomVolume(float range)
    {
        source.volume = UnityEngine.Random.Range(source.volume + -range, source.volume + range);
        return this;
    }
    /// <summary>
    /// Set random volume of this instance between min and max
    /// </summary>
    public Audio RandomVolume(float min, float max)
    {
        source.volume = UnityEngine.Random.Range(min, max);
        return this;
    }
    /// <summary>
    /// Set random volume of this instance based on a probability curve
    /// </summary>
    public Audio RandomVolume(AnimationCurve probability)
    {
        source.volume = probability.Evaluate(UnityEngine.Random.Range(0f, 1f));
        return this;
    }
    /// <summary>
    /// Set random volume of this instance based on a probability curve, min is clip volume - range, max is clip volume + range
    /// </summary>
    public Audio RandomVolume(float range, AnimationCurve probability)
    {
        float value = probability.Evaluate(UnityEngine.Random.Range(0f, 1f));
        source.volume = Tween.Remap(value, 0f, 1f, source.volume - range, source.volume + range);
        return this;
    }
    /// <summary>
    /// Set random volume of this instance based on a probability curve scaled by min and max
    /// </summary>
    public Audio RandomVolume(float min, float max, AnimationCurve probability)
    {
        float value = probability.Evaluate(UnityEngine.Random.Range(0f, 1f));
        source.volume = Tween.Remap(value, 0f, 1f, min, max);
        return this;
    }

    /// <summary>
    /// Fades the current clip for seconds going from 0 to volume
    /// </summary>
    public Audio FadeIn(float seconds)
    {
        mTween.NewTween(seconds).VolumeTo(source, 0f, volume);
        return this;
    }
    /// <summary>
    /// Fades the current clip for seconds going from 0 to volume based on curve
    /// </summary>
    public Audio FadeIn(float seconds, AnimationCurve curve)
    {
        mTween.NewTween(seconds).VolumeTo(source, 0f, volume, curve);
        return this;
    }
    /// <summary>
    /// Fades the current clip for seconds towards to
    /// </summary>
    public Audio Fade(float seconds, float to)
    {
        mTween.NewTween(seconds).VolumeTo(source, source.volume, to);
        return this;
    }
    /// <summary>
    /// Fades the current clip for seconds going from towards to
    /// </summary>
    public Audio Fade(float seconds, float from, float to)
    {
        mTween.NewTween(seconds).VolumeTo(source, from, to);
        return this;
    }
    /// <summary>
    /// Fades the current clip for seconds towards to based on curve
    /// </summary>
    public Audio Fade(float seconds, float to, AnimationCurve curve)
    {
        mTween.NewTween(seconds).VolumeTo(source, 0f, to, curve);
        return this;
    }
    /// <summary>
    /// Fades the current clip for seconds going from towards to based on curve
    /// </summary>
    public Audio Fade(float seconds, float from, float to, AnimationCurve curve)
    {
        mTween.NewTween(seconds).VolumeTo(source, from, to, curve);
        return this;
    }
    /// <summary>
    /// Fades the current clip for seconds towards 0
    /// </summary>
    public Audio FadeOut(float seconds)
    {
        mTween.NewTween(seconds).VolumeTo(source, source.volume, 0f);
        return this;
    }
    /// <summary>
    /// Fades the current clip for seconds towards 0 based on curve
    /// </summary>
    public Audio FadeOut(float seconds, AnimationCurve curve)
    {
        mTween.NewTween(seconds).VolumeTo(source, source.volume, 0f, curve);
        return this;
    }

    /// <summary>
    /// Plays the first assigned clip
    /// </summary>
    public Audio Play()
    {
        source.clip = clips[0];
        time = source.clip.length * 1 / source.pitch;
        tween = mTween.NewTween(time + 0.1f).SetOnComplete(Dispose);
        source.Play();
        return this;
    }
    /// <summary>
    /// Plays a randomly selected clip from the assigned clips list
    /// </summary>
    public Audio PlayRandom()
    {
        int i = UnityEngine.Random.Range(0, clips.Count);
        source.clip = clips[i];
        time = source.clip.length * 1 / source.pitch;
        tween = mTween.NewTween(time + 0.1f).SetOnComplete(Dispose);
        source.Play();
        return this;
    }
    /// <summary>
    /// Plays the first assigned clip
    /// </summary>
    public Audio PlayOneShot()
    {
        source.PlayOneShot(clips[0]);
        return this;
    }
    /// <summary>
    /// Plays a randomly selected clip from the assigned clips list
    /// </summary>
    public Audio PlayOneShotRandom()
    {
        int i = UnityEngine.Random.Range(0, clips.Count);
        source.clip = clips[i];
        source.PlayOneShot(clips[i]);
        return this;
    }
    /// <summary>
    /// Stops the current clip from playing
    /// </summary>
    public Audio Stop()
    {
        mTween.NewTween(0.1f).VolumeTo(source, volume, 0f).SetOnComplete(StopThis);
        return this;
    }
    /// <summary>
    /// Pauses the current clip
    /// </summary>
    public Audio Pause()
    {
        mTween.NewTween(0.1f).VolumeTo(source, volume, 0f).SetOnComplete(PauseThis);
        return this;
    }
    /// <summary>
    /// Resumes the current clip
    /// </summary>
    public Audio Resume()
    {
        tween.Resume();
        source.UnPause();
        mTween.NewTween(0.1f).VolumeTo(source, 0f, volume);
        return this;
    }

    private void StopThis()
    {
        source.Stop();
        tween.Cancel();
    }
    private void PauseThis()
    {
        source.Pause();
        tween.Pause();
    }
    private void Dispose()
    {
        mAudio.instance.Dispose(source);
    }
}

/// <summary>
/// Used to add new keyframes to ColorLerp gradient
/// </summary>
[Serializable] public struct ColorTimes
{
    public Color color;
    public float time;

    public ColorTimes(Color c, float t)
    {
        this.color = c;
        this.time = t;
    }
}
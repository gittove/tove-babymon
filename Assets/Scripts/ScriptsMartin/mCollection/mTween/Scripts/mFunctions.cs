using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public partial class Tween
{
    #region Transfrom operations
    /// <summary>
    /// Rotate Transform around a center with a given radius
    /// </summary>
    public Tween MoveAlongCircle(Transform t, float r)
    {
        Vector3 center = new Vector3(t.position.x, t.position.y - r, t.position.z);
        lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        return this;
    }
    public Tween MoveAlongCircle(Transform t, float r, bool inverted)
    {
        Vector3 center = new Vector3(t.position.x, t.position.y - r, t.position.z);
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        else
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f));

        return this;
    }
    public Tween MoveAlongCircle(Transform t, Vector3 center, float r)
    {
        lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        return this;
    }
    public Tween MoveAlongCircle(Transform t, Vector3 center, float r, bool inverted)
    {
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        else
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f));

        return this;
    }
    public Tween MoveAlongCircle(Transform t, float r, AnimationCurve curve)
    {
        Vector3 center = new Vector3(t.position.x, t.position.y - r, t.position.z);
        lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        return this;
    }
    public Tween MoveAlongCircle(Transform t, float r, bool inverted, AnimationCurve curve)
    {
        Vector3 center = new Vector3(t.position.x, t.position.y - r, t.position.z);
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        else
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f, curve));

        return this;
    }
    public Tween MoveAlongCircle(Transform t, Vector3 center, float r, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        return this;
    }
    public Tween MoveAlongCircle(Transform t, Vector3 center, float r, bool inverted, AnimationCurve curve)
    {
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        else
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f, curve));

        return this;
    }

    /// <summary>
    /// Rotate Transform around a center with a given radius in local space
    /// </summary>
    public Tween MoveAlongCircleLocal(Transform t, float r)
    {
        Vector3 center = new Vector3(t.localPosition.x, t.localPosition.y - r, t.localPosition.z);
        lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        return this;
    }
    public Tween MoveAlongCircleLocal(Transform t, float r, bool inverted)
    {
        Vector3 center = new Vector3(t.localPosition.x, t.localPosition.y - r, t.localPosition.z);
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        else
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f));

        return this;
    }
    public Tween MoveAlongCircleLocal(Transform t, Vector3 center, float r)
    {
        lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        return this;
    }
    public Tween MoveAlongCircleLocal(Transform t, Vector3 center, float r, bool inverted)
    {
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        else
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f));

        return this;
    }
    public Tween MoveAlongCircleLocal(Transform t, float r, AnimationCurve curve)
    {
        Vector3 center = new Vector3(t.localPosition.x, t.localPosition.y - r, t.localPosition.z);
        lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        return this;
    }
    public Tween MoveAlongCircleLocal(Transform t, float r, bool inverted, AnimationCurve curve)
    {
        Vector3 center = new Vector3(t.localPosition.x, t.localPosition.y - r, t.localPosition.z);
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        else
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f, curve));

        return this;
    }
    public Tween MoveAlongCircleLocal(Transform t, Vector3 center, float r, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        return this;
    }
    public Tween MoveAlongCircleLocal(Transform t, Vector3 center, float r, bool inverted, AnimationCurve curve)
    {
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        else
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f, curve));

        return this;
    }

    /// <summary>
    /// Rotates Transform to face a target
    /// </summary>
    public Tween RotateTowardsTarget(Transform follower, Transform Target)
    {
        Vector3 dir = (Target.position - follower.position).normalized;
        Quaternion lookDir = Quaternion.LookRotation(dir);

        lerpRot.Add(new RotationLerp((i) => follower.rotation = i, follower.rotation, lookDir));
        return this;
    }
    public Tween RotateTowardsTarget(Transform follower, Transform Target, AnimationCurve curve)
    {
        Vector3 dir = (Target.position - follower.position).normalized;
        Quaternion lookDir = Quaternion.LookRotation(dir);

        lerpRot.Add(new RotationLerp((i) => follower.rotation = i, follower.rotation, lookDir, curve));
        return this;
    }

    /// <summary>
    /// Make a transform face a target transform continiously (instant)
    /// </summary>
    public Tween FaceTargetContinuous(Transform t, Transform target)
    {
        lerpTarget.Add(new ContinuousTargetLerp(t, target));
        return this;
    }
    public Tween FaceTargetContinuous(Transform t, Transform target, Vector3 worldUp)
    {
        lerpTarget.Add(new ContinuousTargetLerp(t, target, worldUp));
        return this;
    }

    /// <summary>
    /// Moves transform towards position
    /// </summary>
    public Tween MoveTo(Transform t, Vector3 to)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.position = i, t.position, to));
        return this;
    }
    public Tween MoveTo(Transform t, Vector3 from, Vector3 to)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.position = i, from, to));
        return this;
    }
    public Tween MoveTo(Transform t, Vector3 to, AnimationCurve curve)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.position = i, t.position, to, curve));
        return this;
    }
    public Tween MoveTo(Transform t, Vector3 from, Vector3 to, AnimationCurve curve)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.position = i, from, to, curve));
        return this;
    }
    public Tween MoveTo(Transform t, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.position = i, t.position, to));
        return this;
    }
    public Tween MoveTo(Transform t, Vector2 from, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.position = i, from, to));
        return this;
    }
    public Tween MoveTo(Transform t, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.position = i, t.position, to, curve));
        return this;
    }
    public Tween MoveTo(Transform t, Vector2 from, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.position = i, from, to, curve));
        return this;
    }

    /// <summary>
    /// Moves transform towards position in local space
    /// </summary>
    public Tween MoveToLocal(Transform t, Vector3 to)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.localPosition = i, t.localPosition, to));
        return this;
    }
    public Tween MoveToLocal(Transform t, Vector3 from, Vector3 to)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.localPosition = i, from, to));
        return this;
    }
    public Tween MoveToLocal(Transform t, Vector3 to, AnimationCurve curve)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.localPosition = i, t.localPosition, to, curve));
        return this;
    }
    public Tween MoveToLocal(Transform t, Vector3 from, Vector3 to, AnimationCurve curve)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.localPosition = i, from, to, curve));
        return this;
    }
    public Tween MoveToLocal(Transform t, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.localPosition = i, t.localPosition, to));
        return this;
    }
    public Tween MoveToLocal(Transform t, Vector2 from, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.localPosition = i, from, to));
        return this;
    }
    public Tween MoveToLocal(Transform t, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.localPosition = i, t.localPosition, to, curve));
        return this;
    }
    public Tween MoveToLocal(Transform t, Vector2 from, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.localPosition = i, from, to, curve));
        return this;
    }

    /// <summary>
    /// Scales Transform towards size
    /// </summary>
    public Tween ScaleTo(Transform t, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.localScale = i, t.localScale, to));
        return this;
    }
    public Tween ScaleTo(Transform t, Vector2 from, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.localScale = i, from, to));
        return this;
    }
    public Tween ScaleTo(Transform t, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.localScale = i, t.localScale, to, curve));
        return this;
    }
    public Tween ScaleTo(Transform t, Vector2 from, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.localScale = i, from, to, curve));
        return this;
    }
    public Tween ScaleTo(Transform t, Vector3 to)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.localScale = i, t.localScale, to));
        return this;
    }
    public Tween ScaleTo(Transform t, Vector3 from, Vector3 to)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.localScale = i, from, to));
        return this;
    }
    public Tween ScaleTo(Transform t, Vector3 to, AnimationCurve curve)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.localScale = i, t.localScale, to, curve));
        return this;
    }
    public Tween ScaleTo(Transform t, Vector3 from, Vector3 to, AnimationCurve curve)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.localScale = i, from, to, curve));
        return this;
    }

    /// <summary>
    /// Rotates Transform towards rotation
    /// </summary>
    public Tween RotateTo(Transform t, Quaternion to)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, t.rotation, to));
        return this;
    }
    public Tween RotateTo(Transform t, Quaternion from, Quaternion to)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, from, to));
        return this;
    }
    public Tween RotateTo(Transform t, Quaternion to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, t.rotation, to, curve));
        return this;
    }
    public Tween RotateTo(Transform t, Quaternion from, Quaternion to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, from, to, curve));
        return this;
    }
    public Tween RotateTo(Transform t, Vector3 to)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, t.rotation, Quaternion.Euler(to)));
        return this;
    }
    public Tween RotateTo(Transform t, Vector3 from, Vector3 to)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, Quaternion.Euler(from), Quaternion.Euler(to)));
        return this;
    }
    public Tween RotateTo(Transform t, Vector3 to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, t.rotation, Quaternion.Euler(to), curve));
        return this;
    }
    public Tween RotateTo(Transform t, Vector3 from, Vector3 to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, Quaternion.Euler(from), Quaternion.Euler(to), curve));
        return this;
    }

    /// <summary>
    /// Rotates Transform around axis towards angle
    /// </summary>
    public Tween AngleTo(Transform t, float to, Vector3 orientation)
    {
        lerpFloat.Add(new floatLerp((i) => t.eulerAngles = orientation * i, t.eulerAngles.magnitude, to));
        return this;
    }
    public Tween AngleTo(Transform t, float to, Vector3 orientation, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.eulerAngles = orientation * i, t.eulerAngles.magnitude, to, curve));
        return this;
    }
    public Tween AngleTo(Transform t, float from, float to, Vector3 orientation)
    {
        lerpFloat.Add(new floatLerp((i) => t.eulerAngles = orientation * i, from, to));
        return this;
    }
    public Tween AngleTo(Transform t, float from, float to, Vector3 orientation, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.eulerAngles = orientation * i, from, to, curve));
        return this;
    }

    /// <summary>
    /// Rotates Transform towards rotation in local space
    /// </summary>
    public Tween RotateToLocal(Transform t, Quaternion to)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, t.localRotation, to));
        return this;
    }
    public Tween RotateToLocal(Transform t, Quaternion from, Quaternion to)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, from, to));
        return this;
    }
    public Tween RotateToLocal(Transform t, Quaternion to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, t.localRotation, to, curve));
        return this;
    }
    public Tween RotateToLocal(Transform t, Quaternion from, Quaternion to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, from, to, curve));
        return this;
    }
    public Tween RotateToLocal(Transform t, Vector3 to)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, t.localRotation, Quaternion.Euler(to)));
        return this;
    }
    public Tween RotateToLocal(Transform t, Vector3 from, Vector3 to)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, Quaternion.Euler(from), Quaternion.Euler(to)));
        return this;
    }
    public Tween RotateToLocal(Transform t, Vector3 to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, t.localRotation, Quaternion.Euler(to), curve));
        return this;
    }
    public Tween RotateToLocal(Transform t, Vector3 from, Vector3 to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, Quaternion.Euler(from), Quaternion.Euler(to), curve));
        return this;
    }
    #endregion

    #region RectTransform operations
    /// <summary>
    /// Rotate RectTransform around a center with a given radius
    /// </summary>
    public Tween MoveAlongCircle(RectTransform t, float r)
    {
        Vector3 center = new Vector3(t.position.x, t.position.y - r, t.position.z);
        lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        return this;
    }
    public Tween MoveAlongCircle(RectTransform t, float r, bool inverted)
    {
        Vector3 center = new Vector3(t.position.x, t.position.y - r, t.position.z);
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        else
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f));

        return this;
    }
    public Tween MoveAlongCircle(RectTransform t, Vector3 center, float r)
    {
        lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        return this;
    }
    public Tween MoveAlongCircle(RectTransform t, Vector3 center, float r, bool inverted)
    {
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        else
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f));

        return this;
    }
    public Tween MoveAlongCircle(RectTransform t, float r, AnimationCurve curve)
    {
        Vector3 center = new Vector3(t.position.x, t.position.y - r, t.position.z);
        lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        return this;
    }
    public Tween MoveAlongCircle(RectTransform t, float r, bool inverted, AnimationCurve curve)
    {
        Vector3 center = new Vector3(t.position.x, t.position.y - r, t.position.z);
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        else
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f, curve));

        return this;
    }
    public Tween MoveAlongCircle(RectTransform t, Vector3 center, float r, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        return this;
    }
    public Tween MoveAlongCircle(RectTransform t, Vector3 center, float r, bool inverted, AnimationCurve curve)
    {
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        else
            lerpFloat.Add(new floatLerp((i) => t.position = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f, curve));

        return this;
    }

    /// <summary>
    /// Rotate RectTransform around a center with a given radius in local space
    /// </summary>
    public Tween MoveAlongCircleLocal(RectTransform t, float r)
    {
        Vector3 center = new Vector3(t.localPosition.x, t.localPosition.y - r, t.localPosition.z);
        lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        return this;
    }
    public Tween MoveAlongCircleLocal(RectTransform t, float r, bool inverted)
    {
        Vector3 center = new Vector3(t.localPosition.x, t.localPosition.y - r, t.localPosition.z);
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        else
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f));

        return this;
    }
    public Tween MoveAlongCircleLocal(RectTransform t, Vector3 center, float r)
    {
        lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        return this;
    }
    public Tween MoveAlongCircleLocal(RectTransform t, Vector3 center, float r, bool inverted)
    {
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2));
        else
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f));

        return this;
    }
    public Tween MoveAlongCircleLocal(RectTransform t, float r, AnimationCurve curve)
    {
        Vector3 center = new Vector3(t.localPosition.x, t.localPosition.y - r, t.localPosition.z);
        lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        return this;
    }
    public Tween MoveAlongCircleLocal(RectTransform t, float r, bool inverted, AnimationCurve curve)
    {
        Vector3 center = new Vector3(t.localPosition.x, t.localPosition.y - r, t.localPosition.z);
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        else
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f, curve));

        return this;
    }
    public Tween MoveAlongCircleLocal(RectTransform t, Vector3 center, float r, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        return this;
    }
    public Tween MoveAlongCircleLocal(RectTransform t, Vector3 center, float r, bool inverted, AnimationCurve curve)
    {
        if (!inverted)
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), 0f, Mathf.PI * 2, curve));
        else
            lerpFloat.Add(new floatLerp((i) => t.localPosition = center + new Vector3(Mathf.Sin(i) * r, Mathf.Cos(i) * r), Mathf.PI * 2, 0f, curve));

        return this;
    }
    /// <summary>
    /// Moves RectTransform towards position
    /// </summary>
    public Tween MoveTo(RectTransform t, Vector3 to)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.anchoredPosition = i, t.anchoredPosition, to));
        return this;
    }
    public Tween MoveTo(RectTransform t, Vector3 from, Vector3 to)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.anchoredPosition = i, from, to));
        return this;
    }
    public Tween MoveTo(RectTransform t, Vector3 to, AnimationCurve curve)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.anchoredPosition = i, t.anchoredPosition, to, curve));
        return this;
    }
    public Tween MoveTo(RectTransform t, Vector3 from, Vector3 to, AnimationCurve curve)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.anchoredPosition = i, from, to, curve));
        return this;
    }
    public Tween MoveTo(RectTransform t, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.anchoredPosition = i, t.anchoredPosition, to));
        return this;
    }
    public Tween MoveTo(RectTransform t, Vector2 from, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.anchoredPosition = i, from, to));
        return this;
    }
    public Tween MoveTo(RectTransform t, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.anchoredPosition = i, t.anchoredPosition, to, curve));
        return this;
    }
    public Tween MoveTo(RectTransform t, Vector2 from, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.anchoredPosition = i, from, to, curve));
        return this;
    }

    /// <summary>
    /// Scales RectTransform towards size
    /// </summary>
    public Tween ScaleTo(RectTransform t, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.sizeDelta = i, t.sizeDelta, to));
        return this;
    }
    public Tween ScaleTo(RectTransform t, Vector2 from, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.sizeDelta = i, from, to));
        return this;
    }
    public Tween ScaleTo(RectTransform t, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.sizeDelta = i, t.sizeDelta, to, curve));
        return this;
    }
    public Tween ScaleTo(RectTransform t, Vector2 from, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.sizeDelta = i, from, to, curve));
        return this;
    }

    /// <summary>
    /// Rotates RectTransform towards rotation
    /// </summary>
    public Tween RotateTo(RectTransform t, Quaternion to)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, t.rotation, to));
        return this;
    }
    public Tween RotateTo(RectTransform t, Quaternion from, Quaternion to)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, from, to));
        return this;
    }
    public Tween RotateTo(RectTransform t, Quaternion to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, t.rotation, to, curve));
        return this;
    }
    public Tween RotateTo(RectTransform t, Quaternion from, Quaternion to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, from, to, curve));
        return this;
    }
    public Tween RotateTo(RectTransform t, Vector3 to)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, t.rotation, Quaternion.Euler(to)));
        return this;
    }
    public Tween RotateTo(RectTransform t, Vector3 from, Vector3 to)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, Quaternion.Euler(from), Quaternion.Euler(to)));
        return this;
    }
    public Tween RotateTo(RectTransform t, Vector3 to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, t.rotation, Quaternion.Euler(to), curve));
        return this;
    }
    public Tween RotateTo(RectTransform t, Vector3 from, Vector3 to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.rotation = i, Quaternion.Euler(from), Quaternion.Euler(to), curve));
        return this;
    }

    /// <summary>
    /// Rotates RectTransform around axis towards angle
    /// </summary>
    public Tween AngleTo(RectTransform t, float to, Vector3 orientation)
    {
        lerpFloat.Add(new floatLerp((i) => t.eulerAngles = orientation * i, t.eulerAngles.magnitude, to));
        return this;
    }
    public Tween AngleTo(RectTransform t, float to, Vector3 orientation, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.eulerAngles = orientation * i, t.eulerAngles.magnitude, to, curve));
        return this;
    }
    public Tween AngleTo(RectTransform t, float from, float to, Vector3 orientation)
    {
        lerpFloat.Add(new floatLerp((i) => t.eulerAngles = orientation * i, from, to));
        return this;
    }
    public Tween AngleTo(RectTransform t, float from, float to, Vector3 orientation, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.eulerAngles = orientation * i, from, to, curve));
        return this;
    }

    /// <summary>
    /// Rotates RectTransform towards rotation in local space
    /// </summary>
    public Tween RotateToLocal(RectTransform t, Quaternion to)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, t.localRotation, to));
        return this;
    }
    public Tween RotateToLocal(RectTransform t, Quaternion from, Quaternion to)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, from, to));
        return this;
    }
    public Tween RotateToLocal(RectTransform t, Quaternion to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, t.localRotation, to, curve));
        return this;
    }
    public Tween RotateToLocal(RectTransform t, Quaternion from, Quaternion to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, from, to, curve));
        return this;
    }
    public Tween RotateToLocal(RectTransform t, Vector3 to)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, t.localRotation, Quaternion.Euler(to)));
        return this;
    }
    public Tween RotateToLocal(RectTransform t, Vector3 from, Vector3 to)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, Quaternion.Euler(from), Quaternion.Euler(to)));
        return this;
    }
    public Tween RotateToLocal(RectTransform t, Vector3 to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, t.localRotation, Quaternion.Euler(to), curve));
        return this;
    }
    public Tween RotateToLocal(RectTransform t, Vector3 from, Vector3 to, AnimationCurve curve)
    {
        lerpRot.Add(new RotationLerp((i) => t.localRotation = i, Quaternion.Euler(from), Quaternion.Euler(to), curve));
        return this;
    }
    #endregion

    #region Alpha operations
    /// <summary>
    /// Lerps CanvasGroup alpha towards value
    /// </summary>
    public Tween AlphaTo(CanvasGroup t, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.alpha = i, t.alpha, to));
        return this;
    }
    public Tween AlphaTo(CanvasGroup t, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.alpha = i, t.alpha, to, curve));
        return this;
    }
    public Tween AlphaTo(CanvasGroup t, float from, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.alpha = i, from, to));
        return this;
    }
    public Tween AlphaTo(CanvasGroup t, float from, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.alpha = i, from, to, curve));
        return this;
    }

    /// <summary>
    /// Lerps Image alpha towards value
    /// </summary>
    public Tween AlphaTo(Image t, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(Image t, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }
    public Tween AlphaTo(Image t, float from, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from), 
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(Image t, float from, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }

    /// <summary>
    /// Lerps RawImage alpha towards value
    /// </summary>
    public Tween AlphaTo(RawImage t, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(RawImage t, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }
    public Tween AlphaTo(RawImage t, float from, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(RawImage t, float from, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }

    /// <summary>
    /// Lerps Text alpha towards value
    /// </summary>
    public Tween AlphaTo(Text t, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(Text t, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }
    public Tween AlphaTo(Text t, float from, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(Text t, float from, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }

    /// <summary>
    /// Lerps SpriteRenderer alpha towards value
    /// </summary>
    public Tween AlphaTo(SpriteRenderer t, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(SpriteRenderer t, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }
    public Tween AlphaTo(SpriteRenderer t, float from, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(SpriteRenderer t, float from, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }
    #endregion

    #region Color operations

    /// <summary>
    /// Lerps Text Color towards value
    /// </summary>
    public Tween ColorTo(Text t, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to)));
        return this;
    }
    public Tween ColorTo(Text t, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to), curve));
        return this;
    }
    public Tween ColorTo(Text t, Color from, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to)));
        return this;
    }
    public Tween ColorTo(Text t, Color from, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to), curve));
        return this;
    }
    public Tween ColorTo(Text t, Gradient gradient)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient));
        return this;
    }
    public Tween ColorTo(Text t, Gradient gradient, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient, curve));
        return this;
    }

    /// <summary>
    /// Lerps Image Color towards value
    /// </summary>
    public Tween ColorTo(Image t, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to)));
        return this;
    }
    public Tween ColorTo(Image t, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to), curve));
        return this;
    }
    public Tween ColorTo(Image t, Color from, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to)));
        return this;
    }
    public Tween ColorTo(Image t, Color from, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to), curve));
        return this;
    }
    public Tween ColorTo(Image t, Gradient gradient)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient));
        return this;
    }
    public Tween ColorTo(Image t, Gradient gradient, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient, curve));
        return this;
    }


    /// <summary>
    /// Lerps RawImage Color towards value
    /// </summary>
    public Tween ColorTo(RawImage t, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to)));
        return this;
    }
    public Tween ColorTo(RawImage t, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to), curve));
        return this;
    }
    public Tween ColorTo(RawImage t, Color from, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to)));
        return this;
    }
    public Tween ColorTo(RawImage t, Color from, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to), curve));
        return this;
    }
    public Tween ColorTo(RawImage t, Gradient gradient)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient));
        return this;
    }
    public Tween ColorTo(RawImage t, Gradient gradient, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient, curve));
        return this;
    }

    /// <summary>
    /// Lerps SpriteRenderer Color towards value
    /// </summary>
    public Tween ColorTo(SpriteRenderer t, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to)));
        return this;
    }
    public Tween ColorTo(SpriteRenderer t, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to), curve));
        return this;
    }
    public Tween ColorTo(SpriteRenderer t, Color from, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to)));
        return this;
    }
    public Tween ColorTo(SpriteRenderer t, Color from, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to), curve));
        return this;
    }
    public Tween ColorTo(SpriteRenderer t, Gradient gradient)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient));
        return this;
    }
    public Tween ColorTo(SpriteRenderer t, Gradient gradient, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient, curve));
        return this;
    }


    #endregion

    #region Material operations

    /// <summary>
    /// Lerps Material Color towards value
    /// </summary>
    public Tween ColorTo(Material t, string value, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.SetColor(value, i), GetGradient(t.color, to)));
        return this;
    }
    public Tween ColorTo(Material t, string value, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.SetColor(value, i), GetGradient(t.color, to), curve));
        return this;
    }
    public Tween ColorTo(Material t, string value, Color from, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.SetColor(value, i), GetGradient(from, to)));
        return this;
    }
    public Tween ColorTo(Material t, string value, Color from, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.SetColor(value, i), GetGradient(from, to), curve));
        return this;
    }
    public Tween ColorTo(Material t, string value, Gradient gradient)
    {
        lerpColor.Add(new ColorLerp((i) => t.SetColor(value, i), gradient));
        return this;
    }
    public Tween ColorTo(Material t, string value, Gradient gradient, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.SetColor(value, i), gradient, curve));
        return this;
    }

    /// <summary>
    /// Lerps Material Float towards value
    /// </summary>
    public Tween ValueTo(Material t, string value, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.SetFloat(value, i), t.GetFloat(value), to));
        return this;
    }
    public Tween ValueTo(Material t, string value, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.SetFloat(value, i), t.GetFloat(value), to, curve));
        return this;
    }
    public Tween ValueTo(Material t, string value, float from, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.SetFloat(value, i), from, to));
        return this;
    }
    public Tween ValueTo(Material t, string value, float from, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.SetFloat(value, i), from, to, curve));
        return this;
    }

    /// <summary>
    /// Lerps Material Vector towards value
    /// </summary>
    public Tween ValueTo(Material t, string value, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.SetVector(value, i), t.GetVector(value), to));
        return this;
    }
    public Tween ValueTo(Material t, string value, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.SetVector(value, i), t.GetVector(value), to, curve));
        return this;
    }
    public Tween ValueTo(Material t, string value, Vector2 from, Vector2 to)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.SetVector(value, i), from, to));
        return this;
    }
    public Tween ValueTo(Material t, string value, Vector2 from, Vector2 to, AnimationCurve curve)
    {
        lerpVector2.Add(new Vector2Lerp((i) => t.SetVector(value, i), from, to, curve));
        return this;
    }
    public Tween ValueTo(Material t, string value, Vector3 to)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.SetVector(value, i), t.GetVector(value), to));
        return this;
    }
    public Tween ValueTo(Material t, string value, Vector3 to, AnimationCurve curve)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.SetVector(value, i), t.GetVector(value), to, curve));
        return this;
    }
    public Tween ValueTo(Material t, string value, Vector3 from, Vector3 to)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.SetVector(value, i), from, to));
        return this;
    }
    public Tween ValueTo(Material t, string value, Vector3 from, Vector3 to, AnimationCurve curve)
    {
        lerpVector3.Add(new Vector3Lerp((i) => t.SetVector(value, i), from, to, curve));
        return this;
    }

    #endregion

    #region TextMesh operations
    /// <summary>
    /// Lerps TextMesh Color towards value
    /// </summary>
    public Tween ColorTo(TextMesh t, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to)));
        return this;
    }
    public Tween ColorTo(TextMesh t, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to), curve));
        return this;
    }
    public Tween ColorTo(TextMesh t, Color from, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to)));
        return this;
    }
    public Tween ColorTo(TextMesh t, Color from, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to), curve));
        return this;
    }
    public Tween ColorTo(TextMesh t, Gradient gradient)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient));
        return this;
    }
    public Tween ColorTo(TextMesh t, Gradient gradient, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient, curve));
        return this;
    }

    /// <summary>
    /// Lerps TextMeshPro Color towards value
    /// </summary>
    public Tween ColorTo(TextMeshPro t, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to)));
        return this;
    }
    public Tween ColorTo(TextMeshPro t, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to), curve));
        return this;
    }
    public Tween ColorTo(TextMeshPro t, Color from, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to)));
        return this;
    }
    public Tween ColorTo(TextMeshPro t, Color from, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to), curve));
        return this;
    }
    public Tween ColorTo(TextMeshPro t, Gradient gradient)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient));
        return this;
    }
    public Tween ColorTo(TextMeshPro t, Gradient gradient, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient, curve));
        return this;
    }

    /// <summary>
    /// Lerps TextMeshProUGUI Color towards value
    /// </summary>
    public Tween ColorTo(TextMeshProUGUI t, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to)));
        return this;
    }
    public Tween ColorTo(TextMeshProUGUI t, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to), curve));
        return this;
    }
    public Tween ColorTo(TextMeshProUGUI t, Color from, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to)));
        return this;
    }
    public Tween ColorTo(TextMeshProUGUI t, Color from, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to), curve));
        return this;
    }
    public Tween ColorTo(TextMeshProUGUI t, Gradient gradient)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient));
        return this;
    }
    public Tween ColorTo(TextMeshProUGUI t, Gradient gradient, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient, curve));
        return this;
    }

    /// <summary>
    /// Lerps TextMesh alpha towards value
    /// </summary>
    public Tween AlphaTo(TextMesh t, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(TextMesh t, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }
    public Tween AlphaTo(TextMesh t, float from, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(TextMesh t, float from, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }

    /// <summary>
    /// Lerps TextMeshPro alpha towards value
    /// </summary>
    public Tween AlphaTo(TextMeshPro t, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(TextMeshPro t, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }
    public Tween AlphaTo(TextMeshPro t, float from, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(TextMeshPro t, float from, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }

    /// <summary>
    /// Lerps TextMeshProUGUI alpha towards value
    /// </summary>
    public Tween AlphaTo(TextMeshProUGUI t, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(TextMeshProUGUI t, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color,
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }
    public Tween AlphaTo(TextMeshProUGUI t, float from, float to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to))));
        return this;
    }
    public Tween AlphaTo(TextMeshProUGUI t, float from, float to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(
                new Color(t.color.r, t.color.g, t.color.b, from),
                new Color(t.color.r, t.color.g, t.color.b, to)), curve));
        return this;
    }
    #endregion

    #region UI operations
    /// <summary>
    /// Lerps Slider towards value
    /// </summary>
    public Tween SliderValueTo(Slider slider, float to)
    {
        lerpFloat.Add(new floatLerp((i) => slider.value = i, slider.value, to));
        return this;
    }
    public Tween SliderValueTo(Slider slider, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => slider.value = i, slider.value, to, curve));
        return this;
    }
    public Tween SliderValueTo(Slider slider, float from, float to)
    {
        lerpFloat.Add(new floatLerp((i) => slider.value = i, from, to));
        return this;
    }
    public Tween SliderValueTo(Slider slider, float from, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => slider.value = i, from, to, curve));
        return this;
    }
    #endregion

    #region Light operations
    /// <summary>
    /// Lerps Light Intensity towards value
    /// </summary>
    public Tween IntensityTo(Light t, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.intensity = i, t.intensity, to));
        return this;
    }
    public Tween IntensityTo(Light t, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.intensity = i, t.intensity, to, curve));
        return this;
    }
    public Tween IntensityTo(Light t, float from, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.intensity = i, from, to));
        return this;
    }
    public Tween IntensityTo(Light t, float from, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.intensity = i, from, to, curve));
        return this;
    }

    /// <summary>
    /// Lerps Light range towards value
    /// </summary>
    public Tween LightRangeTo(Light t, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.range = i, t.range, to));
        return this;
    }
    public Tween LightRangeTo(Light t, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.range = i, t.range, to, curve));
        return this;
    }
    public Tween LightRangeTo(Light t, float from, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.range = i, from, to));
        return this;
    }
    public Tween LightRangeTo(Light t, float from, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.range = i, from, to, curve));
        return this;
    }

    /// <summary>
    /// Lerps Light Color towards value
    /// </summary>
    public Tween ColorTo(Light t, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to)));
        return this;
    }
    public Tween ColorTo(Light t, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(t.color, to), curve));
        return this;
    }
    public Tween ColorTo(Light t, Color from, Color to)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to)));
        return this;
    }
    public Tween ColorTo(Light t, Color from, Color to, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, GetGradient(from, to), curve));
        return this;
    }
    public Tween ColorTo(Light t, Gradient gradient)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient));
        return this;
    }
    public Tween ColorTo(Light t, Gradient gradient, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => t.color = i, gradient, curve));
        return this;
    }
    #endregion

    #region Audio operations
    /// <summary>
    /// Lerps AudioSource volume towards value
    /// </summary>
    public Tween VolumeTo(AudioSource t, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.volume = i, t.volume, to));
        return this;
    }
    public Tween VolumeTo(AudioSource t, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.volume = i, t.volume, to, curve));
        return this;
    }
    public Tween VolumeTo(AudioSource t, float from, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.volume = i, from, to));
        return this;
    }
    public Tween VolumeTo(AudioSource t, float from, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.volume = i, from, to, curve));
        return this;
    }

    /// <summary>
    /// Lerps AudioSource pitch towards value
    /// </summary>
    public Tween PitchTo(AudioSource t, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.pitch = i, t.pitch, to));
        return this;
    }
    public Tween PitchTo(AudioSource t, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.pitch = i, t.pitch, to, curve));
        return this;
    }
    public Tween PitchTo(AudioSource t, float from, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.pitch = i, from, to));
        return this;
    }
    public Tween PitchTo(AudioSource t, float from, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.pitch = i, from, to, curve));
        return this;
    }

    /// <summary>
    /// Lerps AudioMixerGroup value towards value
    /// </summary>
    public Tween ValueTo(AudioMixerGroup t, string value, float to)
    {
        float o;
        t.audioMixer.GetFloat(value, out o);
        lerpFloat.Add(new floatLerp((i) => t.audioMixer.SetFloat(value, i), o, to));
        return this;
    }
    public Tween ValueTo(AudioMixerGroup t, string value, float to, AnimationCurve curve)
    {
        float o;
        t.audioMixer.GetFloat(value, out o);
        lerpFloat.Add(new floatLerp((i) => t.audioMixer.SetFloat(value, i), o, to, curve));
        return this;
    }
    public Tween ValueTo(AudioMixerGroup t, string value, float from, float to)
    {
        lerpFloat.Add(new floatLerp((i) => t.audioMixer.SetFloat(value, i), from, to));
        return this;
    }
    public Tween ValueTo(AudioMixerGroup t, string value, float from, float to, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => t.audioMixer.SetFloat(value, i), from, to, curve));
        return this;
    }
    #endregion

    #region Camera operations
    /// <summary>
    /// Lerps Camera backgroundColor towards value. NOTE: Camera clear flags must be set to Solid Color
    /// </summary>
    public Tween ColorTo(Camera camera, Color end)
    {
        lerpColor.Add(new ColorLerp((i) => camera.backgroundColor = i, GetGradient(camera.backgroundColor, end)));
        return this;
    }
    public Tween ColorTo(Camera camera, Color end, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => camera.backgroundColor = i, GetGradient(camera.backgroundColor, end), curve));
        return this;
    }
    public Tween ColorTo(Camera camera, Color start, Color end)
    {
        lerpColor.Add(new ColorLerp((i) => camera.backgroundColor = i, GetGradient(start, end)));
        return this;
    }
    public Tween ColorTo(Camera camera, Color start, Color end, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => camera.backgroundColor = i, GetGradient(start, end), curve));
        return this;
    }
    public Tween ColorTo(Camera camera, Gradient gradient)
    {
        lerpColor.Add(new ColorLerp((i) => camera.backgroundColor = i, gradient));
        return this;
    }
    public Tween ColorTo(Camera camera, Gradient gradient, AnimationCurve curve)
    {
        lerpColor.Add(new ColorLerp((i) => camera.backgroundColor = i, gradient, curve));
        return this;
    }

    /// <summary>
    /// Interpolate Camera field of view
    /// </summary>
    public Tween FieldOfViewTo(Camera camera, float end)
    {
        lerpFloat.Add(new floatLerp((i) => camera.fieldOfView = i, camera.fieldOfView, end));
        return this;
    }
    public Tween FieldOfViewTo(Camera camera, float end, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => camera.fieldOfView = i, camera.fieldOfView, end, curve));
        return this;
    }
    public Tween FieldOfViewTo(Camera camera, float start, float end)
    {
        lerpFloat.Add(new floatLerp((i) => camera.fieldOfView = i, start, end));
        return this;
    }
    public Tween FieldOfViewTo(Camera camera, float start, float end, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => camera.fieldOfView = i, start, end, curve));
        return this;
    }

    /// <summary>
    /// Interpolate Camera ortographic size
    /// </summary>
    public Tween OrtographicSizeTo(Camera camera, float end)
    {
        lerpFloat.Add(new floatLerp((i) => camera.orthographicSize = i, camera.orthographicSize, end));
        return this;
    }
    public Tween OrtographicSizeTo(Camera camera, float end, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => camera.orthographicSize = i, camera.orthographicSize, end, curve));
        return this;
    }
    public Tween OrtographicSizeTo(Camera camera, float start, float end)
    {
        lerpFloat.Add(new floatLerp((i) => camera.orthographicSize = i, start, end));
        return this;
    }
    public Tween OrtographicSizeTo(Camera camera, float start, float end, AnimationCurve curve)
    {
        lerpFloat.Add(new floatLerp((i) => camera.orthographicSize = i, start, end, curve));
        return this;
    }

    #endregion
}
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;
#endif

[AddComponentMenu("Audio/UI Animation Trigger")]
public class UIAnimationTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private RectTransform rect;
    [SerializeField] private Vector2 sizeIdle, sizeHover;
    [SerializeField] private AnimationCurve animateIn, animateOut, animateClick;
    [SerializeField] private float time = 0.1f;

    [Space]
    public bool animateTransform = false;
    [SerializeField] private Vector3 transformSizeIdle = new Vector3(1,1,1), transformSizeHover = new Vector3(1.2f, 1.2f, 1.2f);

    [Space]
    public UnityEvent onClick;

    private void Awake()
    {
        if(GetComponent<RectTransform>()) rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData) => AnimateEnter();
    public void OnPointerExit(PointerEventData eventData) => AnimateExit();
    public void OnPointerClick(PointerEventData eventData) => AnimateClick();
    private void OnMouseEnter() => AnimateEnter();
    private void OnMouseExit() => AnimateExit();
    public void OnMouseUpAsButton() => AnimateClick();

    public void AnimateEnter()
    {
        if(rect != null)
        {
            mTween.CancelTween(this);
            mTween.NewTween(this, time).ScaleTo(rect, sizeIdle, sizeHover, animateIn);
        }
        else if (animateTransform)
        {
            mTween.CancelTween(this);
            mTween.NewTween(this, time).ScaleTo(transform, transformSizeIdle, transformSizeHover, animateIn);
        }
    }

    public void AnimateExit()
    {
        if (rect != null)
        {
            mTween.CancelTween(this);
            mTween.NewTween(this, time).ScaleTo(rect, sizeHover, sizeIdle, animateOut);
        }
        else if(animateTransform)
        {
            mTween.CancelTween(this);
            mTween.NewTween(this, time).ScaleTo(transform, transformSizeHover, transformSizeIdle, animateOut);
        }
    }

    public void AnimateClick()
    {
        if (rect != null)
        {
            mTween.CancelTween(this);
            mTween.NewTween(this, time).ScaleTo(rect, sizeHover, sizeIdle, animateClick);
        }
        else if (animateTransform)
        {
            mTween.CancelTween(this);
            mTween.NewTween(this, time).ScaleTo(transform, transformSizeHover, transformSizeIdle, animateClick);
        }

        onClick?.Invoke();
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(UIAnimationTrigger))]
public class UIAnimationTriggerEditor : Editor
{
    private SerializedObject uiObject;

    private void OnEnable()
    {
        uiObject = new SerializedObject(target);
    }

    public override void OnInspectorGUI()
    {
        if(uiObject != null)
        {
            using (new EditorGUILayout.VerticalScope())
            {
                using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                {
                    Label("Animation Curve", 2);

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("In", GUILayout.Width(40));
                        EditorGUILayout.PropertyField(uiObject.FindProperty("animateIn"), GUIContent.none);
                    }

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("Out", GUILayout.Width(40));
                        EditorGUILayout.PropertyField(uiObject.FindProperty("animateOut"), GUIContent.none);
                    }

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("Click", GUILayout.Width(40));
                        EditorGUILayout.PropertyField(uiObject.FindProperty("animateClick"), GUIContent.none);
                    }
                }

                using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                {
                    Label("2D Size", 2);

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("Idle Size", GUILayout.Width(80));
                        EditorGUILayout.PropertyField(uiObject.FindProperty("sizeIdle"), GUIContent.none);
                    }

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("Hover Size", GUILayout.Width(80));
                        EditorGUILayout.PropertyField(uiObject.FindProperty("sizeHover"), GUIContent.none);
                    }
                }

                using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                {
                    if(GUILayout.Button("3D Size", GetLabelStyle()))
                    {
                        uiObject.FindProperty("animateTransform").boolValue = !uiObject.FindProperty("animateTransform").boolValue;
                    }

                    if (uiObject.FindProperty("animateTransform").boolValue)
                    {
                        EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 1), new Color(0.15f, 0.15f, 0.15f, 1f));
                        EditorGUILayout.Space(2);

                        using (new EditorGUILayout.HorizontalScope())
                        {
                            EditorGUILayout.LabelField("Idle Size", GUILayout.Width(80));
                            EditorGUILayout.PropertyField(uiObject.FindProperty("transformSizeIdle"), GUIContent.none);
                        }

                        using (new EditorGUILayout.HorizontalScope())
                        {
                            EditorGUILayout.LabelField("Hover Size", GUILayout.Width(80));
                            EditorGUILayout.PropertyField(uiObject.FindProperty("transformSizeHover"), GUIContent.none);
                        }
                    }
                }
            }
        }
    }

    private void Label(string label, int space)
    {
        EditorGUILayout.LabelField(label, GetLabelStyle());
        EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 1), new Color(0.15f, 0.15f, 0.15f, 1f));
        EditorGUILayout.Space(space);
    }

    public GUIStyle GetLabelStyle()
    {
        GUIStyle i = new GUIStyle();
        i.fontStyle = FontStyle.Bold;
        i.fontSize = 14;
        i.normal.textColor = new Color(0.8f, 0.8f, 0.8f,1f);
        i.alignment = TextAnchor.MiddleCenter;
        return i;
    }
}
# endif
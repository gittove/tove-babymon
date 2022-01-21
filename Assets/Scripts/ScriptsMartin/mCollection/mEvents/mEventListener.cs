using UnityEngine.Events;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[AddComponentMenu("mEvents/mEvents Listener")]
public class mEventListener : MonoBehaviour
{
    public int currentEventType = 0;

    public GameEvent gameEvent;
    public UnityEvent onEventTriggered;

    public GameEventFloat gameEventFloat;
    public UnityEvent<float> onEventTriggeredFloat;

    public GameEventInt gameEventInt;
    public UnityEvent<int> onEventTriggeredInt;

    public GameEventBool gameEventBool;
    public UnityEvent<bool> onEventTriggeredBool;

    public GameEventChar gameEventChar;
    public UnityEvent<char> onEventTriggeredChar;

    public GameEventString gameEventString;
    public UnityEvent<string> onEventTriggeredString;

    public GameEventVector2 gameEventVector2;
    public UnityEvent<Vector2> onEventTriggeredVector2;

    public GameEventVector3 gameEventVector3;
    public UnityEvent<Vector3> onEventTriggeredVector3;

    public GameEventColor gameEventColor;
    public UnityEvent<Color> onEventTriggeredColor;

    public GameEventObject gameEventObject;
    public UnityEvent<object> onEventTriggeredObject;

    private void OnEnable()
    {
        if (onEventTriggered != null) gameEvent?.AddListener(onEventTriggered);
        if (onEventTriggeredFloat != null) gameEventFloat?.AddListener(onEventTriggeredFloat);
        if (onEventTriggeredInt != null) gameEventInt?.AddListener(onEventTriggeredInt);
        if (onEventTriggeredBool != null) gameEventBool?.AddListener(onEventTriggeredBool);
        if (onEventTriggeredChar != null) gameEventChar?.AddListener(onEventTriggeredChar);
        if (onEventTriggeredString != null) gameEventString?.AddListener(onEventTriggeredString);
        if (onEventTriggeredVector2 != null) gameEventVector2?.AddListener(onEventTriggeredVector2);
        if (onEventTriggeredVector3 != null) gameEventVector3?.AddListener(onEventTriggeredVector3);
        if (onEventTriggeredColor != null) gameEventColor?.AddListener(onEventTriggeredColor);
        if (onEventTriggeredObject != null) gameEventObject?.AddListener(onEventTriggeredObject);
    }
    private void OnDisable()
    {
        if (onEventTriggered != null) gameEvent?.RemoveListener(onEventTriggered);
        if (onEventTriggeredFloat != null) gameEventFloat?.RemoveListener(onEventTriggeredFloat);
        if (onEventTriggeredInt != null) gameEventInt?.RemoveListener(onEventTriggeredInt);
        if (onEventTriggeredBool != null) gameEventBool?.RemoveListener(onEventTriggeredBool);
        if (onEventTriggeredChar != null) gameEventChar?.RemoveListener(onEventTriggeredChar);
        if (onEventTriggeredString != null) gameEventString?.RemoveListener(onEventTriggeredString);
        if (onEventTriggeredVector2 != null) gameEventVector2?.RemoveListener(onEventTriggeredVector2);
        if (onEventTriggeredVector3 != null) gameEventVector3?.RemoveListener(onEventTriggeredVector3);
        if (onEventTriggeredColor != null) gameEventColor?.RemoveListener(onEventTriggeredColor);
        if (onEventTriggeredObject != null) gameEventObject?.RemoveListener(onEventTriggeredObject);
    }

    public void Debug() => print("Debug");
    public void Debug(float value) => print(value);
    public void Debug(int value) => print(value);
    public void Debug(bool value) => print(value);
    public void Debug(char value) => print(value);
    public void Debug(string value) => print(value);
    public void Debug(Vector2 value) => print(value);
    public void Debug(Vector3 value) => print(value);
    public void Debug(Color value) => print(value);
    public void Debug(object value) => print(value);
}

#if UNITY_EDITOR
[CustomEditor(typeof(mEventListener))]
[CanEditMultipleObjects]
public class mEventListenerEditor : Editor
{
    SerializedProperty gameEvent;
    SerializedProperty onEventTriggered;
    SerializedProperty gameEventFloat;
    SerializedProperty onEventTriggeredFloat;
    SerializedProperty gameEventInt;
    SerializedProperty onEventTriggeredInt;
    SerializedProperty gameEventBool;
    SerializedProperty onEventTriggeredBool;
    SerializedProperty gameEventChar;
    SerializedProperty onEventTriggeredChar;
    SerializedProperty gameEventString;
    SerializedProperty onEventTriggeredString;
    SerializedProperty gameEventVector2;
    SerializedProperty onEventTriggeredVector2;
    SerializedProperty gameEventVector3;
    SerializedProperty onEventTriggeredVector3;
    SerializedProperty gameEventColor;
    SerializedProperty onEventTriggeredColor;
    SerializedProperty gameEventObject;
    SerializedProperty onEventTriggeredObject;

    private void OnEnable()
    {
        gameEvent = serializedObject.FindProperty("gameEvent");
        gameEventFloat = serializedObject.FindProperty("gameEventFloat");
        gameEventInt = serializedObject.FindProperty("gameEventInt");
        gameEventBool = serializedObject.FindProperty("gameEventBool");
        gameEventChar = serializedObject.FindProperty("gameEventChar");
        gameEventString = serializedObject.FindProperty("gameEventString");
        gameEventVector2 = serializedObject.FindProperty("gameEventVector2");
        gameEventVector3 = serializedObject.FindProperty("gameEventVector3");
        gameEventColor = serializedObject.FindProperty("gameEventColor");
        gameEventObject = serializedObject.FindProperty("gameEventObject");

        onEventTriggered = serializedObject.FindProperty("onEventTriggered");
        onEventTriggeredFloat = serializedObject.FindProperty("onEventTriggeredFloat");
        onEventTriggeredInt = serializedObject.FindProperty("onEventTriggeredInt");
        onEventTriggeredBool = serializedObject.FindProperty("onEventTriggeredBool");
        onEventTriggeredChar = serializedObject.FindProperty("onEventTriggeredChar");
        onEventTriggeredString = serializedObject.FindProperty("onEventTriggeredString");
        onEventTriggeredVector2 = serializedObject.FindProperty("onEventTriggeredVector2");
        onEventTriggeredVector3 = serializedObject.FindProperty("onEventTriggeredVector3");
        onEventTriggeredColor = serializedObject.FindProperty("onEventTriggeredColor");
        onEventTriggeredObject = serializedObject.FindProperty("onEventTriggeredObject");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Title("mEvent Listener");

        switch (serializedObject.FindProperty("currentEventType").intValue)
        {
            case 0: DrawEvent(gameEvent, onEventTriggered); break;
            case 1: DrawEvent(gameEventFloat, onEventTriggeredFloat); break;
            case 2: DrawEvent(gameEventInt, onEventTriggeredInt); break;
            case 3: DrawEvent(gameEventBool, onEventTriggeredBool); break;
            case 4: DrawEvent(gameEventChar, onEventTriggeredChar); break;
            case 5: DrawEvent(gameEventString, onEventTriggeredString); break;
            case 6: DrawEvent(gameEventVector2, onEventTriggeredVector2); break;
            case 7: DrawEvent(gameEventVector3, onEventTriggeredVector3); break;
            case 8: DrawEvent(gameEventColor, onEventTriggeredColor); break;
            case 9: DrawEvent(gameEventObject, onEventTriggeredObject); break;
        }
        serializedObject.ApplyModifiedProperties();
    }

    public void DrawEvent(SerializedProperty eventObject, SerializedProperty unityEvent)
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox)) 
        { 
            using (new GUILayout.HorizontalScope())
            {
                EditorGUILayout.PropertyField(eventObject, GUIContent.none);

                serializedObject.FindProperty("currentEventType").intValue = EditorGUILayout.Popup(serializedObject.FindProperty("currentEventType").intValue, new string[]
                {
                " Basic",
                " Float",
                " Int",
                " Bool",
                " Char",
                " String",
                " Vec2",
                " Vec3",
                " Color",
                " Object"
                }, GUILayout.Width(80));
            }

            using (new GUILayout.VerticalScope())
            {
                if (eventObject.objectReferenceValue != null)
                {
                    EditorGUILayout.PropertyField(unityEvent);
                }
                else
                {
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Please create a new " + eventObject.name + " or select a pre-existing one", GetHelpboxStyle());
                    EditorGUILayout.Space();
                    EditorGUILayout.EndVertical();
                }
            }
        }
    }

    public GUIStyle GetLabelStyle()
    {
        GUIStyle x = new GUIStyle();
        x.fontSize = 14;
        x.fontStyle = FontStyle.Bold;
        x.alignment = TextAnchor.MiddleCenter;
        x.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
        return x;
    }

    public GUIStyle GetHelpboxStyle()
    {
        GUIStyle x = new GUIStyle();
        x.padding = new RectOffset(6,6,0,0);
        x.wordWrap = true;
        x.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
        return x;
    }

    void Title(string title)
    {
        EditorGUILayout.Space(5);
        EditorGUI.LabelField(GUILayoutUtility.GetRect(200, 24), title, GetLabelStyle());
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(1, 1), new Color(0, 0, 0, 0.5f));
        EditorGUILayout.Space();
    }
}
#endif
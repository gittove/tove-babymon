using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(mEvents))]
[CanEditMultipleObjects]
public class mEventsEditor : Editor
{
    SerializedProperty canTrigger;
    SerializedProperty currentTab;
    SerializedProperty inputEvents;
    private static bool Input = false;
    private static bool Monobehaviour = false;
    private static bool Settings = false;

    private mEvents mEvent;
    private bool editingEvents;

    SerializedProperty monoEvents;
    public string[] monoEventsString;
    public int index = 0;
    int next;
    private void OnEnable()
    {
        ResetInspector();
    }
    private void Reset()
    {
        ResetInspector();
    }

    private void OnValidate()
    {
        ResetInspector();
    }
    private void ResetInspector()
    {
        mEvent = (mEvents)target;
        canTrigger = serializedObject.FindProperty("canTrigger");
        currentTab = serializedObject.FindProperty("currentTab");
        inputEvents = serializedObject.FindProperty("inputEvents");

        if (mEvent.monoEvents.Count <= 0)
        {
            mEvent.layerMask = LayerMask.NameToLayer("Default");
            mEvent.layerMask2D = LayerMask.NameToLayer("Default");
            mEvent.monoEvents = new List<mMonoType>
        {
            new mMonoType(false, false, "onAwake"),
            new mMonoType(false, false, "onStart"),
            new mMonoType(false, false, "onUpdate"),
            new mMonoType(false, false, "onLateUpdate"),
            new mMonoType(false, false, "onFixedUpdate"),
            new mMonoType(false, false, "onEnable"),
            new mMonoType(false, false, "onDisable"),
            new mMonoType(false, false, "onDestroy"),
            new mMonoType(false, false, "onTriggerEnter"),
            new mMonoType(false, false, "onTriggerStay"),
            new mMonoType(false, false, "onTriggerExit"),
            new mMonoType(false, false, "onTriggerEnter2D"),
            new mMonoType(false, false, "onTriggerStay2D"),
            new mMonoType(false, false, "onTriggerExit2D"),
            new mMonoType(false, false, "onCollisionEnter"),
            new mMonoType(false, false, "onCollisionStay"),
            new mMonoType(false, false, "onCollisionExit"),
            new mMonoType(false, false, "onCollisionEnter2D"),
            new mMonoType(false, false, "onCollisionStay2D"),
            new mMonoType(false, false, "onCollisionExit2D"),
            new mMonoType(false, false, "onMouseEnter"),
            new mMonoType(false, false, "onMouseOver"),
            new mMonoType(false, false, "onMouseExit"),
            new mMonoType(false, false, "onMouseDown"),
            new mMonoType(false, false, "onMouseUp"),
            new mMonoType(false, false, "onMouseUpAsButton"),
        };
        }

        monoEventsString = new string[mEvent.monoEvents.Count - 1];

        for (int i = 0; i < monoEventsString.Length; i++)
            monoEventsString[i] = mEvent.monoEvents[i].ID;

        monoEvents = serializedObject.FindProperty("monoEvents");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Title("mEvents");

        float labelWidth = EditorGUIUtility.labelWidth;

        EditorGUIUtility.labelWidth = 70;
        currentTab.intValue = GUILayout.Toolbar(currentTab.intValue, new string[] { "Custom Events", "Mono Events", "Settings" }, GUILayout.MinHeight(26));

        SelectTab();

        if (Input)
        {
            using (new EditorGUILayout.HorizontalScope(EditorStyles.helpBox))
            {
                EditorGUIUtility.labelWidth = 36;
                EditorGUILayout.PropertyField(inputEvents.FindPropertyRelative("Array.size"), new GUIContent("Keys"));
                EditorGUIUtility.labelWidth = 70;

                if (GUILayout.Button("+", GUILayout.Width(20)))
                {
                    mEvent.AddNewEvent();
                }

                if (GUILayout.Button("-", GUILayout.Width(20)))
                {
                    if (inputEvents.arraySize - 1 < 0)
                        inputEvents.arraySize = 0;
                    else
                        inputEvents.arraySize -= 1;
                }

                if (GUILayout.Button("Edit", GUILayout.Width(36))) editingEvents = !editingEvents;
            }

            for (int i = 0; i < inputEvents.arraySize; i++)
                KeyboardEvent(inputEvents, i);
        }
        if (Monobehaviour)
        {
            using (new EditorGUILayout.HorizontalScope(EditorStyles.helpBox)) 
            {
                index = EditorGUILayout.Popup(index, monoEventsString);
                if (GUILayout.Button("Add Event", GUILayout.Width(80)))
                {
                    for (int i = 0; i < monoEvents.arraySize; i++)
                    {
                        if (index == i)
                        {
                            mEvent.monoEvents[i].Visible = true;
                            mEvent.monoEvents[i].Expanded = true;

                            if (index < monoEventsString.Length)
                                index++;

                            break;
                        }
                        else
                            continue;
                    }
                }

                if (GUILayout.Button("Edit", GUILayout.Width(36))) editingEvents = !editingEvents;
            }
            DrawMonoBehaviourEvents();
        }
        if (Settings)
        {
            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox)) 
            {
                EditorGUIUtility.labelWidth = 80;
                EditorGUILayout.PropertyField(canTrigger);
            }
        }

        EditorGUIUtility.labelWidth = labelWidth;

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawMonoBehaviourEvents()
    {
        for (int i = 0; i < monoEvents.arraySize; i++)
        {
            mMonoType currentEvent = mEvent.monoEvents[i];

            if (currentEvent.Visible)
            {
                using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                {
                    using (new EditorGUILayout.HorizontalScope(GUILayout.Height(24)))
                    {
                        if (GUILayout.Button(currentEvent.ID, GetLabelStyle(), GUILayout.ExpandWidth(true)))
                        {
                            currentEvent.Expanded = !currentEvent.Expanded;
                        }
                        if (editingEvents && GUILayout.Button("✖", GUILayout.Width(20)))
                        {
                            currentEvent.Visible = false;
                            serializedObject.ApplyModifiedProperties();
                            break;
                        }
                    }

                    if (!currentEvent.Expanded) continue;

                    Divider();
                    EditorGUILayout.Space();

                    if ((currentEvent.ID.Contains("Trigger") || currentEvent.ID.Contains("Collision")) && !currentEvent.ID.Contains("2D"))
                    {
                        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                        {
                            if (GUILayout.Button("Modifiers", GetLabelStyle()))
                            {
                                mEvent.triggerType.performAction = !mEvent.triggerType.performAction;
                            }

                            if (!mEvent.triggerType.performAction)
                            {
                                Space();

                                using (new EditorGUILayout.HorizontalScope())
                                {
                                    EditorGUILayout.LabelField(" Mask", GUILayout.Width(36));
                                    EditorGUILayout.PropertyField(serializedObject.FindProperty("layerMask"), GUIContent.none, true);
                                }
                                using (new EditorGUILayout.HorizontalScope())
                                {
                                    EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerType").FindPropertyRelative("SendMessage"), GUIContent.none, true, GUILayout.Width(16));
                                    EditorGUILayout.LabelField("Send Message", GUILayout.Width(100));
                                }

                                if (serializedObject.FindProperty("triggerType").FindPropertyRelative("SendMessage").boolValue)
                                {
                                    using (new EditorGUILayout.HorizontalScope())
                                    {
                                        EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerType").FindPropertyRelative("Message"));

                                        switch (mEvent.triggerType.messageType)
                                        {
                                            case mTriggerTypeEnum.None: break;
                                            case mTriggerTypeEnum.Float: EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerType").FindPropertyRelative("messageInfoFloat"), GUIContent.none, GUILayout.Width(80)); break;
                                            case mTriggerTypeEnum.Int: EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerType").FindPropertyRelative("messageInfoInt"), GUIContent.none, GUILayout.Width(80)); break;
                                            case mTriggerTypeEnum.Bool: EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerType").FindPropertyRelative("messageInfoBool"), GUIContent.none, GUILayout.Width(16)); break;
                                            case mTriggerTypeEnum.String: EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerType").FindPropertyRelative("messageInfoString"), GUIContent.none, GUILayout.Width(80)); break;
                                            default: break;
                                        }

                                        mEvent.triggerType.messageType = (mTriggerTypeEnum)EditorGUILayout.EnumPopup(mEvent.triggerType.messageType, GUILayout.Width(64));
                                        serializedObject.ApplyModifiedProperties();
                                    }
                                }
                            }
                            else
                            {
                                EditorGUILayout.Space();
                            }
                        }
                        Space();
                    }
                    else if ((currentEvent.ID.Contains("Trigger") || currentEvent.ID.Contains("Collision")) && currentEvent.ID.Contains("2D"))
                    {
                        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                        {
                            if (GUILayout.Button("Modifiers", GetLabelStyle()))
                            {
                                mEvent.triggerType2D.performAction = !mEvent.triggerType2D.performAction;
                            }

                            if (!mEvent.triggerType2D.performAction)
                            {
                                Space();

                                using (new EditorGUILayout.HorizontalScope())
                                {
                                    EditorGUILayout.LabelField(" Mask", GUILayout.Width(36));
                                    EditorGUILayout.PropertyField(serializedObject.FindProperty("layerMask2D"), GUIContent.none, true);
                                }
                                using (new EditorGUILayout.HorizontalScope())
                                {
                                    EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerType2D").FindPropertyRelative("SendMessage"), GUIContent.none, true, GUILayout.Width(16));
                                    EditorGUILayout.LabelField("Send Message", GUILayout.Width(100));
                                }

                                if (serializedObject.FindProperty("triggerType2D").FindPropertyRelative("SendMessage").boolValue)
                                {
                                    using (new EditorGUILayout.HorizontalScope())
                                    {
                                        EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerType2D").FindPropertyRelative("Message"));

                                        switch (mEvent.triggerType2D.messageType)
                                        {
                                            case mTriggerTypeEnum.None: break;
                                            case mTriggerTypeEnum.Float: EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerType").FindPropertyRelative("messageInfoFloat"), GUIContent.none, GUILayout.Width(80)); break;
                                            case mTriggerTypeEnum.Int: EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerType").FindPropertyRelative("messageInfoInt"), GUIContent.none, GUILayout.Width(80)); break;
                                            case mTriggerTypeEnum.Bool: EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerType").FindPropertyRelative("messageInfoBool"), GUIContent.none, GUILayout.Width(16)); break;
                                            case mTriggerTypeEnum.String: EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerType").FindPropertyRelative("messageInfoString"), GUIContent.none, GUILayout.Width(80)); break;
                                            default: break;
                                        }

                                        mEvent.triggerType2D.messageType = (mTriggerTypeEnum)EditorGUILayout.EnumPopup(mEvent.triggerType2D.messageType, GUILayout.Width(64));
                                        serializedObject.ApplyModifiedProperties();
                                    }
                                }
                            }
                            else
                            {
                                EditorGUILayout.Space();
                            }
                        }
                        Space();
                    }

                    EditorGUILayout.PropertyField(serializedObject.FindProperty("monoEvents").GetArrayElementAtIndex(i).FindPropertyRelative("unityEvent"));
                }
            }
        }
        serializedObject.ApplyModifiedProperties();
    }

    private void KeyboardEvent(SerializedProperty list, int i)
    {
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            using (new EditorGUILayout.HorizontalScope(GUILayout.Height(24)))
            {
                string label = GetRelativeProperty(list, i, "ID").stringValue == "" ? "New Event" : GetRelativeProperty(list, i, "ID").stringValue;
                string settings = GetRelativeProperty(list, i, "inSettings").intValue == 0 ? "Settings" : "Return";

                if (GUILayout.Button(label, GetLabelStyle(), GUILayout.ExpandWidth(true)))
                {
                    GetRelativeProperty(list, i, "expanded").boolValue = !GetRelativeProperty(list, i, "expanded").boolValue;
                }

                if (GetRelativeProperty(list, i, "expanded").boolValue && GUILayout.Button(settings, GUILayout.Width(70)))
                {
                    if (GetRelativeProperty(list, i, "inSettings").intValue == 0)
                        GetRelativeProperty(list, i, "inSettings").intValue = 1;
                    else if (GetRelativeProperty(list, i, "inSettings").intValue == 1)
                        GetRelativeProperty(list, i, "inSettings").intValue = 0;
                }

                if (editingEvents && GUILayout.Button("↑", GUILayout.Width(20)))
                {
                    list.MoveArrayElement(i, i - 1);
                }
                if (editingEvents && GUILayout.Button("↓", GUILayout.Width(20)))
                {
                    list.MoveArrayElement(i, i + 1);
                }
                if (editingEvents && GUILayout.Button("✖", GUILayout.Width(20)))
                {
                    if (i >= 0)
                    {
                        list.DeleteArrayElementAtIndex(i);
                        return;
                    }
                }

            }
            if (GetRelativeProperty(list, i, "expanded").boolValue)
            {
                Divider();

                if (GetRelativeProperty(list, i, "inSettings").intValue == 0)
                {
                    SerializedProperty x = list.GetArrayElementAtIndex(i);

                    x.FindPropertyRelative("localOrGlobal").intValue = GUILayout.Toolbar(x.FindPropertyRelative("localOrGlobal").intValue, new string[] { "Local Event", "Global Event" });
                    if(x.FindPropertyRelative("localOrGlobal").intValue == 0)
                    {
                        EditorGUILayout.PropertyField(x.FindPropertyRelative("inputEvent"), GUIContent.none);
                    }
                    else
                    {
                        switch (x.FindPropertyRelative("currentEventType").intValue)
                        {
                            case 0: DrawEvent(x, x.FindPropertyRelative("gameEvent")); break;
                            case 1: DrawEvent(x, x.FindPropertyRelative("gameEventFloat"), x.FindPropertyRelative("gameEventFloatValue")); break;
                            case 2: DrawEvent(x, x.FindPropertyRelative("gameEventInt"), x.FindPropertyRelative("gameEventIntValue")); break;
                            case 3: DrawEvent(x, x.FindPropertyRelative("gameEventBool"), x.FindPropertyRelative("gameEventBoolValue")); break;
                            case 4: DrawEvent(x, x.FindPropertyRelative("gameEventChar"), x.FindPropertyRelative("gameEventCharValue")); break;
                            case 5: DrawEvent(x, x.FindPropertyRelative("gameEventString"), x.FindPropertyRelative("gameEventStringValue")); break;
                            case 6: DrawEvent(x, x.FindPropertyRelative("gameEventVector2"), x.FindPropertyRelative("gameEventVector2Value")); break;
                            case 7: DrawEvent(x, x.FindPropertyRelative("gameEventVector3"), x.FindPropertyRelative("gameEventVector3Value")); break;
                            case 8: DrawEvent(x, x.FindPropertyRelative("gameEventColor"), x.FindPropertyRelative("gameEventColorValue")); break;
                            case 9: DrawEvent(x, x.FindPropertyRelative("gameEventObject"), x.FindPropertyRelative("gameEventColorObject")); break;
                        }
                    }
                }
                else
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("Event ID: ", GUILayout.Width(60));
                        GetRelativeProperty(list, i, "ID").stringValue = EditorGUILayout.TextField(GetRelativeProperty(list, i, "ID").stringValue);
                    }

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("Can Trigger", GUILayout.Width(70));
                        GetRelativeProperty(list, i, "canTrigger").boolValue = EditorGUILayout.Toggle(GetRelativeProperty(list, i, "canTrigger").boolValue);
                    }

                    Divider();

                    InputCombination(i);
                }
            }
        }
    }
    private void InputCombination(int i)
    {
        SerializedProperty array = inputEvents.GetArrayElementAtIndex(i).FindPropertyRelative("Combination");

        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("+", GUILayout.Width(20)))
                array.arraySize += 1;

            if (GUILayout.Button("-", GUILayout.Width(20)))
            {
                if (array.arraySize - 1 >= 0)
                    array.arraySize -= 1;
            }

            EditorGUILayout.LabelField("Input Combination");
        }

        GUI.backgroundColor = Color.black;
        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
        {
            GUI.backgroundColor = Color.white;

            for (int x = 0; x < array.arraySize; x++)
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUIUtility.labelWidth = 60;
                    EditorGUILayout.PropertyField(array.GetArrayElementAtIndex(x).FindPropertyRelative("Keypress"), GUILayout.Width(120));
                    EditorGUIUtility.labelWidth = 30;
                    EditorGUILayout.PropertyField(array.GetArrayElementAtIndex(x).FindPropertyRelative("key"));
                    EditorGUIUtility.labelWidth = 70;

                    if (GUILayout.Button("↑", GUILayout.Width(20)))
                    {
                        array.MoveArrayElement(x, x - 1);
                    }

                    if (GUILayout.Button("↓", GUILayout.Width(20)))
                    {
                        array.MoveArrayElement(x, x + 1);
                    }

                    if (GUILayout.Button("✖", GUILayout.Width(20)))
                    {
                        if (array.arraySize - 1 >= 0)
                            array.DeleteArrayElementAtIndex(x);
                    }
                }
            }
        }
    }

    private GUIStyle GetLabelStyle()
    {
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.LowerLeft;
        style.normal.textColor = new Color(0.8f, 0.8f, 0.8f, 1);
        style.fontStyle = FontStyle.Bold;
        style.fontSize = 14;
        style.contentOffset = new Vector2(2, 3);
        return style;
    }
    private GUIStyle GetHelpboxStyle()
    {
        GUIStyle x = new GUIStyle();
        x.padding = new RectOffset(6, 6, 0, 0);
        x.wordWrap = true;
        x.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
        return x;
    }

    public void DrawEvent(SerializedProperty x, SerializedProperty eventObject, SerializedProperty value)
    {
        using (new EditorGUILayout.VerticalScope())
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.PropertyField(eventObject, GUIContent.none);

                x.FindPropertyRelative("currentEventType").intValue = EditorGUILayout.Popup(x.FindPropertyRelative("currentEventType").intValue, new string[]
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

            if (eventObject.objectReferenceValue != null)
            {
                EditorGUILayout.PropertyField(value, GUIContent.none);
            }
            else
            {
                using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Please create a new " + eventObject.name + " or select a pre-existing one", GetHelpboxStyle());
                    EditorGUILayout.Space();
                }
            }
        }
    }
    public void DrawEvent(SerializedProperty x, SerializedProperty eventObject)
    {
        using (new EditorGUILayout.VerticalScope())
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.PropertyField(eventObject, GUIContent.none);

                x.FindPropertyRelative("currentEventType").intValue = EditorGUILayout.Popup(x.FindPropertyRelative("currentEventType").intValue, new string[]
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

            if (eventObject.objectReferenceValue == null) 
            { 
                using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Please create a new " + eventObject.name + " or select a pre-existing one", GetHelpboxStyle());
                    EditorGUILayout.Space();
                }
            }
        }
    }

    void SelectTab()
    {
        Input = false;
        Monobehaviour = false;
        Settings = false;

        switch (currentTab.intValue)
        {
            case 0:
                Input = true;
                break;
            case 1:
                Monobehaviour = true;
                break;
            case 2:
                Settings = true;
                break;
        }
    }
    void Space()
    {
        EditorGUILayout.Space();
        Divider();
        EditorGUILayout.Space();
    }

    void Divider()
    {
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(1, 1), new Color(0, 0, 0, 0.5f));
    }
    void Title(string title)
    {
        EditorGUILayout.Space(5);

        GUIStyle i = EditorStyles.boldLabel;
        i.fontSize = 14;
        i.alignment = TextAnchor.MiddleCenter;
        EditorGUI.LabelField(GUILayoutUtility.GetRect(200, 24), title, i);
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(1, 1), new Color(0, 0, 0, 0.5f));
        EditorGUILayout.Space();
        i = GUIStyle.none;
    }

    private SerializedProperty GetRelativeProperty(SerializedProperty list, int i, string ID)
    {
        return list.GetArrayElementAtIndex(i).FindPropertyRelative(ID);
    }
}
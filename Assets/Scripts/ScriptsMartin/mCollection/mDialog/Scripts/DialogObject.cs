using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Dialog/New Dialog", fileName = "New Dialog")]
public class DialogObject : ScriptableObject
{
    public Dialog[] lines;
}

[System.Serializable]
public struct Dialog
{
    public Sprite characterImage;
    public string DialogID;
    public string characterName;
    [TextArea(4,10)] public string text;
    public Option[] options;

    public string animatorGameObjectName;
    public string animationName;

    [HideInInspector] public bool Expanded;

    public bool HasOptions() => options.Length > 0;
}

[System.Serializable]
public struct Option
{
    public string option;
    public DialogObject branch;
}

#if UNITY_EDITOR

[CustomEditor(typeof(DialogObject))]
[CanEditMultipleObjects]
public class DialogObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        using (new EditorGUILayout.HorizontalScope(EditorStyles.helpBox))
        {
            GUILayout.Label("Prompts", GetLabelStyle());

            if (GUILayout.Button("+", GUILayout.Width(20)))
            {
                serializedObject.FindProperty("lines").arraySize++;
                serializedObject.FindProperty("lines").GetArrayElementAtIndex(serializedObject.FindProperty("lines").arraySize-1).FindPropertyRelative("Expanded").boolValue = true;
            }
            if (GUILayout.Button("-", GUILayout.Width(20)))
            {
                if (serializedObject.FindProperty("lines").arraySize == 0) return;

                serializedObject.FindProperty("lines").arraySize--;
            }
        }

        EditorGUILayout.Space(2);

        for (int i = 0; i < serializedObject.FindProperty("lines").arraySize; i++)
        {
            SerializedProperty dialog = serializedObject.FindProperty("lines").GetArrayElementAtIndex(i);

            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button(GetDialogName(dialog), GetLabelStyle()))
                    {
                        dialog.FindPropertyRelative("Expanded").boolValue = !dialog.FindPropertyRelative("Expanded").boolValue;
                    }

                    if (GUILayout.Button("↑", GUILayout.Width(20)))
                    {
                        serializedObject.FindProperty("lines").MoveArrayElement(i, i-1);
                    }

                    if (GUILayout.Button("↓", GUILayout.Width(20)))
                    {
                        serializedObject.FindProperty("lines").MoveArrayElement(i, i + 1);
                    }

                    if (GUILayout.Button("X", GUILayout.Width(20)))
                    {
                        serializedObject.FindProperty("lines").DeleteArrayElementAtIndex(i);

                        break;
                    }
                }

                EditorGUILayout.Space(2);

                if (dialog.FindPropertyRelative("Expanded").boolValue == false) continue;

                using (new EditorGUILayout.VerticalScope())
                {
                    Divider();

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        using (new EditorGUILayout.VerticalScope())
                        {
                            EditorGUILayout.Space(12);
                            using (new EditorGUILayout.HorizontalScope())
                            {
                                GUILayout.Label("Dialog ID", GUILayout.Width(60));
                                EditorGUILayout.PropertyField(dialog.FindPropertyRelative("DialogID"), GUIContent.none);
                            }

                            using (new EditorGUILayout.HorizontalScope())
                            {
                                GUILayout.Label("Character Name", GUILayout.Width(96));
                                EditorGUILayout.PropertyField(dialog.FindPropertyRelative("characterName"), GUIContent.none);
                            }
                        }

                        dialog.FindPropertyRelative("characterImage").objectReferenceValue =
                                (Sprite)EditorGUILayout.ObjectField(dialog.FindPropertyRelative("characterImage").objectReferenceValue,
                                typeof(Sprite), allowSceneObjects: true,
                                GUILayout.Width(65f), GUILayout.Height(65f));


                    }
                    EditorGUILayout.Space();
                    Divider();

                    EditorGUILayout.PropertyField(dialog.FindPropertyRelative("text"), GUIContent.none);

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        GUILayout.Label("Animator Name", GUILayout.Width(96));
                        EditorGUILayout.PropertyField(dialog.FindPropertyRelative("animatorGameObjectName"), GUIContent.none);
                    }
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        GUILayout.Label("Clip Name", GUILayout.Width(96));
                        EditorGUILayout.PropertyField(dialog.FindPropertyRelative("animationName"), GUIContent.none);
                    }
                }

                Space();

                using (new EditorGUILayout.VerticalScope())
                {
                    using (new EditorGUILayout.HorizontalScope(EditorStyles.helpBox))
                    {
                        GUILayout.Label("Options", GetLabelStyle());

                        if (dialog.FindPropertyRelative("options").arraySize < 4)
                        {
                            if (GUILayout.Button("+", GUILayout.Width(20)))
                            {
                                if (dialog.FindPropertyRelative("options").arraySize == 4) return;
                                dialog.FindPropertyRelative("options").arraySize++;
                            }
                        }
                        else
                        {
                            GUILayout.Space(20);
                        }
                        if (GUILayout.Button("-", GUILayout.Width(20)))
                        {
                            if (dialog.FindPropertyRelative("options").arraySize == 0) return;

                            dialog.FindPropertyRelative("options").arraySize--;
                        }
                    }

                    using (new EditorGUILayout.VerticalScope())
                    {
                        for (int x = 0; x < dialog.FindPropertyRelative("options").arraySize; x++)
                        {
                            using (new EditorGUILayout.HorizontalScope(EditorStyles.helpBox))
                            {
                                SerializedProperty option = dialog.FindPropertyRelative("options").GetArrayElementAtIndex(x);
                                GUILayout.Label("Option");
                                EditorGUILayout.PropertyField(option.FindPropertyRelative("option"), GUIContent.none);
                                GUILayout.Label("Branch");
                                EditorGUILayout.PropertyField(option.FindPropertyRelative("branch"), GUIContent.none);

                                if(GUILayout.Button("X", GUILayout.Width(20)))
                                {
                                    dialog.FindPropertyRelative("options").DeleteArrayElementAtIndex(x);
                                }
                            }
                        }
                    }
                }
            }
        }

        serializedObject.ApplyModifiedProperties();
    }

    private static string GetDialogName(SerializedProperty dialog)
    {
        if (dialog.FindPropertyRelative("DialogID").stringValue != "")
            return dialog.FindPropertyRelative("DialogID").stringValue;
        else
            return "New Prompt";
    }

    void Divider(int i_height = 1)
    {
        Rect rect = EditorGUILayout.GetControlRect(false, i_height);
        rect.height = i_height;
        EditorGUI.DrawRect(rect, new Color(0f, 0f, 0f, 0.4f));
    }

    void Space()
    {
        EditorGUILayout.Space();
    }


    public GUIStyle GetLabelStyle()
    {
        GUIStyle i = new GUIStyle();

        i.alignment = TextAnchor.MiddleCenter;
        i.contentOffset = new Vector2(0, 1f);

        i.fontSize = 14;
        i.fontStyle = FontStyle.Bold;
        i.normal.textColor = new Color(1,1,1,0.6f);

        return i;
    }
}

#endif
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogManager))]
[CanEditMultipleObjects]
public class DialogManagerEditor : Editor
{
    SerializedProperty visiblePos;
    SerializedProperty hiddenPos;
    SerializedProperty newDialogPopAmount;
    SerializedProperty dialogBoxShow;
    SerializedProperty dialogBoxHide;

    SerializedProperty characterVisiblePos;
    SerializedProperty characterHiddenPos;

    SerializedProperty dialogPanel;
    SerializedProperty text;
    SerializedProperty characterName;
    SerializedProperty nextOptionDisplay;

    SerializedProperty characterSprite;

    SerializedProperty nextOptionKey;
    SerializedProperty altOptionKey;

    SerializedProperty options;
    SerializedProperty selectedOption;
    SerializedProperty selectedOptionGraphic;

    SerializedProperty DialogStarted;
    SerializedProperty DialogEnded;
    SerializedProperty OptionSelected;
    SerializedProperty CharacterPrinted;

    private static bool Events = false;
    private static bool Setup = false;

    private void OnEnable()
    {
        visiblePos = serializedObject.FindProperty("visiblePos");
        hiddenPos = serializedObject.FindProperty("hiddenPos");
        newDialogPopAmount = serializedObject.FindProperty("newDialogPopAmount");
        dialogBoxShow = serializedObject.FindProperty("dialogBoxShow");
        dialogBoxHide = serializedObject.FindProperty("dialogBoxHide");

        characterVisiblePos = serializedObject.FindProperty("characterVisiblePos");
        characterHiddenPos = serializedObject.FindProperty("characterHiddenPos");

        dialogPanel = serializedObject.FindProperty("dialogPanel");
        text = serializedObject.FindProperty("text");
        characterName = serializedObject.FindProperty("characterName");
        nextOptionDisplay = serializedObject.FindProperty("nextOptionDisplay");

        characterSprite = serializedObject.FindProperty("characterSprite");

        nextOptionKey = serializedObject.FindProperty("nextOptionKey");
        altOptionKey = serializedObject.FindProperty("altOptionKey");

        options = serializedObject.FindProperty("options");
        selectedOption = serializedObject.FindProperty("selectedOption");
        selectedOptionGraphic = serializedObject.FindProperty("selectedOptionGraphic");

        DialogStarted = serializedObject.FindProperty("DialogStarted");
        DialogEnded = serializedObject.FindProperty("DialogEnded");
        OptionSelected = serializedObject.FindProperty("OptionSelected");
        CharacterPrinted = serializedObject.FindProperty("CharacterPrinted");
    }

    public override void OnInspectorGUI()
    {
        Title("Animation");
        EditorGUILayout.PropertyField(visiblePos, new GUIContent("Visible Position"));
        EditorGUILayout.PropertyField(hiddenPos, new GUIContent("Hidden Position"));
        EditorGUILayout.PropertyField(characterVisiblePos, new GUIContent("Character Visible Position"));
        EditorGUILayout.PropertyField(characterHiddenPos, new GUIContent("Character Hidden Position"));
        EditorGUILayout.PropertyField(newDialogPopAmount, new GUIContent("Pop Amount"));
        EditorGUILayout.PropertyField(dialogBoxShow, new GUIContent("Dialog Box Show"));
        EditorGUILayout.PropertyField(dialogBoxHide, new GUIContent("Dialog Box Hide"));
        Space();

        Events = EditorGUILayout.Foldout(Events, "Events");

        if (Events)
        {
            Title("Events");
            EditorGUILayout.PropertyField(DialogStarted, new GUIContent("Dialog Started"));
            EditorGUILayout.PropertyField(DialogEnded, new GUIContent("Dialog Ended"));
            EditorGUILayout.PropertyField(OptionSelected, new GUIContent("Option Selected"));
            EditorGUILayout.PropertyField(CharacterPrinted, new GUIContent("Character Printed"));
        }

        Space();
        Setup = EditorGUILayout.Foldout(Setup, "Setup");

        if (Setup)
        {
            Title("Setup");
            EditorGUILayout.PropertyField(nextOptionKey, new GUIContent("New Prompt Key"));
            EditorGUILayout.PropertyField(altOptionKey, new GUIContent("New Prompt Key Alt"));

            Space();

            EditorGUILayout.PropertyField(dialogPanel, new GUIContent("Dialog Panel"));
            EditorGUILayout.PropertyField(text, new GUIContent("Dialog Text"));
            EditorGUILayout.PropertyField(characterName, new GUIContent("Character Name"));
            EditorGUILayout.PropertyField(nextOptionDisplay, new GUIContent("Next Option"));
            EditorGUILayout.PropertyField(characterSprite);
            EditorGUILayout.PropertyField(selectedOption, new GUIContent("Selection"));
            EditorGUILayout.PropertyField(selectedOptionGraphic, new GUIContent("Selected Option"));

            EditorGUILayout.PropertyField(options, new GUIContent("Options"));
        }

        serializedObject.ApplyModifiedProperties();
    }

    void Space()
    {
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(1, 1), new Color(0, 0, 0, 0.5f));
        EditorGUILayout.Space();
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
}

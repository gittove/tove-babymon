using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePrefs : MonoBehaviour
{
    public string playerPrefsKey = "DadDialogueCount";

    public List<DialogObject> dadConversation;
    public UnityEngine.Events.UnityEvent<DialogObject> OnTriggerDialogue;

    public DialogManager DialogueManager;

    public GameObject button;
    bool isActive = false;

    private void OnEnable()
    {
        DialogManager.onDialogEnded += DisableDialogue;
    }

    private void OnDisable()
    {
        DialogManager.onDialogEnded += DisableDialogue;
    }

    public void DisableDialogue()
    {
        if(isActive)
        {
            button.SetActive(false);

            isActive = false;
        }
    }

    public void DadDialogue()
    {
        if (DialogueManager.dialogOpen) return;
        
        if(PlayerPrefs.HasKey(playerPrefsKey))
        {
            int currentIndex = PlayerPrefs.GetInt(playerPrefsKey);
            if (PlayerPrefs.GetInt(playerPrefsKey) + 1 < dadConversation.Count)
                currentIndex = (PlayerPrefs.GetInt(playerPrefsKey) + 1);

            DialogObject CurrentDialogue = dadConversation[currentIndex];
            OnTriggerDialogue.Invoke(CurrentDialogue);
            PlayerPrefs.SetInt(playerPrefsKey, currentIndex);
        }
        else
        {
            PlayerPrefs.SetInt(playerPrefsKey, 0);
            DialogObject CurrentDialogue = dadConversation[PlayerPrefs.GetInt(playerPrefsKey)];
            OnTriggerDialogue.Invoke(CurrentDialogue);
        }

        isActive = true;
    }
}

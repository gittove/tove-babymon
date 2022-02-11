using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System;

public class DialogManager : MonoBehaviour
{
    [SerializeField, HideInInspector] private RectTransform dialogPanel;
    [SerializeField, HideInInspector] private TextMeshProUGUI text;
    [SerializeField, HideInInspector] private TextMeshProUGUI characterName;
    [SerializeField, HideInInspector] private Image nextOptionDisplay;

    [SerializeField, HideInInspector] private Image characterSprite;

    [SerializeField, HideInInspector] private Image[] options;
    [SerializeField, HideInInspector] private Image selectedOption;
    [SerializeField, HideInInspector] private Image selectedOptionGraphic;

    [SerializeField] private Vector3 visiblePos;
    [SerializeField] private Vector3 hiddenPos;

    [SerializeField] private Vector3 characterVisiblePos;
    [SerializeField] private Vector3 characterHiddenPos;

    [SerializeField] private float newDialogPopAmount = 50f;
    [SerializeField] private AnimationCurve dialogBoxShow;
    [SerializeField] private AnimationCurve dialogBoxHide;

    [SerializeField, HideInInspector] private KeyCode nextOptionKey;
    [SerializeField, HideInInspector] private KeyCode altOptionKey;

    public static Action onDialogStarted;
    public static Action onDialogEnded;
    public static Action<int> onOptionSelected;
    public static Action<char> onCharacterPrinted;
    [SerializeField, HideInInspector] private UnityEvent DialogStarted;
    [SerializeField, HideInInspector] private UnityEvent DialogEnded;
    [SerializeField, HideInInspector] private UnityEvent<int> OptionSelected;
    [SerializeField, HideInInspector] private UnityEvent<char> CharacterPrinted;

    private DialogObject dialog;

    Animator[] animators;

    private int option = 0;
    private int numOptions = 0;

    public bool dialogOpen;
    private bool dialogAnimating;

    private bool isAnimating;
    private bool skip;
    private int line = 0;

    private static bool dialogActive;
    public static bool DialogActive { get { return dialogActive; } private set { } }

    int CurrentLine { get { return Mathf.Clamp(line, 0, dialog.lines.Length - 1); } }

    private void Awake()
    {
        animators = FindObjectsOfType<Animator>();
        characterSprite.enabled = false;
    }

    private void Update()
    {
        if (!dialogOpen || dialog == null)
            return;

        HandleDialogInput();
        HandleOptionInput();
        AnimateOptionGraphic();
        DisplayOptionGraphic();
    }

    //Input
    private void HandleDialogInput()
    {
        if (dialog == null)
            return;

        if ((Input.GetKeyDown(nextOptionKey) || Input.GetKeyDown(altOptionKey)) && !isAnimating && !dialogAnimating)
            NewLine();
        else if ((Input.GetKeyDown(nextOptionKey) || Input.GetKeyDown(altOptionKey)) && isAnimating && !skip && !dialogAnimating)
            skip = true;
    }
    private void HandleOptionInput()
    {
        if (dialog == null)
            return;

        if (dialog.lines[CurrentLine].HasOptions())
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                option++;
                if (option > numOptions-1)
                    option = 0;

                selectedOption.rectTransform.anchoredPosition = options[option].rectTransform.anchoredPosition;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                option--;
                if (option < 0)
                    option = numOptions-1;

                selectedOption.rectTransform.anchoredPosition = options[option].rectTransform.anchoredPosition;
            }
        }
    }

    //Logic
    public void OpenDialog(DialogObject newDialog)
    {
        if (dialogAnimating || dialogOpen || newDialog.lines.Length == 0)
            return;

        mTween.NewTween(0.5f)
            .SetOnStart(()=>
            {
                dialogAnimating = true;
                text.maxVisibleCharacters = 0;
                dialog = newDialog;
                dialogActive = true;
                text.text = dialog.lines[line].text;
                characterName.text = dialog.lines[line].characterName;
                nextOptionDisplay.enabled = false;

                //Play animation if one has been provided;
                foreach (Animator anim in animators)
                {
                    if (anim.gameObject.name == dialog.lines[line].animatorGameObjectName)
                    {
                        if (dialog.lines[line].animationName != "")
                            anim.Play(dialog.lines[line].animationName);

                        break;
                    }
                }

                //Set Character Sprite to current dialog character sprite
                if (dialog.lines[line].characterImage == null)
                    characterSprite.enabled = false;
                else
                {
                    characterSprite.enabled = true;
                    characterSprite.rectTransform.sizeDelta = new Vector2(dialog.lines[line].characterImage.texture.width, dialog.lines[line].characterImage.texture.height);
                    characterSprite.sprite = dialog.lines[line].characterImage;
                }

                GetOptions();
                StartCoroutine(RevealCharacters());
                onDialogStarted?.Invoke();
                DialogStarted?.Invoke();
            })
            .MoveTo(dialogPanel, hiddenPos, visiblePos, dialogBoxShow)
            .MoveTo(characterSprite.rectTransform, characterHiddenPos, characterVisiblePos, dialogBoxShow)
            .LerpFloat((i)=> 
            {
                if (characterSprite.enabled)
                    characterSprite.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, i);
            }, 0f, 1f)
            .SetOnComplete(() => 
            { 
                dialogAnimating = false;
                dialogOpen = true;
            });
    }
    public void CloseDialog()
    {
        if (dialogAnimating || !dialogOpen)
            return;

        mTween.NewTween(0.5f)
            .SetOnStart(() => 
            {
                dialogAnimating = true; 

                selectedOption.gameObject.SetActive(false);

                for (int i = 0; i < options.Length; i++)
                    options[i].gameObject.SetActive(false);

                dialogOpen = false;
                dialogActive = false;
                onDialogEnded?.Invoke();
                DialogEnded?.Invoke();
            })
            .MoveTo(dialogPanel, visiblePos, hiddenPos, dialogBoxHide)
            .MoveTo(characterSprite.rectTransform, characterVisiblePos, characterHiddenPos, dialogBoxShow)
            .LerpFloat((i) =>
            {
                if (characterSprite.enabled)
                    characterSprite.color = Color.Lerp(Color.white, new Color(1,1,1,0), i);
            }, 0f, 1f)
            .SetOnComplete(() => dialogAnimating = false);
    }
    private void NewLine()
    {
        line++;

        //If current line is the last one...
        if (line >= dialog.lines.Length)
        {
            //If the current line has options...
            if (dialog.lines[line-1].HasOptions())
            {
                //If the selected option does not lead to a new branch, reset the dialogmanager and close the dialog box
                if(dialog.lines[line - 1].options[option].branch == null)
                {
                    ResetManager();
                    CloseDialog();
                    return;
                }

                //Set the new dialog to the current option
                dialog = dialog.lines[line-1].options[option].branch;

                //Invoke option selected event
                onOptionSelected?.Invoke(option);
                OptionSelected?.Invoke(option);

                //Reset the position of the selection cursor
                selectedOption.rectTransform.anchoredPosition = options[0].rectTransform.anchoredPosition;
                line = 0;
                option = 0;
            }
            else //If there are no options
            {
                ResetManager();
                CloseDialog();
                return; 
            }
        }

        //Set the new text to be the next one in the list of lines
        text.text = dialog.lines[line].text;

        //Set character name
        characterName.text = dialog.lines[line].characterName;

        //Play animation if one has been provided;
        foreach (Animator anim in animators)
        {
            if (anim.gameObject.name == dialog.lines[line].animatorGameObjectName)
            {
                if(dialog.lines[line].animationName != "")
                    anim.Play(dialog.lines[line].animationName);

                break;
            }
        }

        //Set Character Sprite to current dialog character sprite
        if (dialog.lines[line].characterImage == null)
            characterSprite.enabled = false;
        else
        {
            characterSprite.enabled = true;
            characterSprite.sprite = dialog.lines[line].characterImage;
        }

        //Animate the dialog box
        mTween.NewTween(0.4f)
            .SetOnStart(() => 
            {
                dialogAnimating = true;

                if(dialog.lines[line].characterImage != null)
                    characterSprite.rectTransform.sizeDelta = new Vector2(dialog.lines[line].characterImage.texture.width, dialog.lines[line].characterImage.texture.height);
            })
            .MoveTo(dialogPanel, visiblePos + Vector3.down * newDialogPopAmount, visiblePos, dialogBoxShow)
            .MoveTo(characterSprite.rectTransform, characterHiddenPos, characterVisiblePos, dialogBoxShow)
            .AlphaTo(characterSprite, 0f, 1f, dialogBoxShow)
            .SetOnComplete(() => dialogAnimating = false);

        //Check if there are options
        GetOptions();

        //Animate text to apear over time
        StartCoroutine(RevealCharacters());
    }

    private void GetOptions()
    {
        if (dialog == null)
            return;

        numOptions = dialog.lines[CurrentLine].options.Length;
        option = 0;

        for (int i = 0; i < options.Length; i++)
            options[i].gameObject.SetActive(false);

        for (int i = 0; i < dialog.lines[CurrentLine].options.Length; i++)
        {
            options[i].gameObject.SetActive(true);
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = dialog.lines[line].options[i].option;
        }
    }


    //Graphics
    private void DisplayOptionGraphic()
    {
        if (dialog == null)
        {
            if(selectedOption.gameObject.activeInHierarchy)
                selectedOption.gameObject.SetActive(false);

            return;
        }

        if (dialog.lines[CurrentLine].HasOptions())
        {
            selectedOption.gameObject.SetActive(true);
        }
        else
        {
            selectedOption.gameObject.SetActive(false);
        }
    }
    private void AnimateOptionGraphic()
    {
        if (dialog == null)
            return;

        nextOptionDisplay.enabled = !(line == dialog.lines.Length-1 || dialog.lines.Length == 0 || dialog.lines[CurrentLine].HasOptions());
        nextOptionDisplay.rectTransform.anchoredPosition = new Vector2(0f, Mathf.Sin(Time.timeSinceLevelLoad * 4f) * 10f);
        selectedOptionGraphic.rectTransform.anchoredPosition = new Vector2(Mathf.Sin(Time.timeSinceLevelLoad * 4f) * 6f - 15f, 0f);
    }
    public IEnumerator RevealCharacters()
    {
        isAnimating = true;

        text.ForceMeshUpdate();

        int chars = text.textInfo.characterCount;
        int i = 0;

        while (i <= chars)
        {
            text.maxVisibleCharacters = i;

            char c;

            if (i < chars)
            {
                c = text.textInfo.characterInfo[i].character;

                if(c != '\0' && c != ' ' && c != '\r' && c != '\n')
                {
                    onCharacterPrinted?.Invoke(c);
                    CharacterPrinted?.Invoke(c);
                }
            }

            i++;
            yield return null;

            if (skip)
                break;
        }

        if (skip)
        {
            text.maxVisibleCharacters = chars;
            skip = false;
        }

        isAnimating = false;
    }

    private void ResetManager()
    {
        line = 0;
        option = 0;
        dialog = null;
    }
}
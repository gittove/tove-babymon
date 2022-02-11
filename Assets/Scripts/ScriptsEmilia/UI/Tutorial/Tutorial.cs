using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum TutorialState
{
    PressKey,
    HoldKey,
    PickUp,
    MonsterManual,
}
public class Tutorial : MonoBehaviour
{
    [Header("Settings for texts: ")]
    [SerializeField, Range(1, 10)] 
    private int numberOfInstructionsTexts;
    [SerializeField, TextArea(5,10)] 
    private List<string> instructionTexts = new List<string>();
    
    [SerializeField, Range(1, 10)] 
    private int numberOfTutorialTexts;
    [SerializeField, TextArea(5,10)] 
    private List<string> tutorialTexts = new List<string>();

    [Header("Settings for keys: ")]
    [SerializeField, Range(0.5f,5f)] 
    private float pressDownKeyTime = 2f;
    
    [Header("References: ")]
    [SerializeField] 
    private GameObject instructions;
    [SerializeField] 
    private TextMeshProUGUI instructionsText;
    [SerializeField] 
    private TextMeshProUGUI babyTextBox;
    [SerializeField] 
    private GameObject pickUpObject;
    [SerializeField] 
    private GameObject letsGoButton;
    [SerializeField] 
    private UnityEvent onPickUp;
    
    [Header("Events: ")]
    [SerializeField] 
    private UnityEvent onMonsterManual;


    // [SerializeField] 
    // private Button playButton;
    // [SerializeField] 
    // private Button nextButton;
    // [SerializeField] 
    // private GameObject backButton;
    
    private Dictionary<int, string> instructionalTextLookUp;
    private Dictionary<int, string> tutorialTextLookUp;
    private int index = 0;
    private float downTime = 0;
    private bool isTutorial;

    private TutorialState currentState;

    public TutorialState CurrentState
    {
        get => currentState;
        set => currentState = value;
    }
    
    private void Awake()
    {
        AddTextToDictionarys();
    }

    private void AddTextToDictionarys()
    {
        instructionalTextLookUp = new Dictionary<int, string>();
        for (int i = 0; i < numberOfInstructionsTexts; i++)
        {
            instructionalTextLookUp.Add(i, instructionTexts[i]);
        }
        
        tutorialTextLookUp = new Dictionary<int, string>();
        for (int i = 0; i < numberOfTutorialTexts; i++)
        {
            tutorialTextLookUp.Add(i, tutorialTexts[i]);
        }
    }
    
    private void Start()
    {
        StartSettings();
        ChangeInstructionText();
    }

    private void StartSettings()
    {
        babyTextBox.gameObject.SetActive(false);
        pickUpObject.SetActive(false);
        index = 0;
        isTutorial = false;
        currentState = TutorialState.PressKey;
        Time.timeScale = 0;
    }

    private void Update()
    {
       ReadInput();
    }

    private void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            PlayGame();
        }
        
        if (!isTutorial && Input.GetMouseButtonDown(0))
        {
            GoNext();
        }
        // if (currentState == TutorialState.PressKey && Input.GetKeyDown(KeyCode.Alpha1)) //event in baby where need 1 is fulfilled
        // {
        //     StartCoroutine(InvokeEventsWithTimeBetween());
        // }
        
        if (currentState == TutorialState.HoldKey && Input.GetKey(KeyCode.Alpha2))
        {
            downTime += Time.deltaTime;
        }
        
        // if (currentState == TutorialState.HoldKey && Input.GetKeyUp(KeyCode.Alpha2))
        // {
        //     if (downTime >= pressDownKeyTime) //event in baby where need 2 is fulfilled
        //     {
        //         ChangeTutorialText(1);
        //         currentState = TutorialState.PickUp;
        //         PlayPickUpEffect();
        //         downTime = 0;
        //     }
        //     else
        //     {
        //         ChangeTutorialText(3);
        //         downTime = 0;
        //     }
        // }

        if (currentState == TutorialState.PickUp && Input.GetKeyDown(KeyCode.E) )
        {
            onPickUp.Invoke();
        }

        if (currentState == TutorialState.MonsterManual && Input.GetKeyDown(KeyCode.M)) 
        {
            letsGoButton.SetActive(true);
            babyTextBox.gameObject.SetActive(false);
        }
    }

    public void FirstNeedFulfilled()
    {
        currentState = TutorialState.HoldKey;
        ChangeTutorialText(1);
    }

    public void SecondNeedFulfilled()
    {
        ChangeTutorialText(1);
        currentState = TutorialState.PickUp;
        PlayPickUpEffect();
        downTime = 0;
    }

    public void ThirdNeedFulfilled()
    {
        currentState = TutorialState.MonsterManual;
        ChangeTutorialText(4);
        onMonsterManual.Invoke();
    }
    
    public void GoNext()
    {
        index++;
        UpdateAccordingToIndex();
        ChangeInstructionText();
    }
    
    private void ChangeInstructionText()
    {
        instructionsText.text = instructionalTextLookUp[index];
    }

    private void UpdateAccordingToIndex()
    {
        if (index >= numberOfInstructionsTexts)
        {
            instructions.SetActive(false);
            isTutorial = true;
            Time.timeScale = 1;
            index = 0;
        }
    }
    
    public void ChangeTutorialText(int index)
    {
        babyTextBox.gameObject.SetActive(true);
        babyTextBox.text = tutorialTextLookUp[index];
    }
    
    // private IEnumerator InvokeEventsWithTimeBetween()
    // {
    //     currentState = TutorialState.HoldKey;
    //     ChangeTutorialText(1);
    //     yield return new WaitForSeconds(2f);
    //     
    // }

    public void ShowSecondNeedText()
    {
        ChangeTutorialText(2);
    }
    
    private void PlayPickUpEffect()
    {
        pickUpObject.SetActive(true);
    }
    
    public void PlayGame()
    {
        //Copied from main menu, music should be from main menu not here tho?
        // MusicManager.instance.PlayStem(musicState.InGame, 0.5f);
        SceneManager.LoadScene(2);
    }
}

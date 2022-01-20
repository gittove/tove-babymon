using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Player input for pause")]
    [SerializeField] 
    private KeyCode pauseKey;
    
    //Observable invoke event whenever pause is changed
    [Header("Scriptable object")]
    [SerializeField] 
    private BoolObservable pauseObservable;
    
    [Header("References")]
    [SerializeField] 
    private GameObject pauseMenuCanvas;
    [SerializeField] 
    private GameObject controlsCanvas;
    
    private bool isShowingControls;
    
    private void Start()
    {
        //Todo put in own set up method later?
        pauseMenuCanvas.SetActive(false);
        controlsCanvas.SetActive(false);
        isShowingControls = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (pauseObservable.Value == true) //Todo more readable with == true?
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //Todo if continue to use scriptable objects with event listener, keep everything in origin script but add listener to pause observable?
    //Same with what happens on resume
    private void PauseGame()
    {
        pauseObservable.SetValue(true);
        pauseMenuCanvas.SetActive(true);
        //pause game timer now done through SO events
        //pause player movement
        //pause baby behaviour

    }
    
    public void ResumeGame() 
    {
        pauseObservable.SetValue(false);
        pauseMenuCanvas.SetActive(false);
        //start game timer
    }

    public void ShowControls() //Todo change method name?
    {
        if (isShowingControls)
        {
            controlsCanvas.SetActive(false);
            isShowingControls = false;
        }
        else
        {
            controlsCanvas.SetActive(true);
            isShowingControls = true;
        }
    }
    
    public void QuitGame() 
    {
        Application.Quit();
    }
}

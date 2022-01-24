using UnityEngine;

public class PlayerInputUI : MonoBehaviour
{
    [Header("Player input for UI")] 
    [SerializeField]
    private KeyCode showAllHappinessKey = KeyCode.Space;
    [SerializeField] 
    private KeyCode pauseKey = KeyCode.Escape;
   
    //Observable invoke event whenever pause is changed
    [Header("Scriptable objects")]
    [SerializeField] 
    private BoolObservable pauseObservable;

    [SerializeField] 
    private ScriptableEventBool onShowPauseMenu;
    
    [SerializeField] 
    private ScriptableEventBase onShowAllHappinessBars;
    

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            ChangePauseObservable();
            //pause player movement
            //pause baby behaviour
            //Todo everything that must pause should have a pause/resume method and listen to event?
        }
        
        if (Input.GetKeyDown(showAllHappinessKey))
        {
            
            if (pauseObservable.Value == false)
            {
                onShowAllHappinessBars.RaiseEvent();
            }
            //Show all bars, but not on pause
        }
    }
    
    private void ChangePauseObservable()
    {
        if (pauseObservable.Value == true) //Todo more readable with == true?
        {
            pauseObservable.SetValue(false);
            onShowPauseMenu.RaiseEvent(false);
        }
        else
        {
            pauseObservable.SetValue(true);
            onShowPauseMenu.RaiseEvent(true);
        }
    }
}

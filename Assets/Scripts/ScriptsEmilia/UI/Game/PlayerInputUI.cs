using UnityEngine;

public class PlayerInputUI : MonoBehaviour
{
    [Header("Key settings:")] 
    [SerializeField]
    private KeyCode showAllHappinessKey = KeyCode.Space;
    [SerializeField] 
    private KeyCode pauseKey = KeyCode.Escape;
    
    [Header("Scriptable objects:")]
    [SerializeField] 
    private BoolObservable pauseObservable;
    [SerializeField] 
    private ScriptableEventBase onShowAllHappinessBars;

    [Header("References: ")]
    [SerializeField] 
    private ScriptableEventBool onShowPauseMenu;

    private bool isGameEnd;
    private bool isNotInvoked;
    private void Start()
    {
        isGameEnd = false;
        pauseObservable.SetValue(false);
        Debug.Log(pauseObservable.Value);
    }

    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        if (!isGameEnd && Input.GetKeyDown(pauseKey))
        {
            ChangePauseObservable();
        }
        
        if (Input.GetKeyDown(showAllHappinessKey) || Input.GetKeyUp(showAllHappinessKey))
        {
            onShowAllHappinessBars.RaiseEvent();
        }
    }

    public void ChangeOnGameEnd()
    {
        isGameEnd = true;
    }
    
    public void ChangePauseObservable()
    {
        if (pauseObservable.Value == true)
        {
            pauseObservable.SetValue(false);
            onShowPauseMenu.RaiseEvent(false);
        }
        else
        {
            pauseObservable.SetValue(true);
            onShowPauseMenu.RaiseEvent(true);
            isNotInvoked = true;
        }
    }
}

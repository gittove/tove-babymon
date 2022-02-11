using UnityEngine;
using UnityEngine.Events;


public class TutorialBaby : MonoBehaviour
{
    [Header("Events: ")]
    [SerializeField]
    private UnityEvent<int> onTaskDone;
    // [SerializeField] 
    // private UnityEvent onMonsterManual;

    [Header("References: ")]
    [SerializeField] 
    private Tutorial tutorial;
    [SerializeField] 
    private GameObject textBoxBaby;

    private string playerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (tutorial.CurrentState == TutorialState.PressKey && other.CompareTag(playerTag))
        {
            onTaskDone.Invoke(0);
        }
    }
    //
    // private void OnTriggerStay(Collider other)
    // {
    //     if (tutorial.CurrentState == TutorialState.PickUp && Input.GetKeyDown(KeyCode.Alpha3) && other.CompareTag(playerTag))
    //     {
    //         tutorial.CurrentState = TutorialState.MonsterManual;
    //         onTaskDone.Invoke(4);
    //         onMonsterManual.Invoke();
    //     }
    // }
    //
    private void OnTriggerExit(Collider other)
    {
        if (tutorial.CurrentState == TutorialState.PressKey || tutorial.CurrentState == TutorialState.PickUp && other.CompareTag(playerTag))
        {
            textBoxBaby.SetActive(false);
        }
    }
}

using UnityEngine;

public class StartCanvas : MonoBehaviour
{
    [Header("References")]
    [SerializeField] 
    private GameObject startCanvas;

    [Header("Scriptable objects")]
    [SerializeField] 
    private BoolObservable pauseObservable;

    private void Start()
    {
        startCanvas.SetActive(true);
        pauseObservable.SetValue(true);
    }

    public void CloseStartCanvas()
    {
        startCanvas.SetActive(false);
        pauseObservable.SetValue(false);
    }
}

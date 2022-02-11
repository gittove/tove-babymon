using System.Collections;
using UnityEngine;

public class UiShowMovable : MonoBehaviour
{
    [Header("References: ")] 
    [SerializeField]
    private GameObject image;

    [SerializeField, Range(0.5f,5f)] 
    private float secondsActive = 1.5f;
    
    private string movableTag = "Moveable";
    private bool isRunning;
    private Coroutine routine;
    
    private void Start()
    {
        image.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(movableTag) && !isRunning)
        {
            routine = StartCoroutine(ShowKey());
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(movableTag) && isRunning)
        {
            StopCoroutine(routine);
            isRunning = false;
            image.SetActive(false);
        }
    }

    private IEnumerator ShowKey()
    {
        image.SetActive(true);
        yield return new WaitForSeconds(secondsActive);
        isRunning = false;
        image.SetActive(false);
    }
}

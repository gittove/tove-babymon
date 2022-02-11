using UnityEngine;

public class DisplayBabyNeeds : MonoBehaviour
{

    [Header("References")] [SerializeField]
    private GameObject happinessBar;

    [SerializeField] private GameObject needsCanvas;
    [SerializeField] private BabyInteractionUI babyInteractionUi;

    private bool isShowingDisplay;
    private bool isPause;
    private bool isHover;
    private bool isSpace;

    public bool IsSpace => isSpace;

    private void Start()
    {
        needsCanvas.SetActive(false);
        happinessBar.SetActive(false);
    }

    public void ShowBar()
    {
        isSpace ^= true;
        if (!happinessBar.activeInHierarchy)
        {
            happinessBar.SetActive(true);
        }
        else if (!isShowingDisplay && !babyInteractionUi.IsInteracting)
        {
            happinessBar.SetActive(false);
        }
    }

    public void OnMouseOver()
    {
        if (!isPause && !isHover && !babyInteractionUi.IsInteracting)
        {
            isShowingDisplay = true;
            isHover = true;
            needsCanvas.SetActive(true);
            happinessBar.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        if (!isPause && !babyInteractionUi.IsInteracting)
        {
            if (isShowingDisplay && isSpace)
            {
                isShowingDisplay = false;
                happinessBar.SetActive(true);
            }
            else
            {
                happinessBar.SetActive(false);
            }

            isShowingDisplay = false;
            isHover = false;
            needsCanvas.SetActive(false);
        }
    }

    public void ChangePauseVariable(bool pause) //Todo change method name
    {
        isPause = pause;
    }
}
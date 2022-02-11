using System;
using UnityEngine;

public class BabyInteractionUI : MonoBehaviour
{
    //Enable ring around baby when player is within distance
    //Show canvas when within that distance

    [Header("References")]
    [SerializeField] 
    private GameObject interactionRing;
    [SerializeField] 
    private GameObject needsCanvas;
    [SerializeField] 
    private GameObject happinessbar;
    [SerializeField] 
    private DisplayBabyNeeds displayBabyNeeds;
    
    private bool isInRange;
    private bool isStop;

    private bool isInteracting;
    
    public bool IsInteracting => isInteracting;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowInteractionUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopShowingInteractionUI();
        }
    }
    
    private void ShowInteractionUI()
    {
        isInteracting = true;
        interactionRing.SetActive(true);
        needsCanvas.SetActive(true);
        happinessbar.SetActive(true);
    }

    private void StopShowingInteractionUI()
    {
        isInteracting = false;
        interactionRing.SetActive(false);
        needsCanvas.SetActive(false);
        if (!displayBabyNeeds.IsSpace)
        {
            happinessbar.SetActive(false);
        }
    }
}

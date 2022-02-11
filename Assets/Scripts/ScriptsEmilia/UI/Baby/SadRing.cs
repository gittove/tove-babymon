using UnityEngine;

public class SadRing : MonoBehaviour
{
    [SerializeField] 
    private GameObject sadRing;

    [SerializeField] 
    private BabyProfile babyProfile;

    public void ActivateRing()
    {
        sadRing.SetActive(true);
    }
    
    public void DeActivateRing()
    {
        sadRing.SetActive(false);
    }
}

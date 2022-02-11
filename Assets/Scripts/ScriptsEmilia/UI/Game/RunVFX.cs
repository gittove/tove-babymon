using UnityEngine;

public class RunVFX : MonoBehaviour
{
    [Header("Scriptable Event")]
    [SerializeField] 
    private ScriptableEventParticleSystem onPlayEffect;

    [SerializeField] 
    private Effect effectType;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayRunVFX();
        }
    }

    private void PlayRunVFX()
    {
        onPlayEffect.RaiseEvent(effectType, transform.position);
    }
}

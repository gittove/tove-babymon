using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator _animator;
    public ScriptableAudioEvent _audioEvent;
    public AudioData _footStepData;
    public AudioData _jumpingGruntData;
    public AudioData _landingGruntData;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetParameterInt(string parName, int parValue)
    {
        _animator.SetInteger(parName, parValue);
    }

    public void SetParameterBool(string parName, bool parValue)
    {
        _animator.SetBool(parName, parValue);
    }
    
    public void SetParameterTrigger(string parName)
    {
        _animator.SetTrigger(parName);
    }

    public void PlayFootStep()
    {
        _audioEvent.RaiseEvent(
            _footStepData.MixerGroup, 
            _footStepData.AudioClip, 
            this.transform.position);
    }

    public void PlayJumpingGrunt()
    {
        _audioEvent.RaiseEvent(
            _jumpingGruntData.MixerGroup, 
            _jumpingGruntData.AudioClip, 
            this.transform.position);
    }

    public void PlayLandingGrunt()
    {
        _audioEvent.RaiseEvent(
            _landingGruntData.MixerGroup, 
            _landingGruntData.AudioClip, 
            this.transform.position);
    }

    


}

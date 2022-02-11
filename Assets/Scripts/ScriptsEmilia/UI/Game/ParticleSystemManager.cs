using System.Collections.Generic;
using UnityEngine;

//Instruction
//1. Add enum Effect for type of particle system effect
//ex. Hungry
public enum Effect
{
   Dust,
   Happy,
   Fail,
   Angry,
   Need,
   Burp
}

public class ParticleSystemManager : MonoBehaviour
{
   //2. Add a serialized field for the particle system effect
   // [SerializeField] 
   // private ParticleSystem theNameOfTheParticleSystem;
   //And drag the ps into the field in the inspector
   
   [Header("Particle system effects")]
   [SerializeField] 
   private ParticleSystem dustParticleSystem;
   [SerializeField] 
   private ParticleSystem loveParticleSystem;
   [SerializeField] 
   private ParticleSystem burpParticleSystem;
   [SerializeField] 
   private ParticleSystem failParticleSystem;

   private Dictionary<Effect, ParticleSystem> particleLookUp;

   //3. Add to dictionary 
   // particleLookUp.Add(Effect.Hungry, theNameOfTheParticleSystem );
   private void Awake()
   {
      particleLookUp = new Dictionary<Effect, ParticleSystem>();
      particleLookUp.Add(Effect.Dust, dustParticleSystem );
      particleLookUp.Add(Effect.Happy, loveParticleSystem );
      particleLookUp.Add(Effect.Fail, failParticleSystem);
      particleLookUp.Add(Effect.Burp, burpParticleSystem);
   }

   public void PlayVFX(Effect type, Vector3 position)
   {
      ParticleSystem effectToplay = particleLookUp[type];
      effectToplay.transform.position = position;
      effectToplay.Play();
   }
}

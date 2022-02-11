using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new ParticleEffect", menuName = "ScriptableObjects/ParticleEffect/ScriptableParticleEffect")]
public class ScriptableParticleSystem : ScriptableObject
{
    [SerializeField] 
    private Effect dust = Effect.Dust;

    public Effect Dust => dust;
}

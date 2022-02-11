using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new BoolVariable", menuName = "ScriptableObjects/Variables/BoolVariable")]
public class BoolVariable : ScriptableObject
{
    [SerializeField] 
    private bool value;

    private bool currentValue;

    public bool Value => currentValue;


    private void OnEnable()
    {
        currentValue = value;
    }

    public virtual void SetValue(bool newValue)
    {
        currentValue = newValue;
    }
}

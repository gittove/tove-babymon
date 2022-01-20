using UnityEngine;

[CreateAssetMenu(fileName = "new BoolVariable", menuName = "ScriptableObjects/Variables/BoolVariable")]
public class BoolVariable : ScriptableObject
{
    [SerializeField] 
    private bool value;

    private bool currentValue;

    public bool Value => currentValue;

    public virtual void SetValue(bool newValue)
    {
        currentValue = newValue;
    }
}

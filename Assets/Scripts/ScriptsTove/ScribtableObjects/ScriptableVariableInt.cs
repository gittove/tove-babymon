using UnityEngine;

[CreateAssetMenu(fileName = "new IntVariable", menuName = "ScriptableObjects/Variables/IntVariable")]
public class ScriptableVariableInt : ScriptableObject
{
    [SerializeField] 
    private int value;

    private int currentValue;

    public int Value => currentValue;
    
    private void OnEnable()
    {
        currentValue = value;
    }
}

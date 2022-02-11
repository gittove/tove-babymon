using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSetBase<T> : ScriptableObject
{

    protected List<T> setList;

    private void OnEnable()
    {
        setList = new List<T>();
    }

    public void Add(T value)
    {
       setList.Add(value);
    }

    public void Remove(T value)
    {
        setList.Remove(value);
    }

    public void ClearSet()
    {
        setList.Clear();
    }
    
}

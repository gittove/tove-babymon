using System;
using UnityEngine;

public class MouseHoover : MonoBehaviour
{
    //When the mouse hovers over the GameObject, it turns to this color (red)
    Color m_MouseOverColor;

    //This stores the GameObject’s original color
    Color m_OriginalColor;

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    MeshRenderer m_Renderer;
    
    bool hoover = true;
    
    // [Header("Scriptable event")]
    // [SerializeField] 
    // private ScriptableEvent onHooverOverBaby;
    [Header("Scriptable event")]
    [SerializeField] 
    private ScriptableEventInt onHooverOverBaby;

    private bool isPause;

    private int instanceId;

    public int InstanceId
    {
        get
        {
            return instanceId;
        }
    }
    private void Awake()
    {
        instanceId = GetInstanceID();
    }

    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        m_MouseOverColor = new Color(1,0,0.7f,0.5f);
        //Fetch the original color of the GameObject
        m_OriginalColor = m_Renderer.material.color;
    }

    void OnMouseOver()
    {
        if (!isPause && hoover)
        {
            onHooverOverBaby.RaiseEvent(instanceId);
            // onHooverOverBaby.RaiseEvent(instanceId);
            // Debug.Log("Baby need 1: Food");
            // Debug.Log("Baby need 2: Diaper change");
            // Debug.Log("Baby need 3: Sleep");
            hoover = false;
            // Change the color of the GameObject to red when the mouse is over GameObject
            m_Renderer.material.color = m_MouseOverColor;
        }
    }

    void OnMouseExit()
    {
        if (!isPause)
        {
            onHooverOverBaby.RaiseEvent(instanceId);
            // onHooverOverBaby.RaiseEvent(instanceId);
            hoover = true;
            // Reset the color of the GameObject back to normal
            m_Renderer.material.color = m_OriginalColor;
        }
    }

    public void ChangePauseVariable(bool pause) //Todo change method name
    {
        isPause = pause;
    }
    
}

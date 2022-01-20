using System.Collections;
using System.Collections.Generic;
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

    private bool isPause;

    
    [SerializeField] 
    private ScriptableEvent<Vector3> onHooverOverBaby;

    //TODO pause
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
        // Change the color of the GameObject to red when the mouse is over GameObject
        m_Renderer.material.color = m_MouseOverColor;
        
        if (hoover && !isPause)
        {
            onHooverOverBaby.RaiseEvent(transform.position);
            Debug.Log("Baby need 1: Food");
            Debug.Log("Baby need 2: Diaper change");
            Debug.Log("Baby need 3: Sleep");
            hoover = false;
        }
    }

    void OnMouseExit()
    {
        onHooverOverBaby.RaiseEvent(transform.position);
        hoover = true;
        // Reset the color of the GameObject back to normal
        m_Renderer.material.color = m_OriginalColor;
    }
    
}

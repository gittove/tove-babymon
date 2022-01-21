using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    Renderer m_Renderer;
    [SerializeField] float outlineWidth = 0.12f;

    void Start()
    {
        m_Renderer = GetComponentInChildren<Renderer>();
    }

    void OnMouseEnter() 
    {
        m_Renderer.material.SetFloat("_OutlineWidth", outlineWidth);
    }

    void OnMouseExit()
    {
        m_Renderer.material.SetFloat("_OutlineWidth", 0.0f);    
    }
}
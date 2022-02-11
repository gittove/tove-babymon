using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    Renderer m_Renderer;
    [SerializeField] float outlineWidth = 0.12f;
    public GameObject player;
    [SerializeField] float minInteractionDistance = 2f;

    void Start()
    {
        m_Renderer = GetComponentInChildren<Renderer>();
    }

    void OnMouseEnter() 
    {
        m_Renderer.material.SetFloat("_OutlineWidth", outlineWidth);
        if (Vector3.Distance(player.transform.position, this.transform.position) < minInteractionDistance)
        {
             Debug.Log(player.GetComponentInChildren<CollisionDetector>().playerID);
        }
    }

    void OnMouseExit()
    {
        m_Renderer.material.SetFloat("_OutlineWidth", 0.0f);    
    }
}
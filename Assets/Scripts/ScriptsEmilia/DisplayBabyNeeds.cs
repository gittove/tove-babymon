using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBabyNeeds : MonoBehaviour
{
    private MeshRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        renderer.enabled = false;
    }

    public void ShowBabyNeeds(Vector3 position)
    {
        if (!renderer.enabled)
        {
            transform.position = new Vector3(position.x, position.y *4, position.z);
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
    }
}

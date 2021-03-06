﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material GazedAtMaterial;
    private Renderer m_MyRenderer;

    public GameObject lidOpen;
    public GameObject lidClose;
    
    public void Start()
    {
        m_MyRenderer = GetComponent<Renderer>();
        SetMaterial(false);
        lidOpen.SetActive(false);
        lidClose.SetActive(true);
    }
    
    public void TeleportObject()
    {
        lidOpen.SetActive(true);
        lidClose.SetActive(false);
        gameObject.SetActive(false);
    }
    

    public void OnPointerEnter()
    {
        SetMaterial(true);
    }
    
    public void OnPointerExit()
    {
        SetMaterial(false);
    }
    
    public void OnPointerClick()
    {
        TeleportObject();
    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            m_MyRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}

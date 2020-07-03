using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadCombinationDigitController : MonoBehaviour
{
//    public Material GazedAtMaterial;
    private Renderer m_MyRenderer;

    public Material[] mats;
    

    public bool isOk = false;
    public int answerIndex = 1;
    private int matIndex = 11;
    
    

    public void Start()
    {
        m_MyRenderer = GetComponent<Renderer>();
//        SetMaterial(false);
        m_MyRenderer.material = mats[matIndex];
    }
    
    public void TeleportObject()
    {
        // change to next material
        matIndex++;
        matIndex = matIndex % mats.Length;
        isOk = matIndex == answerIndex;
        m_MyRenderer.material = mats[matIndex];
    }
    

//    public void OnPointerEnter()
//    {
//        SetMaterial(true);
//    }
    
//    public void OnPointerExit()
//    {
//        SetMaterial(false);
//    }
    
    public void OnPointerClick()
    {
        TeleportObject();
    }

//    /// <summary>
//    /// Sets this instance's material according to gazedAt status.
//    /// </summary>
//    ///
//    /// <param name="gazedAt">
//    /// Value `true` if this object is being gazed at, `false` otherwise.
//    /// </param>
//    private void SetMaterial(bool gazedAt)
//    {
//        m_MyRenderer.material = gazedAt ? GazedAtMaterial : mats[matIndex];
//    }
}

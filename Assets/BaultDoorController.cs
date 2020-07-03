using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaultDoorController : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material GazedAtMaterial;
    private Renderer m_MyRenderer;

    public GameObject numPad;
    
    private bool isObjectMoved = false;
    private float movedAt;
    
    public void Start()
    {
        m_MyRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }
    
    public void TeleportObject()
    {
        if(isObjectMoved) return;
        numPad.SetActive(true);
        isObjectMoved = true;
        movedAt = Time.time;
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

    public void Update()
    {
        if (isObjectMoved && Time.time - movedAt > 10)
        {
            isObjectMoved = false;
            numPad.SetActive(false);
        }
    }
}

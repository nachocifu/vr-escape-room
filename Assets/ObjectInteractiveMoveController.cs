
using UnityEngine;

public class ObjectInteractiveMoveController : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material GazedAtMaterial;
    private Renderer m_MyRenderer;

    private Vector3 originalPosition;
    public Vector3 movedPosition;
    
    private bool isObjectMoved = false;
    private float movedAt;
    
    public void Start()
    {
        m_MyRenderer = GetComponent<Renderer>();
        SetMaterial(false);
        originalPosition =  transform.position;
    }
    
    public void TeleportObject()
    {
        if(isObjectMoved) return;
        transform.position = movedPosition;
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
            transform.position = originalPosition;
        }
    }
}

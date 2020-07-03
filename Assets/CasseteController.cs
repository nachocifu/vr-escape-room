using UnityEngine;

public class CasseteController : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material GazedAtMaterial;
    private Renderer m_MyRenderer;

    public GameObject radioOn;
    public GameObject radioOff;
    
    public void Start()
    {
        m_MyRenderer = GetComponent<Renderer>();
        SetMaterial(false);
        radioOn.SetActive(false);
        radioOff.SetActive(true);
    }
    
    public void TeleportObject()
    {
        radioOn.SetActive(true);
        radioOff.SetActive(false);
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

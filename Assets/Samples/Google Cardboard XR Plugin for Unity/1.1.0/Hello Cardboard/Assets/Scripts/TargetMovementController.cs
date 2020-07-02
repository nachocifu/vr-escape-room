using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementController : MonoBehaviour
{
    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    public Material InactiveMaterial;

    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    public Material GazedAtMaterial;

    // The objects are about 1 meter in radius, so the min/max target distance are
    // set so that the objects are always within the room (which is about 5 meters
    // across).
    private const float k_MinObjectDistance = 2.5f;
    private const float k_MaxObjectDistance = 3.5f;
    private const float k_MinObjectHeight = 0.5f;
    private const float k_MaxObjectHeight = 3.5f;

    private Renderer m_MyRenderer;
    private Vector3 m_StartingPosition;

    private Transform player;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        m_StartingPosition = transform.localPosition;
        m_MyRenderer = GetComponent<Renderer>();
        SetMaterial(false);
        player =  GameObject.Find("Player").transform;
    }

    /// <summary>
    /// Teleports the user to this instance x y coordinates
    /// </summary>
    public void TeleportUser()
    {
        // teleport user to this xy location
        player.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        TeleportUser();
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

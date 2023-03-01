using UnityEngine;

public class BorderToggle : MonoBehaviour
{
    
    private Renderer rend;  // The renderer component of the object
    private Shader originalShader;  // The original shader of the object
    private bool isHovering;  // A flag to track whether the mouse is hovering over the object

    void Start()
    {
        rend = GetComponent<Renderer>();  // Get the renderer component
        originalShader = rend.material.shader;  // Store the original shader
    }

    void OnMouseEnter()
    {
        isHovering = true;  // Set the flag to indicate that the mouse is hovering
        rend.material.shader = Shader.Find("Standard");  // Remove the border shader
    }

    void OnMouseExit()
    {
        //isHovering = false;  // Reset the flag to indicate that the mouse is no longer hovering
        rend.material.shader = originalShader;  // Restore the original shader
    }

    void Update()
    {
        if (isHovering)
        {
        }
    }
}
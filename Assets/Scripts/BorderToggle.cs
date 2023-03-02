/*
 BorderToggle.cs
Create date: 2023.3.1
Created by: Hyunjin Kikm
Code added by: Hyunjin Kim, Jordan Partridge
 */

using UnityEngine;

public class BorderToggle : MonoBehaviour
{
    
    private Renderer rend;  // The renderer component of the object
    private Shader originalShader;  // The original shader of the object
    private Transform grabPointTransform;
    private Rigidbody rb;

    private bool canInteract = true;
    private float interactRange = 1.5f;
    private float smoothing = 20f;

    void Start()
    {
        rend = GetComponent<Renderer>();  // Get the renderer component
        rb = GetComponent<Rigidbody>();
        originalShader = rend.materials[1].shader;  // Store the original shader
    }

    void FixedUpdate()
    {
        if(grabPointTransform != null)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, grabPointTransform.position, Time.deltaTime * smoothing);
            Quaternion newRot = Quaternion.Lerp(transform.rotation, grabPointTransform.rotation, Time.deltaTime * smoothing);

            rb.MovePosition(newPos);
            rb.MoveRotation(newRot);
        }  
    }

    void OnMouseEnter()
    {
        // Enable outline
        if (inRange() && canInteract)
            rend.materials[1].shader = Shader.Find("Shader Graphs/Toon_OutlineShader_Highlighted");  // Remove the border shader
    }

    void OnMouseExit()
    {
        rend.materials[1].shader = originalShader;  // Restore the original shader
    }

    void OnMouseDown()
    {
        if (inRange())
            GrabObject(GameObject.Find("GrabPoint"));
    }

    public void GrabObject(GameObject gameObject)
    {
        grabPointTransform = gameObject.transform;
        rb.useGravity = false;
        canInteract = false;
    }

    public bool inRange()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, interactRange, transform.forward);
        foreach (RaycastHit hit in hits)
            if (hit.collider.gameObject.name == "Player")
                return true;

        return false;
    }
}
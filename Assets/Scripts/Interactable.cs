/*
 BorderToggle.cs
Create date: 2023.3.1
Created by: Hyunjin Kim
Code added by: Hyunjin Kim, Jordan Partridge
 */

using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [SerializeField] private bool canPickUp;
    [SerializeField] private bool throwAway;
    private Renderer rend;  // The renderer component of the object
    private Shader originalShader;  // The original shader of the object
    private Transform grabPointTransform;
    private Rigidbody rb;

    private bool canInteract = true;
    private PlayerController playerController;
    private float interactRange = 1.5f;
    private float smoothing = 20f;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        rend = GetComponent<Renderer>();  // Get the renderer component
        rb = GetComponent<Rigidbody>();
        originalShader = rend.materials[1].shader;  // Store the original shader
    }

    void FixedUpdate()
    {
        if (grabPointTransform != null)
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
            rend.materials[1].shader = Shader.Find("Shader Graphs/Toon_OutlineShader_Green");  // Remove the border shader


    }

    void OnMouseExit()
    {
        rend.materials[1].shader = originalShader;  // Restore the original shader
    }

    void OnMouseDown()
    {
        // When the object is cup
        if (inRange() && canPickUp && playerController.currentDrink == null)
        {
            GrabObject(GameObject.Find("GrabPoint"));
        }
        else if(inRange() && throwAway)
        {
            playerController.currentDrink = null;
            grabPointTransform = null;

            Destroy(gameObject);
        }
    }

    public void GrabObject(GameObject obj)
    {
        grabPointTransform = obj.transform;
        rb.useGravity = false;
        canInteract = false;
        throwAway = true;

        playerController.currentDrink = Instantiate(gameObject, transform.position, transform.rotation);
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
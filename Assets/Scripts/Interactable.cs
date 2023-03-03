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
            if(gameObject.tag == "TrashCan")
                rend.materials[1].shader = Shader.Find("Shader Graphs/Toon_OutlineShader_Red");
            else rend.materials[1].shader = Shader.Find("Shader Graphs/Toon_OutlineShader_Green");
    }

    void OnMouseExit()
    {
        rend.materials[1].shader = Shader.Find("Shader Graphs/Toon_OutlineShader");  // Restore the original shader
    }

    void OnMouseDown()
    {
        // When the object is cup
        if (playerController.currentDrink == null)
        {
            if (inRange() && canPickUp)
                GrabObject(GameObject.Find("GrabPoint"));
        }
        else
        {
            if (inRange() && gameObject.tag == "TrashCan" && playerController.currentDrink.GetComponent<Interactable>().throwAway)
            {
                Destroy(playerController.currentDrink.gameObject);
                playerController.currentDrink = null;
            } 
        }
    }

    public void GrabObject(GameObject obj)
    {
        playerController.currentDrink = Instantiate(gameObject, transform.position, transform.rotation);

        Interactable drinkInteract = playerController.currentDrink.GetComponent<Interactable>();
        drinkInteract.grabPointTransform = obj.transform;
        drinkInteract.canInteract = false;
        drinkInteract.throwAway = true;
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
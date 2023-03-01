using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;

    private Animator anim;

    private Camera playerCamera;
    private CharacterController controller;

    private void Start()
    {
        playerCamera = FindObjectOfType<Camera>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();    
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // Get input direction
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude > 0.1)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        // Rotate towards mouse cursor
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 target = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target - transform.position), Time.deltaTime * rotationSpeed);
        }

        // Move player
        controller.Move(direction * moveSpeed * Time.deltaTime);
    }

}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 5f;
    public float gravity = 9.8f;


    private CharacterController controller;
    private Animator anim;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        if (controller.isGrounded)
            moveDirection = movement;
        else moveDirection += gravity * Vector3.down * Time.deltaTime;

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), turnSpeed * Time.deltaTime);
            controller.Move(moveDirection);
            anim.SetBool("isRunning", true);
        }
        else anim.SetBool("isRunning", false);
    }
}

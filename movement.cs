using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private Vector3 move_direction;
    public CharacterController controller;
    [SerializeField] private bool is_grounded;
    [SerializeField] private float ground_check_distance;
    [SerializeField] private float gravity;
    [SerializeField] private GameObject groundCheck_gameObject;
    [SerializeField] private LayerMask ground_mask;
    private Vector3 velocity;
    private Animator animator;
    public float jumpForce = 0.2f;
    public float jump_height=0.1f;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        move();
        PlayerJump();
    }
   
    private void move()
    {

        
          is_grounded = Physics.CheckSphere(groundCheck_gameObject.transform.position, ground_check_distance, ground_mask);
        //lw heya 3ala el ard stop apply gravity
        if (is_grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float move_z = Input.GetAxis("Vertical");/////ws
        move_direction = new Vector3(0, 0, move_z);
        move_direction = transform.TransformDirection(move_direction);
        if (is_grounded)
        {
            if (move_direction != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                walk();
            }
            else if (move_direction != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                run();
            }
            else if (move_direction == Vector3.zero)
            {
                idle();
            }
        }

        move_direction *= moveSpeed;
        controller.Move(move_direction * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void idle()
    {
        animator.SetFloat("Blend", 0);
    }
    private void walk()
    {
        moveSpeed = walkSpeed;
        animator.SetFloat("Blend", 0.5f);
    }
    private void run()
    {
        moveSpeed = runSpeed;
        animator.SetFloat("Blend", 1);
    }
    void PlayerJump()
    {
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpForce;
            velocity.y = Mathf.Sqrt(jump_height * -2f * gravity);
            animator.SetBool("jump", true);
        }

        else
        {
            animator.SetBool("jump", false);
        }
    }
}

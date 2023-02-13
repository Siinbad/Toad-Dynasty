using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller;
        // For grounded
        controller = GetComponent<CharacterController>();
        bool groundedPlayer; // is grounded?
        // bool value to tell if WASD key is being held down
        bool wPressed = Input.GetKey("w");
        bool aPressed = Input.GetKey("a");
        bool sPressed = Input.GetKey("s");
        bool dPressed = Input.GetKey("d");
        bool lShiftPressed = Input.GetKey("left shift");
        bool isJumping = Input.GetKey("space");
      


        // Is grounded?
        groundedPlayer = controller.isGrounded;

        // w, walking if pressed or if not being pressed
        if (wPressed || aPressed || sPressed || dPressed)
        {
            animator.SetBool("isWalking", true);
        }

        if (!wPressed && !aPressed && !sPressed && !dPressed)
        {
            animator.SetBool("isWalking", false);
        }

        // sprinting with left shift
        if (lShiftPressed && (wPressed || aPressed || sPressed || dPressed))
        {
            animator.SetBool("isRunning", true);
        }

        if (!lShiftPressed)
        {
            animator.SetBool("isRunning", false);
        }

        // Jumping
        if (isJumping)
        {
            animator.SetBool("isJumping", true);
        }
        else if (groundedPlayer)
        {
            animator.SetBool("isJumping", false);
        }
    }
}

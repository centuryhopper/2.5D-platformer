// using System;
// using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController controller = null;
    bool isGrounded = true;
    public float speed = 10f;
    public float jumpSpeed = 2.0f;
    public float gravity = 10.0f;
    private Vector3 movingDirection = Vector3.zero;

    [SerializeField] Animator anim = null;
    [SerializeField] Transform groundChecker = null;
    [SerializeField] LayerMask ground;
    public float groundDistance = 3f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // move the player left and right with the character controller
        Vector3 move = new Vector3(0, 0, Input.GetAxis("Horizontal"));

        // if we're moving
        if (move != Vector3.zero)
            transform.forward = move;

        controller.Move(move * Time.deltaTime * speed);

        // add animations to horizontal movement
        // 0 <= blend values <= 0.6f
        anim.SetFloat("Blend", Mathf.Abs(Input.GetAxis("Horizontal")));


        // check for jumping
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, ground, QueryTriggerInteraction.Ignore);
        // if (isGrounded && movingDirection.y < 0)
        //     movingDirection.y = 0f;

        // add jump functionality
        Jump();
    }


    // debug the ground checker by showing a green sphere
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundChecker.position, groundDistance);
    }

    void Jump()
    {
        // if the player is touching the ground
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            print("jump");
            movingDirection.y = jumpSpeed;
        }
        movingDirection.y -= gravity * Time.deltaTime;
        controller.Move(movingDirection * Time.deltaTime);
    }
}

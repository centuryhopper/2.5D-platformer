using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Player : MonoBehaviour
    {
        public int level;
        public int health;

        public float speed = 20f, jumpHeight = 10f;

        Rigidbody rb = null;

        BoxCollider feetCollider = null;
        CapsuleCollider bodyCollider = null;

        private bool grounded = true;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            feetCollider = GetComponent<BoxCollider>();
            bodyCollider = GetComponent<CapsuleCollider>();
        }

        void Update()
        {
            // move left when holding this key down
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Vector3.back * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            }
            // move right when holding this key down
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (Input.GetButtonDown("Jump") && grounded)
            {
                Jump();
            }

            // transform.rotation = Quaternion.Identity;
        }

        void Jump()
        {
            // if touching the ground, add a force upwards
            // otherwise, you're airborne, so let gravity
            // drop you down first
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            // grounded = false;
        }

        void OnTriggerStay(Collider other)
        {
            if(other.gameObject.CompareTag("ground"))
            {
                grounded = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if(other.gameObject.CompareTag("ground"))
            {
                grounded = false;
            }
        }
    }
}

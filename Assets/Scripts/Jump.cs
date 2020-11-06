using UnityEngine;

namespace Game.PlayerCharacter
{
    public class Jump : MonoBehaviour
    {
        [Range(1, 10)]
        public float jumpForce = 5f;
        Rigidbody rb;
        bool isGrounded = true;
        bool shouldJump;
        readonly string jumpInput = "Jump";


        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (isGrounded)
            {
                shouldJump = Input.GetButtonDown(jumpInput);
            }
            else
            {
                shouldJump = false;
            }
        }

        void FixedUpdate()
        {
            if (shouldJump)
            {
                print("jump");
                rb.velocity = new Vector3(0, 10, 0);
            }
        }

        void OnCollisionEnter(Collision c)
        {
            if (c.gameObject.CompareTag("ground"))
            {
                isGrounded = true;
            }
        }

        void OnCollisionExit(Collision c)
        {
            if (c.gameObject.CompareTag("ground"))
            {
                isGrounded = false;
            }
        }
    }
}

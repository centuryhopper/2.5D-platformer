using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (rb.velocity.y < 0)
        // {
        //     rb.gravityScale = fallMultiplier;
        // }
        // else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        // {
        //     rb.gravityScale = lowJumpMultiplier;
        // }
        // else
        // {
        //     rb.gravityScale = 1f;
        // }
    }
}

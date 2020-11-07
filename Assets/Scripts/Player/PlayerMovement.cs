
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.PlayerCharacter
{
    public enum AnimationParameters
    {
        move,
        jump,
        force_transition,
        isGrounded
    }

    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 10f;
        public bool jump;
        public bool moveLeft, moveRight;
        // Animator anim = null;
        BoxCollider box = null;
        Rigidbody rb;
        public Rigidbody RB
        {
            get
            {
                if (rb == null)
                {
                    rb = GetComponent<Rigidbody>();
                }
                return rb;
            }
        }

        public List<GameObject> groundCheckers { get; private set; }

        [SerializeField] GameObject groundCheckingSphere = null;

        [SerializeField] int sections = 5;

        void Awake()
        {
            box = GetComponent<BoxCollider>();
            groundCheckers = new List<GameObject>();

            // y-z plane in this case
            float top = box.bounds.center.y + box.bounds.extents.y;
            float bottom = box.bounds.center.y - box.bounds.extents.y;

            float front = box.bounds.center.z + box.bounds.extents.z;
            float back = box.bounds.center.z - box.bounds.extents.z;

            // create the spheres and add them to the list
            GameObject bottomFrontSphere = CreateGroundCheckingSphere(new Vector3(0, bottom, front));
            GameObject bottomBackSphere = CreateGroundCheckingSphere(new Vector3(0, bottom, back));

            groundCheckers.Add(bottomFrontSphere);
            groundCheckers.Add(bottomBackSphere);

            // parent the player to the spheres so the positions of the ground checkers are accurate
            bottomFrontSphere.transform.parent = this.transform;
            bottomBackSphere.transform.parent = this.transform;

            // divide into 5 sections and add a sphere for each section
            float section = (bottomFrontSphere.transform.position
            - bottomBackSphere.transform.position).magnitude / sections;

            for (int i = 0; i < sections; ++i)
            {
                // find position for each section
                //         X       X       X       X       X
                // | ..... | ..... | ..... | ..... | ..... | ..... |
                Vector3 position = bottomBackSphere.transform.position + (Vector3.forward * section * (i + 1));

                // instantiate sphere
                GameObject sphere = CreateGroundCheckingSphere(position);

                // parent it to the player
                sphere.transform.parent = this.transform;

                // add it to the list
                groundCheckers.Add(sphere);
            }
        }

        public GameObject CreateGroundCheckingSphere(Vector3 position) => Instantiate(groundCheckingSphere, position, Quaternion.identity);






        // /// <summary>
        // /// moves the player left and right
        // /// </summary>
        // void MovePlayer()
        // {
        //     // side scroller
        //     print("here");
        //     if (Input.GetKey(KeyCode.D))
        //     {
        //         transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //         // transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //         transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.up);
        //         anim.SetBool(AnimationParameters.move.ToString(), true);
        //     }
        //     else if (Input.GetKey(KeyCode.A))
        //     {
        //         transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //         // transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        //         transform.rotation = Quaternion.LookRotation(-Vector3.forward, transform.up);
        //         anim.SetBool(AnimationParameters.move.ToString(), true);
        //     }
        //     else
        //     {
        //         anim.SetBool(AnimationParameters.move.ToString(), false);
        //     }
        // }

        // void FlipSprite()
        // {
        //     // don't cache Input.GetAxis("Horizontal"), or it will not work
        //     if (Input.GetAxis("Horizontal") != 0)
        //     {
        //         float zScale = Mathf.Abs(transform.localScale.z);
        //         transform.localScale = (Input.GetAxis("Horizontal") > 0) ?
        //         new Vector3(transform.localScale.x,transform.localScale.y,zScale) :
        //         new Vector3(transform.localScale.x,transform.localScale.y,-zScale);
        //     }
        // }
    }

}
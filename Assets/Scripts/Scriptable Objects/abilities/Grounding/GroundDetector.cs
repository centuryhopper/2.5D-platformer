using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.PlayerCharacter
{
    [CreateAssetMenu(fileName = "New State", menuName = "ability/ground detector", order = 0)]
    public class GroundDetector : StateData
    {
        [Range(.01f, 5)]
        public float distanceOfDetection;

        override public void OnEnter(CharacterStateBase character, Animator a, AnimatorStateInfo asi)
        {
            // throw new System.NotImplementedException();
        }

        override public void UpdateAbility(CharacterStateBase c, Animator a, AnimatorStateInfo asi)
        {
            PlayerMovement p = c.GetPlayerMoveMent(a);

            if (IsGrounded(p))
            {
                a.SetBool(AnimationParameters.isGrounded.ToString(), true);
            }
            else
            {
                // Debug.LogWarning("not grounded");
                a.SetBool(AnimationParameters.isGrounded.ToString(), false);
            }
        }

        override public void OnExit(CharacterStateBase c, Animator a, AnimatorStateInfo asi)
        {

        }

        private bool IsGrounded(PlayerMovement p)
        {
            if (Mathf.Approximately(p.RB.velocity.y, 0))
            {
                return true;
            }

            foreach (GameObject obj in p.groundCheckers)
            {
                // show the rays
                Debug.DrawRay(obj.transform.position, Vector3.down * distanceOfDetection, Color.black);

                RaycastHit hit;

                // project a ray downwards
                if (Physics.Raycast(obj.transform.position, Vector3.down, out hit, distanceOfDetection))
                {
                    return true;
                }
            }


            // here the player is still airborne
            return false;
        }
    }
}

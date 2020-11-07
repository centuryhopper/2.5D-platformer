using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.PlayerCharacter
{
    [CreateAssetMenu(fileName = "New State", menuName = "ability/move", order = 0)]
    public class MoveForward : StateData
    {
        public AnimationCurve speedGraph;
        public float speed;

        override public void OnEnter(CharacterStateBase character, Animator a, AnimatorStateInfo asi)
        {
            throw new System.NotImplementedException();
        }

        override public void UpdateAbility(CharacterStateBase c, Animator a, AnimatorStateInfo asi)
        {
            MovePlayer(c.GetPlayerMoveMent(a), a, asi);
        }

        override public void OnExit(CharacterStateBase c, Animator a, AnimatorStateInfo asi)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// moves the player left and right
        /// </summary>
        void MovePlayer(PlayerMovement p, Animator animator, AnimatorStateInfo asi)
        {
            // side scroller
            if (Input.GetKey(KeyCode.D))
            {
                // multiple by the speed graph value so that we can still move while we jump
                p.transform.Translate(Vector3.forward * speed * speedGraph.Evaluate(asi.normalizedTime) * Time.deltaTime);
                // p.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                // transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                p.transform.rotation = Quaternion.LookRotation(Vector3.forward, p.transform.up);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                // multiple by the speed graph value so that we can still move while we jump
                p.transform.Translate(Vector3.forward * speed * speedGraph.Evaluate(asi.normalizedTime) * Time.deltaTime);
                // p.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                // transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                p.transform.rotation = Quaternion.LookRotation(-Vector3.forward, p.transform.up);
            }
            else
            {
                // go back to idle animation
                animator.SetBool(AnimationParameters.move.ToString(), false);
            }
        }
    }
}

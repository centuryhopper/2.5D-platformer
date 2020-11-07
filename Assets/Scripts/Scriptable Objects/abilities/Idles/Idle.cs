using UnityEngine;

namespace Game.PlayerCharacter
{
    [CreateAssetMenu(fileName = "idle", menuName = "idle")]
    public class Idle : StateData
    {
        override public void OnEnter(CharacterStateBase character, Animator a, AnimatorStateInfo asi)
        {
            // prevents the bug: player jumping while airborne
            a.SetBool(AnimationParameters.jump.ToString(), false);
        }

        override public void UpdateAbility(CharacterStateBase c, Animator a, AnimatorStateInfo asi)
        {

            // only determine when to switch to the walk animation
            if (Input.GetKey(KeyCode.D))
            {
                a.SetBool(AnimationParameters.move.ToString(), true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                a.SetBool(AnimationParameters.move.ToString(), true);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                a.SetBool(AnimationParameters.jump.ToString(), true);
            }
            else
            {
                a.SetBool(AnimationParameters.move.ToString(), false);
            }
        }

        override public void OnExit(CharacterStateBase c, Animator a, AnimatorStateInfo asi)
        {
            throw new System.NotImplementedException();
        }
    }
}
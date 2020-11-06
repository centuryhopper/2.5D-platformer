using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.PlayerCharacter
{
    [CreateAssetMenu(fileName = "New State", menuName = "ability/landing", order = 0)]
    public class Landing : StateData
    {
        [Range(0.01f, 1f)]
        public float transitionTime;

        override public void OnEnter(CharacterStateBase character, Animator a, AnimatorStateInfo asi)
        {
            a.SetBool(AnimationParameters.jump.ToString(), false);
        }

        override public void UpdateAbility(CharacterStateBase c, Animator a, AnimatorStateInfo asi)
        {

        }

        override public void OnExit(CharacterStateBase c, Animator a, AnimatorStateInfo asi)
        {
            
        }

    }
}

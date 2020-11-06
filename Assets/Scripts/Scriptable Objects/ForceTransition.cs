using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.PlayerCharacter
{
    [CreateAssetMenu(fileName = "New State", menuName = "ability/force transition", order = 0)]
    public class ForceTransition : StateData
    {
        [Range(0.01f, 1f)]
        public float transitionTime;

        override public void OnEnter(CharacterStateBase character, Animator a, AnimatorStateInfo asi)
        {
            // throw new System.NotImplementedException();
        }

        override public void UpdateAbility(CharacterStateBase c, Animator a, AnimatorStateInfo asi)
        {
            if (asi.normalizedTime >= transitionTime)
            {
                a.SetBool(AnimationParameters.force_transition.ToString(), true);
            }
        }

        override public void OnExit(CharacterStateBase c, Animator a, AnimatorStateInfo asi)
        {
            a.SetBool(AnimationParameters.force_transition.ToString(), false);
        }

    }
}

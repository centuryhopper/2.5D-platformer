using System.Collections.Generic;
using UnityEngine;

namespace Game.PlayerCharacter
{
    public class CharacterStateBase : StateMachineBehaviour
    {
        // list of scriptable objects
        public List<StateData> abilityDataLst = new List<StateData>();

        public void UpdateAll(CharacterStateBase c, Animator a, AnimatorStateInfo asi)
        {
            foreach (StateData d in abilityDataLst)
            {
                d.UpdateAbility(c, a, asi);
            }
        }

        override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            foreach (StateData d in abilityDataLst)
            {
                d.OnEnter(this, animator, animatorStateInfo);
            }
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            UpdateAll(this, animator, animatorStateInfo);
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            foreach (StateData d in abilityDataLst)
            {
                d.OnExit(this, animator, animatorStateInfo);
            }
        }

        private PlayerMovement playerMovement;

        public PlayerMovement GetPlayerMoveMent(Animator animator)
        {
            if (playerMovement == null)
            {
                playerMovement = animator.GetComponentInParent<PlayerMovement>();
            }

            return playerMovement;
        }
    }
}

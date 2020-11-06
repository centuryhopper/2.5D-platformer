using UnityEngine;

namespace Game.PlayerCharacter
{
    public abstract class StateData : ScriptableObject
    {
        public abstract void OnEnter(CharacterStateBase character, Animator a, AnimatorStateInfo asi);
        public abstract void UpdateAbility(CharacterStateBase c, Animator a, AnimatorStateInfo asi);
        public abstract void OnExit(CharacterStateBase c, Animator a, AnimatorStateInfo asi);
    }
}

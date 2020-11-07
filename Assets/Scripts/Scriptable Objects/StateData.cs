using UnityEngine;

namespace Game.PlayerCharacter
{
    /// <summary>
    /// the base model for every player action/ability that has
    /// and will be created.
    /// Always get the player movement script from the CharacterStateBase class
    /// </summary>
    public abstract class StateData : ScriptableObject
    {
        public abstract void OnEnter(CharacterStateBase character, Animator a, AnimatorStateInfo asi);
        public abstract void UpdateAbility(CharacterStateBase c, Animator a, AnimatorStateInfo asi);
        public abstract void OnExit(CharacterStateBase c, Animator a, AnimatorStateInfo asi);
    }
}

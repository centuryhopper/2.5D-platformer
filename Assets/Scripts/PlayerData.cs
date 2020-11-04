using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    /// <summary>
    /// all data you want to save
    /// </summary>
    [System.Serializable]
    public class PlayerData
    {
        public int level;
        public int health;
        public float[] positions;

        public PlayerData(Player player)
        {
            level = player.level; health = player.health;
            positions = new float[]
            {
            player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z,
            };
        }

    }
}

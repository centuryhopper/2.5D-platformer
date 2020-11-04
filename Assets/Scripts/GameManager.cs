using System.Collections;
using System.Collections.Generic;
using Game.Core;
using Game.Utils;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player = null;

    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(player);
    }

    public void LoadPlayerData()
    {
        // load out the player data
        PlayerData playerData = SaveSystem.LoadPlayer();

        if (playerData != null)
        {
            player.level = playerData.level;
            player.health = playerData.health;

            Vector3 playerPos = new Vector3
            (
                playerData.positions[0],
                playerData.positions[1],
                playerData.positions[2]
            );

            player.transform.position = playerPos;
        }
    }


}

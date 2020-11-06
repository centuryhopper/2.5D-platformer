using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using Game.Core;

// Game.Utils should only contain static classes
namespace Game.Utils
{
    public static class SaveSystem
    {
        // auxiliary members
        static string playerPath = Application.persistentDataPath + "/player.txt";
        static BinaryFormatter formatter = new BinaryFormatter();
        static FileStream fs;

        public static void SavePlayer(Player player)
        {
            fs = new FileStream(playerPath, FileMode.Create);

            // allocate playerdata
            PlayerData data = new PlayerData(player);

            // save the player data into the txt file
            formatter.Serialize(fs, data);

            // maintain good practice by closing the file stream when done
            fs.Close();
        }

        public static PlayerData LoadPlayer()
        {
            if (File.Exists(playerPath))
            {
                // open up a file
                fs = new FileStream(playerPath, FileMode.Open);

                // convert binary file back into usable data
                PlayerData data = formatter.Deserialize(fs) as PlayerData;

                // maintain good practice by closing the file stream when done
                fs.Close();

                return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + playerPath);
                return null;
            }
        }
    }
}

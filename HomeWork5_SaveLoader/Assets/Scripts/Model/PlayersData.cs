using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class PlayersData
    {
        [field:SerializeField] public int IndexNewPlayer { get; private set; }
        public List<PlayerData> Players = new List<PlayerData>();
        
        public PlayerData CreatePlayer()
        {
            IndexNewPlayer++;
            int ValueResourceDefault = 100;
            int ValueResourceDefaultMax = 10000;
            var playerData = new PlayerData()
            {
                IndexPlayer = IndexNewPlayer,
                UnitsData = new UnitsData(),
                ResourcesData = new ResourcesData()
                {
                    ResourceFood = new ResourceFood(ValueResourceDefault,ValueResourceDefaultMax, 12),
                    ResourceGold = new ResourceGold(ValueResourceDefault,ValueResourceDefaultMax, 2),
                    ResourceWood = new ResourceWood(ValueResourceDefault,ValueResourceDefaultMax, 7),
                    ResourceRock = new ResourceRock(ValueResourceDefault,ValueResourceDefaultMax, 4),
                }
            };

            Players.Add(playerData);
            
            return playerData;
        }
    }
}
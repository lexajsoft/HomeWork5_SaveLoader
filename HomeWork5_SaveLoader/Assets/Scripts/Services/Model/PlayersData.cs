using System;
using System.Collections.Generic;
using Services.SaveLoader;
using UnityEngine;

namespace Services.Model
{
    [Serializable]
    public class PlayersData
    {
        private int IndexNewPlayer = -1;
        public List<PlayerData> Players;
        
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
                    ResourceFood = new ResourceFood(ValueResourceDefault,ValueResourceDefaultMax),
                    ResourceGold = new ResourceGold(ValueResourceDefault,ValueResourceDefaultMax),
                    ResourceWood = new ResourceWood(ValueResourceDefault,ValueResourceDefaultMax),
                    ResourceRock = new ResourceRock(ValueResourceDefault,ValueResourceDefaultMax),
                }
            };

            Players.Add(playerData);
            
            return playerData;
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Services.Model
{
    [Serializable]
    public class GameModel
    {
        // Список тут нужен только для сохранения/загрузки и не более ибо jsonUnility не умеет со словарем работать 
        public PlayersData PlayerDatas;
        public List<MiningObject<ResourceBase>> MiningObjects;
        public Action OnGameModelLoaded;
        
        public Dictionary<int, PlayerData> PlayerDatasDictionary;
        public Dictionary<int, MiningObject<ResourceBase>> MiningObjectsDictionary;

        public void Init()
        {
            // Добавление игроков в словарь            
            PlayerDatasDictionary = new Dictionary<int, PlayerData>();
            for (int i = 0; i < PlayerDatas.Players.Count; i++)
            {
                PlayerDatasDictionary[PlayerDatas.Players[i].IndexPlayer] = PlayerDatas.Players[i];
            }

            // добавление добываемых ресурсов в игру
            MiningObjectsDictionary = new Dictionary<int, MiningObject<ResourceBase>>();
            for (int i = 0; i < MiningObjects.Count; i++)
            {
                MiningObjectsDictionary.Add(MiningObjects[i].IndexMiningObject, MiningObjects[i]);
            }
            
            OnGameModelLoaded?.Invoke();
        }

        public void CreatePlayer()
        {
            var playerData = PlayerDatas.CreatePlayer();
            PlayerDatasDictionary[playerData.IndexPlayer] = playerData;
        }

        public bool TryGetPlayerByIndex(int indexPlayer, out PlayerData playerData)
        {
            var index = PlayerDatas.Players.FindIndex(item => item.IndexPlayer == indexPlayer);
            if (indexPlayer >= 0)
            {
                playerData = PlayerDatas.Players[index];
                return true;
            }

            playerData = null;
            return false;
        }

        public void AddUnit(int indexPlayer, UnitData unitData)
        {
            PlayerDatasDictionary[indexPlayer].UnitsData.Add(unitData);
        }

        public void RemoveUnit(int indexPlayer, UnitData unitData)
        {
            PlayerDatasDictionary[indexPlayer].UnitsData.Remove(unitData);
        }

        // public string Save()
        // {
        //     return JsonUtility.ToJson(this);
        // }
        //
        // public void Load(string json)
        // {
        //     var data = JsonUtility.FromJson<GameModel>(json);
        //     this.PlayerDatas = data.PlayerDatas;
        //     this.MiningObjects = data.MiningObjects;
        //     Init();
        // }
        public void SetData(GameModel gameModel)
        {
            this.PlayerDatas = gameModel.PlayerDatas;
            this.MiningObjects = gameModel.MiningObjects;
        }
    }
}
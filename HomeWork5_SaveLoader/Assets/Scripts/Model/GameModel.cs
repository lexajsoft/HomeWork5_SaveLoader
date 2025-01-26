using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Model
{
    [Serializable]
    public class GameModel
    {
        // Список тут нужен только для сохранения/загрузки и не более ибо jsonUnility не умеет со словарем работать 
        public PlayersData PlayerDatas = new PlayersData();
        public MiningObjectsData MiningObjectsData = new MiningObjectsData();
        
        public Dictionary<int, PlayerData> PlayerDatasDictionary = new Dictionary<int, PlayerData>();
        public Dictionary<int, MiningObject<ResourceBase>> MiningObjectsDictionary = new Dictionary<int, MiningObject<ResourceBase>>();

        public Action<UnitData> OnAddUnit;
        public Action<UnitData> OnDelUnit;

        public Action OnCountPlayersChanged;
        public Action OnGameModelLoaded;
        public Action OnClearAll;
        
        public void InitAfterLoad()
        {
            Debug.Log("[GameModel]:init");
            // Добавление игроков в словарь            
            PlayerDatasDictionary = new Dictionary<int, PlayerData>();
            for (int i = 0; i < PlayerDatas.Players.Count; i++)
            {
                PlayerDatasDictionary[PlayerDatas.Players[i].IndexPlayer] = PlayerDatas.Players[i];
            }

            // добавление добываемых ресурсов в игру
            MiningObjectsDictionary = new Dictionary<int, MiningObject<ResourceBase>>();
            for (int i = 0; i < MiningObjectsData.MiningObjects.Count; i++)
            {
                MiningObjectsDictionary.Add(MiningObjectsData.MiningObjects[i].IndexMiningObject, MiningObjectsData.MiningObjects[i]);
            }

            OnGameModelLoaded?.Invoke();
            OnCountPlayersChanged?.Invoke();
        }

        public void CreatePlayer()
        {
            var playerData = PlayerDatas.CreatePlayer();
            PlayerDatasDictionary[playerData.IndexPlayer] = playerData;
            Debug.Log("Создан игрок с номером:" + playerData.IndexPlayer);
            
            OnCountPlayersChanged?.Invoke();
        }

        public bool TryGetPlayerByIndex(int indexPlayer, out PlayerData playerData)
        {
            var index = PlayerDatas.Players.FindIndex(item => item.IndexPlayer == indexPlayer);
            if (index >= 0)
            {
                playerData = PlayerDatas.Players[index];
                return true;
            }

            playerData = null;
            return false;
        }

        public void AddUnit(int indexPlayer, UnitData unitData)
        {
            unitData.PlayerIndex = indexPlayer;
            PlayerDatasDictionary[indexPlayer].UnitsData.Add(unitData);
            OnAddUnit?.Invoke(unitData);
        }

        public void RemoveUnit(int indexPlayer, UnitData unitData)
        {
            PlayerDatasDictionary[indexPlayer].UnitsData.Remove(unitData);
            OnDelUnit?.Invoke(unitData);
        }

        public void SetData(GameModel gameModel)
        {
            this.PlayerDatas = gameModel.PlayerDatas;
            this.MiningObjectsData = gameModel.MiningObjectsData;
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < PlayerDatas.Players.Count; i++)
            {
                PlayerDatas.Players[i].ResourcesData.UpdatePassiveAddingResources(deltaTime);
            }
        }

        public void ClearAll()
        {
            PlayerDatas = new PlayersData();
            MiningObjectsData = new MiningObjectsData();
            MiningObjectsDictionary = new Dictionary<int, MiningObject<ResourceBase>>();
            PlayerDatasDictionary = new Dictionary<int, PlayerData>();
            
            OnClearAll?.Invoke();
            OnCountPlayersChanged?.Invoke();
        }

        
    }
}
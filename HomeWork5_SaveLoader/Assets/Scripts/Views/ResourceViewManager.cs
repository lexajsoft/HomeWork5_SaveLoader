using System;
using Model;
using Services.ServiceLocator;
using TriInspector;
using UnityEngine;

namespace Views
{
    public class ResourceViewManager : ViewBase
    {
        [Inject] private GameModel _gameModel;
        [SerializeField] private ResourceValueView _foodResourceValueView;
        [SerializeField] private ResourceValueView _woodResourceValueView;
        [SerializeField] private ResourceValueView _goldResourceValueView;
        [SerializeField] private ResourceValueView _rockResourceValueView;
        
        [SerializeField] [ReadOnly] private int _playerIndex = 0;

        private void Start()
        {
            _gameModel.OnGameModelLoaded += OnGameModelLoaded;
            _gameModel.OnCountPlayersChanged += OnGameModelLoaded;
        }

        private void OnGameModelLoaded()
        {
            Init();
        }

        private void Init()
        {
            if (_gameModel.PlayerDatas.Players.Count > _playerIndex && _playerIndex >= 0)
            {
                var resourceData = _gameModel.PlayerDatas.Players[_playerIndex].ResourcesData;
                _foodResourceValueView.SetResources(resourceData.ResourceFood);
                _woodResourceValueView.SetResources(resourceData.ResourceWood);
                _goldResourceValueView.SetResources(resourceData.ResourceGold);
                _rockResourceValueView.SetResources(resourceData.ResourceRock);
            }
            else
            {
                _foodResourceValueView.SetResources(null);
                _woodResourceValueView.SetResources(null);
                _goldResourceValueView.SetResources(null);
                _rockResourceValueView.SetResources(null);
            }
        }

        public void SetPlayerIndex(int playerIndex)
        {
            _playerIndex = playerIndex;
            Init();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Configs;
using Model;
using Services.ServiceLocator;
using TriInspector;
using UnityEngine;
using Views;
using Random = UnityEngine.Random;

public class GameModelController : ViewBase
{
    [Inject] private GameModel _gameModel;
    [Inject] private UnitsConfig _unitsConfig;
    [Inject] private ResourceViewManager _resourceViewManager;
    
    [SerializeField] private int _playerIndex = 0;
    [SerializeField] private bool _createUnitInrandomPoint;
    [SerializeField] private float _randomDistanceSpawn = 10;

    private void OnValidate()
    {
        if(_resourceViewManager != null)
            _resourceViewManager.SetPlayerIndex(_playerIndex);
    }

    protected override void Awake()
    {
        base.Awake();
        _gameModel.InitAfterLoad();
        _resourceViewManager.SetPlayerIndex(_playerIndex);
    }

    private void Update()
    {
        _gameModel.Update(Time.deltaTime);
    }

    [Button]
    public void AddRandomUnit()
    {
        AddRandomUnit(_playerIndex, _createUnitInrandomPoint);
    }

    // добавлеяет выбранному юнита в параметрах игроку 
    public void AddRandomUnit(int indexPlayer = -1, bool isRandomPosition = false)
    {
        if(_gameModel.TryGetPlayerByIndex(indexPlayer, out var playerData))
        {
            var unitData = _unitsConfig.GetRandomUnitPrototype().ToNewUnitData();
            
            if (isRandomPosition)
            {
                unitData.Position = new Vector3Data()
                {
                    X = Random.Range(-_randomDistanceSpawn, _randomDistanceSpawn),
                    Z = Random.Range(-_randomDistanceSpawn, _randomDistanceSpawn)
                };
                unitData.EulerAngel = new Vector3Data()
                {
                    X = unitData.EulerAngel.X,
                    Y = Random.Range(0,360),
                    Z = unitData.EulerAngel.Z
                };
            }

            _gameModel.AddUnit(indexPlayer, unitData);
        }
        else
        {
            Debug.LogError($"Не удалось найти игрока с номером #{indexPlayer}");
        }
        
    }

    [Button]
    public void DelRandomUnit()
    {
        DelRandomUnit(_playerIndex);
    }

    public void DelRandomUnit(int indexPlayer = -1)
    {
        if (_gameModel.TryGetPlayerByIndex(indexPlayer, out var playerData))
        {
            if (playerData.UnitsData.Units.Count == 0)
                return;

            var randomUnitIndex = Random.Range(0, playerData.UnitsData.Units.Count);
            var randomUnit = playerData.UnitsData.Units[randomUnitIndex];
            _gameModel.RemoveUnit(indexPlayer, randomUnit);
        }
        else
        {
            Debug.LogError($"Не удалось найти игрока с номером #{indexPlayer}");
        }
    }

    // Добавлет игрока
    [Button]
    public void AddPlayer()
    {
        _gameModel.CreatePlayer();    
    }

    [Button]
    public void MoveToRandomPlaceUnits()
    {
        MoveToRandomPlaceUnits(_playerIndex);
    }

    // Перемещает рандомного юнита в случайную точку
    public void MoveToRandomPlaceUnits(int indexPlayer = -1)
    {
        if (_gameModel.TryGetPlayerByIndex(indexPlayer, out var playerData))
        {
            if (playerData.UnitsData.Units.Count == 0)
            {
                Debug.LogError($"У игрока нет юнитов (PlayerIndex:{indexPlayer}) ");
                return;
            }

            int randomUnitIndex = Random.Range(0, playerData.UnitsData.Units.Count);
            var unitData = playerData.UnitsData.Units[randomUnitIndex];
            unitData.Position = new Vector3Data()
            {
                X = Random.Range(-_randomDistanceSpawn, _randomDistanceSpawn),
                Z = Random.Range(-_randomDistanceSpawn, _randomDistanceSpawn)
            };
            unitData.EulerAngel = new Vector3Data()
            {
                X = unitData.EulerAngel.X,
                Y = Random.Range(0,360),
                Z = unitData.EulerAngel.Z
            };
            
        }
        else
        {
            Debug.LogError($"Не удалось найти игрока с номером #{indexPlayer}");
        }
    }

    public void ClearAll()
    {
        _gameModel.ClearAll();
    }
}

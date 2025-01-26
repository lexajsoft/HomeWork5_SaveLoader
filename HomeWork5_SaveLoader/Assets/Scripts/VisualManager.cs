using System;
using System.Collections;
using System.Collections.Generic;
using Factory;
using Model;
using Model.Factory;
using Services.ServiceLocator;
using UnityEngine;
using UnityEngine.Serialization;
using Views;

public class VisualManager : ViewBase
{
    [Inject] private GameModel _gameModel;
    [Inject] private UnitsFactory _unitsFactory;
    
    [SerializeField] private Transform _unitsContainer;
    [SerializeField] private Transform _miningContainer;

    private List<UnitViewBase> _units;
    private List<MiningObjectViewBase> _minings;
    
    public void Start()
    {
        Debug.Log("[VisualManager].Start");
        _gameModel = ServiceLocator.Get<GameModel>();
        _gameModel.OnGameModelLoaded += OnGameModelLoaded;
        
        _gameModel.OnAddUnit += OnAddUnit;
        _gameModel.OnDelUnit += OnDelUnit;
        _gameModel.OnClearAll += OnClearAll;
        _units = new List<UnitViewBase>();
        
    }

    private void OnClearAll()
    {
        DestroyUnits();
        DestroyMinings();
    }

    private void OnDestroy()
    {
        _gameModel.OnAddUnit -= OnAddUnit;
        _gameModel.OnDelUnit -= OnDelUnit;
    }

    private void OnAddUnit(UnitData unitData)
    {
        AddUnit(unitData);
    }

    private void OnDelUnit(UnitData unitData)
    {
        DelUnit(unitData);
    }
    
    private void OnGameModelLoaded()
    {
        DestroyUnits();
        DestroyMinings();

        // Создание юнитов
        for (int playerIndex = 0; playerIndex < _gameModel.PlayerDatas.Players.Count; playerIndex++)
        {
            for (int unitIndex = 0; unitIndex < _gameModel.PlayerDatas.Players[playerIndex].UnitsData.Units.Count; unitIndex++)
            {
                var unitView = _unitsFactory.CreateNew(_gameModel.PlayerDatas.Players[playerIndex].UnitsData.Units[unitIndex],
                        _unitsContainer);
                _units.Add(unitView);
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < _units.Count; i++)
        {
            _units[i].UpdateVisual();
        }
    }

    private void DestroyMinings()
    {
        
    }

    private void AddUnit(UnitData unitData)
    {
        var unitView = _unitsFactory.CreateNew(unitData, _unitsContainer);
        _units.Add(unitView);
    }

    private void DelUnit(UnitData unitData)
    {
        var index =_units.FindIndex(item => item.GetData.UnitIndex == unitData.UnitIndex);
        if (index >= 0)
        {
            Destroy(_units[index].gameObject);
            _units.RemoveAt(index);
        }
    }

    private void DestroyUnits()
    {
        for (int i = 0; i < _units.Count; i++)
        {
            Destroy(_units[i].gameObject);
        }
        _units.Clear();
    }
}

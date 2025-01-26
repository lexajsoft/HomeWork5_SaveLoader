using System;
using Services.ServiceLocator;
using UnityEngine;
using Views;

public class TestLauncher : ViewBase
{
    [Inject] private GameModelController _gameModelController;

    public void Generation()
    {
        Debug.Log("[TestLauncher].Generation");
        // indexPlayer = 1
        _gameModelController.AddPlayer();
        // indexPlayer = 2
        _gameModelController.AddPlayer();
        
        _gameModelController.AddRandomUnit(1,true);
        _gameModelController.AddRandomUnit(1,true);
        _gameModelController.AddRandomUnit(1,true);
        _gameModelController.AddRandomUnit(1,true);
        _gameModelController.AddRandomUnit(1,true);
        _gameModelController.AddRandomUnit(1,true);
        _gameModelController.AddRandomUnit(2,true);
        _gameModelController.AddRandomUnit(2,true);
        _gameModelController.AddRandomUnit(2,true);
        _gameModelController.AddRandomUnit(2,true);
        _gameModelController.AddRandomUnit(2,true);
    }

    public void Clear()
    {
        Debug.Log("[TestLauncher].Clear");
        _gameModelController.ClearAll();
    }
}
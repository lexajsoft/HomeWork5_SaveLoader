using System;
using System.Collections;
using System.Collections.Generic;
using Configs;
using Factory;
using Model;
using Model.Factory;
using Services.ServiceLocator;
using UnityEngine;
using Views;

[DefaultExecutionOrder(-1000)]
public class BootStrap : MonoBehaviour
{
    [SerializeField] private UnitsConfig UnitsConfig;
    //[SerializeField] private Mining MiningConfig;
    [SerializeField] private GameModelController _gameModelController;
    [SerializeField] private ResourceViewManager _resourceViewManager;
    private void Awake()
    {
        Debug.Log("[Bootstrap]: initing");
        ServiceLocator.CreateAndRegistry<GameModel>();
        
        ConfigsInit();
        FactoriesInit();
        
        ServiceLocator.Registry<ResourceViewManager>(_resourceViewManager);
        ServiceLocator.Registry<GameModelController>(_gameModelController);
    }

    private void ConfigsInit()
    {
        ServiceLocator.CreateCloneAndRegistryConfig(UnitsConfig);
    }

    private static void FactoriesInit()
    {
        if (ServiceLocator.CreateAndRegistry<UnitsFactory>(out var factory))
        {
            factory.Resolve();
        }
    }
}

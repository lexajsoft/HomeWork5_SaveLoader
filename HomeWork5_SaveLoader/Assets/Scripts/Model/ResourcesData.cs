using System;
using UnityEngine;
using Untils;

namespace Model
{
    [Serializable]
    public class ResourcesData
    {
        [field : SerializeField] public ResourceGold ResourceGold { get; set; }
        [field : SerializeField]public ResourceFood ResourceFood { get; set; }
        [field : SerializeField]public ResourceWood ResourceWood { get; set; }
        [field : SerializeField]public ResourceRock ResourceRock { get; set; }

        // сюда можно добавить методы по трате ресурсов но понял что пока что нет смысла сюда добавлять так как в задании нет требования строить что то по этому нет смысла

        [SerializeField] private Timer _addingResourceTimer;

        public ResourcesData()
        {
            _addingResourceTimer = new Timer(1f);
        }

        public void UpdatePassiveAddingResources(float deltaTime)
        {
            if (_addingResourceTimer.UpdateAndCheck(deltaTime))
            {
                ResourceGold.AddResourcePerSecond();
                ResourceFood.AddResourcePerSecond();
                ResourceWood.AddResourcePerSecond();
                ResourceRock.AddResourcePerSecond();
            }

        }
    }
}
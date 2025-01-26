using System;
using UnityEngine;

namespace Services.Model
{
    [Serializable]
    public class ResourcesData
    {
        [field : SerializeField] public ResourceGold ResourceGold { get; set; }
        [field : SerializeField]public ResourceFood ResourceFood { get; set; }
        [field : SerializeField]public ResourceWood ResourceWood { get; set; }
        [field : SerializeField]public ResourceRock ResourceRock { get; set; }

        // сюда можно добавить методы по трате ресурсов но понял что пока что нет смысла сюда добавлять так как в задании нет требования строить что то по этому нет смысла
        
    }
}
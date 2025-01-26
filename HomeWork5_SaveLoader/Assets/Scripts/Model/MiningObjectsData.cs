using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class MiningObjectsData
    {
        public List<MiningObject<ResourceBase>> MiningObjects = new List<MiningObject<ResourceBase>>();
    }
}
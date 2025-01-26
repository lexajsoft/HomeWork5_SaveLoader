using System;

namespace Services.Model
{
    [Serializable]
    public abstract class MiningObject<ResourceBase>
    {
        public int IndexMiningObject;
        public virtual bool IsCanMining() => RemainValue > 0;
        public int RemainValue;
    }
}
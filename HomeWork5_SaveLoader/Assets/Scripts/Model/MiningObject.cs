using System;

namespace Model
{
    [Serializable]
    public abstract class MiningObject<TResource> : MiningObjectBase where TResource : ResourceBase 
    {
        public TResource Resource;
        public override bool IsCanMining() => Resource.Value > 0;
        public override int RemainValue() => Resource.Value;
    }
}
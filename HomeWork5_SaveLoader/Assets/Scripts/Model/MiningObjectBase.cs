using System;

namespace Model
{
    [Serializable]
    public abstract class MiningObjectBase
    {
        public int IndexMiningObject;
        public abstract bool IsCanMining();
        public abstract int RemainValue();
    }
}
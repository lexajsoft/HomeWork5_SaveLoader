using System;

namespace Model
{
    [Serializable]
    public class ResourceRock : ResourceBase
    {
        public ResourceRock(int value, int valueMax) : base(value, valueMax,0)
        {
        }
        public ResourceRock(int value, int valueMax, int valuePerSecond) : base(value, valueMax,valuePerSecond)
        {
        }

        public override string GetName()
        {
            return "Камень";
        }
    }
}
using System;

namespace Model
{
    [Serializable]
    public class ResourceWood : ResourceBase
    {
        public ResourceWood(int value, int valueMax) : base(value, valueMax,0)
        {
        }
        public ResourceWood(int value, int valueMax, int valuePerSecond) : base(value, valueMax,valuePerSecond)
        {
        }
        public override string GetName()
        {
            return "Дерево";
        }
    }
}
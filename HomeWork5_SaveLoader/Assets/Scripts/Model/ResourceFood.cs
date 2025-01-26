using System;

namespace Model
{
    [Serializable]
    public class ResourceFood : ResourceBase
    {
        public ResourceFood(int value, int valueMax) : base(value, valueMax,0)
        {
        }
        public ResourceFood(int value, int valueMax, int valuePerSecond) : base(value, valueMax,valuePerSecond)
        {
        }
        
        public override string GetName()
        {
            return "Еда";
        }
    }
}
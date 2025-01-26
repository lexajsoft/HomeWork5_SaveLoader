using System;

namespace Model
{
    [Serializable]
    public class ResourceGold : ResourceBase
    {
        public ResourceGold(int value, int valueMax) : base(value, valueMax,0)
        {
        }
        public ResourceGold(int value, int valueMax, int valuePerSecond) : base(value, valueMax,valuePerSecond)
        {
        }
        public override string GetName()
        {
            return "Золото";
        }

        
    }
}
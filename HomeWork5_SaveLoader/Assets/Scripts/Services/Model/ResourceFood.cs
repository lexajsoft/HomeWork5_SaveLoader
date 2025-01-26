using System;

namespace Services.Model
{
    [Serializable]
    public class ResourceFood : ResourceBase
    {
        public ResourceFood(int value, int valueMax) : base(value, valueMax)
        {
        }
    }
}
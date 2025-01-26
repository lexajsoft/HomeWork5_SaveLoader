using System;

namespace Services.Model
{
    [Serializable]
    public class ResourceWood : ResourceBase
    {
        public ResourceWood(int value, int valueMax) : base(value, valueMax)
        {
        }
    }
}
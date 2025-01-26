using System;

namespace Services.Model
{
    [Serializable]
    public class ResourceRock : ResourceBase
    {
        public ResourceRock(int value, int valueMax) : base(value, valueMax)
        {
        }
    }
}
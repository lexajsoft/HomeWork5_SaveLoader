using System;

namespace Services.Model
{
    [Serializable]
    public class ResourceGold : ResourceBase
    {
        public ResourceGold(int value, int valueMax) : base(value, valueMax)
        {
        }
    }
}
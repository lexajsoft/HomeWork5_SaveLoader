using System;

namespace Services.Model
{
    [Serializable]
    public class PlayerData
    {
        public int IndexPlayer = -1;
        public ResourcesData ResourcesData;
        public UnitsData UnitsData;
    }
}
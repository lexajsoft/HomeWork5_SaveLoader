using System;

namespace Services.Model
{
    [Serializable]
    public class UnitData
    {
        public int UnitIndex;
        // номер игрока к которому относится данный юнит
        public PositionData PositionData;
        public HealthData HealthData;
    }
}
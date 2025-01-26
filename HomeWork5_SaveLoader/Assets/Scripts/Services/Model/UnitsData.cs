using System;
using System.Collections.Generic;

namespace Services.Model
{
    [Serializable]
    public class UnitsData
    {
        public List<UnitData> Units;
        public Action<UnitData> OnAddedNewUnit;
        public Action<int> OnRemovedUnit;
        public void Add(UnitData unit)
        {
            Units.Add(unit);
        }
        public void Remove(UnitData unit)
        {
            Units.Remove(unit);
            OnRemovedUnit?.Invoke(unit.UnitIndex);
        }
    }
}
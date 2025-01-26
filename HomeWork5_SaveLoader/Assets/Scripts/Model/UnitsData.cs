using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class UnitsData
    {
        public static int Index;
        
        public List<UnitData> Units = new List<UnitData>();
        
        public static Action<UnitData> OnAddedNewUnit;
        public static Action<int> OnRemovedUnit;

        private static int GetNextIndex()
        {
            return ++Index;
        }

        public void Add(UnitData unit)
        {
            unit.UnitIndex = GetNextIndex();
            Units.Add(unit);
            OnAddedNewUnit?.Invoke(unit);
        }
        public void Remove(UnitData unit)
        {
            Units.Remove(unit);
            OnRemovedUnit?.Invoke(unit.UnitIndex);
        }
    }
}
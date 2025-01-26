using Model;

namespace Configs
{
    public static class UnitPrototypeToUnitData
    {
        public static UnitData ToNewUnitData(this UnitPrototype prototype)
        {
            return new UnitData()
            {
                Position = new Vector3Data(),
                EulerAngel = new Vector3Data(),
                UnitIndex = -1,
                UnitLink = prototype.UnitLink,
                PlayerIndex = -1,
                UnitName = prototype.UnitName,
                HealthData = prototype.HealthData
            };
        }
    }
}
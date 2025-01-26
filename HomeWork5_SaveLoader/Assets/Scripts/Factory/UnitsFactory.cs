using Configs;
using Model;
using Services.ServiceLocator;
using UnityEngine;
using Views;

namespace Factory
{
    public class UnitsFactory
    {
        [Inject] private UnitsConfig _unitsConfig;

        public UnitViewBase CreateNew(UnitData unitData, Transform transform)
        {
            var prototype = _unitsConfig.GetUnitPrototype(unitData.UnitLink);
            var gameObject = GameObject.Instantiate(prototype.Model, transform);
            gameObject.transform.position = unitData.Position.ConvertToVector3();
            gameObject.transform.rotation = Quaternion.Euler(unitData.EulerAngel.ConvertToVector3());
            var unitViewBase = gameObject.AddComponent<UnitViewBase>();
            unitViewBase.SetData(unitData);
            return unitViewBase;
        }
    }
}
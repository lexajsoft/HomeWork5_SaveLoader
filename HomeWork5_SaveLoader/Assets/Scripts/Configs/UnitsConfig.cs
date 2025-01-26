using System;
using System.Collections.Generic;
using ObjectLinks.Units;
using Services.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Configs
{
    [CreateAssetMenu(menuName = "Create/UnitsConfig", fileName = "UnitsConfig", order = 0)]
    public class UnitsConfig : ConfigBase
    {
        [SerializeField] private List<UnitPrototype> UnitPrototypes;
        private  Dictionary<Type, UnitPrototype> _prototypes;
        public override void Init()
        {
            _prototypes = new Dictionary<Type, UnitPrototype>();
            for (int i = 0; i < UnitPrototypes.Count; i++)
            {
                _prototypes.Add(UnitPrototypes[i].UnitLink.GetType(), UnitPrototypes[i]);
            }
        }

        public UnitPrototype GetUnitPrototype(UnitLink unitLink)
        {
            return _prototypes[unitLink.GetType()];
        }

        public UnitPrototype GetRandomUnitPrototype()
        {
            int index = Random.Range(0, UnitPrototypes.Count);
            return UnitPrototypes[index];
        }
    }
}
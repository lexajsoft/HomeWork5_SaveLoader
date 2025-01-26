using Model;
using ObjectLinks.Units;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Create/UnitPrototype", fileName = "UnitPrototype", order = 0)]
    public class UnitPrototype : ScriptableObject
    {
        public string UnitName;
        [SerializeReference] public UnitLink UnitLink;
        public HealthData HealthData;
        public GameObject Model;
    }
}
using System;
using ObjectLinks.Units;
using UnityEngine;
using UnityEngine.Serialization;

namespace Model
{
    [Serializable]
    public class UnitData
    {
        // номер юнита
        public int UnitIndex;
        // номер игрока к которому юнит относится
        public int PlayerIndex;
        
        public string UnitName;
        [field:SerializeReference] public UnitLink UnitLink;
        
        public Vector3Data Position;
        public Vector3Data EulerAngel;
        
        public HealthData HealthData;
    }
}
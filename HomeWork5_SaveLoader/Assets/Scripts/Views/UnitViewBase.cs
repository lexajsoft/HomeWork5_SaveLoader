using Model;
using UnityEngine;

namespace Views
{
    public class UnitViewBase : ViewBase
    { 
        [SerializeField] private UnitData _unitData;

        public UnitData GetData => _unitData;
        
        public void SetData(UnitData unitData)
        {
            _unitData = unitData;
        }

        public void UpdateVisual()
        {
            transform.position = _unitData.Position.ConvertToVector3();
            transform.rotation = Quaternion.Euler(_unitData.EulerAngel.ConvertToVector3());
        }
    }
}
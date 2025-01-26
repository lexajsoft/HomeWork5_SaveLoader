using Model;
using UnityEngine;

namespace Views
{
    public class MiningObjectViewBase : ViewBase
    {
        [SerializeField] private MiningObjectBase _miningObjectBase;
        public void SetData(MiningObjectBase miningObjectBase)
        {
            _miningObjectBase = miningObjectBase;
        }
    }
}
using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public abstract class ResourceBase
    {
        [field:SerializeField] public int ValuePerSecond { get;private set; } = 0;
        [field:SerializeField] public int Value { get;private set; }
        [field:SerializeField] public int ValueMax  { get;private set; }

        public Action<int> OnValueChanged;

        public ResourceBase(int value, int valueMax)
        {
            Value = value;
            ValueMax = valueMax;
            ValuePerSecond = 0;
        }

        public ResourceBase(int value, int valueMax, int valuePerSecond)
        {
            Value = value;
            ValueMax = valueMax;
            ValuePerSecond = valuePerSecond;
        }
        
        public void AddResourcePerSecond()
        {
            if(ValuePerSecond != 0)
                Add(ValuePerSecond);
        }
        
        public void Add(int value)
        {
            Value += value;
            if (Value > ValueMax)
            {
                Value = ValueMax;
                
            }
            OnValueChanged?.Invoke(Value);
        }

        public bool IsCanWorst(int cost)
        {
            return Value >= cost;
        }

        public abstract string GetName();
        
        public bool TryWorst(int cost)
        {
            if (IsCanWorst(cost))
            {
                Value -= cost;
                OnValueChanged?.Invoke(Value);
                return true;
            }
            return false;
        }
    }
}
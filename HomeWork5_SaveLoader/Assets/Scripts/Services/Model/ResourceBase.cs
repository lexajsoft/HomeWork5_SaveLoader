using System;

namespace Services.Model
{
    [Serializable]
    public abstract class ResourceBase
    {
        public int Value { get;private set; }
        public int ValueMax  { get;private set; }

        public Action<int> OnValueChanged;

        public ResourceBase(int value, int valueMax)
        {
            Value = value;
            ValueMax = valueMax;
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
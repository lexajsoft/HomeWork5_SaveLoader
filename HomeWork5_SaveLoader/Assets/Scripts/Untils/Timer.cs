using System;
using UnityEngine;

namespace Untils
{
    [Serializable]
    public class Timer
    {
        [SerializeField] private float _delay;
        [SerializeField] private float _remain;

        public Timer(float delay)
        {
            _delay = delay;
            Reset();
        }

        public void SetDelay(float delay)
        {
            _delay = delay;
        }

        public void Reset()
        {
            _remain = 0;
        }

        public bool UpdateAndCheck(float timeDelta)
        {
            _remain += timeDelta;
            if (_delay <= _remain)
            {
                Reset();
                return true;
            }

            return false;
        }
    }
}
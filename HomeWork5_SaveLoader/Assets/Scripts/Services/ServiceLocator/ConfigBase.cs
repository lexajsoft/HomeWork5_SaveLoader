using UnityEngine;

namespace Services.ServiceLocator
{
    public abstract class ConfigBase : ScriptableObject
    {
        public virtual ScriptableObject Clone()
        {
            return Instantiate(this);
        }

        public abstract void Init();

    }
}
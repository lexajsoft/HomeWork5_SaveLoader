using Services.ServiceLocator;
using UnityEngine;

namespace Views
{
    public abstract class ViewBase : MonoBehaviour
    {
        protected virtual void Awake()
        {
            this.Resolve();
        }
    }
}
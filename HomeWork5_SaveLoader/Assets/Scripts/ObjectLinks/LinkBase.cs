using System;
using UnityEngine;

namespace ObjectLinks
{
    [Serializable]
    public abstract class LinkBase
    {
        public string GetNameClass()
        {
            return this.GetType().Name;
        }
    }
}
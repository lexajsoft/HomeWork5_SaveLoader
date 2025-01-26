using System;
using System.Collections.Generic;
// https://github.com/codewriter-packages/Tri-Inspector.git
using TriInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.ServiceLocator
{
    public class ServiceLocatorViewer : MonoBehaviour
    {

        [field: SerializeReference] public List<object> objects; // { get; private set; }
        [field: SerializeField] public List<UnityEngine.Object> UnityObjects;
        [Button]
        public void ReadAllObjects()
        {
            objects = new List<object>();
            UnityObjects = new List<Object>();
            
            var enumerator = ServiceLocator.GetEnumeratorObjects();

            foreach(KeyValuePair<Type, object> entry in enumerator)
            {
                if (entry.Value is UnityEngine.Object obj)
                {
                    UnityObjects.Add(obj);
                }
                else
                {
                    objects.Add(entry.Value);    
                }
            }
        }
    }
}
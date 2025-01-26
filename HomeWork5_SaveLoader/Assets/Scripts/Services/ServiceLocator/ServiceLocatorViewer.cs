using System;
using System.Collections.Generic;
// https://github.com/codewriter-packages/Tri-Inspector.git
using TriInspector;
using UnityEngine;

namespace Services.ServiceLocator
{
    public class ServiceLocatorViewer : MonoBehaviour
    {

        [field: SerializeReference] [ReadOnly] public List<object> objects { get; private set; }

        [Button]
        public void ReadAllObjects()
        {
            objects = new List<object>();
            var enumerator = ServiceLocator.GetEnumeratorObjects();
            // enumerator.MoveNext();
            //
            // while(enumerator.Current != null)
            // {
            //     objects.Add(enumerator.Current);
            //     enumerator.MoveNext();
            // }
            
            foreach(KeyValuePair<Type, object> entry in enumerator)
            {
                objects.Add(entry.Value);
                // do something with entry.Value or entry.Key
            }
        }
    }
}
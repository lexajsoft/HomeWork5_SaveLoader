using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = System.Object;

namespace Services.ServiceLocator
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, System.Object> _objects = new Dictionary<Type, object>();
    
        public static T Get<T>() where T : class
        {
            if (_objects.ContainsKey(typeof(T)))
            {
                if (_objects.TryGetValue(typeof(T), out object obj))
                {
                    return obj as T;
                }
            }

            return null;
        }
    
        public static object Get(Type type)
        {
            if (_objects.ContainsKey(type))
            {
                if (_objects.TryGetValue(type, out object obj))
                {
                    return obj;
                }
            }

            return null;
        }

        /// <summary>
        /// Регистрируется тип, указывается объект, и если надо то есть возможность перезаписывать если hardRegistry - true
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="hardRegistry"></param>
        /// <returns></returns>
        public static bool Registy(Type type, System.Object obj, bool hardRegistry = true)
        {
            if (_objects.ContainsKey(type) && hardRegistry)
            {
                UnRegistry(type);
            }

            if (_objects.ContainsKey(type) == false)
            {
                _objects.Add(type,obj);
                return true;
            }

            return false;
        }
    
        /// <summary>
        /// Регистрируется тип, указывается объект, и если надо то есть возможность перезаписывать если hardRegistry - true
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="hardRegistry"></param>
        /// <returns></returns>
        public static bool Registry<T>(Object obj, bool hardRegistry = true)
        {
            Type type = typeof(T);
            if (_objects.ContainsKey(type) && hardRegistry)
            {
                UnRegistry(type);
            }

            if (_objects.ContainsKey(type) == false)
            {
                _objects.Add(type,obj);
                return true;
            }

            return false;
        }
        
        public static bool CreateCloneAndRegistryConfig<T>(T obj) where T : ConfigBase
        {
            Type type = typeof(T);
            if (_objects.ContainsKey(type))
            {
                UnRegistry(type);
            }
            
            if (_objects.ContainsKey(type) == false)
            {
                var obj2 = (T)obj.Clone();
                obj2.Init();
                _objects.Add(type,obj2);
                return true;
            }
            
            return false;
        }

        public static bool CreateAndRegistry<T>() where T : class, new()
        {
            var t = new T();
            return (Registry<T>(t, false));
        }
        
        public static bool CreateAndRegistry<T>(out T result) where T : class, new()
        {
            var t = new T();
            if (Registry<T>(t, false))
            {
                result = t;
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
        
        public static bool CreateMonoAndRegistry<T>() where T : MonoBehaviour, new()
        {
            var obj = new GameObject();
            obj.name = typeof(T).Name;
            var tScript = obj.AddComponent<T>();
            
            return Registry<T>(tScript,false);
        }

        public static void UnRegistry(Type type)
        {
            _objects.Remove(type);
        }
        public static void UnRegistry<T>()
        {
            _objects.Remove(typeof(T));
        }

        public static void Clear()
        {
            _objects.Clear();
        }

        public static void Resolve(this object obj)
        {
            if(obj == null)
                return;
            var objType = obj.GetType();

            var members = objType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < members.Length; i++)
            {
                var listAtributes = members[i].GetCustomAttributes<InjectAttribute>();
                if (listAtributes.Any())
                {
                    members[i].SetValue(obj, Get(members[i].FieldType));
                }
            }
        }

        public static Dictionary<Type, object> GetEnumeratorObjects()
        {
            return _objects;
        }
    }
}
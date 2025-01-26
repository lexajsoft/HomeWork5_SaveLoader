using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class Vector3Data
    {
        public float X, Y, Z;

        public Vector3Data()
        {
            X = Y = Z = 0;
        }

        public void Set(Vector3 vector3)
        {
            X = vector3.x;
            Y = vector3.y;
            Z = vector3.z;
        }

        public Vector3 ConvertToVector3()
        {
            return new Vector3(X, Y, Z);
        }
    }
}
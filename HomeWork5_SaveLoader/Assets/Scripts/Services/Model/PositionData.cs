using System;
using UnityEngine;

namespace Services.Model
{
    [Serializable]
    public class PositionData
    {
        public float X, Y, Z;
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
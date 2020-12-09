using System;
using UnityEngine;

namespace Parabox.Stl
{
    struct StlVector3 : IEquatable<StlVector3>
    {
        const float k_Resolution = 10000f;

        public float x;
        public float y;
        public float z;

        public StlVector3(Vector3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }

        public StlVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public StlVector3 normalized { get { return StlVector3.Normalize(this); } }

        public const float kEpsilon = 0.00001F;

        public static StlVector3 Normalize(StlVector3 value)
        {
            float mag = Magnitude(value);
            if (mag > kEpsilon)
                return value / mag;
            else
                return zero;
        }

        public static float Magnitude(StlVector3 vector) { return (float)Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z); }

        public static StlVector3 zero
        {
            get { return new StlVector3(0, 0, 0); }
        }

        public static explicit operator Vector3(StlVector3 vec)
        {
            return new Vector3(vec.x, vec.y, vec.z);
        }

        public static explicit operator StlVector3(Vector3 vec)
        {
            return new StlVector3(vec);
        }

        public static StlVector3 operator /(StlVector3 a, float d) { return new StlVector3(a.x / d, a.y / d, a.z / d); }

        public static StlVector3 operator +(StlVector3 left, StlVector3 right)
        {
            left.x += right.x;
            left.y += right.y;
            left.z += right.z;
            return left;
        }

        public bool Equals(StlVector3 other)
        {
            return Mathf.Approximately(x, other.x)
                && Mathf.Approximately(y, other.y)
                && Mathf.Approximately(z, other.z);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is StlVector3))
                return false;

            return Equals((StlVector3)obj);
        }

        public override int GetHashCode()
        {
            // https://stackoverflow.com/questions/720177/default-implementation-for-object-gethashcode/720282#720282
            unchecked
            {
                int hash = 27;

                hash = (13 * hash) + (x * k_Resolution).GetHashCode();
                hash = (13 * hash) + (y * k_Resolution).GetHashCode();
                hash = (13 * hash) + (z * k_Resolution).GetHashCode();

                return hash;
            }
        }

        public static bool operator ==(StlVector3 a, StlVector3 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(StlVector3 a, StlVector3 b)
        {
            return !a.Equals(b);
        }
    }
}

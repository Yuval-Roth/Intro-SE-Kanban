using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.Utilities
{
    public sealed class Integer : IComparable,IComparable<Integer>, IEquatable<Integer>, ICloneable
    {
        private readonly int value;

        public int Value => value;

        [JsonConstructor]
        public Integer(int num) 
        {
            value = num;
        }
        public object Clone()
        {
            return new Integer(value);
        }
        public int CompareTo(object obj)
        {
            return value.CompareTo(obj);
        }
        private int CompareTo(Integer other)
        {
            return value.CompareTo(other.value);
        }
        public bool Equals(Integer other)
        {
            if (other == null) return false;
            return value == other.value;
        }
        private bool Equals(int other)
        {
            return value == other;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return Equals((Integer)obj);
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (obj is int num) return Equals(num);
            return false;
        }
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
        int IComparable<Integer>.CompareTo(Integer other)
        {
            return value.CompareTo(other.value);
        }
        public static bool operator ==(Integer left, Integer right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }
        public static bool operator !=(Integer left, Integer right)
        {
            return !(left == right);
        }
        public static bool operator <(Integer left, Integer right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }
        public static bool operator <=(Integer left, Integer right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }
        public static bool operator >(Integer left, Integer right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }
        public static bool operator >=(Integer left, Integer right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
        public static Integer operator +(Integer left, Integer right)
        {
            return new Integer(left.value + right.value);
        }
        public static string operator +(Integer left, string right)
        {
            return left.value + right;
        }
        public static string operator +(string left, Integer right)
        {
            return left + right.value;
        }
        public static Integer operator -(Integer left, Integer right)
        {
            return new Integer(left.value - right.value);
        }
        public static Integer operator /(Integer left, Integer right)
        {
            return new Integer(left.value / right.value);
        }
        public static Integer operator *(Integer left, Integer right)
        {
            return new Integer(left.value * right.value);
        }
        public static Integer operator ^(Integer left, Integer right)
        {
            return new Integer(left.value ^ right.value);
        }
        public static Integer operator %(Integer left, Integer right)
        {
            return new Integer(left.value % right.value);
        }
        public static implicit operator Integer(int num)
        {
            return new Integer(num);
        }
    }
}

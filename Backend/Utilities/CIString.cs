
using System;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.Utilities
{
    [Serializable]
    public sealed class CIString : IEquatable<CIString>, IComparable,IComparable<CIString>,ICloneable
    {
        private readonly string value;

        public string Value => value;

        [JsonIgnore]
        public int Length => value.Length;

        [JsonConstructor]
        public CIString(string Value)
        {
            value = Value;
        }
        public bool Equals(CIString s)
        {
            if (s == null) return false;
            return value.ToLower().Equals(s.value.ToLower());
        }
        private bool Equals(string s)
        {
            if (s == null) return false;
            return value.ToLower().Equals(s.ToLower());
        }
        int IComparable.CompareTo(object obj)
        {
            if (obj is CIString s)
            {
                return value.ToLower().CompareTo(s.value.ToLower());
            }
            else throw new ArgumentException("Argument is not a CIString");
        }
        private int CompareTo(CIString other)
        {
            return value.ToLower().CompareTo(other.value.ToLower());
        }
        public override string ToString()
        {
            return value;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return Equals((CIString)obj);
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }   
            if (obj is string @str)  return Equals(@str);
            return false;
        }
        public override int GetHashCode()
        {            
            return value.GetHashCode();
        }
        public object Clone()
        {
            return new CIString(new string(value));
        }
        int IComparable<CIString>.CompareTo(CIString other)
        {
            return value.ToLower().CompareTo(other.value.ToLower());
        }
        public static bool operator ==(CIString left, CIString right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }
            return left.Equals(right);
        }
        public static bool operator !=(CIString left, CIString right)
        {
            return !(left == right);
        }     
        public static bool operator <(CIString left, CIString right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(CIString left, CIString right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(CIString left, CIString right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }
        public static bool operator >=(CIString left, CIString right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
        public static CIString operator +(CIString left, CIString right)
        {
            return new CIString(left.value + right.value);
        }
        public static CIString operator +(int left, CIString right)
        {
            return new CIString(left + right.value);
        }
        public static CIString operator +(CIString left, int right)
        {
            return new CIString(left.value + right);
        }
        public static string operator +(CIString left, string right)
        {
            return left.value + right;
        }
        public static string operator +(string left, CIString right)
        {
            return left + right.value;
        }
        public static implicit operator CIString(string v)
        {
            return new CIString(v);
        }
        public static implicit operator string(CIString v)
        {
            return v.value;
        }
    }
}

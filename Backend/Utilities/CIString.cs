
using System;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.Utilities
{
    public class CIString : IEquatable<CIString>, IComparable
    {
        private readonly string value;

        public string Value => value;
        public int Length => value.Length;


        [JsonConstructor]
        public CIString(string s)
        {
            value = s;
        }

        public bool Equals(CIString s)
        {
            return value.ToLower().Equals(s.value.ToLower());
        }
        int IComparable.CompareTo(object obj)
        {
            if (obj is CIString s)
            {
                return value.ToLower().CompareTo(s.value.ToLower());
            }
            else throw new ArgumentException("Argument is not a CIString");
        }
        public override string ToString()
        {
            return value;
        }
    }
}

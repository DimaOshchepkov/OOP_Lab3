using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3Library
{
    public class Indexer
    {
        private double[] array;
        public int Length { get; private set; }
        public int begin;
        public int end;
        public Indexer(double[] array, int b, int e)
        {
            if (b < 0 || e >= array.Length || b > e)
                throw new ArgumentException();
            this.array = array;
            this.Length = e - b + 1;
            begin = b;
            end = e;
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index + begin > end )
                    throw new IndexOutOfRangeException();
                return array[begin + index];
            }
            set
            {
                if (index < 0 || index >= this.Length)
                    throw new IndexOutOfRangeException();
                array[begin + index] = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Indexer other = (Indexer)obj;
            return array == other.array && begin == other.begin
                && end == other.end;
        }
        public override int GetHashCode()
        {
            unchecked
            {
 
                int hash = array.GetHashCode() + 42;
                hash = hash ^ begin.GetHashCode() + 42;
                hash = hash ^ end.GetHashCode() + 42;
                return hash;
            }
        }


    }
}

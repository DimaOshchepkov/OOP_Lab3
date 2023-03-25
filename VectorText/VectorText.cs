using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DocumentLib;

namespace operation
{
    public static class Operation
    {
        private static double MultiplyVectors(Dictionary<string, double> v1, Dictionary<string, double> v2)
        {
            double result = 0;
            foreach (string key in v1.Keys.Intersect(v2.Keys))
                result += v1[key] * v2[key];

            return result;
        }

        public static double Cos(Document vt1, Document vt2)
        {
            if (vt1.vector.Count != 0 && vt2.vector.Count != 0)
                return MultiplyVectors(vt1.vector, vt2.vector);
            else
                return 0;
        }
     
    }
}

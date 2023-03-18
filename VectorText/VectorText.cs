using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VectorText
{
    public class VectorText
    {
        public Dictionary<string, double> vector { get; private set; }
        public VectorText(string textOrPath, TextOrPath TOrP = TextOrPath.Text)
        {
            if (TextOrPath.Path == TOrP)
                SetTextFromFile(textOrPath);
            else if (TextOrPath.Text == TOrP)
                SetText(textOrPath);

        }
        
        public static double NormVector(Dictionary<string, double> vector)
        {
            double sum = 0;
            foreach (string key in vector.Keys)
                sum += Math.Pow(vector[key], 2);

            return Math.Sqrt(sum);

        }

        private static double MultiplyVectors(Dictionary<string, double> v1, Dictionary<string, double> v2)
        {
            double result = 0;
            foreach (string key in v1.Keys.Intersect(v2.Keys))
                result += v1[key] * v2[key];

            return result;      
        }
        public static double Cos(VectorText vt1, VectorText vt2)
        {
            if (vt1.vector.Count != 0 && vt2.vector.Count != 0)
                return MultiplyVectors(vt1.vector, vt2.vector);
            else
                return 0;
        }

        public void SetText(string str)
        {
            Regex regex = new Regex(@"\w+");
            var matches = regex.Matches(str);

            vector = new Dictionary<string, double>();
            foreach (Match match in matches)
            {
                if (!vector.ContainsKey(match.Value))
                    vector[match.Value] = 1;
                else
                    vector[match.Value]++;
            }

            double norm = NormVector(vector);
            foreach (string key in vector.Keys.ToList())
                vector[key] /= norm;
        }
        public void SetTextFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadToEnd().ToLower();
                SetText(line);
            }
        }
    }

    public enum TextOrPath : int
    {
        Text = 0,
        Path,
    }
}

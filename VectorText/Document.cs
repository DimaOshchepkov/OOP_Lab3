using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace DocumentLib
{
    public class Document
    {
        public Dictionary<string, double> vector { get; private set; }
        public Document(string textOrPath, TextOrPath TOrP = TextOrPath.Text)
        {
            if (TextOrPath.Path == TOrP)
                SetTextFromFile(textOrPath);
            else if (TextOrPath.Text == TOrP)
                SetText(textOrPath);
        }

        private void SetText(string str)
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
        private void SetTextFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadToEnd().ToLower();
                SetText(line);
            }
        }

        public static double NormVector(Dictionary<string, double> vector)
        {
            double sum = 0;
            foreach (string key in vector.Keys)
                sum += Math.Pow(vector[key], 2);

            return Math.Sqrt(sum);
        }
    }
    public enum TextOrPath : int
    {
        Text = 0,
        Path,
    }
}

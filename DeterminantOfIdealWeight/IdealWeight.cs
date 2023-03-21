using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeight
{
    public enum sex
    {
        male,
        female,
    }
    public class IdealWeight
    {
        public int age = 0;
        public double weight = 0, height = 0;
        public sex? gender = null;

        public IdealWeight(double h)
        {
            if (h < 0)
                throw new ArgumentException();
            else height = h;
        }
        public IdealWeight(double h, int a)
        {
            if (a < 0 && a > 100 || h < 0)
                throw new ArgumentException();
            else { age = a; height = h; }
        }
        public IdealWeight(double h, double w, int a)
        {
            if (a < 0 && a > 100 || h < 0 || w < 0)
                throw new ArgumentException();
            height = h;
            weight = w;
            age = a;
        }
        public IdealWeight(double h, sex s)
        {
            if (h < 0)
                throw new ArgumentException();
            height = h;
            gender = s;
        }

        public double Broke()
        {
            if (this.age == 0) throw new ArgumentException();
            else
            {
                if (this.age < 40)
                    return this.height - 110;
                else if (this.age >= 40)
                    return this.height - 100;
                else
                    return 0;
            }
        }

        public string Cuttle()
        {
            if (this.age == 0 && this.weight == 0)
                throw new ArgumentException();
            else
            {
                string def = "Дефицит массы тела", izb = "Избыток массы тела",
                    norm = "Приемлимая масса тела";
                double IMT = weight / Math.Pow(height / 100, 2);
                if (IMT < 19.0) return def;
                else if (age >= 19 && age <= 24 && IMT <= 24)
                    return norm;
                else if (age >= 25 && age <= 34 && IMT <= 25)
                    return norm;
                else if (age >= 35 && age <= 44 && IMT <= 26)
                    return norm;
                else if (age >= 45 && age <= 54 && IMT <= 27)
                    return norm;
                else if (age <= 55 && age <= 64 && IMT <= 28)
                    return norm;
                else if (age >= 65 && IMT <= 29)
                    return norm;
                else
                    return izb;
            }
        }

        public double Lorenz() => (height - 100) - (height - 150) / 2;

        public double Cooper()
        {
            if (gender == null)
                throw new ArgumentException();
            else
            {
                if (gender == sex.male) return Math.Round((height * 4.0 / 2.54 - 128) * 0.453, 2);
                else return Math.Round((height * 3.5 / 2.54 - 108) * 0.453, 2);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterminantOfIdealWeight
{
    enum Gender
    {
        Male,
        Female
    }
    abstract class IFormula
    {
        public abstract double GetIdealWeight(double height, double age, Gender gender);
        public abstract double GetIdealWeight(double height, double age);
    }

    class Broke : IFormula
    {
        public override double GetIdealWeight(double height, double age)
        {
            if (age < 40)
                return height - 110;
            else
                return height - 100;
        }
        public abstract double GetIdealWeight(double height, double age, Gender g);
    }
}

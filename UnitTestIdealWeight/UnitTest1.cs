using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeight
{
    [TestClass]
    public class TestIdealWeight
    {
        int age = 19;
        double height = 176, weight = 58;
        readonly sex gender = sex.male;

        [TestMethod]
        public void GetCorretcly()
        {
            var idealWeight = new IdealWeight(height, age);

            Assert.AreEqual(176, idealWeight.height);
            Assert.AreEqual(19, idealWeight.age);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Error()
        {
            Assert.Equals(typeof(ArgumentException), new IdealWeight(-24, 10));
        }

        [TestMethod]
        public void Broke()
        {
            var Vlad = new IdealWeight(height, age);

            Assert.AreEqual(66, Vlad.Broke());
        }

        [TestMethod]
        public void Cuttle()
        {
            var Vlad = new IdealWeight(height, weight, age);

            Assert.AreEqual("Дефицит массы тела", Vlad.Cuttle());
        }

        [TestMethod]
        public void Lorenz()
        {
            var Vlad = new IdealWeight(height);

            Assert.AreEqual(63, Vlad.Lorenz());
        }

        [TestMethod]
        public void Cooper()
        {
            var Vlad = new IdealWeight(height, gender);

            Assert.AreEqual(67.57, Vlad.Cooper());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ErrorBroke()
        {
            Assert.Equals(typeof(ArgumentException), new IdealWeight(-24).Broke());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ErrorCuttle()
        {
            Assert.Equals(typeof(ArgumentException), new IdealWeight(-24).Cuttle());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ErrorLorenz()
        {
            Assert.Equals(typeof(ArgumentException), new IdealWeight(-24, 12).Lorenz());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ErrorCooper()
        {
            Assert.Equals(typeof(ArgumentException), new IdealWeight(-24).Cooper());
        }

    }
}


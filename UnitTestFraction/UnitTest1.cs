using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.Eventing.Reader;

namespace FractionLib
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class UnitTestConstrucror
        {
            [TestMethod]
            public void FormationWithoutСontraction()
            {
                var el = new Fraction(5, 4);
                Assert.IsTrue(el.numerator == 5 && el.denominator == 4);
            }
            [TestMethod]
            public void FormationWithСontraction()
            {
                var el = new Fraction(10, 5);
                Assert.IsTrue(el.numerator == 2 && el.denominator == 1);
            }
            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void DenominatorEqvalZero()
            {
                Assert.AreEqual(typeof(ArgumentException), new Fraction(10, 0));
            }

            [TestMethod]
            public void DenominatorLessZero()
            {
                Assert.AreEqual(new Fraction(-2, -3), new Fraction(2, 3));
                Assert.AreEqual(new Fraction(-2, -2), new Fraction(2, 2));
                Assert.AreEqual(new Fraction(2, -1), new Fraction(-2, 1));
            }
        }
        [TestClass]
        public class UnitTestOperatrion
        {
            [TestMethod]
            public void Multiply()
            {
                var el1 = new Fraction(5, 4);
                var el2 = new Fraction(10, 5);
                Assert.AreEqual(el1 * el2, new Fraction(5, 2));
            }

            [TestMethod]
            public void MultiplyWithOverflow()
            {
                var el1 = new Fraction(int.MaxValue, 1);
                var el2 = new Fraction(1, int.MaxValue);
                Assert.AreEqual(el1 * el2, new Fraction(1, 1));
            }

            [TestMethod]
            public void Minus()
            {
                var el1 = new Fraction(3, 2);
                var el2 = new Fraction(6, 7);
                Assert.AreEqual(el1 - el2, new Fraction(9, 14));
            }
            public void MinusEqvals()
            {
                var el1 = new Fraction(3, 2);
                var el2 = new Fraction(3, 2);
                Assert.AreEqual(el1 - el2, new Fraction(0, 1));
            }

            [TestMethod]
            public void MinusWithOverflow()
            {
                var el1 = new Fraction(int.MaxValue, 1);
                var el2 = new Fraction(int.MaxValue, 2);
                Assert.AreEqual(el1 - el2, new Fraction(int.MaxValue, 2));
            }

            [TestMethod]
            public void UnaryMinus()
            {
                var el1 = new Fraction(-1, 1);
                Assert.AreEqual(-el1, new Fraction(1, 1));

                var el2 = new Fraction(1, 1);
                Assert.AreEqual(-el2, new Fraction(-1, 1));
            }

            [TestMethod]
            public void PowPositive()
            {
                var ell = new Fraction(6, 7);
                ell.Pow(2);
                Assert.AreEqual(ell, new Fraction(36, 49));

                var ell2 = new Fraction(-6, 7);
                ell2.Pow(2);
                Assert.AreEqual(ell2, new Fraction(36, 49));

                var ell3 = new Fraction(-6, 7);
                ell3.Pow(3);
                Assert.AreEqual(ell3, new Fraction(-216, 343));

            }

            [TestMethod]
            public void PowNegative()
            {
                var ell = new Fraction(6, 7);
                ell.Pow(-2);
                Assert.AreEqual(ell, new Fraction(49, 36));

                var ell2 = new Fraction(-6, 7);
                ell2.Pow(-2);
                Assert.AreEqual(ell2, new Fraction(49, 36));

                var ell3 = new Fraction(-6, 7);
                ell3.Pow(-3);
                Assert.AreEqual(ell3, new Fraction(-343, 216));
            }

            [TestMethod]
            public void ZeroPow()
            {
                var ell = new Fraction(6, 7);
                ell.Pow(0);
                Assert.AreEqual(ell, new Fraction(1, 1));
            }

            [TestMethod]
            public void Plus()
            {
                var el1 = new Fraction(1, 2);
                var el2 = new Fraction(2, 3);
                Assert.AreEqual(el1 + el2, new Fraction(7, 6));
            }

            [TestMethod]
            public void PlusWithOverflow()
            {
                var el1 = new Fraction(int.MaxValue, 2);
                var el2 = new Fraction(int.MaxValue, 3);
                Assert.AreEqual(el1 + el2, new Fraction(5, 6) * new Fraction(int.MaxValue, 1));
            }

        }
    }
}

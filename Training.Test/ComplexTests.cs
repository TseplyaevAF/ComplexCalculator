using Training;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training.Test
{
    [TestClass]
    public class ComplexTests
    {
        [TestMethod]
        public void Constructor_0and0returned()
        {
            Complex a = new Complex();
            Assert.IsTrue(a.Re == 0 && a.Im == 0);
        }

        [TestMethod()]
        public void Constructor_float_paratemeters()
        {
            Complex a = new Complex(10, 20);
            Assert.IsTrue(a.Re == 10 && a.Im == 20);

            Complex b = new Complex(-6, 8);
            Assert.IsTrue(b.Re == -6 && b.Im == 8);

            Complex c = new Complex(-6.89f, 8.001f);
            Assert.IsTrue(c.Re == -6.89f && c.Im == 8.001f);
        }

        [TestMethod()]
        public void Constructor_string_parameter()
        {
            string number = "25,24+8i";
            Complex a = new Complex(number);
            Assert.IsTrue(a.Re == 25.24f && a.Im == 8);

            string number2 = "-25-90i";
            Complex b = new Complex(number2);
            Assert.IsTrue(b.Re == -25 && b.Im == -90);
        }

        [TestMethod()]
        public void Method_ToString()
        {
            Complex a = new Complex(25, 90);
            string expected = "25+90i";
            string res = a.ToString();
            Assert.IsTrue(expected == res);
        }

        [TestMethod()]
        public void Return_Abs()
        {
            Complex a = new Complex(16, 3);
            float expected = 16.2788f;
            float res = a.Abs();
            res = (float)Math.Round(res, 4);
            Assert.IsTrue(expected == res);
        }
    }
}

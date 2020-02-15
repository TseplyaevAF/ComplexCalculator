using Training;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training.Test
{
    [TestClass]
    public class ComplexTests
    {
        [TestMethod]
        public void Test_Constructor_default()
        {
            Complex a = new Complex();
            Assert.IsTrue(a.Re == 0 && a.Im == 0);
        }

        [TestMethod()]
        public void Test_Constructor_float_paratemeters()
        {
            {
                Complex a = new Complex(10, 20);
                Assert.IsTrue(a.Re == 10 && a.Im == 20);
            }

            {
                Complex b = new Complex(-6, 8);
                Assert.IsTrue(b.Re == -6 && b.Im == 8);
            }

            {
                Complex c = new Complex(-6.89f, 8.001f);
                Assert.IsTrue(c.Re == -6.89f && c.Im == 8.001f);
            }
        }

        [TestMethod()]
        public void Test_Constructor_string_parameter()
        {
            {
                string number = "25,24+8i";
                Complex a = new Complex(number);
                Assert.IsTrue(a.Re == 25.24f && a.Im == 8);
            }

            {
                string number2 = "-25-90i";
                Complex b = new Complex(number2);
                Assert.IsTrue(b.Re == -25 && b.Im == -90);
            }
        }

        [TestMethod()]
        public void Test_ToString()
        {
            Complex a = new Complex(25, 90);
            string expected = "25+90i";
            string res = a.ToString();
            Assert.IsTrue(expected == res);
        }

        [TestMethod()]
        public void Test_Abs()
        {
            Complex a = new Complex(16, 3);
            float expected = 16.2788f;
            float res = a.Abs();
            res = (float)Math.Round(res, 4);
            Assert.IsTrue(expected == res);
        }

        [TestMethod()]
        public void Test_Arg()
        {
            Complex a = new Complex(16, 3);
            float expected = 0.1853f;
            float res = a.Arg();
            res = (float)Math.Round(res, 4);
            Assert.IsTrue(expected == res);
        }

        [TestMethod()]
        public void Test_Sum()
        {
            Complex a = new Complex(30, -20.34f);
            Complex b = new Complex(-7.1f, 88f);
            Complex c1 = a + b;
            Complex c2 = a + (-5);
            Assert.IsTrue(c1.Re == 22.9f && c1.Im == 67.66f
                && c2.Re == 25 && c2.Im == -20.34f);
        }

        [TestMethod()]
        public void Test_Sub()
        { 
            Complex a = new Complex(30, 20);
            Complex b = new Complex(-5, 40);
            Complex c1 = a - b;
            Complex c2 = a - 5;
            Assert.IsTrue(c1.Re == 35 && c1.Im == -20
                && c2.Re == 25 && c2.Im == 20);
        }

        [TestMethod()]
        public void Test_Mul()
        {
            Complex a = new Complex(30, 20);
            Complex b = new Complex(-5, 40);
            Complex c1 = a * b;
            Complex c2 = a * 5;
            Assert.IsTrue(c1.Re == -950 && c1.Im == 1100
                && c2.Re == 150 && c2.Im == 100);

        }

        [TestMethod()]
        public void Test_Div()
        {
            {
                Complex a = new Complex(30, 20);
                Complex b = new Complex(0, 40);
                Complex c1 = a / b;
                Complex c2 = a / 5;
                Assert.IsTrue(c1.Re == 0.5f && c1.Im == -0.75f
                    && c2.Re == 6 && c2.Im == 4);
            }

            {
                Complex a = new Complex(60, -42);
                Complex b = new Complex(-5, 0);
                Complex c1 = a / b;
                Complex c2 = a / 0.1f;
                Assert.IsTrue(c1.Re == -12 && c1.Im == 8.4f
                    && c2.Re == 600 && c2.Im == -420);
            }

        }

        [TestMethod()] 
        public void Test_ToExponential()
        {
            {
                Complex a = new Complex(0.09f, 222);
                a.ToExponential();
                Assert.IsTrue(a.Re == 222 && Math.Round(a.Im, 2) == 89.98);
            }

            {
                Complex a = new Complex(-56, 567.98f);
                a.ToExponential();
                Assert.IsTrue(Math.Round(a.Re,2) == 570.73 && Math.Round(a.Im, 2) == 95.63);
            }
        }

        [TestMethod()]
        public void Test_Less()
        {
            {
                Complex a = new Complex(-0.0008f, 56);
                Complex b = new Complex(-0.0008f, 67.23f);
                Assert.IsTrue(a < b);
            }

            {
                Complex a = new Complex(46, 56);
                Complex b = new Complex(56, -90);
                Assert.IsTrue(a < b);
            }
        }

        [TestMethod()]
        public void Test_More()
        {
            {
                Complex a = new Complex(0.0008f, 67.23f);
                Complex b = new Complex(-0.0008f, 56);
                Assert.IsTrue(a > b);
            }

            {
                Complex a = new Complex(-50, -90);
                Complex b = new Complex(-50, -91);
                Assert.IsTrue(a > b);
            }
        }

        public void Test_Equally()
        {
            Complex a = new Complex(0.0008f, 56);
            Complex b = new Complex(0.0008f, 56);
            Assert.IsTrue(a == b);
        }

        public void Test_NotEqually()
        {
            {
                Complex a = new Complex(0.0008f, 56);
                Complex b = new Complex(-0.0008f, 56);
                Assert.IsTrue(a != b);
            }

            {
                Complex a = new Complex(-50, -90);
                Complex b = new Complex(-50, -91);
                Assert.IsTrue(a != b);
            }

            {
                Complex a = new Complex(-52, -90);
                Complex b = new Complex(-50, -91);
                Assert.IsTrue(a != b);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ComplexLib
{
    public class Complex
    {
        float re, im;

        public Complex()
        {
            re = 0;
            im = 0;
        }
        public Complex(float re, float im)
        {
            this.re = re;
            this.im = im;
        }

        // Доступ к полю re
        public float Re
        {
            get
            {
                return re;
            }
            set
            {
                re = value;
            }
        }

        // Доступ к полю im
        public float Im
        {
            get
            {
                return im;
            }
            set
            {
                im = value;
            }
        }

        // Перевод комплексного числа в строку
        public override string ToString()
        {
            return im < 0 ? re.ToString() + im.ToString() + "i" :
                 re.ToString() + "+" + im.ToString() + "i";
        }

        // Оператор сложения двух комплексных чисел
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.re + b.re, a.im + b.im);
        }

        // Оператор вычитания двух комплексных чисел
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.re - b.re, a.im - b.im);
        }

        // Оператор умножения двух комплексных чисел
        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.re * b.re - a.im * b.im,
               b.im * a.re + a.im * b.re);
        }

        // Оператор деления двух комплексных чисел
        public static Complex operator /(Complex a, Complex b)
        {
            if (b.re == 0 && b.im == 0) throw new Exception("Деление на ноль");
            else
            {
                Complex result = new Complex
                {
                    re = (a.re * b.re + a.im * b.im) / (b.re * b.re + b.im * b.im),
                    im = (b.re * a.im - a.re * b.im) / (b.re * b.re + b.im * b.im)
                };
                return result;
            }
        }

        // Оператор сложения комплексного числа с действительным
        public static Complex operator +(Complex a, float number)
        {
            return new Complex(a.re + number, a.im);
        }

        // Оператор вычитания из комплексного числа действительное
        public static Complex operator -(Complex a, float number)
        {
            return new Complex(a.re - number, a.im);
        }

        // Оператор умножения комплексного числа на действительное
        public static Complex operator *(Complex a, float number)
        {
            return new Complex(a.re * number, a.im * number);
        }

        // Оператор деления комплексного числа на действительное
        public static Complex operator /(Complex a, float number)
        {
            if (number == 0) throw new Exception("Деление на ноль");
            else
            {
                Complex result = new Complex
                {
                    re = (a.re * number) / (number * number),
                    im = (number * a.im) / (number * number)
                };
                return result;
            }
        }

        // Вычисление модуля комплексного числа
        public float Abs()
        {
            return (float)Math.Sqrt(Math.Pow(re, 2) + Math.Pow(im, 2));
        }

        // Нахождение аргумента комплексного числа
        public float Arg()
        {
            return (float)Math.Atan2(im, re);
        }

        // Перевод из алгебраической формы в показательную
        public void ToExponential()
        {
            float arg = Arg();
            arg = (float)(arg * 180 / Math.PI); // Из радиан в градусы
            re = (float)Math.Round(Abs(), 4);
            im = (float)Math.Round(arg, 4);
        }

        // Конструктор преобразования числа, представленного в виде строки
        public Complex(string number)
        {
            Regex regex = new Regex(@"\d*\,?\d+[+|-]\d*\,?\d+i");
            if (!regex.IsMatch(number)) throw new Exception("Некорректные данные");
            for (int i = 1; i < number.Length; i++)
            {
                if (number[i] == '+')
                {
                    string[] s1 = number.Split(new char[] { '+', 'i' },
                        StringSplitOptions.RemoveEmptyEntries);
                    re = Convert.ToSingle(s1[0]);
                    im = Convert.ToSingle(s1[1]);
                    break;
                }
                else
                if (number[i] == '-')
                {
                    string[] s1 = number.Split(new char[] { '-', 'i' },
                        StringSplitOptions.RemoveEmptyEntries);
                    //string str1, str2;
                    if (number[0] == '-')
                        s1[0] = "-" + s1[0];
                    s1[1] = "-" + s1[1];
                    re = Convert.ToSingle(s1[0]);
                    im = Convert.ToSingle(s1[1]);
                    break;
                }
            }
        }

        // Оператор сравнения >
        // Вернет true, если левый операнд больше правого
        public static bool operator >(Complex a, Complex b)
        {
            if (a.Re > b.Re) return true;
            else
                if ((a.Re == b.Re) && (a.Im > b.Im)) return true;
            else return false;
        }

        // Оператор сравнения <
        // Вернет true, если левый операнд меньше правого
        public static bool operator <(Complex a, Complex b)
        {
            if (a.Re < b.Re) return true;
            else
                if ((a.Re == b.Re) && (a.Im < b.Im)) return true;
            else return false;
        }

        // Оператор сравнения ==
        // Вернет true, если левый и правый операнды равны
        public static bool operator ==(Complex a, Complex b)
        {
            if ((a.Re == b.Re) && (a.Im == b.Im)) return true;
            else return false;
        }

        // Оператор сравнения !=
        // Вернет true, если левый и правый операнды не равны
        public static bool operator !=(Complex a, Complex b)
        {
            if ((a.Re != b.Re) || (a.Im != b.Im)) return true;
            else return false;
        }
    }
}

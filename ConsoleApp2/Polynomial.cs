using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class Polynomial
    {
        private readonly List<double> coefficients;

        public Polynomial()
        {
            coefficients = new List<double>();
        }

        public Polynomial(List<double> coeffs)
        {
            coefficients = new List<double>(coeffs);
            TrimLeadingZeros();
        }

        // Добавление коэффициента для определенной степени
        public void AddTerm(int degree, double coefficient)
        {
            while (coefficients.Count <= degree)
                coefficients.Add(0.0);
            coefficients[degree] = coefficient;
            TrimLeadingZeros();
        }

        // Удаление ведущих нулей
        private void TrimLeadingZeros()
        {
            while (coefficients.Count > 1 && coefficients[coefficients.Count - 1] == 0)
                coefficients.RemoveAt(coefficients.Count - 1);
        }

        // Вывод полинома в виде строки
        public string PrintPolynomial()
        {
            if (coefficients.Count == 0 || coefficients.All(c => c == 0))
                return "0";

            var sb = new StringBuilder();
            bool isFirst = true;

            for (int degree = coefficients.Count - 1; degree >= 0; degree--)
            {
                double coefficient = coefficients[degree];
                if (coefficient == 0) continue;

                if (!isFirst)
                    sb.Append(coefficient > 0 ? " + " : " - ");
                else if (coefficient < 0)
                    sb.Append("-");

                double absCoefficient = Math.Abs(coefficient);
                if (degree == 0 || absCoefficient != 1)
                    sb.Append(absCoefficient);
                else if (degree == 1 && absCoefficient == 1)
                    sb.Append("x");
                else if (degree > 1 && absCoefficient == 1)
                    sb.Append($"x^{degree}");

                if (degree > 0 && absCoefficient != 1)
                {
                    sb.Append("x");
                    if (degree > 1)
                        sb.Append($"^{degree}");
                }

                isFirst = false;
            }

            return sb.ToString();
        }

        // Сложение полиномов
        public Polynomial Add(Polynomial other)
        {
            int maxDegree = Math.Max(coefficients.Count, other.coefficients.Count);
            List<double> result = new List<double>(new double[maxDegree]);

            for (int i = 0; i < maxDegree; i++)
            {
                double coef1 = i < coefficients.Count ? coefficients[i] : 0;
                double coef2 = i < other.coefficients.Count ? other.coefficients[i] : 0;
                result[i] = coef1 + coef2;
            }

            return new Polynomial(result);
        }

        // Умножение полиномов
        public Polynomial Multiply(Polynomial other)
        {
            List<double> result = new List<double>(new double[coefficients.Count + other.coefficients.Count - 1]);

            for (int i = 0; i < coefficients.Count; i++)
            {
                for (int j = 0; j < other.coefficients.Count; j++)
                {
                    result[i + j] += coefficients[i] * other.coefficients[j];
                }
            }

            return new Polynomial(result);
        }

        // Умножение полинома на число
        public Polynomial MultiplyByNumber(double number)
        {
            List<double> result = new List<double>(coefficients.Count);
            foreach (var coef in coefficients)
            {
                result.Add(coef * number);
            }
            return new Polynomial(result);
        }

        // Дифференцирование полинома
        public Polynomial Differentiate()
        {
            if (coefficients.Count <= 1)
                return new Polynomial(new List<double> { 0 });

            List<double> result = new List<double>(coefficients.Count - 1);
            for (int i = 1; i < coefficients.Count; i++)
            {
                result.Add(coefficients[i] * i);
            }
            return new Polynomial(result);
        }

        // Интегрирование полинома
        public Polynomial Integrate()
        {
            List<double> result = new List<double>(coefficients.Count + 1);
            result.Add(0); // Константа интегрирования = 0
            for (int i = 0; i < coefficients.Count; i++)
            {
                result.Add(coefficients[i]); 
            }
            return new Polynomial(result);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем первый полином: 3x^2 + 2x + 1
            Polynomial poly1 = new Polynomial();
            poly1.AddTerm(2, 3); // 3x^2
            poly1.AddTerm(1, 2); // 2x
            poly1.AddTerm(0, 1); // 1

            // Создаем второй полином: x + 1
            Polynomial poly2 = new Polynomial();
            poly2.AddTerm(1, 1); // x
            poly2.AddTerm(0, 1); // 1

            // Выводим полиномы
            Console.WriteLine("Polynomial 1: " + poly1.PrintPolynomial());
            Console.WriteLine("Polynomial 2: " + poly2.PrintPolynomial());

            // Сложение
            Polynomial sum = poly1.Add(poly2);
            Console.WriteLine("Сложение: " + sum.PrintPolynomial());

            // Умножение
            Polynomial product = poly1.Multiply(poly2);
            Console.WriteLine("Умножение: " + product.PrintPolynomial());

            // Умножение на число
            Polynomial scaled = poly1.MultiplyByNumber(2);
            Console.WriteLine("Умножение на число (x2): " + scaled.PrintPolynomial());

            // Дифференцирование
            Polynomial derivative = poly1.Differentiate();
            Console.WriteLine("Дифферинцирование: " + derivative.PrintPolynomial());

            // Интегрирование
            Polynomial integral = poly1.Integrate();
            Console.WriteLine("Интеграл: " + integral.PrintPolynomial());
        }
    }
}

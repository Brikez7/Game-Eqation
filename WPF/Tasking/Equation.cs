using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace WPF.Tasking
{
    public class Equation
    {
        public static double Coficent { get; private set; }
        private static readonly char[] _chars = new char[5] { '+', '-', '/', '*', '%' };
        private readonly Random _random = new Random();
        private readonly string _equation;
        private readonly double _unswer;

        public string GetEqution() 
            => _equation;

        public double GetUnswer() 
            => _unswer;

        private char RandomOperation() 
            => _chars[_random.Next(_chars.Length)];


        public Equation()
        {
            Coficent = Game.Coficent;
            int countDigits = RandomCountDigit();

            double value = Math.Round(_random.Next(10) * Coficent, 2);
            _equation += value;

            for (int x = 0; x < countDigits; x++)
            {
                double digit = Math.Round(RandomDigit(), 2);

                _equation += RandomOperation() switch
                {
                    '+' => $" + {digit}",
                    '-' => $" - {digit}",
                    '/' => $" * {digit}",
                    '*' => $" / {digit}",
                    '%' => $" % {digit}",
                    _ => throw new Exception("this operation not exit"),
                };
            }
            _unswer = Evaluate(_equation);
        }

        private static double Evaluate(string expression)
        {
            var xsltExpression =
                string.Format("number({0})",
                    new Regex(@"([\+\-\*])").Replace(expression, " ${1} ")
                                            .Replace("/", " div ")
                                            .Replace("%", " mod "));
            return (double)new XPathDocument
                (new StringReader("<r/>"))
                    .CreateNavigator()
                    .Evaluate(xsltExpression);
        }

        private int RandomCountDigit()
            => (_random.Next(1 + (int)(Coficent / 2), (int)(10 * Coficent)));

        private double RandomDigit()
            => Math.Round(
                _random.Next(1,(int)(10 * Coficent))
                + _random.NextDouble(),2);
    }
}


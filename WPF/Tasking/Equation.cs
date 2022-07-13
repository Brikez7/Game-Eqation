using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace WPF.Tasking
{
    public class Equation
    {
        private Random _random = new Random();
        private string _equation;
        private double _unswer;
        public static double _coficent { get; private set; } = Game._coficent;
        private static readonly char[] _chars = new char[5] { '+', '-', '/', '*','%' };

        public string GetEqution() => _equation;

        public double GetUnswer() => _unswer;

        private char RandomOperation() 
        {
            return _chars[_random.Next(_chars.Length)];
        }

        public Equation()
        {
            int countDigits = RandomCountDigit();

            double value = Math.Round(_random.Next(10) * _coficent, 2);
            _equation += value;
            for (int x = 0; x < countDigits; x++)
            {
                double digit = Math.Round(RandomDigit(), 2);

                switch (RandomOperation())
                {
                    case '+':
                        _equation += $" + {digit}";
                        break;
                    case '-':
                        _equation += $" - {digit}";
                        break;
                    case '/':
                        _equation += $" * {digit}";
                        break;
                    case '*':
                        _equation += $" / {digit}";
                        break;
                    case '%':
                        _equation += $" % {digit}";
                        break;
                    default:
                        throw new Exception("this operation not exit");
                }
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

            // ReSharper disable PossibleNullReferenceException
            return (double)new XPathDocument
                (new StringReader("<r/>"))
                    .CreateNavigator()
                    .Evaluate(xsltExpression);
            // ReSharper restore PossibleNullReferenceException
        }

        private int RandomCountDigit()
        {
            return (_random.Next(1 + (int)(_coficent / 2), (int)(10 * _coficent)));
        }

        private double RandomDigit()
        {
            return Math.Round(_random.Next((int)(10 * _coficent)) + _random.NextDouble(),2);
        }
    }
}


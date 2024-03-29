﻿namespace Lab_2.Models
{
    public class Calculator
    {
        public double? A { get; set; }
        public double? B { get; set; }
        public Operators? Op { get; set; }

        public bool? isValid()
        {
            return A != null && B != null && Op != null;
        }

        public double Calculate()
        {

            switch (Op)
            {
                case Operators.Add:
                    return (double)(A + B);
                case Operators.Sub:
                    return (double)(A - B);
                case Operators.Mul:
                    return (double)(A * B);
                case Operators.Div:
                    return (double)(A / B);
                default: return double.NaN;

            }
        }
        public string getOperatorSymbol()
        {
            switch (Op)
            {
                case Operators.Add:
                    return "+";
                case Operators.Sub:
                    return "-";
                case Operators.Mul:
                    return "*";
                case Operators.Div:
                    return "/";
                default: return "";

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNOtation
{
    class RPN
    {
        static void Main(string[] args)
        {

            //reversePolish NOtation
            string input;
            Stack<double> values = new Stack<double>();

            //example 5 1 2 + 4 x + 3 -
            //equivalent to 5 + ((1 + 2) * 4) - 3

            Console.WriteLine("RPN Calculator: ");
            Console.WriteLine("Enter an expression to calculate: ");
            input = Console.ReadLine();

            String[] inputs = input.Split();

            //string digits = "0123456789";
            string delim = " ";
            //default random flag value if values don't get successfully calculated.
            double finalValue = -918293;

            foreach (string value in inputs)
            {
                //if blank space, goto the next value to be read in string input.
                if (value == delim) continue;

                //push values to stack if it is a number.
                double convertedValue;
                if (double.TryParse(value,out convertedValue))
                {
                    Console.WriteLine("Pushing " + value);
                    values.Push(convertedValue);
                }
                else//pop values off and do the calculation if no digits were pushed to the stack.
                {
                    double left = values.Pop();
                    double right = values.Pop();
                    Console.WriteLine("Popped: " + left + " and " + right);

                    //flag of -99999 will be an error where calculation cannot be completed
                    double newValue = -99999;

                    if (value == "+")
                        newValue = left + right;
                    else if (value ==  "-")
                        newValue = right - left;
                    else if (value == "/")
                        newValue = right / left;
                    else if (value == "*")
                        newValue = left * right;
                    else//if no valid operators were read, throw an error msg and leave the loop.
                    {
                        Console.WriteLine("Not a valid operator: {0}", value);
                        return;
                    }

                    string ops = "+-/*";
                    //if the value in the string input is read as an operator and the new value is successfully calculated
                    //push the new calculated value to the stack.
                    if (ops.Contains(value) && newValue != -99999)
                    {
                        values.Push(newValue);
                        Console.WriteLine("New value: " + newValue);
                    }

                    //check to see if stack only has 1 value stored
                    //set finalvalue = 1 value in the stack.
                    if (values.Count == 1)
                    {
                        finalValue = values.Peek();
                    }
                }
            }
                        
            Console.WriteLine("Calculated Value: {0}", finalValue);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitAssignment7
{
    public class Question1
    {
        int SumOfnNumbersByWhileLoop(int n)
        {
            int sum = 0;
            while(n>0)
            {
                sum += n;
                n--;
            }

            return sum;
        }

        int CalculatorBySwitchCase(string op,int x,int y)
        {
            int result=0;
            switch(op)
            {
                case "+":
                    result=x + y;
                    break;
                case "-":
                    result = x - y;
                    break;
                case "*":
                    result = x * y;
                    break;
                case "/":
                    result = x / y;
                    break;
            }
            return result;
        }

        string OddEvenByIfElse(int x)
        {
            if (x % 2 == 0)
                return "Even";
            else
                return "Odd";
        }

        int SumOfnNumbersByForeachLoop(int n)
        {
            int sum = 0;
            foreach(int i in n)
            {
                sum += i;
            }
            return sum;
        }
    }
}

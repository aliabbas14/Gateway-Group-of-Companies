using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitAssignment7
{
    public class Question1
    {
        public int SumOfnNumbersByWhileLoop(int n)
        {
            int sum = 0;
            while(n>0)
            {
                sum += n;
                n--;
            }

            return sum;
        }

        public int CalculatorBySwitchCase(string op,int x,int y)
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

        public string OddEvenByIfElse(int x)
        {
            if (x % 2 == 0)
                return "Even";
            else
                return "Odd";
        }

        public int SumOfArrayByForeachLoop(int []n)
        {
            int sum = 0;
            foreach(int i in n)
            {
                sum += i;
            }
            return sum;
        }

        public int SumOfnNumbersByForLoop(int n)
        {
            int sum = 0;

            for(int i=1;i<=n;i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}

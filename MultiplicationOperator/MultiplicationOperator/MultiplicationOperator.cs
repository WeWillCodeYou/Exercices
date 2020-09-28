using System;

namespace MultiplicationOperator
{
    public class MultiplicationOperator
    {
        public int Multiply(int a, int b)
        {
            int result = 0;

            for (int i = 0; i < Math.Abs(a); ++i)
            {
                result += a > 0 ? b : -b;
            }

            return result;
        }
    }
}

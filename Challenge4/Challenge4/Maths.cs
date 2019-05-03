namespace Challenge4
{
    public static class Maths
    {
        public static int CalculateLeastCommonMultiple(int a, int b)
        {
            int num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (int i = 1; i < num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num1 * num2;
        }

        public static int CalculateGreatestCommonDivisor(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        public static (int, int) ReduceFraction(int numerator, int denominator)
        {
            var greatestCommonDivisor = Maths.CalculateGreatestCommonDivisor(numerator, denominator);

            while (greatestCommonDivisor != 1)
            {
                numerator = numerator / greatestCommonDivisor;
                denominator = denominator / greatestCommonDivisor;

                greatestCommonDivisor = Maths.CalculateGreatestCommonDivisor(numerator, denominator);
            }

            return (numerator, denominator);
        }
    }
}

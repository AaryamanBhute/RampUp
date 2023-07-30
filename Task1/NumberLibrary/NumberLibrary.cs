namespace Library
{
    public class NumberLibrary
    {
        public static bool isEven(int num)
        {
            return num % 2 == 0;
        }

        public static int square(int num)
        {
            return num * num;
        }

        public static string stringify(int num)
        {
            //handle overflow edge case

            if (num == int.MinValue)
            {
                return ("-2147483648");
            }

            //handle negative numbers

            if (num < 0)
            {
                return ("-" + stringify(-num));
            }

            //handle if num is 0

            if(num == 0)
            {
                return("0");
            }

            string ret = "";

            while(num > 0)
            {
                ret += (char) (num % 10 + 48);
                num /= 10;
            }

            char[] reversed = ret.ToCharArray();

            Array.Reverse(reversed);

            return new String(reversed);
        }

        public static int[] randomSample(int lower, int upper, int count)
        {
            if(lower >= upper) {
                throw new InvalidOperationException("Upper must be greater than Lower");
            }

            Random randomizer = new Random();

            int[] result = new int[count];

            for(int i = 0; i < count; i++) {
                result[i] = randomizer.Next(lower, upper);
            }

            return result;
        }

        public static bool allUnique(int[] nums)
        {
            HashSet<int> encountered = new HashSet<int>();

            foreach (int num in nums)
            {
                if (encountered.Contains(num))
                {
                    return (false);
                }

                encountered.Add(num);
            }

            return (true);
        }
    }
}
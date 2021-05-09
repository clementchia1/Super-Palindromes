using System;
using System.Linq;
using System.Text;

namespace Super_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "4";
            string s2 = "1000";
            Program program = new Program();
            Console.WriteLine("program.SuperpalindromesInRange(" + s1 + "," + s2 + "):" + program.SuperpalindromesInRange(s1, s2));

        }

        public int SuperpalindromesInRange(string left, string right)
        {
            long left_long = long.Parse(left);
            long right_long = long.Parse(right);
            int counter = 0;

            for (int i = 1; i < 100000; i++)
            {
                StringBuilder sb = new StringBuilder(i.ToString());
                for (int j = sb.Length - 1; j >= 0; j--)
                {
                    sb.Append(sb[j]);
                }

                long n = long.Parse(sb.ToString());
                n *= n;
                if (n > right_long)
                {
                    break;
                }
                else if (n >= left_long && verify(n))
                {
                    counter++;
                }
            }

            for (int i = 1; i < 100000; i++)
            {
                StringBuilder sb = new StringBuilder(i.ToString());
                for (int j = sb.Length - 2; j >= 0; j--)
                {
                    sb.Append(sb[j]);
                }

                long n = long.Parse(sb.ToString());
                n *= n;
                if (n > right_long)
                {
                    break;
                }
                else if (n >= left_long && verify(n))
                {
                    counter++;
                }
            }

            return counter;

        }

        static bool verify(long num)
        {
            long num_copy = num;
            long rev = 0;
            while (num_copy > 0)
            {
                rev = rev * 10 + num_copy % 10;
                num_copy /= 10;
            }
            return num == rev;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knuth_morris_pratt
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input main string");
            string str1 = Console.ReadLine();
            Console.WriteLine("Input searched string");
            string str2 = Console.ReadLine();


            int position = FindSubstring(str1, str2);
            Console.WriteLine(position);

        }

        private static int FindSubstring(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;
            int count = 0;
            int[] d = GetPrefixFunction(str2);

            int i = 0, j = 0;
            while (j < m && i - j < n - m + 1)
            {
                if (str1[i] == str2[j])
                {
                    Console.WriteLine(str2[j] + " " +str1[i] );

                    j++;
                    i++;
                    count++;
                }

                else if (j == 0)
                {
                    Console.WriteLine(str2[j] + " " + str1[i]);


                    i++;

                    count++;
                }
                else
                {
                    Console.WriteLine(str2[j] + " " + str1[i]);


                    count++;
                    i = i-d[j-1];
                    j = 0;
                }
                
            }

            if (j == m)
            {
                Console.WriteLine("Operation count : " + count);
                Console.WriteLine("UnderIndex : ");
                return i - j + 1;
            }
            else
            {    Console.WriteLine("Operation count : " + count);
            
                return -1;
            }
        }

        private static int[] GetPrefixFunction(string str2)
        {
            int length = str2.Length;
            int[] result = new int[length];

            int i = 1;
            int j = 0;
            result[0] = 0;
            while (i <= length - 1)
            {

                if (str2[i] == str2[j])
                {
                    result[i] = j + 1;
                    i++; j++;
                }
                else if (j == 0)
                {
                    result[i] = 0; i++;
                }
                else j = result[j - 1];
            }

            return result;
        }
    }
}
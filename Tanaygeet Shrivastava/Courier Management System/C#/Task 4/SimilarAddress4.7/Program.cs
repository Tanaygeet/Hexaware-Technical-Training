/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimilarAddress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> addresses = new List<string>
            {
                "123 Main St, Gandhi Marg, AP",
                "124 Main St, Gandhi Marg, AP",
                "123 Main Street, Gandhi Marg, AP",
                "789 Pine St, New York, NY",
                "123 Main St, New York, NY"
            };

            FindSimilarAddresses(addresses);

            // Keep the console open
            Console.ReadLine();
        }

        public static void FindSimilarAddresses(List<string> addresses)
        {
            Console.WriteLine("Similar Addresses Found:");
            for (int i = 0; i < addresses.Count; i++)
            {
                for (int j = i + 1; j < addresses.Count; j++)
                {
                    if (GetLevenshteinDistance(addresses[i], addresses[j]) <= 5) // Threshold to decide similarity
                    {
                        Console.WriteLine($"- \"{addresses[i]}\" and \"{addresses[j]}\" are similar.");
                    }
                }
            }
        }

        public static int GetLevenshteinDistance(string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i;
                    }
                    else if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1]));
                    }
                }
            }

            return dp[s1.Length, s2.Length];
        }
    }
}

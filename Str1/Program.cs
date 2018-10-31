using System;
/* Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
    Example 1: Input: "babad" Output: "bab" Note: "aba" is also a valid answer.
    Example 2: Input: "cbbd" Output: "bb" */
namespace Str1
{
    class Program
    {
        // The longest palindrome substring (LPS)
        public static string LPS(string str)
        {
            //length of LPS 
            int maxLength = 0;
            int len = str.Length;
            int low, high, subs = 0;

            for (int i = 1; i < len; i++)
            {
                // Find the longest even length palindrome with center points as i-1 and i
                low = i - 1;
                high = i;
                while (low >= 0 && high < len && str[low] == str[high])
                {
                    int k = high - low + 1;
                    if (k > maxLength)
                    {
                        subs = low;
                        maxLength = k;
                    }
                    low--;
                    high++;
                }

                // Find the longest odd length palindrome with center point as i
                low = i - 1;
                high = i + 1;
                while (low >= 0 && high < len && str[low] == str[high])
                {
                    int k = high - low + 1;
                    if (k > maxLength)
                    {
                        subs = low;
                        maxLength = k;
                    }
                    low--;
                    high++;
                }
            }

            string res = "";
            if (len == 1)
                res = str;
            else if (len > 1 && maxLength >= 1)
            { 
                for (int i = subs; i < subs + maxLength; ++i)
                {
                    res = res + str[i];
                }
            }
            else if (len > 1 && maxLength == 0)
            {
                int i = 0;
                res = res + str[i];
            }
            Console.WriteLine(res);
            return res;
        }

        public static string LongestPalindromeSubstring(string str)
        {
            /*Dynamic Programming
            We maintain a boolean table[n][n] that is filled in bottom up manner.
            The value of table[i][j] is true, if the substring is palindrome, otherwise false. 
            To calculate table[i][j], we first check the value of table[i + 1][j - 1], if the value is true and str[i] is same as str[j], then we make table[i][j] true. 
            Otherwise, the value of table[i][j] is made false.*/
            //Time complexity: O ( n^2 )
            //Auxiliary Space: O(n ^ 2)

            //if (matrix[i+1, j-1] == true && s[i]==s[j])
            //  matrix[i, j] = true
            //else
            //  matrix[i, j] = false

            int len = str.Length;
            int maxLength = 0, subs = 0;
            bool[,] matrix = new bool[len,len];

            //if i == j this is a palindrom, so we fill true
            for (int i = 0; i < len; i++)
            {
                matrix[i, i] = true;
            }

            //length = 2
            for (int i = 0; i < (len-1); i++)
            {
                if (str[i] == str[i+1])
                {
                    matrix[i, i] = true;
                    subs = i;
                    maxLength = 2;
                }
            }

            //length >=3
            for (int k = 3; k <= len; k++)
            {
                //start index i
                for (int i = 0; i < len-k+1; i++)
                {
                    //end index j
                    int j = i + k - 1;

                    //if (str[i+1] to str[j-1]) is a palindrome 
                    if (matrix[i+1, j-1] && str[i] == str[j])
                    {
                        matrix[i, j] = true;

                        if (k > maxLength)
                        {
                            subs = i;
                            maxLength = k;
                        }
                    }
                }

            }
            string res = "";
            if (len == 1)
                res = str;
            else if (len > 1 && maxLength >= 1)
            {
                for (int i = subs; i < subs + maxLength; ++i)
                {
                    res = res + str[i];
                }
            }
            else if (len > 1 && maxLength == 0)
            {
                int i = 0;
                res = res + str[i];
            }
            Console.WriteLine(res);
            return res;
        }


        public static void Main(string[] args)
        {
            String str = "ac";

            String str2 = LongestPalindromeSubstring(str);
            Console.WriteLine("----------");
            String str3 = LPS(str);
        }
    }
}

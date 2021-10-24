using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UMath
{
    public static class UMath
    {

		// Function to check if a number is
		// perfect square or not
		static bool isPerfect(int N)
		{
			if ((Mathf.Sqrt(N) - Mathf.Floor(Mathf.Sqrt(N))) != 0)
				return false;
			return true;
		}

		// Function to find the closest perfect square
		// taking minimum steps to reach from a number
		static void getClosestPerfectSquare(int N)
		{
			if (isPerfect(N))
			{
				Debug.Log(N + " "
								+ "0");
				return;
			}

			// Variables to store first perfect
			// square number
			// above and below N
			int aboveN = -1, belowN = -1;
			int n1;

			// Finding first perfect square
			// number greater than N
			n1 = N + 1;
			while (true)
			{
				if (isPerfect(n1))
				{
					aboveN = n1;
					break;
				}
				else
					n1++;
			}

			// Finding first perfect square
			// number less than N
			n1 = N - 1;
			while (true)
			{
				if (isPerfect(n1))
				{
					belowN = n1;
					break;
				}
				else
					n1--;
			}

			// Variables to store the differences
			int diff1 = aboveN - N;
			int diff2 = N - belowN;

			if (diff1 > diff2)
				Debug.Log(belowN + " " + diff2);
			else
				Debug.Log(aboveN + " " + diff1);
		}

		public static int GreatestCommonDivider(int a, int b)
        {

            if (a == 0)
                return b;
            if (b == 0)
                return a;


            if (a == b)
                return a;

            if (a > b)
                return GreatestCommonDivider(a - b, b);
            return GreatestCommonDivider(a, b - a);
        }


        // Utility function to find ceiling
        // of r in arr[l..h] 
        public static int FindCeilInArray(int[] arr, int r,
                            int l, int h)
        {
            int mid;
            while (l < h)
            {

                // Same as mid = (l+h)/2 
                mid = l + ((h - l) >> 1);

                if (r > arr[mid])
                    l = mid + 1;
                else
                    h = mid;
            }
            return (arr[l] >= r) ? l : -1;
        }

        // The main function that returns a random number
        // from arr[] according to distribution array 
        // defined by freq[]. n is size of arrays. 
        public static int ChooseRandomlyWithFrequency(int[] arr, int[] freq, int n)
        {

            // Create and fill prefix array 
            int[] prefix = new int[n];
            int i;
            prefix[0] = freq[0];

            for (i = 1; i < n; ++i)
                prefix[i] = prefix[i - 1] + freq[i];

            // prefix[n-1] is sum of all frequencies.
            // Generate a random number with 
            // value from 1 to this sum
            System.Random rand = new System.Random();
            int r = Random.Range(0, prefix[n - 1]) + 1; /*((int)(rand.Next() * (323567)) %
                              prefix[n - 1]) + 1;*/

            // Find index of ceiling of r in prefix array 
            int indexc = FindCeilInArray(prefix, r, 0, n - 1);
            return arr[indexc];
        }
    }


}
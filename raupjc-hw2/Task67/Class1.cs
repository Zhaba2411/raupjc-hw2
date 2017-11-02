using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task67
{
    public class Class1
    {
        public static async Task<int> FactorialDigitSumAsync(int n)
        {
            int temp = 1, sum = 0;

            while (n > 1)
            {
                temp = temp * n;
                n--;
            }

            while (temp > 0)
            {
                sum = sum + temp % 10;
                temp = temp / 10;
            }

            return sum;
        }

        private static async Task LetsSayUserClickedAButtonOnGuiMethodAsync()
        {
            var result = await GetTheMagicNumberAsync();
            Console.WriteLine(result);
        }
        private static async Task<int> GetTheMagicNumberAsync()
        {
            return await IKnowIGuyWhoKnowsAGuyAsync();
        }
        private static async Task<int> IKnowIGuyWhoKnowsAGuyAsync()
        {
            return await IKnowWhoKnowsThisAsync(10) + await IKnowWhoKnowsThisAsync(5);
        }
        private static async Task<int> IKnowWhoKnowsThisAsync(int n)
        {
            return FactorialDigitSumAsync(n).Result;
        }
    }
}

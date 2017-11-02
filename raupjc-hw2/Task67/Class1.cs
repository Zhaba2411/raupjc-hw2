using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task67
{
    public class Class1
    {
        public async Task<long> FactorialDigitSumAsync(int n)
        {
            long temp = 1, sum = 0;

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
    }
}

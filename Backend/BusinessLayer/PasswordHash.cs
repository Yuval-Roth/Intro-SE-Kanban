using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    /// <summary>
    /// This class hashes passwords of length 6-20 into 180 character strings.
    /// <br/>
    /// Every time a new instance of this class is created,<br/>
    /// unique hashing keys are generated.
    /// <br/><br/>
    /// ===================
    /// <br/>
    /// <c>Ⓒ Yuval Roth</c>
    /// <br/>
    /// ===================
    /// </summary>
    public class PasswordHash
    {
        private long basePrime;
        private long[] primes;
        private static readonly int PRIME_LOWER_BOUND = 11111111;
        private static readonly int PRIME_UPPER_BOUND = 99999999;

        public PasswordHash()
        {
            basePrime = GeneratePrimes(1, PRIME_LOWER_BOUND, PRIME_UPPER_BOUND)[0];
            primes = GeneratePrimes(8,PRIME_LOWER_BOUND,PRIME_UPPER_BOUND);
        }
        public string Hash(string s)
        { 
            //inflate the string to be 20 characters
            if (s.Length < 20) s = inflate(s);

            //process the string into a big number
            string numbers = "";
            long[] multiplied = new long[8];
            int index = 0;
            foreach (long prime in primes)
            {
                long mul = prime * basePrime;
                if (mul < 1000000000000000)
                {
                    mul = mul * 7;
                    multiplied[index] = mul;
                }
                else if (mul > 9999999999999999)
                {
                    mul = mul / 10;
                    multiplied[index] = mul;
                }
                else multiplied[index] = mul;   
                index++;
            }
            index = 0;
            foreach (char c in s) 
            {
                if (index == 7) index = 0;

                numbers += multiplied[index] * c;
            }
            //========================================


            // turn the numbers into chars
            string charBlock = "";
            string output = "";
            foreach (char c in numbers)
            {
                if (charBlock.Length == 2)
                {
                    int number = (char)int.Parse(charBlock);
                    if (number < 33) number += 33;
                    output += (char)number;
                    charBlock = "";
                }
                charBlock += c;
            }
            //===============================

            //force hash to be 180 chars long
            int outLength = output.Length;
            if (outLength > 180) output = output.Substring(0, outLength - (outLength - 180));
            if (outLength < 180) output = output + output.Substring(0, 180 - outLength);
            //===============================

            return output;
        }        
        private long[] GeneratePrimes(int count, long lowerBound,long upperBound) 
        {
            long[] output = new long[count]; 
            int currentCount = 0;
            Random random = new Random();

            //generate primes
            while (currentCount < count)
            {
                bool isPrime = true;
                long potentialPrime = random.NextInt64(lowerBound, upperBound);

                //check if the random number is a prime
                for (int i = 2; i <= Math.Sqrt(potentialPrime) & isPrime; i++) 
                {
                    if (potentialPrime % i == 0) 
                    {
                        isPrime = false;
                    }
                }

                //prime found, add to output
                if (isPrime)
                {
                    output[currentCount] = potentialPrime;
                    currentCount++;
                }    
            }
            return output;
        }
        private string inflate(string s) 
        {
            string output = s;
            int index = 0;
            int addition = 1;
            while (output.Length < 20)
            {
                if (index == s.Length) index = 0;
                output += (char)(s[index]+addition);
                index++;
                addition++;
            }
            return output;        
        }
    }
}

// https://projecteuler.net/problem=10
// The sum of the primes below 10 is 2 + 5 + 3 + 7 = 17 
// Find the sum of all the primes below two million.


using System.Numerics;
using static System.Console;

HashSet<int> numbers = [];
int upper = 2_000_000;
int p = 2;

for (int i = p; i <= upper; i++)
{
    numbers.Add(i);
}

while (true)
{
    // remove all multiples of p
    for (int i = p + p; i <= upper; i+= p) 
        numbers.Remove(i);
    
    // assign next p
    int oldp = p;
    for (int i = p + 1; i <= upper; i++)
    {
        if (numbers.Contains(i))
        {
            p = i;
            break;
        }
    }
    // 
    if(p == oldp)
        break;
}

BigInteger total = new BigInteger(0);
foreach (var number in numbers)
{
    total += number;
}

WriteLine(total);



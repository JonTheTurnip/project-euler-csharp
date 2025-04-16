// https://projecteuler.net/problem=10
// The sum of the primes below 10 is 2 + 5 + 3 + 7 = 17 
// Find the sum of all the primes below two million.


using System.Collections;
using System.Diagnostics;
using System.Numerics;
using static System.Console;


// 142913828922 (2_000_000)
// 95673602693282040 (2_000_000_000)

int x = 2_000_000_000;

// var check1 = Func1(x);
// WriteLine(check1);

var sw = new Stopwatch();
sw.Start();
var check2 = Func2(x);
sw.Stop();
WriteLine($"seconds {sw.Elapsed.TotalSeconds}");
WriteLine(check2);



BigInteger Func2(long upper)
{
    
    
    long p = 2;  // the first prime
    BigInteger total = new BigInteger(p);
    int offset = (int)p;

    // all bits initialised to false, i.e not sieved
    // we need enough bits to represent p to upper inclusive
    BitArray x = new BitArray(((int)upper - (int)p) + 1); 

    while (true)
    {
        // sieve all multiples of p (set to true to sieve them)
        for (long i = p + p; i <= upper; i+=p)
        {
            x[(int)(i - offset)] = true;
        }
    
        // assign next p
        long oldp = p;
        for (long i = p + 1; i <= upper; i++)
        {
            if (!x[(int)i - offset])
            {
                p = i;
                total += i;
                break;
            }
        }
        // 
        if(p == oldp)
            break;
    }

    return total;

}



BigInteger Func1(long upper)
{

    HashSet<long> numbers = [];
    //long upper = 2_000_000_000;
    // long upper = 2_000_000;
    long p = 2;

    for (long i = p; i <= upper; i++)
    {
        numbers.Add(i);
    }

    while (true)
    {
        // remove all multiples of p
        for (long i = p + p; i <= upper; i+= p) 
            numbers.Remove(i);
    
        // assign next p
        long oldp = p;
        for (long i = p + 1; i <= upper; i++)
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

    return total;
}




using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int startCount = 1;
            int endCount = 100;
            int fizz = 3;
            int buzz = 5;
            
            for (int i = startCount; i <= endCount; i++)
            {
                if (i % (fizz * buzz) == 0) { Console.WriteLine("FizzBuzz"); }
                else if (i % fizz == 0) { Console.WriteLine("Fizz"); }
                else if (i % buzz == 0) { Console.WriteLine("Buzz"); }
                else { Console.WriteLine(i); }
            }
        }
    }
}
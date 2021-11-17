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
                string output = "";
                
                if (i % fizz == 0) { output += "Fizz"; }
                if (i % buzz == 0) { output += "Buzz"; } 
                if (output == "") { output = i.ToString(); }
                
                Console.WriteLine(output);
            }
        }
    }
}
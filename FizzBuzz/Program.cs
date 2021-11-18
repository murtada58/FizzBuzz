using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int startCount = 1;
            int endCount = 1000;

            int[] order = {3, 5, 7, 11, 13, 17};

            Dictionary<int, Action<int, Output>> terms = new Dictionary<int, Action<int, Output>>();

            terms.Add(3, SimplePrint(3, "Fizz"));
            
            terms.Add(5, SimplePrint(5, "Buzz"));
            
            terms.Add(7, SimplePrint(7, "Bang"));

            terms.Add(11, (number, output) =>
            {
                if (number % 11 == 0)
                {
                    output.bong = true;
                    output.value.Clear();
                    output.value.Add("Bong");
                }
            });

            terms.Add(13, (number, output) =>
            {
                if (number % 13 == 0)
                {
                    bool placeAtEnd = true;
                    int i = 0;
                    foreach (string term in output.value)
                    {
                        if (term.StartsWith("B"))
                        {
                            placeAtEnd = false;
                            output.value.Insert(i, "Fezz");
                            break;
                        }
                        i++;
                    }
                    if(placeAtEnd) { output.value.Add("Fezz"); }
                }
            });
            
            terms.Add(17, (number, output) => { if (number % 17 == 0) { output.value.Reverse(); }});
            
            for (int i = startCount; i <= endCount; i++)
            {
                Output output = new Output();
                foreach (int number in order)
                {
                    terms[number](i, output);
                }

                Console.WriteLine(output.Repr() == "" ? i : output.Repr());
            }
        }

        public static Action<int, Output> SimplePrint(int activationNumber, string term)
        {
            return (number, output) =>
            {
                if (number % activationNumber == 0 && !output.bong) { output.value.Add(term); }
            };
        }
    }

    class Output
    {
        public List<string> value = new List<string>();
        public bool bong = false;

        public string Repr()
        {
            return string.Join("", value);
        }
    }
}
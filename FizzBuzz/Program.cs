using System;
using System.Collections.Generic;
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

            Dictionary<int, Func<int, Output, string>> terms = new Dictionary<int, Func<int, Output, string>>();
            
            terms.Add(3, (number, output) => number % 3 == 0 && !output.bong ? "Fizz" : "" );
            
            terms.Add(5, (number, output) => number % 5 == 0 && !output.bong ? "Buzz" : "" );
            
            terms.Add(7, (number, output) => number % 7 == 0 && !output.bong ? "Bang" : "" );
            
            terms.Add(11, (number, output) =>
            {
                if (number % 11 == 0)
                {
                    output.bong = true;
                    output.value.Clear();
                    return "Bong";
                }
                return "";
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
                    if(placeAtEnd)
                    {
                        return "Fezz";
                    }
                }

                return "";
            });
            
            terms.Add(17, (number, output) =>
            {
                if (number % 17 == 0)
                {
                    output.value.Reverse();
                }

                return "";
            });
            
            for (int i = startCount; i <= endCount; i++)
            {
                Output output = new Output();
                foreach (int number in order)
                {
                    output.value.Add(terms[number](i, output));
                }

                Console.WriteLine(output.Repr() == "" ? i : output.Repr());
            }
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
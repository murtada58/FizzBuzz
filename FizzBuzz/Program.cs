using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int startCount = 1;
            int endCount = 1000;

            OrderedDict terms = new OrderedDict();

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
                foreach (int key in terms)
                {
                    terms.dict[key](i, output);
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

    public class Output
    {
        public List<string> value = new List<string>();
        public bool bong = false;

        public string Repr()
        {
            return string.Join("", value);
        }
    }

    public class OrderedDict : IEnumerable
    {
        private List<int> order = new List<int>();
        public Dictionary<int, Action<int, Output>> dict = new Dictionary<int, Action<int, Output>>();

        public void Add(int key, Action<int, Output> value)
        {
            order.Add(key);
            dict.Add(key, value);
        }

        public IEnumerator GetEnumerator()
        {
            return order.GetEnumerator();
        }
    }
}
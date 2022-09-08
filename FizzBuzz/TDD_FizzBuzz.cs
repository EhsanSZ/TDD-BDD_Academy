using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FizzBuzz
{
    public class TDD_FizzBuzz
    {
        public static List<string> Start(in int input)
        {
            var result = new List<string>();
            for (int i = 1; i <= input; i++)
            {
                var output = i % 3 == 0 ? "Fizz" : "";
                output += i % 5 == 0 ? "Buzz" : "";
                output += output == string.Empty ? i.ToString() : string.Empty;
                result.Add(output);
            }
            return result;
        }
    
    }
}

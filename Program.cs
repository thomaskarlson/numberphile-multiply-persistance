using System;

namespace numberphile_multiplicative_persistence
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Watch https://youtu.be/Wim9WJeDTHQ");
            var ptest = new persistanceTest(277777788888899);

            ulong currentNumber = 0;
            int currentSteps = 0;

            while (currentSteps<12)
            {
                var test = new persistanceTest(++currentNumber);
                if (test.MultiplicationSteps > currentSteps)
                {
                    Console.WriteLine(test);
                    currentSteps = test.MultiplicationSteps;
                }
            }
        }
    }

    public class persistanceTest
    {
        private ulong _num;
        private int _multiplicationSteps = 1;
        public persistanceTest(ulong num)
        {
            _num = num;
            Run();
        }

        public int LengthNumber => _num.ToString().Length;
        public int MultiplicationSteps => _multiplicationSteps;
        public ulong Number => _num;
        public bool RunTest()
        {

            if (_num.ToString().Contains("0")) return false;
            if (_num.ToString().Length == 1) return false;
            
            return true;

        }
        public persistanceTest Next { get; set; }
        private persistanceTest Run()
        {
            if (RunTest())
            {
                ulong i = 1;
                foreach (var digit  in _num.ToString().ToCharArray())
                {
                    i *=  ulong.Parse(digit.ToString());
                }
                
                Next = new persistanceTest(i);
                _multiplicationSteps = Next._multiplicationSteps + 1;
            }

            return this;
        }

        public override string ToString()
        {
            return $"Step {_multiplicationSteps}: {_num}\n{Next?.ToString()}";
        }
    }
}
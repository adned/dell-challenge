using System;

namespace DellChallenge.C
{
    /// <summary>
    /// The class that represents the current application.
    /// </summary>
    internal class Program
    {
        #region Methods
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">The command arguments when launching the application (if any).</param>
        private static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability

            /*
             Refactoring results:
                - StartHere() renamed to PerformCalculations();
                - myObject to SumCalculator<T>;
            */
            PerformCalculations();
            Console.ReadKey(true);
        }
        #endregion

        #region Implementation
        /// <summary>
        /// Performs the calculations for the provided numbers.
        /// </summary>
        private static void PerformCalculations()
        {
            Calculator<int> calculator = new SumCalculator<int>();
            int firstSum = calculator.Compute(1, 3);
            int secondSum = calculator.Compute(1, 3, 5);
            Console.WriteLine(firstSum);
            Console.WriteLine(secondSum);
        }
        #endregion
    }
}
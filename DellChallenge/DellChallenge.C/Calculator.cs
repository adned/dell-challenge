using System;

namespace DellChallenge.C
{
    /// <summary>
    /// The abstract class to be implemented by any calculator.
    /// </summary>
    /// <typeparam name="T">The type of the input parameters.</typeparam>
    internal abstract class Calculator<T>
    {
        #region Methods
        /// <summary>
        /// Computes the specified numbers.
        /// </summary>
        /// <param name="numbers">The numbers to be computed.</param>
        /// <returns>The result of the computation.</returns>
        public T Compute(params T[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("numbers");
            }

            T result = ExecuteOperation(numbers);
            Console.WriteLine($"Compute sucessfuly executed for {numbers.Length} numbers of {typeof(T).Name} type.");
            return result;
        }
        #endregion

        #region Implementation
        /// <summary>
        /// Executes the operation for the specific calculator.
        /// </summary>
        /// <param name="numbers">The numbers to execute operation for.</param>
        /// <returns>The result of the operation.</returns>
        protected abstract T ExecuteOperation(params T[] numbers);
        #endregion
    }
}
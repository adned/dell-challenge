using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DellChallenge.C
{
    /// <summary>
    /// Implementation of the sum calculator.
    /// </summary>
    /// <typeparam name="T">The type to perform sum for.</typeparam>
    internal sealed class SumCalculator<T> : Calculator<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        /// <summary>
        /// Executes the operation for the specific calculator.
        /// </summary>
        /// <param name="numbers">The numbers to execute operation for.</param>
        /// <returns>The result of the operation.</returns>
        protected override T ExecuteOperation(params T[] numbers)
        {
            decimal sum = 0;
            foreach (T number in numbers)
            {
                sum += Convert.ToDecimal(number);
            }

            T result = default(T);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                result = (T)converter.ConvertFrom(sum.ToString());
            }

            return result;
        }
    }
}
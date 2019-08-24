using System;

using DellChallenge.B.Contracts;

namespace DellChallenge.B.Entities
{
    /// <summary>
    /// The class that represents an human.
    /// </summary>
    internal class Human : Animal, IHuman
    {
        #region Properties
        /// <summary>
        /// Gets the name for this animal.
        /// </summary>
        protected override string Name => "Human";
        #endregion

        #region Methods
        /// <summary>
        /// Think action for an human.
        /// </summary>
        public void Think()
        {
            Console.WriteLine($"Think operation successfully executed for {Name}.");
        }
        #endregion
    }
}
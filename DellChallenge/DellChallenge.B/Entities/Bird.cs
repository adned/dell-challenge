using System;

using DellChallenge.B.Contracts;

namespace DellChallenge.B.Entities
{
    /// <summary>
    /// The class that represents a bird.
    /// </summary>
    internal class Bird : Animal, IBird
    {
        #region Properties
        /// <summary>
        /// Gets the name for this animal.
        /// </summary>
        protected override string Name => "Bird";
        #endregion

        #region Methods
        /// <summary>
        /// Fly action for a bird.
        /// </summary>
        public void Fly()
        {
            Console.WriteLine($"Fly operation successfully executed for {Name}.");
        }
        #endregion
    }
}
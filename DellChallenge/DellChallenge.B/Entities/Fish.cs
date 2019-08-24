using System;

using DellChallenge.B.Contracts;

namespace DellChallenge.B.Entities
{
    /// <summary>
    /// The class that represents a fish.
    /// </summary>
    internal class Fish : Animal, IFish
    {
        #region Properties
        /// <summary>
        /// Gets the name for this animal.
        /// </summary>
        protected override string Name => "Fish";
        #endregion

        #region Methods
        /// <summary>
        /// Swim action for a fish.
        /// </summary>
        public void Swim()
        {
            Console.WriteLine($"Swim operation successfully executed for {Name}.");
        }
        #endregion
    }
}
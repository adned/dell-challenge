using System;

using DellChallenge.B.Contracts;

namespace DellChallenge.B.Entities
{
    /// <summary>
    /// The class that descriebes an animal.
    /// </summary>
    internal class Animal : IAnimal
    {
        #region Property
        /// <summary>
        /// Gets the name for this regnum.
        /// </summary>
        protected virtual string Name
        {
            get
            {
                return "Animal";
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of an animal.
        /// </summary>
        internal Animal()
        {
            Console.WriteLine($"{Name} created.");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Drink action for an animal.
        /// </summary>
        public void Drink()
        {
            Console.WriteLine($"Drink operation successfully executed for {Name}.");
        }

        /// <summary>
        /// Eat action for an animal.
        /// </summary>
        public void Eat()
        {
            Console.WriteLine($"Eat operation successfully executed for {Name}.");
        }
        #endregion
    }
}
using System;

using DellChallenge.B.Contracts;
using DellChallenge.B.Entities;

namespace DellChallenge.B
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
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)

            /*
             Reworked for clarity:
                - replaced species with Animalia regnum for a broader spectrum of classification;
                - replaced GetSpecies method with template property Name;
                - added Think method to Human;
            */

            // Base
            IAnimal animal = new Animal();
            animal.Drink();
            animal.Eat();
            Console.ReadKey(true);

            // Fish
            IFish fish = new Fish();
            fish.Drink();
            fish.Eat();
            fish.Swim();
            Console.ReadKey(true);

            // Bird
            IBird bird = new Bird();
            bird.Drink();
            bird.Eat();
            bird.Fly();
            Console.ReadKey(true);

            // Human
            IHuman human = new Human();
            human.Drink();
            human.Eat();
            human.Think();
            Console.ReadKey(true);
        }
        #endregion
    }
}
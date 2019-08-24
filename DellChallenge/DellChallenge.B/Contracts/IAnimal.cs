namespace DellChallenge.B.Contracts
{
    /// <summary>
    /// The interface to be implemented by all animal calsses.
    /// </summary>
    public interface IAnimal
    {
        #region Methods
        /// <summary>
        /// Drink action for an animal.
        /// </summary>
        void Drink();

        /// <summary>
        /// Eat action for an animal.
        /// </summary>
        void Eat();
        #endregion
    }
}
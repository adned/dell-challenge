namespace DellChallenge.B.Contracts
{
    /// <summary>
    /// The interface to be implemented by fish animals.
    /// </summary>
    public interface IFish : IAnimal
    {
        #region Methods
        /// <summary>
        /// Swim action for a fish.
        /// </summary>
        void Swim();
        #endregion
    }
}
namespace DellChallenge.B.Contracts
{
    /// <summary>
    /// The interface to be implemented by bird animals.
    /// </summary>
    public interface IBird : IAnimal
    {
        #region Methods
        /// <summary>
        /// Fly action for a bird.
        /// </summary>
        void Fly();
        #endregion
    }
}
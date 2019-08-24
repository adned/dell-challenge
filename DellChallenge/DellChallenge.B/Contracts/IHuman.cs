namespace DellChallenge.B.Contracts
{
    /// <summary>
    /// The interface to be implemented by humans.
    /// </summary>
    public interface IHuman : IAnimal
    {
        #region Methods
        /// <summary>
        /// Think action for an human.
        /// </summary>
        void Think();
        #endregion
    }
}
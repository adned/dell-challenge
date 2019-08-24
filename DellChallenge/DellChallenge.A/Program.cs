using System;

namespace DellChallenge.A
{
    /// <summary>
    /// The class that represents the current application.
    /// </summary>
    internal class Program
    {
        #region Nested Types
        /// <summary>
        /// The base calss for our example.
        /// </summary>
        private class A
        {
            #region Fields
            /// <summary>
            /// The age of A representation.
            /// </summary>
            private int _age;
            #endregion

            #region Properties
            /// <summary>
            /// Gets or sets the age of A representation.
            /// </summary>
            public int Age
            {
                get
                {
                    return _age;
                }
                set
                {
                    _age = value;

                    // We trace the _age modification here via the setter of Age property.
                    Console.WriteLine("A.Age");
                }
            }
            #endregion

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the A.
            /// </summary>
            public A()
            {
                // Trace base class constructor call.
                Console.WriteLine("A.A()");
            }
            #endregion
        }

        /// <summary>
        /// The class that inherits A class.
        /// </summary>
        private class B : A
        {
            #region Constructors
            /// <summary>
            /// Initializes a new instance of B class.
            /// </summary>
            public B()
                : base()
            {
                // Traces derived calss constructor call.
                Console.WriteLine("B.B()");

                // Set the base property here.
                Age = 0;
            }
            #endregion
        }
        #endregion

        #region Methods
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">The command arguments when launching the application (if any).</param>
        private static void Main(string[] args)
        {
            // State and explain console output order.
            new B();

            Console.ReadKey(true);

            /*
             A.A():
              - A is the base class for B, that is, the base() constructor is called when we instantiate B;
             B.B():
              - B is instantiated so we write in the constructor of this derived class;
             A.Age:
              - We assign 0 to Age property in the B constructor.

             Note:
              - There is no need to assign 0 to Age property since _age field is already initialized with 0 (i.e. 0 = default(Int32)), when the base class A is instantiated.
            */
        }
        #endregion
    }
}
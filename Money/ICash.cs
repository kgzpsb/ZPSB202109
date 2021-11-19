namespace NUnit.Samples.Cash
{

    /// <summary>The common interface for simple Monies and MoneyBags.</summary>
    public interface ICash
    {
        /// <summary>Adds a money to this money.</summary>
        ICash Add(ICash m);

        /// <summary>Adds a simple Money to this money. This is a helper method for
        /// implementing double dispatch.</summary>
        ICash AddMoney(Cash m);

        /// <summary>Adds a MoneyBag to this money. This is a helper method for
        /// implementing double dispatch.</summary>
        ICash AddMoneyBag(ICash s);

        /// <value>True if this money is zero.</value>
        bool IsZero { get; }

        /// <summary>Multiplies a money by the given factor.</summary>
        ICash Multiply(int factor);

        /// <summary>Negates this money.</summary>
        ICash Negate();

        /// <summary>Subtracts a money from this money.</summary>
        ICash Subtract(ICash m);
    }
}
namespace NUnit.Samples.Cash
{

    using System;
    using System.Text;

    /// <summary>A simple Money.</summary>
    public class Cash : ICash
    {

        private int fAmount;
        private String fCurrency;

        /// <summary>Constructs a money from the given amount and
        /// currency.</summary>
        public Cash(int amount, String currency)
        {
            fAmount = amount;
            fCurrency = currency;
        }

        /// <summary>Adds a money to this money. Forwards the request to
        /// the AddMoney helper.</summary>
        public ICash Add(ICash m)
        {
            return m.AddMoney(this);
        }

        public ICash AddMoney(Cash m)
        {
            if (m.Currency.Equals(Currency))
                return new Cash(Amount + m.Amount, Currency);
            return new CashBag(this, m);
        }

        public ICash AddMoneyBag(CashBag s)
        {
            return s.AddMoney(this);
        }

        public int Amount
        {
            get { return fAmount; }
        }

        public String Currency
        {
            get { return fCurrency; }
        }

        public override bool Equals(Object anObject)
        {
            if (IsZero)
                if (anObject is ICash)
                    return ((ICash)anObject).IsZero;
            if (anObject is Cash)
            {
                Cash aMoney = (Cash)anObject;
                return aMoney.Currency.Equals(Currency)
                    && Amount == aMoney.Amount;
            }
            return false;
        }

        public void SetCurrency(string v)
        {
            //throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return fCurrency.GetHashCode() + fAmount;
        }

        public bool IsZero
        {
            get { return Amount == 0; }
        }

        public ICash Multiply(int factor)
        {
            return new Cash(Amount * factor, Currency);
        }

        public ICash Negate()
        {
            return new Cash(-Amount, Currency);
        }

        public ICash Subtract(ICash m)
        {
            return Add(m.Negate());
        }

        public override String ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append("[" + Amount + " " + Currency + "]");
            return buffer.ToString();
        }
    }
}

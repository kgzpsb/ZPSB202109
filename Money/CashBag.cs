namespace NUnit.Samples.Cash
{

    using System;
    using System.Collections;
    using System.Text;

    /// <summary>A MoneyBag defers exchange rate conversions.</summary>
    /// <remarks>For example adding 
    /// 12 Swiss Francs to 14 US Dollars is represented as a bag 
    /// containing the two Monies 12 CHF and 14 USD. Adding another
    /// 10 Swiss francs gives a bag with 22 CHF and 14 USD. Due to 
    /// the deferred exchange rate conversion we can later value a 
    /// MoneyBag with different exchange rates.
    ///
    /// A MoneyBag is represented as a list of Monies and provides 
    /// different constructors to create a MoneyBag.</remarks>
    public class CashBag : ICash
    {
        private ArrayList fMonies = new ArrayList(5);

        private CashBag()
        {
        }
        public CashBag(Cash[] bag)
        {
            for (int i = 0; i < bag.Length; i++)
            {
                if (!bag[i].IsZero)
                    AppendMoney(bag[i]);
            }
        }
        public CashBag(Cash m1, Cash m2)
        {
            AppendMoney(m1);
            AppendMoney(m2);
        }
        public CashBag(Cash m, CashBag bag)
        {
            AppendMoney(m);
            AppendBag(bag);
        }
        public CashBag(CashBag m1, CashBag m2)
        {
            AppendBag(m1);
            AppendBag(m2);
        }
        public ICash Add(ICash m)
        {
            return m.AddMoneyBag(this);
        }
        public ICash AddMoney(Cash m)
        {
            return (new CashBag(m, this)).Simplify();
        }
        public ICash AddMoneyBag(ICash s)
        {
            return (new CashBag((Cash)s, this)).Simplify();
        }
        private void AppendBag(CashBag aBag)
        {
            foreach (Cash m in aBag.fMonies)
                AppendMoney(m);
        }
        private void AppendMoney(Cash aMoney)
        {
            ICash old = FindMoney(aMoney.Currency);
            if (old == null)
            {
                fMonies.Add(aMoney);
                return;
            }
            fMonies.Remove(old);
            ICash sum = old.Add(aMoney);
            if (sum.IsZero)
                return;
            fMonies.Add(sum);
        }
        private bool Contains(Cash aMoney)
        {
            Cash m = FindMoney(aMoney.Currency);
            return m.Amount == aMoney.Amount;
        }
        public override bool Equals(Object anObject)
        {
            if (IsZero)
                if (anObject is ICash)
                    return ((ICash)anObject).IsZero;

            if (anObject is CashBag)
            {
                CashBag aMoneyBag = (CashBag)anObject;
                if (aMoneyBag.fMonies.Count != fMonies.Count)
                    return false;

                foreach (Cash m in fMonies)
                {
                    if (!aMoneyBag.Contains(m))
                        return false;
                }
                return true;
            }
            return false;
        }
        private Cash FindMoney(String currency)
        {
            foreach (Cash m in fMonies)
            {
                if (m.Currency.Equals(currency))
                    return m;
            }
            return null;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            foreach (Cash m in fMonies)
            {
                hash ^= m.GetHashCode();
            }
            return hash;
        }
        public bool IsZero
        {
            get { return fMonies.Count == 0; }
        }
        public ICash Multiply(int factor)
        {
            CashBag result = new CashBag();
            if (factor != 0)
            {
                foreach (Cash m in fMonies)
                {
                    result.AppendMoney((Cash)m.Multiply(factor));
                }
            }
            return result;
        }
        public ICash Negate()
        {
            CashBag result = new CashBag();
            foreach (Cash m in fMonies)
            {
                result.AppendMoney((Cash)m.Negate());
            }
            return result;
        }
        private ICash Simplify()
        {
            if (fMonies.Count == 1)
                return (ICash)fMonies[0];
            return this;
        }
        public ICash Subtract(ICash m)
        {
            return Add(m.Negate());
        }
        public override String ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append("{");
            foreach (Cash m in fMonies)
                buffer.Append(m);
            buffer.Append("}");
            return buffer.ToString();
        }
    }
}
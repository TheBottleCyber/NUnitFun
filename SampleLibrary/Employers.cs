using System;

namespace SampleLibrary
{
    public abstract class Employer
    {
        private int _age;
        private string _name;
        private double _pay;

        private Employer() { }

        protected Employer(int age, string name, double pay)
        {
            Age = age;
            Name = name;
            Pay = pay;
        }

        public int Age
        {
            get => _age;
            private set
            {
                if (value <= 0) throw new ArgumentException("Age can't be less or equal 0", nameof(value));

                _age = value;
            }
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));

                _name = value;
            }
        }

        public double Pay
        {
            get => _pay;
            private set
            {
                if (value < 0) throw new ArgumentException("Pay can't be less 0", nameof(value));
                if (_pay + value < 0) throw new ArgumentException("Pay can't be less 0", nameof(value));

                _pay = value;
            }
        }

        public virtual void IncreasePay(double amount)
        {
            Pay += amount;
        }

        public override string ToString()
        {
            return $"[Name: {Name}, Age: {Age}, Pay: {Pay}]";
        }
    }

    public sealed class Manager : Employer
    {
        public Manager(int age, string name, double pay) : base(age, name, pay) { }
    }
}
using System;
using NUnit.Framework;
using SampleLibrary;

namespace TestProject
{
    public class ManagerTests
    {
        [TestCase(30, "Leonardo", 30.0)]
        [TestCase(25, "Alexandr", 50.0)]
        public void ManagerConstructor(int age, string name, double pay)
        {
            var manager = new Manager(age, name, pay);
            
            Assert.NotNull(manager);
            
            Assert.AreEqual(manager.Age, age);
            Assert.AreEqual(manager.Name, name);
            Assert.AreEqual(manager.Pay, pay);
        }
        
        [TestCase(-50)]
        [TestCase(0)]
        public void ManagerConstructorWithWrongAgeException(int age)
        {
            Assert.Throws<ArgumentException>(() => new Manager(age, "Leonardo", 30.0));
        }
        
        [TestCase("")]
        [TestCase(null)]
        public void ManagerConstructorWithWrongNameException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Manager(16, name, 30.0));
        }
        
        [TestCase(-1)]
        [TestCase(-15)]
        public void ManagerConstructorWithWrongPayException(double pay)
        {
            Assert.Throws<ArgumentException>(() => new Manager(16, "Leonardo", pay));
        }
        
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void ManagerIncreasePay(double amount)
        {
            var manager = new Manager(31, "Leonardo", 14.0);
            
            Assert.NotNull(manager);
            double oldValue = manager.Pay;
            manager.IncreasePay(amount);
            
            Assert.AreEqual(manager.Pay, oldValue + amount);
        }
        
        [TestCase(-100)]
        [TestCase(-15)]
        public void ManagerIncreasePayWithWrongAmountException(double amount)
        {
            var manager = new Manager(31, "Leonardo", 14.0);
            
            Assert.NotNull(manager);
            Assert.Throws<ArgumentException>(() => manager.IncreasePay(amount));
        }

        [Test]
        public void ManagerToString()
        {
            var manager = new Manager(31, "Leonardo", 14.0);
            
            Assert.NotNull(manager);

            var toString = manager.ToString();
            
            TestContext.Out.WriteLine(toString);
            
            Assert.AreEqual($"[Name: {manager.Name}, Age: {manager.Age}, Pay: {manager.Pay}]", toString);
        }
    }
}
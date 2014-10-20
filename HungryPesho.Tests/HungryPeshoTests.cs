using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HungryPesho.Creatures;

namespace HungryPesho.Tests
{
    [TestClass]
    public class HungryPeshoTests
    {
        [TestMethod]
        public void TestNewCharactersCreation()
        {
            var mage = new Mage();
            Assert.AreEqual(mage.Name, "Mage");

            var warrior = new Warrior();
            Assert.AreEqual(warrior.Name, "Warrior");
        }

        public void TestItemCreation()
        {
            // TODO
        }

        public void TestWeaponCreation()
        {
            // TODO
        }

        public void TestArmorCreation()
        {
            // TODO
        }

        public void TestFoodCreation()
        {
            // TODO
        }

        public void TestAbilityCreation()
        {
            // TODO
        }
    }
}
namespace HungryPesho.Tests
{
    using System;
    using HungryPesho.Abilities;
    using HungryPesho.Creatures;
    using HungryPesho.Engine;
    using HungryPesho.Items;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HungryPeshoTests
    {
        [TestMethod]
        public void TestNewCharactersCreation()
        {
            var mage = new Mage();
            Assert.IsInstanceOfType(mage, typeof(Character));
            Assert.AreEqual(mage.Name, "Mage");

            var warrior = new Warrior();
            Assert.IsInstanceOfType(warrior, typeof(Character));
            Assert.AreEqual(warrior.Name, "Warrior");
        }

        [TestMethod]
        public void TestRandomItemCreation()
        {
            var item = ItemsFactory.CreateItem();

            Assert.IsInstanceOfType(item, typeof(Item));
        }

        [TestMethod]
        public void TestWeaponCreation()
        {
            var weapon = new Weapon();

            Assert.IsInstanceOfType(weapon, typeof(Item));
        }

        [TestMethod]
        public void TestArmorCreation()
        {
            var armor = new Armor();

            Assert.IsInstanceOfType(armor, typeof(StatItem));
        }

        [TestMethod]
        public void TestFoodCreation()
        {
            var food = new Food();

            Assert.IsInstanceOfType(food, typeof(EffectItem));
        }

        [TestMethod]
        public void TestAbilityCreation()
        {
            var ability = new Ability("test", "test", AbilityEffects.DirectDamage, 30);

            Assert.IsInstanceOfType(ability, typeof(Ability));
        }

        [TestMethod]
        public void TestingInitialSoundStatus()
        {
            GameSettings.LoadGameSettings();

            Assert.AreEqual(GameSettings.SoundStatus, true);
        }

        [TestMethod]
        public void TestingTurningSoundOFF()
        {
            GameSettings.LoadGameSettings();
            GameSettings.SoundStatus = false;

            Assert.AreEqual(GameSettings.SoundStatus, false);
        }
    }
}
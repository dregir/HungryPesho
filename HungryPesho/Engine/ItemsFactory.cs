namespace HungryPesho.Engine
{
    using System;
    using HungryPesho.Items;

    public class ItemsFactory
    {
        public static Item CreateItem()
        {
            Random randGen = new Random();
            int randomNumber = randGen.Next(1, 4);
            switch (randomNumber)
            {
                case 1:
                    return CreateWeapon();
                case 2:
                    return CreateArmor();
                case 3:
                    return CreateFood();
                default:
                    return CreateFood();
            }
        }

        private static Weapon CreateWeapon()
        {
            var random = new Random();
            var weapon = new Weapon();

            weapon.WeaponDamage = random.Next(1, 100);
            weapon.Agility = random.Next(1, 11);
            weapon.Intellect = random.Next(1, 11);
            weapon.Stamina = random.Next(1, 11);
            weapon.Strength = random.Next(1, 11);

            var weaponType = random.Next(1, 5);

            switch (weaponType)
            {
                case 1: weapon.WeaponType = WeaponTypes.Sword; weapon.Description = "You can chop off heads now!"; weapon.Name = "Sword"; break;
                case 2: weapon.WeaponType = WeaponTypes.Staff; weapon.Description = "Will make you a bit wiser!"; weapon.Name = "Staff"; break;
                case 3: weapon.WeaponType = WeaponTypes.Dagger; weapon.Description = "You can cook with this one!"; weapon.Name = "Dagger"; break;
                case 4: weapon.WeaponType = WeaponTypes.Bow; weapon.Description = "You can shoot out in a distance!"; weapon.Name = "Bow"; break;

                default:
                    break;
            }

            return weapon;
        }

        private static Armor CreateArmor()
        {
            var random = new Random();
            var armor = new Armor();

            armor.ArmorProtection = random.Next(1, 100);
            armor.Agility = random.Next(1, 11);
            armor.Intellect = random.Next(1, 11);
            armor.Stamina = random.Next(1, 11);
            armor.Strength = random.Next(1, 11);

            var armorType = random.Next(1, 5);

            switch (armorType)
            {
                case 1: armor.ArmorType = ArmorTypes.Chest; armor.Description = "Safe from stabs in the back!"; armor.Name = "Chest"; break;
                case 2: armor.ArmorType = ArmorTypes.Helmet; armor.Description = "Forget the combs!"; armor.Name = "Helmet"; break;
                case 3: armor.ArmorType = ArmorTypes.Legs; armor.Description = "You can kick a..pples now!"; armor.Name = "Legs"; break;
                case 4: armor.ArmorType = ArmorTypes.Rings; armor.Description = "My preciousss!"; armor.Name = "Rings"; break;
                default:
                    break;
            }

            return armor;
        }

        private static Food CreateFood()
        {
            var random = new Random();
            var food = new Food();

            //food. = random.Next(1, 11);
            //food. = random.Next(1, 11);   //What properties the food would have?
            //food. = random.Next(1, 11);
            //food. = random.Next(1, 11);

            var foodType = random.Next(1, 5);

            switch (foodType)
            {
                case 1: food.FoodType = FoodTypes.Beer; food.Description = "Cheers!"; food.Name = "Beer"; break;
                case 2: food.FoodType = FoodTypes.Chicken; food.Description = "Not like steak, but ok!"; food.Name = "Chicken"; break;
                case 3: food.FoodType = FoodTypes.Pizza; food.Description = "Yummy! Wait a minute...what do you mean it's vegan?!"; food.Name = "Pizza"; break;
                case 4: food.FoodType = FoodTypes.Steak; food.Description = "That's what I call food!"; food.Name = "Steak"; break;
                default:
                    break;
            }

            return food;
        }
    }
}
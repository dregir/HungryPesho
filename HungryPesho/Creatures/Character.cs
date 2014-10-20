namespace HungryPesho.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Media;
    using HungryPesho.Abilities;
    using HungryPesho.Engine;
    using HungryPesho.ExceptionClasses;
    using HungryPesho.Interfaces;
    using HungryPesho.Items;
    using HungryPesho.UI;

    public abstract class Character : Creature, IStatable
    {
        private int agility;
        private int strength;
        private int intellect;
        private Dictionary<string, Item> items = new Dictionary<string, Item>(); 

        public Character()
        {
        }

        #region Properties

        public int Agility
        {
            get
            {
                return this.agility;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 1, 100);
                this.agility = value;
            }
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 1, 100);
                this.strength = value;
            }
        }

        public int Intellect
        {
            get
            {
                return this.intellect;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 1, 100);
                this.intellect = value;
            }
        }
        #endregion

        public void Action(Creature target, ConsoleKeyInfo action)
        {
            var random = new Random();
            var result = random.Next(0, 11);
            var attackSucceeded = result > 1;
            int key = (int)action.Key - 49;

            var damageModifier = this.GetType().Name == "Mage" ? this.Intellect : this.Strength;

            if (action.Key.Equals(ConsoleKey.Escape))
            {
                LoadScreen.LoadIngameMenu();
            }
            else if (key > this.Abilities.Count && key < 0)
            {
                throw new GameException("You need to choose action between 1 and " + Abilities.Count);
            }
            else if (this.Energy < this.Abilities[key].EnergyCost)
            {
                throw new GameException("You don't have enough energy for this ability!");
            }
            else
            {
                Ability ability = this.Abilities[key];
                this.Energy -= ability.EnergyCost;
                var damage = ability.EnergyCost + damageModifier;

                if (attackSucceeded)
                {
                    if (ability.AbilityEffect == AbilityEffects.DirectDamage)
                    { // Direct damage abilities

                        MediaPlayer.Play(Sound.HIT);

                        Console.WriteLine(
                                DrawHelper.Color("You perform", ConsoleColor.White),
                                DrawHelper.Color(ability.Name, ConsoleColor.Yellow),
                                DrawHelper.Color("and hit", ConsoleColor.White),
                                DrawHelper.Color(target.Name, ConsoleColor.Cyan),
                                DrawHelper.Color("for", ConsoleColor.White),
                                DrawHelper.Color(damage.ToString(), ConsoleColor.Green),
                                DrawHelper.Color("damage!", ConsoleColor.White));
                    }
                    else if (ability.AbilityEffect == AbilityEffects.Freeze)
                    { // Effect abilities

                        MediaPlayer.Play(Sound.FREEZE);
                        Console.WriteLine("You preform " + ability.Name + " hitting " + target.Name + " with " + damageModifier + " damage, freezing him for the next turn!");
                        target.Initiative = 0;
                    }

                    else if (ability.AbilityEffect == AbilityEffects.Ultimate)
                    {
                        if (this.GetType().Name == "Mage")
                        {
                            this.Energy = 0;

                            Console.WriteLine(
                                DrawHelper.Color("► You gaze deep into your opponent's eyes and and slowly but steadly drain all his and yours remaining energy dealing", ConsoleColor.Magenta),
                                DrawHelper.Color(target.Energy.ToString(), ConsoleColor.Yellow),
                                DrawHelper.Color("damage!", ConsoleColor.Magenta)
                                             );

                            target.Health -= target.Energy;
                            target.Energy = 0;
                        }
                    }

                    // else if (ability.AbilityEffect == AbilityEffects.Dodge) // TODO: Implement logic
                    // {
                    //     Console.WriteLine("You preform " + ability.Name + " and you will dodge the next attack!");
                    // }
                    // else if (ability.AbilityEffect == AbilityEffects.Speed)
                    // {
                    //     Console.WriteLine("You preform " + ability.Name + " and your agility is not double!");
                    // }

                    if (target.Health < damage)
                    {
                        target.Health = 0;
                        return;
                    }

                    target.Health -= damage;
                }
                else
                {

                    this.Energy -= ability.AbilityEffect.Equals(AbilityEffects.Ultimate) ? Energy : ability.EnergyCost;

                    MediaPlayer.Play(Sound.MISS);

                    Console.WriteLine(result == 0 ?
                            DrawHelper.Color("You missed.", ConsoleColor.Gray) :
                            DrawHelper.Color(target.Name + " evaded your " + ability.Name, ConsoleColor.DarkGray)
                        );
                }
            }

            DrawHelper.ReloadStats();
        }

        public void AddItem(Item item)
        {
            switch (item.GetType().Name)
            {
                case "Armor":
                    Armor armorItem = item as Armor;
                    if (this.items.ContainsKey("Armor" + armorItem.ArmorType))
                    {
                        throw new GameException(String.Format("Pesho already has Armor {0}", armorItem.ArmorType));
                    }
                    this.items.Add("Armor" + armorItem.ArmorType, item);
                    break;
                case "Weapon":
                    Weapon weaponItem = item as Weapon;
                    if (this.items.ContainsKey("Weapon" + weaponItem.WeaponType))
                    {
                        throw new GameException(String.Format("Pesho already has Weapon {0}", weaponItem.WeaponType));
                    }
                    this.items.Add("Weapon" + weaponItem.WeaponType, item);
                    break;
                case "Food":
                    Food foodItem = item as Food;
                    if (this.items.ContainsKey("Food" + foodItem.FoodType))
                    {
                        throw new GameException(String.Format("Pesho already has Food {0}", foodItem.FoodType));
                    }
                    this.items.Add("Food" + foodItem.FoodType, item);
                    break;
                default:
                    throw new GameException("No item of this type exists!");
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - Level: {1} \r\nHealth: {2} \r\nEnergy: {3} \r\nAgility: {4} \r\nStrength: {5} \r\nIntellect: {6}",
                this.GetType().Name, this.Level, this.Health, this.Energy, this.Agility, this.Strength, this.Intellect);
        }
    }
}
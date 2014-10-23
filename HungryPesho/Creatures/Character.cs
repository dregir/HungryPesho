namespace HungryPesho.Creatures
{
    using System;
    using System.Collections.Generic;
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
        private int experience;

        private Dictionary<string, Item> items = new Dictionary<string, Item>();

        #region Properties

        public int Experience
        {
            get
            {
                return this.experience;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 0, int.MaxValue);
                this.experience = value;
            }
        }

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
            var result = random.Next(0, 10);
            var attackSucceeded = result > 1;
            int key = (int)action.Key - 49;

            var damageModifier = this.GetType().Name == "Mage" ? this.Intellect : this.Strength;

            if (action.Key.Equals(ConsoleKey.Escape))
            {
                LoadScreen.LoadIngameMenu();
            }
            else if (key > this.Abilities.Count || key < 0)
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
                var damage = (this.Attack + ((damageModifier / 2) + ability.EnergyCost)) / 2;
                var storedAgility = this.Agility;
                this.Energy -= ability.EnergyCost;

                if (ability.AbilityEffect.Equals(AbilityEffects.Speed))
                {
                    var chancesToEscape = this.Agility + this.Initiative;
                    bool gotLucky = random.Next(0, 10) >= 5;

                    if (chancesToEscape > target.Initiative && gotLucky)
                    {
                        Console.WriteLine(
                            DrawHelper.Color("► You successfully escaped from", ConsoleColor.Green),
                            DrawHelper.Color(target.Name, ConsoleColor.Red));
                        this.Agility = storedAgility;
                        Engine.BossFight = false;
                        DrawHelper.BlockInputAndWaitFor(3);
                        StoryEngine.StateAfterBattle();
                    }
                    else
                    {
                        Console.WriteLine(
                            DrawHelper.Color("► You fail to escape from", ConsoleColor.Red),
                            DrawHelper.Color(target.Name, ConsoleColor.DarkMagenta));
                    }
                }
                else if (ability.AbilityEffect.Equals(AbilityEffects.Dodge))
                {
                    if (this.Agility < 50)
                    {
                        Console.WriteLine(
                            DrawHelper.Color("► You perform", ConsoleColor.White),
                            DrawHelper.Color(ability.Name, ConsoleColor.Yellow),
                            DrawHelper.Color("which increases your chance to dodge by", ConsoleColor.White),
                            DrawHelper.Color("50%", ConsoleColor.Green));
                        damage = 0;
                        this.Agility += 50;
                    }
                    else
                    {
                        throw new GameException(
                            "You can not use this ability more than once in a single battle!");
                    }
                }
                else
                {
                    if (attackSucceeded)
                    {
                        switch (ability.AbilityEffect)
                        {
                            case AbilityEffects.DirectDamage:
                                MediaPlayer.Play(Sound.Hit);
                                Console.WriteLine(
                                    DrawHelper.Color("► You perform", ConsoleColor.White),
                                    DrawHelper.Color(ability.Name, ConsoleColor.Yellow),
                                    DrawHelper.Color("and hit", ConsoleColor.White),
                                    DrawHelper.Color(target.Name, ConsoleColor.Cyan),
                                    DrawHelper.Color("for", ConsoleColor.White),
                                    DrawHelper.Color(damage.ToString(), ConsoleColor.Green),
                                    DrawHelper.Color("damage!", ConsoleColor.White));
                                break;
                            case AbilityEffects.Freeze:
                                MediaPlayer.Play(Sound.Freeze);
                                Console.WriteLine(
                                    DrawHelper.Color("► You cast", ConsoleColor.White),
                                    DrawHelper.Color(ability.Name, ConsoleColor.Blue),
                                    DrawHelper.Color("on", ConsoleColor.White),
                                    DrawHelper.Color(target.Name, ConsoleColor.Cyan),
                                    DrawHelper.Color("dealing", ConsoleColor.White),
                                    DrawHelper.Color(damage.ToString(), ConsoleColor.Yellow),
                                    DrawHelper.Color("damage", ConsoleColor.White),
                                    DrawHelper.Color("freezing him for the next turn.", ConsoleColor.Blue));
                                target.Initiative = 0;
                                break;

                            case AbilityEffects.Ultimate:
                                if (this.GetType().Name == "Mage")
                                {
                                    this.Energy = 0;
                                    damage = target.Energy;
                                    target.Energy = 0;

                                    Console.WriteLine(
                                        DrawHelper.Color(
                                            "► You gaze deep into your opponent's eyes and and slowly but steadly drain all his and yours remaining energy dealing",
                                            ConsoleColor.Magenta),
                                        DrawHelper.Color(damage.ToString(), ConsoleColor.Yellow),
                                        DrawHelper.Color("damage!", ConsoleColor.Magenta));
                                }
                                else
                                {
                                    if (this.Health >= 10)
                                    {
                                        damage = (this.Attack + damageModifier) * 2;
                                        this.Health -= Health / 10;
                                        Console.WriteLine(
                                            DrawHelper.Color(
                                                "► You strike ferociously thrusting your blade through",
                                                ConsoleColor.Magenta),
                                            DrawHelper.Color(target.Name + "'s", ConsoleColor.Cyan),
                                            DrawHelper.Color("dark and corrupted flesh, inflicting",
                                                ConsoleColor.Magenta),
                                            DrawHelper.Color(damage.ToString(), ConsoleColor.Yellow),
                                            DrawHelper.Color("damage!", ConsoleColor.Magenta));
                                    }
                                    else
                                    {
                                        throw new GameException("You can not use this ability when you are below 10 hp.");
                                    }
                                }

                                break;
                        }

                        if (target.Health < damage)
                        {
                            target.Health = 0;
                            DrawHelper.ReloadStats(target);
                            return;
                        }

                        target.Health -= damage;
                    }
                    else
                    {
                        MediaPlayer.Play(Sound.Miss);
                        Console.WriteLine(result == 0
                            ? DrawHelper.Color("You missed.", ConsoleColor.Gray)
                            : DrawHelper.Color(target.Name + " evaded your " + ability.Name, ConsoleColor.DarkGray));
                    }
                }
            }

            DrawHelper.ReloadStats(target);
        }

        public void AddItem(Item item)
        {
            if (item is Food)
            {
                Player.Pesho.Health += ((Food)item).HealthGained;
                Player.Pesho.Energy += ((Food)item).EnergyGained;
            }
            else
            {
                string key = this.GetType().Name;

                if (this.items.ContainsKey(key))
                {
                    this.items.Remove(key);
                }

                this.items.Add(key, item);
            }

            foreach (KeyValuePair<string, Item> statItem in this.items)
            {
                if (statItem.Value is Weapon)
                {
                    Player.Pesho.Attack = Player.Pesho.Attack + ((Weapon)statItem.Value).WeaponDamage;
                }
                else if (statItem.Value is Armor)
                {
                    Player.Pesho.Agility = Player.Pesho.Agility + ((Armor)statItem.Value).ArmorProtection;
                }

                Player.Pesho.Agility = Player.Pesho.Agility + ((IStatable)statItem.Value).Agility;
                Player.Pesho.Strength = Player.Pesho.Strength + ((IStatable)statItem.Value).Strength;
                Player.Pesho.Intellect = Player.Pesho.Intellect + ((IStatable)statItem.Value).Intellect;
            }
        }

        public Dictionary<string, Item> GetItems()
        {
            return new Dictionary<string, Item>(this.items);
        }

        public override string ToString()
        {
            return string.Format("{0} - Level: {1} \r\nHealth: {2} \r\nEnergy: {3} \r\nAgility: {4} \r\nStrength: {5} \r\nIntellect: {6}", this.GetType().Name, this.Level, this.Health, this.Energy, this.Agility, this.Strength, this.Intellect);
        }
    }
}
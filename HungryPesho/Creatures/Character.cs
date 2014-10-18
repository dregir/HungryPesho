namespace HungryPesho.Creatures
{
    using System.Collections;
    using System.Collections.Generic;
    using HungryPesho.Interfaces;
    using HungryPesho.Abilities;
    using System;
    using HungryPesho.UI;
    using System.Threading;

    public abstract class Character : Creature, IStatable
    {
        private int agility;
        private int strength;
        private int intellect;

        public Character()
        {
        }

        #region Properties
        // TODO: Validate
        public int Agility
        {
            get
            {
                return this.agility;
            }

            set
            {
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
                this.intellect = value;
            }
        }
        #endregion

        public void Action(Creature target, ConsoleKeyInfo action)
        {
            int key = (int)action.Key - 49;
            Ability ability = this.Abilities[0];
            var damageModifier = this.GetType().Name == "Mage" ? this.Intellect : this.Strength;

            if (key < this.Abilities.Count)
            {
                ability = this.Abilities[key];
            }
            else
            {
                throw new ArgumentOutOfRangeException("You need to choose action between 1 and " + Abilities.Count);
            }

            if (ability.AbilityEffect == AbilityEffects.DirectDamage) // Direct damage abilities
            {
                var damage = ability.EnergyCost + damageModifier;

                target.Health -= damage;
                DrawHelper.ReloadStats();

                //Console.SetCursorPosition(0, startingRows++);
                Console.WriteLine("You preform " + ability.Name + " and hit  " + target.Name + " with " + (ability.EnergyCost += damage).ToString());
                
                Console.WriteLine( // TODO: fix
                        DrawHelper.Color("You preform " + ability.Name + " and hit  " + target.Name + " with ", ConsoleColor.White),
                        DrawHelper.Color((ability.EnergyCost += damage).ToString(), ConsoleColor.Green));
            }
            else if (ability.AbilityEffect == AbilityEffects.Freeze)
            {
                Console.WriteLine("You preform " + ability.Name + " hitting " + target.Name + " with " + damageModifier + " damage, freezing him for the next turn!");
                this.Energy -= ability.EnergyCost;
                target.Initiative = 0;
            }
            //else if (ability.AbilityEffect == AbilityEffects.Dodge) // TODO: Implement logic
            //{
            //    Console.WriteLine("You preform " + ability.Name + " and you will dodge the next attack!");
            //}
            //else if (ability.AbilityEffect == AbilityEffects.Speed)
            //{
            //    Console.WriteLine("You preform " + ability.Name + " and your agility is not double!");
            //}

            Thread.Sleep(2000); // Pause the game for 2 sec after player's turn
        }

        public override string ToString()
        {
            return string.Format("{0} - Level: {1} \r\nHealth: {2} \r\nEnergy: {3} \r\nAgility: {4} \r\nStrength: {5} \r\nIntellect: {6}",
                this.GetType().Name, this.Level, this.Health, this.Energy, this.Agility, this.Strength, this.Intellect);
        }
    }
}
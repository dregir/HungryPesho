namespace HungryPesho.Creatures
{
    using System;
    using System.Collections.Generic;
    using HungryPesho.Abilities;

    public class Enemy : Creature
    {    
        private List<Ability> abilities;

        public Enemy(string description, int level, int attack, int health, int energy, int initiative, Ability ability) 
            : base(description, level, attack, health, energy, initiative)
        {
            this.abilities = new List<Ability>();

            this.Abilities.Add(ability);
        }

        public List<Ability> Abilities { get; set; }
         
        public void Action(Creature target)
        {
            var random = new Random();
            var chanceToUseAbility = random.Next(0, 4);

            if (chanceToUseAbility == 2)
            {
                if (this.Abilities.Count > 0)
                {
                    //this.Abilities[random.Next(0, this.Abilities.Count)].Effect(enemy, peshaka);
                }
            }
        }
    }
}
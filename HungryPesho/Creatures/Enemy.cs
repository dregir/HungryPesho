using System;
using System.Collections.Generic;
using HungryPesho.Abilities;

namespace HungryPesho.Creatures
{
    public class Enemy : Creature
    {    
        private IList<Ability> abilities;

        public Enemy(string name, double attack, double health, double mana, double initiative, IList<Ability> abilities) 
            : base(name, attack, health, mana, initiative)
        {
            Abilities = abilities;
        }

        public IList<Ability> Abilities { get; set; }
         
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

using HungryPesho.UI;

namespace HungryPesho.Creatures
{
    using System;
    using System.Collections.Generic;
    using HungryPesho.Abilities;

    public class Enemy : Creature 
    {    
        private Ability ability;

        //public Enemy(string description, int level, int attack, int health, int energy, int initiative, Ability ability) 
        //    : base(description, level, attack, health, energy, initiative)
        //{
        //    this.abilities = new List<Ability>();

        //    this.Abilities.Add(ability);
        //}

        public Ability Ability { get; set; }

        public string Name { get; set; } 
         
        public override void Action(Creature target) 
        {
            var random = new Random();
            var chanceToUseAbility = random.Next(0, 4);

            if (chanceToUseAbility == 2 && this.Energy >= this.Ability.EnergyCost)
            {
                if (this.Ability != null )
                {
                    if (this.Ability.AbilityEffect == AbilityEffects.DirectDamage)
                    {
                        //var abilityNames = new[]
                        //{
                        // "Fireball", 
                        // "Fireblast", 
                        // "Arcaneblast", 
                        // "Kebapshot", 
                        // "Rotten Egg Strike"
                        //};
                        var damage = Ability.EnergyCost;

                        this.Energy -= this.Ability.EnergyCost;

                        target.Health -= damage;

                        Console.WriteLine(Color.ColorMe(Name, ConsoleColor.Cyan),
                            Color.ColorMe("hit you with", ConsoleColor.Green),
                            Color.ColorMe(Ability.Name, ConsoleColor.Yellow),
                            Color.ColorMe("for:", ConsoleColor.Green),
                            Color.ColorMe(damage.ToString(), ConsoleColor.Red),
                            Color.ColorMe("damage!", ConsoleColor.Green));
                    }
                }
            }
            else
            {
                var damage = random.Next(1, Attack);
                target.Health -= damage;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                "The nasty {0} inflicts {1} damage to your skinny body.",
                                                             this.Name,
                                                             damage);
                Console.ResetColor();
            }
        }
    }
}
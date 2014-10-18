using HungryPesho.UI;

namespace HungryPesho.Creatures
{
    using System;
    using System.Collections.Generic;
    using HungryPesho.Abilities;

    public class Enemy : Creature
    {
        private Ability ability;

        public Enemy()
        {
        }

        public Ability Ability
        {
            get
            {
                return this.ability;
            }

            set
            {
                this.ability = value;
            }
        }

        public override void Action(Creature target)
        {
            var random = new Random();
            var chanceToUseAbility = random.Next(0, 4);

            if (chanceToUseAbility == 2 && this.Energy >= this.Ability.EnergyCost)
            {
                if (this.Ability != null)
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

                        Console.WriteLine(DrawHelper.Color(Name, ConsoleColor.Cyan),
                            DrawHelper.Color("hit you with", ConsoleColor.Green),
                            DrawHelper.Color(Ability.Name, ConsoleColor.Yellow),
                            DrawHelper.Color("for:", ConsoleColor.Green),
                            DrawHelper.Color(damage.ToString(), ConsoleColor.Red),
                            DrawHelper.Color("damage!", ConsoleColor.Green));
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
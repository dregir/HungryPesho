using HungryPesho.UI;

namespace HungryPesho.Creatures
{
    using System;
    using System.Collections.Generic;
    using HungryPesho.Abilities;
    using HungryPesho.Interfaces;

    public class Enemy : Creature
    {
        public Enemy()
        {
        }

        public IAbility GetRandomAbility()
        {
            var random = new Random();

            return this.Abilities[random.Next(0, Abilities.Count)];
        }

        public override void Action(Creature target)
        {
            var random = new Random();
            var chanceToUseAbility = random.Next(0, 4);
            var randomAbility = GetRandomAbility();

            if (chanceToUseAbility == 2 && this.Energy >= randomAbility.EnergyCost)
            {
                if (randomAbility.AbilityEffect == AbilityEffects.DirectDamage)
                {
                    //var abilityNames = new[]
                    //{
                    // "Fireball", 
                    // "Fireblast", 
                    // "Arcaneblast", 
                    // "Kebapshot", 
                    // "Rotten Egg Strike"
                    //};

                    var damage = randomAbility.EnergyCost;
                    this.Energy -= randomAbility.EnergyCost;

                    target.Health -= damage;

                    Console.WriteLine(DrawHelper.Color(Name, ConsoleColor.Cyan),
                        DrawHelper.Color("hit you with", ConsoleColor.Green),
                        DrawHelper.Color(randomAbility.Name, ConsoleColor.Yellow),
                        DrawHelper.Color("for:", ConsoleColor.Green),
                        DrawHelper.Color(damage.ToString(), ConsoleColor.Red),
                        DrawHelper.Color("damage!", ConsoleColor.Green));
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
            DrawHelper.ReloadStats();
        }
    }
}
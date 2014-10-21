namespace HungryPesho.Creatures
{
    using System;
    using HungryPesho.Abilities;
    using HungryPesho.Interfaces;
    using HungryPesho.UI;

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
            var randomAbility = this.GetRandomAbility();
            var damage = 0;

            if (chanceToUseAbility == 2 && this.Energy >= randomAbility.EnergyCost)
            {
                MediaPlayer.Play(Sound.Slam);
                this.Energy -= randomAbility.EnergyCost;

                if (randomAbility.AbilityEffect == AbilityEffects.DirectDamage)
                {
                    // var abilityNames = new[]
                    // {
                    //  "Fireball", 
                    //  "Fireblast", 
                    //  "Arcaneblast", 
                    //  "Kebapshot", 
                    //  "Rotten Egg Strike"
                    // };

                    damage = randomAbility.EnergyCost;

                    if (target.Health < damage)
                    {
                        target.Health = 0;
                        return;
                    }

                    target.Health -= damage;

                    Console.WriteLine(DrawHelper.Color("► " + this.Name, ConsoleColor.Cyan),
                        DrawHelper.Color("hit you with", ConsoleColor.Green),
                        DrawHelper.Color(randomAbility.Name, ConsoleColor.Yellow),
                        DrawHelper.Color("for:", ConsoleColor.Green),
                        DrawHelper.Color(damage.ToString(), ConsoleColor.Red),
                        DrawHelper.Color("damage!", ConsoleColor.Green));
                }
            }
            else
            {
                MediaPlayer.Play(Sound.Strike);

                damage = random.Next(1, this.Attack);

                if (target.Health >= damage)
                {
                    target.Health -= damage;
                }
                else
                {
                    target.Health = 0;
                }
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("► The nasty {0} inflicts {1} damage to your skinny body.", this.Name, damage);
                Console.ResetColor();
            }

            DrawHelper.ReloadStats(target);
        }
    }
}
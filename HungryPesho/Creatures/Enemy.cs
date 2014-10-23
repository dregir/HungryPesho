namespace HungryPesho.Creatures
{
    using System;
    using HungryPesho.Abilities;
    using HungryPesho.Engine;
    using HungryPesho.Interfaces;
    using HungryPesho.UI;

    public class Enemy : Creature
    {
        private Random random = new Random();

        public Enemy()
        {
            var listOfNames = new[] 
            {
                "Yeti",
                "Rabbit Dog",
                "Grizzly Bear",
                "Mad Bunny",
                "Angry French Chef",
                "Spaska The Dragon",
                "StackOverflow",
                "Forest Troll",
                "Alf",
                "Joey from Friends",
                "Garfield",
                "Uncle Gosho",
                "Evil Harpy",
                "Invisible Man", 
                "Hercules",
                "Sandokan",
                "Flintstone",
                "Fatal Error"
            };

            var abilityList = new[]
            {
                new Ability("Kebap", "Throws Kebap at you", AbilityEffects.DirectDamage, 4),
                new Ability("Prashka", "Stone in your face", AbilityEffects.DirectDamage, 5),
                new Ability("Fireball", "Fireballs u", AbilityEffects.DirectDamage, 6),
                new Ability("Fireblast", "Fireblast u", AbilityEffects.DirectDamage, 7),
                new Ability("Anal Injection", "Inject you with magic", AbilityEffects.DirectDamage, this.random.Next(8)),
                new Ability("Spectral hit", "Spectral hits u", AbilityEffects.DirectDamage, this.random.Next(1, 9)),
                new Ability("Roundhouse kick", "Norris kick", AbilityEffects.DirectDamage, this.random.Next(10)),
            };

            this.AddAbilities(abilityList);
            this.Attack = this.random.Next(Player.Pesho.Attack / 2, Player.Pesho.Attack * 2);
            this.Energy = this.random.Next(Player.Pesho.Energy / 2, Player.Pesho.Energy * 2);
            this.Health = this.random.Next(Player.Pesho.Attack * 2, (Player.Pesho.Attack * 3) + (3 * Player.Pesho.Level));
            this.Initiative = this.random.Next(1, 10);
            this.Name = listOfNames[this.random.Next(0, listOfNames.Length)];
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
                   damage = randomAbility.EnergyCost;

                    if (target.Health < damage)
                    {
                        target.Health = 0;
                        return;
                    }

                    target.Health -= damage;

                    Console.WriteLine(
                        DrawHelper.Color("► " + this.Name, ConsoleColor.Cyan),
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

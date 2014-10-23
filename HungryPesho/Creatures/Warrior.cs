namespace HungryPesho.Creatures
{
    using HungryPesho.Abilities;

    public class Warrior : Character
    {
        private const string WarriorName = "Warrior";
        private const string WarriorDescription = "Strong and powerful character who slay his opponents with brute force!";

        private const int StartingLevel = 1;
        private const int StartingHealth = 12;
        private const int StartingEnergy = 9;
        private const int StartingAgility = 6;
        private const int StartingStrength = 8;
        private const int StartingIntellect = 5;
        private const int StartingAttack = 4;
        private const int StartingInitiative = 2;
        private const int StartingExperience = 0;

        public Warrior()
        {
            this.Name = WarriorName;
            this.Description = WarriorDescription;
            this.Level = StartingLevel;
            this.Health = StartingHealth;
            this.Energy = StartingEnergy;
            this.Agility = StartingAgility;
            this.Strength = StartingStrength;
            this.Intellect = StartingIntellect;
            this.Attack = StartingAttack;
            this.Initiative = StartingInitiative;
            this.Experience = StartingExperience;

            //Starting Warrior Abilities
            this.Abilities.Add(new Ability("Basic Attack", "Just a hit with your weapon.", AbilityEffects.DirectDamage, 0));
            this.Abilities.Add(new Ability("Slam", "Slam your opponent with powerful attack.", AbilityEffects.DirectDamage, 5));
            this.Abilities.Add(new Ability("Frozen Blade", "Damages and freezes your opponent for one round.", AbilityEffects.Freeze, 5));
            this.Abilities.Add(new Ability("Swift Reflexes", "Increase your chance to dodge by 50% for the rest of the battle.", AbilityEffects.Dodge, 4));
            this.Abilities.Add(new Ability("Run!", "Run, Pesho, Run!", AbilityEffects.Speed, 0));
        }

        public void LoadUltimate() 
        {
            // Ultimate
            if (this.Level == 5)
            {
                this.Abilities.Add(new Ability("Death Wish", "Does double damage at cost of 10% of your health.", AbilityEffects.Ultimate, 0));
            }
        }
    }
}
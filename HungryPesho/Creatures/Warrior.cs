namespace HungryPesho.Creatures
{
    using HungryPesho.Abilities;

    public class Warrior : Character
    {
        private const string WarriorName = "Warrior";
        private const string WarriorDescription = "Strong and powerful character who slay his opponents with brute force!";

        private const int StartingLevel = 1;
        private const int StartingHealth = 10;
        private const int StartingEnergy = 7;
        private const int StartingAgility = 6;
        private const int StartingStrength = 7;
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

            this.LoadAbilities();
        }

        public void LoadAbilities()
        {
            // Starting warrior abilities
            this.Abilities.Add(new Ability("Basic Attack", "Just a hit with your weapon", AbilityEffects.DirectDamage, 0));
            this.Abilities.Add(new Ability("Slam", "Slam your opponent with powerful attack", AbilityEffects.DirectDamage, 5));
            this.Abilities.Add(new Ability("Frozen Blade", "Damages and freezes your opponent for one round", AbilityEffects.Freeze, 5));

            // Ultimates
            if (this.Level == 5)
            {
                this.Abilities.Add(new Ability("Death Wish", "Does double damage at cost of 10% of your health.", AbilityEffects.Ultimate, 0));
            }
        }
    }
}
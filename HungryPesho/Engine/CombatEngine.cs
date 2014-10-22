namespace HungryPesho.Engine
{
    public class CombatEngine
    {
        private BattleStates currnetState;

        public CombatEngine()
        {
            this.currnetState = BattleStates.Start;
        }

        public BattleStates BattleStates { get; set; }

        private void Update()
        {
            switch (this.currnetState)
            {
                case BattleStates.Start:
                    this.currnetState = BattleStates.Player;
                    break;
                case BattleStates.Player:
                    this.currnetState = BattleStates.Enemy;
                    break;
                case BattleStates.Enemy:
                    break;
                case BattleStates.Lose:
                    break;
                case BattleStates.Win:
                    break;
                default:
                    break;
            }
        }
    }
}
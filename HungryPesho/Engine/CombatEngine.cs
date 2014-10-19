namespace HungryPesho.Engine
{
    public enum BattleStates
    {
        START,
        PLAYER,
        ENEMY,
        LOSE,
        WIN
    }

    public class CombatEngine
    {
        private BattleStates currnetState;

        public CombatEngine()
        {
            this.currnetState = BattleStates.START;
        }

        public BattleStates BattleStates { get; set; }

        private void Update()
        {
            switch (this.currnetState)
            {
                case BattleStates.START:
                    this.currnetState = BattleStates.PLAYER;
                    break;
                case BattleStates.PLAYER:
                    this.currnetState = BattleStates.ENEMY;
                    break;
                case BattleStates.ENEMY:
                    break;
                case BattleStates.LOSE:
                    break;
                case BattleStates.WIN:
                    break;
                default:
                    break;
            }
        }
    }
}
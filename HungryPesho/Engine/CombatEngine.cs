namespace HungryPesho.Engine
{
    public class CombatEngine
    {
        public enum BattleStates
        {
            START,
            PLAYER,
            ENEMY,
            LOSE,
            WIN
        }

        private BattleStates currnetState;

        public CombatEngine()
        {
            this.currnetState = BattleStates.START;
        }

        private void Update()
        {
            switch (currnetState)
            {
                case BattleStates.START:
                    break;
                case BattleStates.PLAYER:
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

        public void OnAction()
        {
            // TODO: Make action switch
        }
    }
}
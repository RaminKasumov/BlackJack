
namespace BlackJack2022_3AHITN.Lib
{
    public class PlayerStrategyHardHands : IPlayerStrategy
    {
        #region methods
        /// <summary>
        /// Nächste Aktion des Spielers wird automatisch ausgeführt
        /// </summary>
        /// <param name="hand">Hand des Spielers</param>
        /// <returns></returns>
        public PlayerAction GetNextAction(Hand hand)
        {
            if (hand.Sum <= 11)
            {
                return PlayerAction.Hit;
            }
            else
            {
                return PlayerAction.Stand;
            }
        }

        /// <summary>
        /// Nächste Aktion des Spielers wird automatisch ausgeführt
        /// </summary>
        /// <param name="hand">Hand des Spielers</param>
        /// <returns></returns>
        public PlayerAction GetNextActionDealerCardValueIsThreeOrTwo(Hand hand)
        {
            if (hand.Sum <= 12)
            {
                return PlayerAction.Hit;
            }
            else
            {
                return PlayerAction.Stand;
            }
        }

        /// <summary>
        /// Nächste Aktion des Spielers wird automatisch ausgeführt
        /// </summary>
        /// <param name="hand">Hand des Spielers</param>
        /// <returns></returns>
        public PlayerAction GetNextActionDealerCardValueIsHigherThanSix(Hand hand)
        {
            if (hand.Sum <= 16)
            {
                return PlayerAction.Hit;
            }
            else
            {
                return PlayerAction.Stand;
            }
        }
        #endregion
    }
}
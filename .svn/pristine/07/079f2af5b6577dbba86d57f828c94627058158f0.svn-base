
namespace BlackJack2022_3AHITN.Lib
{
    public class PlayerStrategySoftHands : IPlayerStrategy
    {
        #region methods
        /// <summary>
        /// Nächste Aktion des Spielers wird automatisch ausgeführt
        /// </summary>
        /// <param name="hand">Hand des Spielers</param>
        /// <returns></returns>
        public PlayerAction GetNextAction(Hand hand)
        {
            if (hand.Sum <= 17 && hand.GetCards().ToList().Count >= 2)
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
        public PlayerAction GetNextActionDealerCardValueIsHigherThanEight(Hand hand)
        {
            if (hand.Sum == 18 && hand.GetCards().ToList().Count >= 3)
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
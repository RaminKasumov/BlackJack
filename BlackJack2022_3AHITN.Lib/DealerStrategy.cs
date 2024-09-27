
namespace BlackJack2022_3AHITN.Lib
{
    public class DealerStrategy : IPlayerStrategy
    {
        #region method
        /// <summary>
        /// Nächste Aktion des Dealers wird automatisch ausgeführt
        /// </summary>
        /// <param name="hand">Hand des Dealers</param>
        /// <returns></returns>
        public PlayerAction GetNextAction(Hand hand)
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
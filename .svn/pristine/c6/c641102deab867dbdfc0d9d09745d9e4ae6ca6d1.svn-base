
namespace BlackJack2022_3AHITN.Lib
{
    /// <summary>
    /// Der Konstruktor von der Klasse wird mithilfe der geerbten Klasse befüllt
    /// </summary>
    public class Dealer : AbstractPlayer
    {
        #region constructor
        /// <summary>
        /// Die gezogene Karte des Spielers wird von der geerbten Klasse übergeben
        /// </summary>
        /// <param name="cardSource">Deck der Karten</param>
        /// <param name="strategy">Strategie</param>
        internal Dealer(ICardSource cardSource, IPlayerStrategy strategy) : base("Dealer", cardSource, strategy)
        {
            
        }
        #endregion

        #region method
        /// <summary>
        /// Nächste Aktion wird von der zugeordneten Strategie bestimmt
        /// </summary>
        /// <returns>Liefert die richtige Aktion zurück</returns>
        public override PlayerAction PlayAction(Card firstDealerCard)
        {
            PlayerAction action = PlayAction(Strategy.GetNextAction(Hand), false);
            return action;
        }
        #endregion
    }
}
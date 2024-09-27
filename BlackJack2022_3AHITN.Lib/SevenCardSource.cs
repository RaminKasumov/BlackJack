
namespace BlackJack2022_3AHITN.Lib
{
    /// <summary>
    /// Karten mit dem Wert 7 werden ausgegeben (Symbol der Karte ist zufällig)
    /// </summary>
    public class SevenCardSource : ICardSource
    {
        #region method
        /// <summary>
        /// Karten mit dem Wert 7 werden zurückgeliefert, CardSuit ist zufällig
        /// </summary>
        /// <returns>Liefert eine Karte mit dem Wert 7 zurück</returns>
        public Card DrawCard()
        {
            Random random = new Random();
            Card card = new Card((CardColor)random.Next(Enum.GetValues(typeof(CardColor)).Length), CardValue.Seven);
            return card;
        }
        #endregion
    }
}
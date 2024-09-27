
namespace BlackJack2022_3AHITN.Lib
{
    /// <summary>
    /// Es gibt Karten mit verschiedenen Symbolen und Werten nach französischem Blatt
    /// </summary>
    public class Card
    {
        #region properties
        /// <summary>
        /// Symbole der Karten
        /// </summary>
        public CardColor Color { private set; get; }

        /// <summary>
        /// Werte der Karten
        /// </summary>
        public CardValue Value { private set; get; }
        #endregion

        #region constructor
        /// <summary>
        /// Jede Karte hat ein Symbol und ein Wert
        /// </summary>
        /// <param name="color">Symbol der Karte</param>
        /// <param name="value">Wert der Karte</param>
        public Card(CardColor color, CardValue value)
        {
            Color = color;
            Value = value;
        }
        #endregion

        #region method
        /// <summary>
        /// Informationen über eine Karte werden angezeigt
        /// </summary>
        /// <returns>Symbol und Wert der Karten werden ausgegeben</returns>
        public override string ToString()
        {
            return $"Symbol: {Color}, Wert: {Value}";
        }
        #endregion
    }
}
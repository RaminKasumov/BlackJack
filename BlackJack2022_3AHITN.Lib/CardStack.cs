
namespace BlackJack2022_3AHITN.Lib
{
    /// <summary>
    /// Insgesamt werden 52 Karten mit unterschiedlichen Symbolen und Werten erzeugt
    /// </summary>
    public class CardStack
    {
        #region property
        /// <summary>
        /// Alle Karten werden in Array gespeichert
        /// </summary>
        public Card[] Cards { private set; get; }
        #endregion

        #region constructor
        /// <summary>
        /// 52 verschiedene Karten werden erzeugt
        /// </summary>
        public CardStack()
        {
            Cards = new Card[52];
            CreateStack();
        }
        #endregion

        #region method
        /// <summary>
        /// Die Karten mit verschiedenen Symbolen und Werten werden erzeugt und in Array gespeichert
        /// </summary>
        /// <returns>Alle Karten werden ausgegeben</returns>
        private void CreateStack()
        {
            int index = 0;

            foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    Cards[index] = new Card(color, value);
                    index++;
                }
            }
        }
        #endregion
    }
}
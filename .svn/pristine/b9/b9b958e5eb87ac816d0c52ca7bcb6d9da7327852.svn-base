
namespace BlackJack2022_3AHITN.Lib
{
    /// <summary>
    /// Es gibt insgesamt 6 Pakete mit jeweils 52 Karten, die irgendwie vermischt und dann gezogen werden können
    /// </summary>
    public class CardDeck : ICardSource
    {
        #region property
        /// <summary>
        /// Alle Karten werden in einer Liste gespeichert
        /// </summary>
        public List<Card> Cards { get; }
        #endregion

        #region constructor
        /// <summary>
        /// 6 Pakete werden mit jeweils 52 Karten erstellt
        /// </summary>
        public CardDeck()
        {
            Cards = new List<Card>(Settings.GetInstance().GetGameConfig().PacksPerStack * 52);
            CreateDeck();
        }
        #endregion

        #region methods
        /// <summary>
        /// Alle Karten werden in die Liste hinzugefügt
        /// </summary>
        private void CreateDeck()
        {
            int packsPerStack = Settings.GetInstance().GetGameConfig().PacksPerStack;

            for (int i = 0; i < packsPerStack; i++)
            {
                CardStack cardStack = new CardStack();

                foreach (var card in cardStack.Cards)
                {
                    Cards.Add(card);
                }
            }
        }

        /// <summary>
        /// Die Karten werden zufällig miteinander vermischt
        /// </summary>
        public void Shuffle()
        {
            //BogoSort wird angewendet
            Random random = new Random();
            int numberOfShuffles = Settings.GetInstance().GetGameConfig().ShuffleCount;

            for (int i = 0; i < numberOfShuffles; i++)
            {
                Swap(random.Next(Cards.Count), random.Next(Cards.Count));
            }
        }

        /// <summary>
        /// Die Karten werden vertauscht
        /// </summary>
        /// <param name="index1">Erste Index</param>
        /// <param name="index2">Zweite Index</param>
        private void Swap(int index1, int index2)
        {
            (Cards[index1], Cards[index2]) = (Cards[index2], Cards[index1]);
        }

        /// <summary>
        /// Erste Karte wird gezogen und ist nicht mehr im Stack vorhanden
        /// </summary>
        /// <returns>Die gezogene Karte wird ausgegeben</returns>
        public Card DrawCard()
        {
            Card card = Cards[0];
            Cards.Remove(card);
            return card;
        }
        #endregion
    }
}
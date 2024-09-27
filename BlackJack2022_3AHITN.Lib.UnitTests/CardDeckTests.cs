using NUnit.Framework;

namespace BlackJack2022_3AHITN.Lib.UnitTests
{
    /// <summary>
    /// Alle testbaren Eigenschaften/Methoden der Klasse CardDeck werden getestet und überprüft
    /// </summary>
    public class CardDeckTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Es wird getestet, ob in der Klasse CardDeck insgesamt 312 Karten (6 Pakete mit jeweils 52 Karten) erstellt werden
        /// </summary>
        [Test]
        public void Cards_NewCardDeck_ReturnTrueAmountOfCards()
        {
            //Arrange
            CardDeck cardDeck = new CardDeck();
            int expected = 312;

            //Act
            int actual = cardDeck.Cards.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob in der Klasse CardDeck die gezogene Karte auch zurückgeliefert wird
        /// </summary>
        [Test]
        public void DrawCard_NewCard_ReturnTheFirstCard()
        {
            //Arrange
            CardDeck cardDeck = new CardDeck();
            Card expected = cardDeck.Cards[0];

            //Act
            Card actual = cardDeck.DrawCard();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

using NUnit.Framework;
using System.Text.RegularExpressions;

namespace BlackJack2022_3AHITN.Lib.UnitTests
{
    /// <summary>
    /// Alle testbaren Eigenschaften/Methoden der Klasse Card werden getestet und �berpr�ft
    /// </summary>
    public class CardTests
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
        /// Es wird getestet, ob in der Klasse Card die Karte den richtigen Symbolen hat
        /// </summary>
        [Test]
        public void CardColor_NewCard_ReturnTrueSymbol()
        {
            //Arrange
            Card card = new Card(CardColor.Heart, CardValue.Ten);
            CardColor expected = CardColor.Heart;

            //Act
            CardColor actual = card.Color;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob in der Klasse Card die Karte den richtigen Wert hat
        /// </summary>
        [Test]
        public void CardValue_NewCard_ReturnTrueValue()
        {
            //Arrange
            Card card = new Card(CardColor.Diamond, CardValue.Four);
            CardValue expected = CardValue.Four;

            //Act
            CardValue actual = card.Value;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob in der Klasse Card richtige Symbol und Wert der Karten angezeigt wird
        /// </summary>
        [Test]
        public void ToString_NewCard_ReturnTrueResult()
        {
            //Arrange
            Card card = new Card(CardColor.Club, CardValue.Eight);
            string expected = "Symbol: Club, Wert: Eight";

            //Act
            string actual = card.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird mithilfe einer Regex getestet, ob in der Klasse Card richtige Symbol und Wert der Karten angezeigt wird
        /// </summary>
        [Test]
        public void ToString_NewCard_ReturnTrueResultWithRegex()
        {
            //Arrange
            Card card = new Card(CardColor.Club, CardValue.Eight);
            string expected = @"Symbol: \w+, Wert: [A-Za-z]+";

            //Act
            string actual = card.ToString();

            //Assert
            Assert.IsTrue(Regex.IsMatch(actual, expected));
        }
    }
}
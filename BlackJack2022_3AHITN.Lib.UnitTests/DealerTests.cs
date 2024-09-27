using NUnit.Framework;
using System.Text.RegularExpressions;

namespace BlackJack2022_3AHITN.Lib.UnitTests
{
    /// <summary>
    /// Alle testbaren Eigenschaften/Methoden der Klasse Dealer werden getestet und überprüft
    /// </summary>
    public class DealerTests
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
        /// Es wird getestet, ob die passende Aktion für den Dealer zurückgeliefert wird
        /// </summary>
        [Test]
        public void PlayAction_NewDealer_ReturnTrueAction()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            DealerStrategy dealerStrategy = new DealerStrategy();
            IPlayer dealer = playerFactory.CreateDealer(cardSource, dealerStrategy);
            dealer.PlayAction(PlayerAction.Hit, false);
            PlayerAction expected = PlayerAction.Hit;

            //Act
            PlayerAction actual = dealer.PlayAction(dealer.FirstCard);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob die richtige Information über den Dealer und seine erste Karte ausgegeben wird
        /// </summary>
        [Test]
        public void ToString_NewDealer_ReturnTrueInformation()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            DealerStrategy dealerStrategy = new DealerStrategy();
            IPlayer dealer = playerFactory.CreateDealer(cardSource, dealerStrategy);
            dealer.PlayAction(PlayerAction.Hit, false);
            dealer.PlayAction(PlayerAction.Hit, false);
            string expected = "Dealer : Symbol: Club, Wert: Ace";

            //Act
            bool firstCardOnly = true;
            string actual = dealer.ToString(firstCardOnly);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird mithilfe von Regex getestet, ob die richtige Information über den Dealer und seine erste Karte ausgegeben wird
        /// </summary>
        [Test]
        public void ToString_NewDealer_ReturnTrueInformationWithRegex()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            DealerStrategy dealerStrategy = new DealerStrategy();
            IPlayer dealer = playerFactory.CreateDealer(cardSource, dealerStrategy);
            dealer.PlayAction(PlayerAction.Hit, false);
            dealer.PlayAction(PlayerAction.Hit, false);
            string expected = @"Dealer : Symbol: \w+, Wert: \w+";

            //Act
            bool firstCardOnly = true;
            string actual = dealer.ToString(firstCardOnly);

            //Assert
            Assert.IsTrue(Regex.IsMatch(actual, expected));
        }
    }
}

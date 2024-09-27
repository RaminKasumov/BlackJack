using System.Collections.Generic;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace BlackJack2022_3AHITN.Lib.UnitTests
{
    /// <summary>
    /// Alle testbaren Eigenschaften/Methoden der Klasse Player werden getestet und überprüft
    /// </summary>
    public class PlayerTests
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
        /// Es wird getestet, ob die Karte wirklich die erste Karte von der Hand ist
        /// </summary>
        [Test]
        public void FirstCard_NewPlayer_ReturnTrueCard()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            IPlayer player = playerFactory.CreatePlayer("Marco", cardSource, playerStrategy);
            player.PlayAction(PlayerAction.Hit, false);
            player.PlayAction(PlayerAction.Hit, false);
            List<Card> cards = (List<Card>)player.Cards;
            Card expected = cards[0];

            //Act
            Card actual = player.FirstCard;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob das Spiel wirklich zu Ende ist oder nicht
        /// </summary>
        [Test]
        public void HasFinished_PlayerAction_ReturnTrueIfGameIsFinished()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            IPlayer player = playerFactory.CreatePlayer("Alexander", cardSource, playerStrategy);
            player.PlayAction(PlayerAction.Hit, false);
            player.PlayAction(PlayerAction.Stand, false);
            bool expected = true;

            //Act
            bool actual = player.HasFinished;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob die richtige Aktion des Spielers ausgegeben wird
        /// </summary>
        [Test]
        public void PlayerAction_PlayerAction_ReturnTrueAction()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            IPlayer player = playerFactory.CreatePlayer("Martin", cardSource, playerStrategy);
            PlayerAction expected = PlayerAction.Hit;

            //Act
            PlayerAction actual = player.PlayAction(PlayerAction.Hit, false);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob der richtige Name des Spielers ausgegeben wird
        /// </summary>
        [Test]
        public void GetName_NewPlayer_ReturnTrueNameOfPlayer()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            IPlayer player = playerFactory.CreatePlayer("Emin", cardSource, playerStrategy);
            string expected = "Emin";

            //Act
            string actual = player.GetName();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob der richtige Wert der Karten des Spielers zurückgeliefert wird
        /// </summary>
        [Test]
        public void GetHandValue_NewPlayer_ReturnTrueCardValue()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            IPlayer player = playerFactory.CreatePlayer("Dario", cardSource, playerStrategy);
            player.PlayAction(PlayerAction.Hit, false);
            player.PlayAction(PlayerAction.Hit, false);
            int expected = 14;

            //Act
            int actual = player.GetHandValue();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob der passende Status der Karten des Spielers ausgegeben wird
        /// </summary>
        [Test]
        public void GetHandStatus_NewPlayer_ReturnTrueStatus()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            IPlayer player = playerFactory.CreatePlayer("Gabriel", cardSource, playerStrategy);
            player.PlayAction(PlayerAction.Hit, false);
            player.PlayAction(PlayerAction.Hit, false);
            HandStatus expected = HandStatus.Normal;

            //Act
            HandStatus actual = player.GetHandStatus();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob die richtige Information über den Spieler und seine Karte zurückgeliefert wird
        /// </summary>
        [Test]
        public void ToString_NewPlayer_ReturnTrueInformation()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            IPlayer player = playerFactory.CreatePlayer("Daniel", cardSource, playerStrategy);
            player.PlayAction(PlayerAction.Hit, false);
            player.PlayAction(PlayerAction.Stand, false);
            string expected = $"Daniel : Symbol: {player.FirstCard.Color}, Wert: {player.FirstCard.Value} (Summe: 7, Status: Normal) (Stand)";

            //Act
            string actual = player.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird mithilfe von Regex getestet, ob die richtige Information über den Spieler und seine Karte zurückgeliefert wird
        /// </summary>
        [Test]
        public void ToString_NewPlayer_ReturnTrueInformationWithRegex()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            IPlayer player = playerFactory.CreatePlayer("Stefan", cardSource, playerStrategy);
            player.PlayAction(PlayerAction.Hit, false);
            player.PlayAction(PlayerAction.Stand, false);
            string expected = @"^Stefan";
            Regex regex = new Regex(expected);

            //Act
            string actual = player.ToString();
            Match match = regex.Match(actual);

            //Assert
            Assert.IsTrue(match.Success);
        }

        /// <summary>
        /// Es wird getestet, ob Pot den richtigen Einsatz des Spielers hat
        /// </summary>
        [Test]
        public void Bet_NewPlayer_ReturnTruePotValue()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            Player player = (Player)playerFactory.CreatePlayer("Jonathan", cardSource, playerStrategy);
            player.Bet(574);
            int expected = 574;

            //Act
            int actual = player.Pot;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob die Wette überhaupt gemacht wird, wenn der Einsatz mehr als das Guthaben ist
        /// </summary>
        [Test]
        public void Bet_NewPlayer_ReturnFalse()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            Player player = (Player)playerFactory.CreatePlayer("Peter", cardSource, playerStrategy);
            bool expected = false;

            //Act
            bool actual = player.Bet(2530);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob der Spieler das richtige Guthaben erhält, wenn er das Spiel gewinnt
        /// </summary>
        [Test]
        public void Payout_NewPlayer_ReturnTrueBalanceIfPlayerWins()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            Player player = (Player)playerFactory.CreatePlayer("Karl", cardSource, playerStrategy);
            player.Bet(846);
            player.Payout(1);
            int expected = 1846;

            //Act
            int actual = player.Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob der Spieler das richtige Kapital erhält, wenn niemand das Spiel gewinnt
        /// </summary>
        [Test]
        public void Payout_NewPlayer_ReturnTrueBalanceIfNoneWinner()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            Player player = (Player)playerFactory.CreatePlayer("Nina", cardSource, playerStrategy);
            player.Bet(364);
            player.Payout(0);
            int expected = 1000;

            //Act
            int actual = player.Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es wird getestet, ob der Spieler das richtige Kapital erhält, wenn er das Spiel verliert
        /// </summary>
        [Test]
        public void Payout_NewPlayer_ReturnTrueBalanceIfPlayerLoses()
        {
            //Arrange
            PlayerFactory playerFactory = new PlayerFactory();
            ICardSource cardSource = new CardDeck();
            PlayerStrategySoftHands playerStrategy = new PlayerStrategySoftHands();
            Player player = (Player)playerFactory.CreatePlayer("Franz", cardSource, playerStrategy);
            player.Bet(492);
            player.Payout(-1);
            int expected = 508;

            //Act
            int actual = player.Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

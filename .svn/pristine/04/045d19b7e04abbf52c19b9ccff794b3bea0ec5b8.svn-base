using System.Runtime.Serialization;
using System.Text;

namespace BlackJack2022_3AHITN.Lib
{
    /// <summary>
    /// Alle nötigen Eigenschaften und Methoden für die Teilnehmer des Spiels BlackJack werden implementiert
    /// </summary>
    [Serializable]
    [DataContract]
    public abstract class AbstractPlayer : IPlayer
    {
        #region instancevariables
        /// <summary>
        /// Name des Teilnehmers
        /// </summary>
        [DataMember(Name = "Name")]
        string _name;

        /// <summary>
        /// Hand des Teilnehmers
        /// </summary>
        protected Hand Hand;

        /// <summary>
        /// Zweite Hand des Spielers
        /// </summary>
        protected Hand SecondHand;

        /// <summary>
        /// Deck der Karten
        /// </summary>
        ICardSource _cardSource;

        /// <summary>
        /// Strategie des Spielers
        /// </summary>
        protected IPlayerStrategy Strategy;
        #endregion

        #region properties
        /// <summary>
        /// Die erste gezogene Karte des Teilnehmers wird ausgegeben
        /// </summary>
        public Card FirstCard
        {
            get
            {
                List<Card> cards = Hand.GetCards().ToList();
                return cards[0];
            }
        }

        /// <summary>
        /// Anzahl der Ass-Karten des Spielers wird zurückgeliefert
        /// </summary>
        public int NumberOfAceCards => Hand.GetNumberOfCards(CardValue.Ace);

        /// <summary>
        /// Karten in der Hand des Teilnehmers
        /// </summary>
        /// <returns>Liefert alle Karten des Teilnehmers zurück</returns>
        public IEnumerable<Card> Cards => Hand.GetCards();

        /// <summary>
        /// Karten in der zweiten Hand des Teilnehmers
        /// </summary>
        /// <returns>Liefert alle Karten des Teilnehmers zurück</returns>
        public IEnumerable<Card> SecondHandCards => SecondHand.GetCards();

        /// <summary>
        /// Es wird überprüft, ob der Teilnehmer auf die Aktion Stand gedrückt hat oder nicht
        /// </summary>
        bool IsStanding { set; get; }

        /// <summary>
        /// Es wird überprüft, ob das Spiel schon zu Ende ist oder nicht
        /// </summary>
        public bool HasFinished
        {
            get
            {
                if (IsStanding || GetHandStatus() == HandStatus.Bust)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Liefert private Instanzvariable _cardSource zurück
        /// </summary>
        public ICardSource CardSource
        {
            set => _cardSource = value;
            get => _cardSource;
        }
        #endregion

        #region constructor

        /// <summary>
        /// Der Name und die erste gezogene Karte des Teilnehmers werden befüllt
        /// </summary>
        /// <param name="name">Name des Teilnehmers</param>
        /// <param name="cardSource">Deck der Karten</param>
        /// <param name="strategy">Strategie</param>
        internal AbstractPlayer(string name, ICardSource cardSource, IPlayerStrategy strategy)
        {
            _name = name;
            _cardSource = cardSource;
            Strategy = strategy;
            Hand = new Hand();
            SecondHand = new Hand();
        }
        #endregion

        #region methods
        /// <summary>
        /// Instanzvariable für die Strategie des Spielers wird initialisiert
        /// </summary>
        public void SetPlayerStrategy(IPlayerStrategy strategy)
        {
            Strategy = strategy;
        }

        /// <summary>
        /// Mithilfe des eingegebenen Aktions wird entweder in die Hand des Spielers eine Karte hinzugefügt oder ist er fertig
        /// </summary>
        /// <param name="action">Die vom Spieler ausgewählte Aktion</param>
        /// <param name="secondHand">Zweite Hand</param>
        /// <returns></returns>
        public PlayerAction PlayAction(PlayerAction action, bool secondHand)
        {
            if (action == PlayerAction.Double)
            {
                if (secondHand)
                {
                    SecondHand.AddCard(_cardSource.DrawCard());
                }
                else
                {
                    Hand.AddCard(_cardSource.DrawCard());
                }
                return PlayerAction.Double;
            }
            else if (action == PlayerAction.Split && !HasFinished)
            {
                SecondHand.AddCard(Hand.GetCards().ToList()[1]);
                Hand.RemoveCard(1);
                return PlayerAction.Split;
            }
            else if (action == PlayerAction.Hit)
            {
                if (secondHand)
                {
                    SecondHand.AddCard(_cardSource.DrawCard());
                }
                else
                {
                    Hand.AddCard(_cardSource.DrawCard());
                }
                return PlayerAction.Hit;
            }
            else if (action == PlayerAction.Stand)
            {
                IsStanding = true;
                return PlayerAction.Stand;
            }
            else
            {
                IsStanding = false;
                Hand.RemoveCards();
                SecondHand.RemoveCards();
                return PlayerAction.ThrowHand;
            }
        }

        /// <summary>
        /// Nächste Aktion wird von der zugeordneten Strategie bestimmt
        /// </summary>
        /// <returns>Liefert die Aktion zurück</returns>
        public virtual PlayerAction PlayAction(Card firstDealerCard)
        {
            if (Strategy is PlayerStrategySoftHands)
            {
                if (firstDealerCard.Value == CardValue.Nine || firstDealerCard.Value == CardValue.Ten || firstDealerCard.Value == CardValue.King || firstDealerCard.Value == CardValue.Jack || firstDealerCard.Value == CardValue.Queen || firstDealerCard.Value == CardValue.Ace)
                {
                    PlayerAction action = PlayAction(((PlayerStrategySoftHands)Strategy).GetNextActionDealerCardValueIsHigherThanEight(Hand), false);
                    return action;
                }
                else
                {
                    PlayerAction action = PlayAction(Strategy.GetNextAction(Hand), false);
                    return action;
                }
            }
            else
            {
                if (firstDealerCard.Value == CardValue.Six || firstDealerCard.Value == CardValue.Five || firstDealerCard.Value == CardValue.Four)
                {
                    PlayerAction action = PlayAction(Strategy.GetNextAction(Hand), false);
                    return action;
                }
                else if (firstDealerCard.Value == CardValue.Three || firstDealerCard.Value == CardValue.Two)
                {
                    PlayerAction action = PlayAction(((PlayerStrategyHardHands)Strategy).GetNextActionDealerCardValueIsThreeOrTwo(Hand), false);
                    return action;
                }
                else
                {
                    PlayerAction action = PlayAction(((PlayerStrategyHardHands)Strategy).GetNextActionDealerCardValueIsHigherThanSix(Hand), false);
                    return action;
                }
            }
        }

        /// <summary>
        /// Name des Teilnehmers
        /// </summary>
        /// <returns>Liefert den Namen des Teilnehmers zurück</returns>
        public string GetName()
        {
            return _name;
        }

        /// <summary>
        /// Wert der Karten in der Hand des Teilnehmers
        /// </summary>
        /// <returns>Gibt den Wert der Karten in der Hand des Teilnehmers zurück</returns>
        public int GetHandValue()
        {
            int handValue = Hand.Sum;
            return handValue;
        }

        /// <summary>
        /// Status der Karten in der Hand des Teilnehmers
        /// </summary>
        /// <returns>Gibt den Status der Karten in der Hand des Teilnehmers zurück</returns>
        public HandStatus GetHandStatus()
        {
            HandStatus handStatus = Hand.GetStatus();
            return handStatus;
        }

        /// <summary>
        /// Wert der Karten in der zweiten Hand des Teilnehmers
        /// </summary>
        /// <returns>Gibt den Wert der Karten in der zweiten Hand des Teilnehmers zurück</returns>
        public int GetSecondHandValue()
        {
            int secondHandValue = SecondHand.Sum;
            return secondHandValue;
        }

        /// <summary>
        /// Status der Karten in der zweiten Hand des Teilnehmers
        /// </summary>
        /// <returns>Gibt den Status der Karten in der zweiten Hand des Teilnehmers zurück</returns>
        public HandStatus GetSecondHandStatus()
        {
            HandStatus secondHandStatus = SecondHand.GetStatus();
            return secondHandStatus;
        }

        /// <summary>
        /// Informationen über den Namen und Status des Teilnehmers
        /// </summary>
        /// <returns>Liefert die Informationen über den Namen und Status des Teilnehmers zurück</returns>
        public override string ToString()
        {
            StringBuilder playerStatus = new StringBuilder();

            playerStatus.Append(Hand);
            if (IsStanding)
            {
                playerStatus.Append(" (Stand)");
            }

            return $"{_name} : {playerStatus}";
        }

        /// <summary>
        /// Informationen über den Namen und die erste Karte des Teilnehmers
        /// </summary>
        /// <param name="firstCardOnly">Nur die erste Karte</param>
        /// <returns>Liefert die Informationen über den Namen und die erste Karte des Teilnehmers zurück</returns>
        public string ToString(bool firstCardOnly)
        {
            if (firstCardOnly)
            {
                return $"{_name} : {FirstCard}";
            }
            else
            {
                return ToString();
            }
        }
        #endregion
    }
}
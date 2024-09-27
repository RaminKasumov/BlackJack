using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace BlackJack2022_3AHITN.Lib
{
    /// <summary>
    /// Der Konstruktor von der Klasse wird mithilfe der geerbten Klasse befüllt
    /// </summary>
    [Serializable]
    [DataContract]
    public class Player : AbstractPlayer
    {
        #region properties
        /// <summary>
        /// Guthaben des Spielers
        /// </summary>
        [DataMember(Name = "Balance")]
        public int Balance
        {
            private set; get;
        }

        /// <summary>
        /// Einsatz des Spielers
        /// </summary>
        public int Pot
        {
            private set; get;
        }
        #endregion

        #region constructor

        /// <summary>
        /// Name und gezogene Karte des Spielers wird von der geerbten Klasse übergeben
        /// </summary>
        /// <param name="name">Name des Spielers</param>
        /// <param name="cardSource">Deck der Karten</param>
        /// <param name="strategy">Strategie</param>
        internal Player(string name, ICardSource cardSource, IPlayerStrategy strategy) : base(name, cardSource, strategy)
        {
            Balance = Settings.GetInstance().GetGameConfig().StartBalance;
            Pot = 0;
        }
        #endregion

        #region methods
        /// <summary>
        /// Einsatz des Spielers wird getätigt
        /// </summary>
        /// <param name="amount">Einsatz des Spielers</param>
        /// <returns></returns>
        public bool Bet(int amount)
        {
            if (Balance >= amount)
            {
                Pot += amount;
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Spieler bekommt seine Auszahlung
        /// </summary>
        /// <param name="winRatio">Gewinn-Verhältnis</param>
        public void Payout(double winRatio)
        {
            Balance += Convert.ToInt32(Pot + Pot * winRatio);
            Pot = 0;
        }

        /// <summary>
        /// Schreibt die Daten zu einem Spieler in eine Datei
        /// </summary>
        /// <param name="stream">Zeichenkette</param>
        public void WriteJson(Stream stream)
        {
            var serializer = new DataContractJsonSerializer(typeof(Player));
            serializer.WriteObject(stream, this);
        }

        /// <summary>
        /// Liest die Daten zu einem Spieler aus einer Datei ein
        /// </summary>
        /// <param name="stream">Zeichenkette</param>
        /// <returns></returns>
        public static Player ReadJson(Stream stream)
        {
            var serializer = new DataContractJsonSerializer(typeof(Player));
            Player player = (Player)serializer.ReadObject(stream)!;
            player.Hand = new Hand();
            player.SecondHand = new Hand();
            return player;
        }
        #endregion
    }
}
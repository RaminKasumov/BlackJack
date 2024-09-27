
namespace BlackJack2022_3AHITN.Lib
{
    /// <summary>
    /// Es gibt insgesamt drei Einstellungen für das Spiel BlackJack
    /// </summary>
    public class GameConfig : IGameConfig
    {
        #region properties
        /// <summary>
        /// Anzahl der Kartenpakete im Kartenstapel ist als 6 festgelegt
        /// </summary>
        public int PacksPerStack => 6;

        /// <summary>
        /// Anzahl der in einem neuen Kartenstapel durchzuführenden Mischvorgänge sind als 10000 festgelegt
        /// </summary>
        public int ShuffleCount => 10000;

        /// <summary>
        /// Mindesteinsatz des Spielers ist als 5 festgelegt
        /// </summary>
        public int MinimumBet => 5;

        /// <summary>
        /// Anfangsguthaben des Spielers ist als 1000 Euro festgelegt
        /// </summary>
        public int StartBalance => 1000;

        #endregion
    }
}
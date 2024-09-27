
namespace BlackJack2022_3AHITN.Lib
{
    /// <summary>
    /// Es gibt drei Eigenschaften als Einstellungen für das Spiel BlackJack
    /// </summary>
    public interface IGameConfig
    {
        #region properties
        /// <summary>
        /// Anzahl der Kartenpakete im Kartenstapel
        /// </summary>
        int PacksPerStack { get; }

        /// <summary>
        /// Anzahl der in einem neuen Kartenstapel durchzuführenden Mischvorgänge
        /// </summary>
        int ShuffleCount { get; }

        /// <summary>
        /// Mindesteinsatz des Spielers
        /// </summary>
        int MinimumBet { get; }

        /// <summary>
        /// Anfangsguthaben des Spielers
        /// </summary>
        int StartBalance { get; }
        #endregion
    }
}